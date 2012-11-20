using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Threading;
using System.Collections;

namespace Nebula
{
    class SpriteManager : Sprite
    {
        protected Asis Asis;
        protected Laser Laser;
        protected Enemy redEnemy; 
        SoundEffect LaserSoundEffect;
        SoundEffect BackwardsLaserSoundEffect;
        protected internal Stack TimeStack; 
        protected internal Sprite[] PositionsArray;
        public Game1 myGame;
        private ScrollingManager myScrollingManager; 

        public SpriteManager(Texture2D texture, Vector2 position, Vector2 screen, Game1 aGame, Asis anAsis, 
            Laser aLaser, Enemy aEnemy, SoundEffect aLaserSoundEffect, SoundEffect aBackwardsLaserSoundEffect, ScrollingManager manager)
            : base(texture, position)
        {
            myPosition = position;
            myScreenSize = screen;
            myGame = aGame;
            Asis = anAsis;
            Laser = aLaser;
            redEnemy = aEnemy; 
            LaserSoundEffect = aLaserSoundEffect;
            BackwardsLaserSoundEffect = aBackwardsLaserSoundEffect;
            myState = new IdleState(this);
            TimeStack = new Stack();
            PositionsArray = new Sprite[3];
            SetUpInput();
            myScrollingManager = manager; 
        }

        public void SetUpInput()
        {
            PositionsArray[0] = Asis;
            PositionsArray[1] = Laser;
            PositionsArray[2] = redEnemy;

            GameAction fire = new GameAction(
                this, this.GetType().GetMethod("Fire"),
                new object[0]);
            GameAction timeTravel = new GameAction(
                this, this.GetType().GetMethod("TimeTravel"),
                new object[0]);

            InputManager.AddToKeyboardMap(Keys.X, timeTravel);
            InputManager.AddToKeyboardMap(Keys.F, fire);
        }

        public void Fire() {
            // Only one laser beam from Asis is allowed on the screen at a time - this makes it so the player cannot just spam the fire button
            if (Laser.myPosition.X + Laser.myTexture.Width < 0 || Laser.myPosition.X > myScreenSize.X || Laser.myPosition.Y < 0 || Laser.myPosition.Y > myScreenSize.Y)
            {
                // If the direction they were last moving was to the left, then fire to the left
                if (Asis.getDirection().Equals("left"))
                {
                    Laser.myPosition = new Vector2(Asis.myPosition.X - Laser.myTexture.Width, Asis.myPosition.Y + Asis.myTexture.Height / 4);
                    LaserSoundEffect.Play();
                    Laser.myVelocity.X = -20;
                }
                // Otherwise fire to the right
                else
                {
                    Laser.myPosition = new Vector2(Asis.myPosition.X + Asis.myTexture.Width, Asis.myPosition.Y + Asis.myTexture.Height / 4);
                    LaserSoundEffect.Play();
                    Laser.myVelocity.X = 20;
                }
            }        
        }

        // Method responsible for producing the effect of going back in time
        public void TimeTravel()
        {
            Array stack = TimeStack.ToArray();
            // TimeStack.Count();
            // If stack is not empty
            if (stack.Length > 0)
            {
                for (int i = PositionsArray.Length - 1; i >= 0; i--)
                {
                    PositionsArray[i].myPosition = (Vector2)TimeStack.Pop();
                }
                // Changes background color
                myState = new TimeTravelState(this);

                /*
                // Remove and set the positions that the Sprites were previously in
                Laser.myPosition = (Vector2)TimeStack.Pop();
                Asis.setDirection((String)TimeStack.Pop());   
                Asis.myPosition = (Vector2)TimeStack.Pop();
                redEnemy.myPosition = (Vector2)TimeStack.Pop();
                if (redEnemy.getAlive() == false)
                {
                    redEnemy.Resurrect();
                }
                myState = new TimeTravelState(this);
                */
            }
        }

