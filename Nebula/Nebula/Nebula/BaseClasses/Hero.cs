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
using System.Collections;

namespace Nebula.SuperClasses
{
    class Hero : Sprite
    {
        protected String direction;

        public String getDirection()
        {
            return direction;
        }
        public void setDirection(String s)
        {
            direction = s;
        }

        public Hero(Texture2D texture, Vector2 position, Vector2 screen) 
            : base(texture, position)   
        {
            myScreenSize = screen;
            myState = new ExistState(this);
            hasJumped = true;
            myPosition.X = myScreenSize.X/12;
            myPosition.Y = myScreenSize.Y - myTexture.Height * 2;
            // Start her facing to the right
            direction = "right";
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

            InputManager.AddToKeyboardMap(Keys.Left, moveLeft);
            InputManager.AddToButtonsMap(Buttons.DPadLeft, moveLeft);
            InputManager.AddToButtonsMap(Buttons.LeftThumbstickLeft, moveLeft);
            InputManager.AddToKeyboardMap(Keys.Right, moveRight);
            InputManager.AddToButtonsMap(Buttons.DPadRight, moveRight);
            InputManager.AddToButtonsMap(Buttons.LeftThumbstickRight, moveRight);
        }
        public void GoLeft()
        {
            // if (myPosition.X > myScreenSize.X * .10)
            // {
                myPosition.X -= 5;
                direction = "left";
            // }
        }
        public void GoRight()
        {
            // if (myPosition.X < myScreenSize.X * .60)
            // {
                myPosition.X += 5;
                direction = "right";

            // }
        }

        // State that Asis begins in - ability to jump and gravity are built into this state
        class ExistState : State
        {
            public ExistState(Sprite sprite)
            {
            }
            public void Update(double elapsedTime, Sprite sprite)
            {
                if ((Keyboard.GetState().IsKeyDown(Keys.Space) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.A)) && sprite.hasJumped == false)
                {
                    sprite.myPosition.Y -= 10f;
                    sprite.myVelocity.Y = -7f;
                    sprite.hasJumped = true;
                }

                // if (sprite.myPosition.Y >= 0)
                // {
                    float i = 1;
                    // change 0.18f to alter speed of falling
                    sprite.myVelocity.Y += 0.18f * i;
                // }

                /*
                // If he's in the air make hero fall
                if (sprite.hasJumped == true)
                {
                    // change 0.18f to alter speed of falling
                   sprite.myVelocity.Y += 0.18f * i;
                }
                */

                // Keeps player from falling through the bottom of the screen
                // sprite.myPosition.Y + sprite.myTexture.Height > sprite.myScreenSize.Y
                if (sprite.myVelocity.Y == 0)
                {
                    sprite.hasJumped = false;
                    // sprite.myVelocity.Y = 0f;
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
