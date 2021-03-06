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
using System.Collections;

namespace Nebula.SuperClasses
{
    public class Hero : Sprite
    {
        protected String direction;
        SoundEffect BoostSound;

        public String getDirection()
        {
            return direction;
        }
        public void setDirection(String s)
        {
            direction = s;
        }

        public Hero(Texture2D texture, Vector2 position, Vector2 screen, NebulaGame myGame) 
            : base(texture, position)   
        {
            myScreenSize = screen;
            myState = new ExistState(this);
            hasJumped = true;
            myPosition = position;
            // Change back to  for start of game 
            // myPosition.X = myScreenSize.X;
                
                // 

            // myPosition.Y = 0;
            //  myScreenSize.Y - myTexture.Height * 2; ;
            // Start her facing to the right
            direction = "right";

            BoostSound = myGame.Content.Load<SoundEffect>("boost-sound");

            SetUpInput();
        }

        public void SetUpInput()
        {
            GameAction moveLeft = new GameAction(
                this, this.GetType().GetMethod("GoLeft"),
                new object[0]);

            GameAction moveRight = new GameAction(
                this, this.GetType().GetMethod("GoRight"),
                new object[0]);

            GameAction boost = new GameAction(
                this, this.GetType().GetMethod("Boost"),
                new object[0]);

            InputManager.AddToKeyboardMap(Keys.Left, moveLeft);
            InputManager.AddToButtonsMap(Buttons.DPadLeft, moveLeft);
            InputManager.AddToKeyboardMap(Keys.Right, moveRight);
            InputManager.AddToButtonsMap(Buttons.DPadRight, moveRight);
            InputManager.AddToButtonsMap(Buttons.B, boost);
            InputManager.AddToButtonsMap(Buttons.RightShoulder, boost);
            InputManager.AddToKeyboardMap(Keys.B, boost);
        }

        public void GoLeft()
        {
                myPosition.X -= 5;
                direction = "left";
        }
        public void GoRight()
        {
                myPosition.X += 5;
                direction = "right";
        }
        public void Boost()
        {
            if (time > 5)
            {
                if (direction.Equals("right"))
                {
                    BoostSound.Play();
                    myPosition.X += 200;
                    time = 0;    
                }
                if (direction.Equals("left"))
                {
                    BoostSound.Play();
                    myPosition.X -= 200;
                    time = 0;
                }
            }
        }

        // State that Asis begins in - ability to jump and gravity are built into this state
        class ExistState : State
        {
            public ExistState(Sprite sprite)
            {
            }
            public void Update(double elapsedTime, Sprite sprite)
            {
                if (!Keyboard.GetState().IsKeyDown(Keys.X) && (!GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.X)))
                {
                    if ((Keyboard.GetState().IsKeyDown(Keys.Space)
                        || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.A)
                        || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftShoulder))
                        && sprite.hasJumped == false)
                    {
                        sprite.myPosition.Y -= 10f;
                        sprite.myVelocity.Y = -7f;
                        sprite.hasJumped = true;
                    }

                    float i = 1;
                    // change 0.18f to alter speed of falling
                    sprite.myVelocity.Y += 0.18f * i;


                    /*
                    // If he's in the air make hero fall
                    if (sprite.hasJumped == true)
                    {
                        // change 0.18f to alter speed of falling
                       sprite.myVelocity.Y += 0.18f * i;
                    }
                    */

                    if (sprite.myVelocity.Y == 0)
                    {
                        sprite.hasJumped = false;
                        // sprite.myVelocity.Y = 0f;
                    }
                }
            }
            public void Draw(Sprite sprite, SpriteBatch batch)
            {
                batch.Draw(sprite.myTexture, sprite.myPosition,
                null, Color.White,
                sprite.myAngle, sprite.myOrigin,
                sprite.myScale, SpriteEffects.None, 0f);
            }
        }
    }
}
