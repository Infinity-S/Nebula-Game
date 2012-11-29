﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Nebula.SuperClasses;


namespace Nebula.Subclasses
{
    class Manager : SpriteManager
    {
        List<Sprite> spritesList;
        AsisLaser aLaser;
        DraconisEnemy dEnemy;
        DraconisEnemy dEnemy2;
        DraconisLaser dLaser;
        Asis asis;
        // Sprite[] platformsArray = new Sprite[50];
        List<Sprite> platformsList = new List<Sprite>();
        List<DraconisEnemy> EnemiesList = new List<DraconisEnemy>();
        public GrassPlatform grass;
        // Shorthand for X screen length and Y screen length
        float xSL;
        float ySL;
        Ceres myCeres;
        double accumTime = 0;

        protected internal SpriteFont myFont;

        SoundEffect LaserSoundEffect;
        SoundEffect BackwardsLaserSoundEffect;

        GameOver GameOverScreen;

        public Manager(Texture2D texture, Vector2 position, Vector2 screen, Game1 aGame, Ceres aCeres, 
            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Asis asis2, GameOver aGameOverScreen)
            : base(texture, position, screen, aGame, aPlatformsList, asis2) 
        {
            myTexture = texture;
            myPosition = position;
            myScreenSize = screen;
            myGame = aGame;
            myCeres = aCeres;
            spritesList = aSpritesList;
            

            LaserSoundEffect = myGame.Content.Load<SoundEffect>("LaserSoundEffect");
            BackwardsLaserSoundEffect = myGame.Content.Load<SoundEffect>("LaserSoundEffectBackwards");
            // xSL * -3, ySL * -3
            GameOverScreen = aGameOverScreen;

            for (int i = 0; i < aPlatformsList.Count; i++)
            {
                platformsList.Add(aPlatformsList[i]);
            }

            myFont = aFont;

            grass = (GrassPlatform)platformsList[0];
            
            asis = (Asis)spritesList[0];
            aLaser = (AsisLaser)spritesList[1];
            dEnemy = (DraconisEnemy)spritesList[2];
            dLaser = (DraconisLaser)spritesList[3];
            dEnemy2 = (DraconisEnemy)spritesList[4];

            EnemiesList.Add(dEnemy);
            EnemiesList.Add(dEnemy2);
            
            myState = new GameState(this);
            SetUpInput2();
        }
        

        public void AddGrassPlatform(Vector2 position, bool canLandOn)
        {
            Sprite newGrassPlatform = grass.Clone();
            newGrassPlatform.myPosition = position;
            myCeres.AddSprite(newGrassPlatform);
            // If we want Asis to be able to land on the platform and not fall through - add it to the platformsList
            if (canLandOn)
            {
                platformsList.Add(newGrassPlatform);
            }
        }

        /*
        public DraconisEnemy AddDraconisEnemy(Vector2 position)
        {
            Sprite newDraconisEnemy = dEnemy.Clone();
            newDraconisEnemy.myPosition = position;
            myGame.AddSprite(newDraconisEnemy);
            EnemiesList.Add((DraconisEnemy)newDraconisEnemy);
            return (DraconisEnemy)newDraconisEnemy;
        }
        */

        public void SetUpInput2()
        {
            xSL = myScreenSize.X;
            ySL = myScreenSize.Y;

            GameAction fire = new GameAction(
                this, this.GetType().GetMethod("Fire"),
                new object[0]);

            InputManager.AddToKeyboardMap(Keys.F, fire);
        }

        // Helper method that returns true if Asis's laser is offscreen, false otherwise
        private bool aLaserOffScreen()
        {
            if (aLaser.myPosition.X + aLaser.myTexture.Width < asis.myPosition.X - myScreenSize.X / 6
                || aLaser.myPosition.X > asis.myPosition.X + myScreenSize.X
                || aLaser.myPosition.Y < 0
                || aLaser.myPosition.Y > myScreenSize.Y)
            {
                return true;
            }
            else return false;
        }

        public void Fire()
        {
            // Only one laser beam from Asis is allowed on the screen at a time - this makes it so the player cannot just spam the fire button
            if (aLaserOffScreen())
            {
                // If the direction they were last moving was to the left, then fire to the left
                if (asis.getDirection().Equals("left"))
                {
                    aLaser.myPosition = new Vector2(asis.myPosition.X - aLaser.myTexture.Width, asis.myPosition.Y + asis.myTexture.Height / 4);
                    LaserSoundEffect.Play();
                    aLaser.myVelocity.X = -24;
                }
                // Otherwise fire to the right
                else
                {
                    aLaser.myPosition = new Vector2(asis.myPosition.X + asis.myTexture.Width, asis.myPosition.Y + asis.myTexture.Height / 4);
                    LaserSoundEffect.Play();
                    aLaser.myVelocity.X = 24;
                }
            }
        }

