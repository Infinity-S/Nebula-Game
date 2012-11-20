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

namespace Nebula
{
    class Asis : Sprite
    {   

        private String direction;

        public String getDirection()
        {
            return direction;
        }
        public void setDirection(String s)
        {
            direction = s;
        }

        public Asis(Texture2D texture, Vector2 position, Vector2 screen) 
            : base(texture, position)   
        {
            myScreenSize = screen;
            myState = new ExistState(this);
            hasJumped = true;
            myPosition.X = myTexture.Width;
            myPosition.Y = myScreenSize.Y - myTexture.Height;
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
            InputManager.AddToKeyboardMap(Keys.Right, moveRight);
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
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && sprite.hasJumped == false)
                {
                    sprite.myPosition.Y -= 10f;
                    sprite.myVelocity.Y = -7f;
                    sprite.hasJumped = true;
                }
                if (sprite.hasJumped == true)
                {
                    float i = 1;
                    // change 0.15 to alter speed of falling
                   sprite.myVelocity.Y += 0.18f * i;
                }
                if (sprite.myPosition.Y + sprite.myTexture.Height > sprite.myScreenSize.Y)
                {
                    sprite.hasJumped = false;
                    sprite.myVelocity.Y = 0f;
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
