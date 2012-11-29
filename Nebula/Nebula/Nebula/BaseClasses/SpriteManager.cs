﻿using System;
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
using Nebula.SuperClasses;
using Nebula.Subclasses;

namespace Nebula.SuperClasses
{
    class SpriteManager : Sprite
    {
        protected internal Stack TimeStack; 
        protected internal List<Sprite> PositionsList;
        public Game1 myGame;
        Asis myAsis;
        SoundEffect TimeTravelSound;
        SoundEffectInstance TimeTravelSoundInstance;
        // private ScrollingManager myScrollingManager;

        // To update list
        public void setPositionsList(List<Sprite> myPositionsList)
        {
            PositionsList = myPositionsList;
        }

        public SpriteManager(Texture2D texture, Vector2 position, Vector2 screen, Game1 aGame,
            List<Sprite> aPositionsList, Asis asis)
            : base(texture, position)
        {
            myTexture = texture;
            myPosition = position;
            myGame = aGame;
            myScreenSize = screen;
            PositionsList = aPositionsList;
            myAsis = asis;

            TimeTravelSound = myGame.Content.Load<SoundEffect>("time-swoosh");
            TimeTravelSoundInstance = TimeTravelSound.CreateInstance();
            TimeTravelSoundInstance.IsLooped = true;


            myState = new IdleState(this);
            TimeStack = new Stack();

            SetUpInput();
        }

        public void SetUpInput()
        {

            GameAction timeTravel = new GameAction(
                this, this.GetType().GetMethod("TimeTravel"),
                new object[0]);

            InputManager.AddToKeyboardMap(Keys.X, timeTravel);
        }
        
        // Method responsible for producing the effect of going back in time
        public void TimeTravel()
        {
            // Array stack = TimeStack.ToArray();
            // TimeStack.Count();
            // If stack is not empty
            if (TimeStack.Count > 0)
            {
                for (int i = PositionsList.Count - 1; i >= 0; i--)
                {
                    PositionsList[i].myPosition = (Vector2)TimeStack.Pop();
                }
                // Changes background color
                myState = new TimeTravelState(this);
            }
        }

        class TimeTravelState : State
        {
            public TimeTravelState(Sprite sprite) 
            {
                SpriteManager sm = (SpriteManager)(sprite);
            }
            public void Update(double elapsedTime, Sprite sprite)
            {
                SpriteManager sm = (SpriteManager)(sprite);
                // sm.myScrollingManager.Update(elapsedTime); 
                // If x is not being pressed change its state

                sm.TimeTravelSoundInstance.Play();

                sprite.myPosition = new Vector2(sm.myAsis.myPosition.X - sm.myScreenSize.X/6, 
                    sm.myAsis.myPosition.Y - sm.myScreenSize.Y + sm.myAsis.myTexture.Height + sm.myAsis.myTexture.Height/2);

                if (!Keyboard.GetState().IsKeyDown(Keys.X))
                {
                    sm.TimeTravelSoundInstance.Stop();
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
                sprite.myPosition = new Vector2(sprite.myScreenSize.X * -2, sprite.myScreenSize.Y * -2); 
            }
            public void Update(double elapsedTime, Sprite sprite)
            {
                SpriteManager sm = (SpriteManager)(sprite);

                // If X key is not being pressed, add positions of sprites to Stack
                if (!Keyboard.GetState().IsKeyDown(Keys.X))
                {
                    for (int i = 0; i < sm.PositionsList.Count; i ++) {
                    sm.TimeStack.Push(sm.PositionsList[i].myPosition);
                }
                }  
            }
            public void Draw(Sprite sprite, SpriteBatch batch)
            {
                SpriteManager sm = (SpriteManager)(sprite);
                sm.myGame.GraphicsDevice.Clear(Color.AliceBlue);
                batch.Draw(sprite.myTexture, sprite.myPosition,
                null, Color.White,
                sprite.myAngle, sprite.myOrigin,
                sprite.myScale, SpriteEffects.None, 0f); 
            }
        }
        }
    }