        class TimeTravelState : State
        {
            public TimeTravelState(Sprite sprite) 
            {
            }
            public void Update(double elapsedTime, Sprite sprite)
            {
                SpriteManager sm = (SpriteManager)(sprite);

                //sm.myScrollingManager.Update(elapsedTime); 

                // Plays the laser sound effect in reverse when it falls into a certain range of x pixels 
                // depending on which direction they were facing when they fired it
                double t = sprite.time;
                if (sprite.time > .5)
                {
                        float xFireFromLeft = sm.Asis.myPosition.X - (sm.Laser.myTexture.Width * 2) - sm.myScreenSize.X / 2;
                        // sm.myScreenSize.X/8 = size of x range
                        float xFireFromLeftPlus = xFireFromLeft - sm.myScreenSize.X/8;
                        if (sm.Laser.myPosition.X <= xFireFromLeft && sm.Laser.myPosition.X >= xFireFromLeftPlus)
                        {
                            sm.BackwardsLaserSoundEffect.Play();
                            sprite.time = 0;
                        }

                        float xFireFromRight = sm.Asis.myPosition.X + (sm.Asis.myTexture.Width * 2) + sm.myScreenSize.X / 2;
                        // sm.myScreenSize.X/8 = size of x range
                        float xFireFromRightPlus = xFireFromRight + sm.myScreenSize.X/8;
                        if (sm.Laser.myPosition.X >= xFireFromRight && sm.Laser.myPosition.X <= xFireFromRightPlus)
                        {
                            sm.BackwardsLaserSoundEffect.Play();
                            sprite.time = 0;
                        }
                }
                // If x is not being pressed change its state
                if (!Keyboard.GetState().IsKeyDown(Keys.X))
                {
                    sprite.myState = new IdleState(sprite);
                }

            }
            public void Draw(Sprite sprite, SpriteBatch batch)
            {
                // Change background color to signify traveling back in time
                SpriteManager sm = (SpriteManager)(sprite);
                sm.myGame.GraphicsDevice.Clear(Color.Gray);
                //sm.myScrollingManager.Draw(batch);
                batch.Draw(sprite.myTexture, sprite.myPosition,
                null, Color.White,
                sprite.myAngle, sprite.myOrigin,
                sprite.myScale, SpriteEffects.None, 0f);
            }
        }

        class IdleState : State
        {
            public IdleState(Sprite sprite)
            {
            }
            public void Update(double elapsedTime, Sprite sprite)
            {
                SpriteManager sm = (SpriteManager)(sprite);
                // If X key is not being pressed, add positions of sprites to Stack

                sm.myScrollingManager.Update(elapsedTime);

                if (!Keyboard.GetState().IsKeyDown(Keys.X))
                {  
                    sm.TimeStack.Push(sm.Asis.myPosition);
                    sm.TimeStack.Push(sm.Laser.myPosition);
                    sm.TimeStack.Push(sm.redEnemy.myPosition); 
                    // sm.TimeStack.Push(sm.Asis.getDirection());
                    
                }
                // If center of laser sprite is at anytime between the two vertical and two horizontal edges, kill the sprite
                float xCenterOfLaserSprite = sm.Laser.myPosition.X + sm.Laser.myTexture.Width / 2;
                float leftEdgeOfEnemy = sm.redEnemy.myPosition.X;
                float rightEdgeOfEnemy = sm.redEnemy.myTexture.Width + sm.redEnemy.myPosition.X;
                float yCenterOfLaserSprite = sm.Laser.myPosition.Y + sm.Laser.myTexture.Height / 2;
                float topEdgeOfEnemy = sm.redEnemy.myPosition.Y;
                float bottomEdgeOfEnemy = sm.redEnemy.myPosition.Y + sm.redEnemy.myTexture.Height;
                if ((xCenterOfLaserSprite >= leftEdgeOfEnemy && xCenterOfLaserSprite <= rightEdgeOfEnemy) && (yCenterOfLaserSprite >= topEdgeOfEnemy && yCenterOfLaserSprite <= bottomEdgeOfEnemy))
                {
                    sm.redEnemy.Die(); 
                }
 

            }
            public void Draw(Sprite sprite, SpriteBatch batch)
            {
               SpriteManager sm = (SpriteManager)(sprite);
                sm.myGame.GraphicsDevice.Clear(Color.AliceBlue);

                //sm.myScrollingManager.Draw(batch);

                batch.Draw(sprite.myTexture, sprite.myPosition,
                null, Color.White,
                sprite.myAngle, sprite.myOrigin,
                sprite.myScale, SpriteEffects.None, 0f); 
            }
        }
        }
    }

