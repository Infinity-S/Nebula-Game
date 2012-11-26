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
using Nebula.SuperClasses;
using Nebula.Subclasses;

namespace Nebula.SuperClasses
{
    class SpriteManager : Sprite
    {
        protected internal Stack TimeStack; 
        protected internal Sprite[] PositionsArray;
        public Game1 myGame;
        // private ScrollingManager myScrollingManager;

        public SpriteManager(Texture2D texture, Vector2 position, Vector2 screen, Game1 aGame,
            Sprite[] aPositionsArray)
            : base(texture, position)
        {
            myPosition = position;
            myScreenSize = screen;
            myGame = aGame;
            PositionsArray = aPositionsArray;
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
                // sm.myScrollingManager.Update(elapsedTime); 
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

                // sm.myScrollingManager.Update(elapsedTime);

                // If X key is not being pressed, add positions of sprites to Stack
                if (!Keyboard.GetState().IsKeyDown(Keys.X))
                {
                    for (int i = 0; i < sm.PositionsArray.Length; i ++) {
                    sm.TimeStack.Push(sm.PositionsArray[i].myPosition);
                }
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