        // Helper method that takes Asis and a laser as objects and returns true if it hits her, false otherwise
        private bool Hit(Sprite person, Sprite laser)
        {
            if (laser.myPosition.X + laser.myTexture.Width / 2 > person.myPosition.X
                && laser.myPosition.X + laser.myTexture.Width / 2 < person.myPosition.X + person.myTexture.Width
                && laser.myPosition.Y > person.myPosition.Y && laser.myPosition.Y < person.myPosition.Y + person.myTexture.Height)
            {
                return true;
            }
            else return false;
        }


        class GameState : State
        {
            public GameState(Sprite sprite) 
            {
                Manager sm = (Manager)sprite;
                float xSL = sprite.myScreenSize.X;
                float ySL = sprite.myScreenSize.Y;

                // ADD MORE PLATFORMS/ENEMIES HERE
                
                sm.AddGrassPlatform(new Vector2(xSL/12, ySL - sm.grass.myTexture.Height * 2), true);
                sm.AddGrassPlatform(new Vector2(xSL / 2 + xSL / 4 + sm.grass.myTexture.Width / 8, ySL / 2 + ySL / 4), true);
                sm.AddGrassPlatform(new Vector2(xSL + xSL / 4 - sprite.myTexture.Width, ySL / 2 + ySL / 4), true);
                sm.AddGrassPlatform(new Vector2(xSL + xSL / 2, ySL / 2 + ySL / 16), true);
                sm.AddGrassPlatform(new Vector2(xSL + xSL / 2 + sm.grass.myTexture.Width, ySL / 2 + ySL / 16), false);
                sm.AddGrassPlatform(new Vector2(xSL + xSL / 2 + sm.grass.myTexture.Width * 2, ySL / 2 + ySL / 16), false);
                sm.AddGrassPlatform(new Vector2(xSL + xSL / 2 + sm.grass.myTexture.Width * 3, ySL / 2 + ySL / 16), true);
                sm.AddGrassPlatform(new Vector2(xSL * 2 + sm.grass.myTexture.Width * 3, ySL / 2 + ySL / 4 + sm.grass.myTexture.Height * 2), true);
                sm.AddGrassPlatform(new Vector2(xSL * 2 + sm.grass.myTexture.Width * 4, ySL / 2 + ySL / 4 + sm.grass.myTexture.Height * 2), true);
                sm.AddGrassPlatform(new Vector2(xSL * 2 + sm.grass.myTexture.Width * 5, ySL / 2 + ySL / 4 + sm.grass.myTexture.Height * 2), true);
                sm.AddGrassPlatform(new Vector2(xSL * 2 + sm.grass.myTexture.Width * 6, ySL / 2 + ySL / 4 + sm.grass.myTexture.Height * 2), true);
                sm.AddGrassPlatform(new Vector2(xSL * 2 + sm.grass.myTexture.Width * 7, ySL / 2 + ySL / 4 + sm.grass.myTexture.Height * 2), true);
                

            }
            public void Update(double elapsedTime, Sprite sprite)
            {
                Manager sm = (Manager)sprite;

                sm.accumTime += elapsedTime;

                if (sm.aLaserOffScreen())
                {
                    sm.aLaser.myPosition = new Vector2(sm.aLaser.myPosition.X, sm.aLaser.myPosition.Y + sm.ySL);
                }

                    // For each platform, if Asis jumps on it - set her y velocity to 0
                    for (int i = 0; i < sm.platformsList.Count; i++)
                    {
                        if (sm.asis.myPosition.Y + sm.asis.myTexture.Height >= sm.platformsList[i].myPosition.Y
                            && sm.asis.myPosition.Y + sm.asis.myTexture.Height <= sm.platformsList[i].myPosition.Y + sm.platformsList[i].myTexture.Height
                            && sm.asis.myPosition.X + sm.asis.myTexture.Width / 2 >= sm.platformsList[i].myPosition.X
                            && sm.asis.myPosition.X + sm.asis.myTexture.Width / 2 <= sm.platformsList[i].myPosition.X + sm.platformsList[i].myTexture.Width)
                        {
                            /*
                            // If statement helps avoid a glitch when going back in time Asis would get stuck below a platform
                            if (Keyboard.GetState().IsKeyDown(Keys.X)
                                && sm.asis.myPosition.Y + sm.asis.myTexture.Height <= sm.platformsList[i].myPosition.Y + sm.platformsList[i].myTexture.Height
                                && sm.asis.myPosition.Y + sm.asis.myTexture.Height >= sm.platformsList[i].myPosition.Y)
                            {
                                sm.asis.myPosition.Y -= 5;
                            }
                            */

                            sm.asis.myVelocity.Y = 0;

                            // Allows hero to jump off platforms
                            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                            {
                                sm.asis.myVelocity.Y = -7f;
                            }
                        }
                    }
                
                // For each enemy, if Asis's laser hits them, kill them
                for (int i = 0; i < sm.EnemiesList.Count; i++)
                {
                    if (sm.Hit(sm.EnemiesList[i], sm.aLaser))
                    {
                        sm.EnemiesList[i].Die();
                    }
                }

                //Schuyler worked on this!! to make it so that whener asis is in a specific proximity to a enemy, they attack
                foreach (Sprite enemy in sm.EnemiesList)
                {
                    //attack if Asis is in range between 5 texture widths before enemy position to enemy position 
                    if ((sm.asis.myPosition.X > (enemy.myPosition.X - (enemy.myTexture.Width * 4)) && sm.asis.myPosition.X < enemy.myPosition.X))
                    {
                        //Fire a laser every 1.5 seconds, will be an instance varible, so can be changed 
                        if (sm.accumTime > 1.5)
                        {
                            sm.dLaser.myPosition = new Vector2(enemy.myPosition.X - sm.dLaser.myTexture.Width, enemy.myPosition.Y);
                            sm.dLaser.myVelocity.X = -16;
                            sm.accumTime = 0;
                        }
                    }
                }

                //// First enemy firing spot
                //// When asis is between 3/4 Screen length x and 3/4 Screen length + her texture width divided by 8
                //if (sm.asis.myPosition.X > sm.xSL / 2 + sm.xSL / 4 && sm.asis.myPosition.X < sm.xSL / 2 + sm.xSL / 4 + sm.asis.myTexture.Width/8)
                //{
                //    sm.dLaser.myPosition = new Vector2(sm.dEnemy.myPosition.X - sm.dLaser.myTexture.Width, sm.dEnemy.myPosition.Y);
                //    sm.dLaser.myVelocity.X = -16;
                //}

                //// Second enemy firing spot
                //if (sm.asis.myPosition.X > sm.xSL * 2 + sm.grass.myTexture.Width * 3 && sm.asis.myPosition.X < sm.xSL * 2 + sm.grass.myTexture.Width * 3 + sm.grass.myTexture.Width / 16)
                //{
                //    sm.dLaser.myPosition = new Vector2(sm.dEnemy2.myPosition.X - sm.dLaser.myTexture.Width, sm.dEnemy2.myPosition.Y);
                //    sm.dLaser.myVelocity.X = -16;
                //}

                // If Asis gets hit by Enemy laser, display GameOverScreen - otherwise hide it
                if (sm.Hit(sm.asis, sm.dLaser) || sm.asis.myPosition.Y > sm.ySL + sm.ySL/2)
                {
                    sm.asis.myPosition.Y = sm.asis.myPosition.Y + sm.ySL;
                    sm.GameOverScreen.myPosition = new Vector2(sm.asis.myPosition.X - sm.xSL / 6, 0);
                }
                else sm.GameOverScreen.myPosition = new Vector2(sm.xSL * -3, sm.ySL * -3);

                // Plays the laser sound effect in reverse when it falls into a certain range of x pixels 
                // depending on which direction they were facing when they fired it (when going back in time)
                if (Keyboard.GetState().IsKeyDown(Keys.X))
                {
                double t = sprite.time;
                // Using the arbitrary grass timer here instead of Asis's because hers is one being displayed on screen and we don't want to reset that one
                // even when she is going back in time
                if (sm.grass.time > .5)
                 {
                    float xFireFromLeft = sm.asis.myPosition.X - (sm.aLaser.myTexture.Width * 2) - sm.myScreenSize.X / 2;
                        // sm.myScreenSize.X/8 = size of x range
                        float xFireFromLeftPlus = xFireFromLeft - sm.myScreenSize.X/8;
                        if (sm.aLaser.myPosition.X <= xFireFromLeft && sm.aLaser.myPosition.X >= xFireFromLeftPlus)
                        {
                            sm.BackwardsLaserSoundEffect.Play();
                            sm.grass.time = 0;
                        }
                        float xFireFromRight = sm.asis.myPosition.X + (sm.asis.myTexture.Width * 2) + sm.myScreenSize.X / 2;
                        // sm.myScreenSize.X/8 = size of x range
                        float xFireFromRightPlus = xFireFromRight + sm.myScreenSize.X/8;
                        if (sm.aLaser.myPosition.X >= xFireFromRight && sm.aLaser.myPosition.X <= xFireFromRightPlus)
                        {
                            sm.BackwardsLaserSoundEffect.Play();
                            sm.grass.time = 0;
                        }
                }
                }
            }
            public void Draw(Sprite sprite, SpriteBatch batch)
            {
                Manager sm = (Manager)sprite;

                batch.Draw(sprite.myTexture, sprite.myPosition,
                null, Color.White,
                sprite.myAngle, sprite.myOrigin,
                sprite.myScale, SpriteEffects.None, 0f);
                // Timer gets drawn here - unaffected by time travel ability
                batch.DrawString(sm.myFont, "Time: " + Convert.ToString(Convert.ToInt32(sprite.time)), new Vector2(sm.asis.myPosition.X - sm.xSL/6, 0 ), 
                    Color.Black, 0, new Vector2(0,0), 1.3f, SpriteEffects.None, 0.5f);
            }
        }
    }
}