using System;
using System.Collections.Generic;
using System.Linq;
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
using Nebula.Subclasses; 

namespace Nebula
{
    class ScrollingManager
    {
        private Asis myAsis;
        private List<BackgroundSprite> myBackgrounds;
        //private float globalPos = 0f;
        private float backgroundLength;
        //private float charPos;
        private float CameraSize;
        //private float cameraPos = 0f;
        private double LEFT_INTERVAL;
       // private double leftMargin; 
        private double RIGHT_INTERVAL;
       // private float rightMargin; 
        private float MAX_CAMERA_POS; 
        private Vector2 scrollingDirection = new Vector2(-1, 0);
        private Vector2 aSpeed = new Vector2(1, 0);
        private BackgroundScreen myBackgroundScreen;

        public ScrollingManager(Asis MainChar, List<BackgroundSprite> backgroundsList, float ScreenWidth, BackgroundScreen aBackgroundScreen)
        {
            myAsis = MainChar;
            myBackgrounds = backgroundsList;
            //caculating the size of the whole background put together
            foreach (BackgroundSprite bs in myBackgrounds)
            {
                backgroundLength += bs.size.Width;
            }
           // myAsis.myPosition.X = 200f; 
            //charPos = myAsis.myPosition.X;
            CameraSize = ScreenWidth;
            //left interval is 10% of screen
            LEFT_INTERVAL = CameraSize * .10;
            //right interval is 40% of screen, so the player can see what is coming next
            RIGHT_INTERVAL = CameraSize * .60;
            MAX_CAMERA_POS = backgroundLength;

            myBackgroundScreen = aBackgroundScreen;

        }

        public void SwitchDirection()
        {
            scrollingDirection = -scrollingDirection;
        }

        public void ScrollForward()
        {

            for (int i = 1; i < myBackgrounds.Count(); i++)
            {
                if (myAsis.myPosition.X > myBackgrounds[i].myPosition.X + myBackgrounds[i].myTexture.Width * 2)
                {
                        myBackgrounds[i].myPosition.X = myBackgrounds[i-1].myPosition.X
                        + myBackgrounds[i-1].myTexture.Width;
                }
            }
            if (myAsis.myPosition.X > myBackgrounds[0].myPosition.X + myBackgrounds[0].myTexture.Width * 2)
            {
                myBackgrounds[0].myPosition.X = myBackgrounds[myBackgrounds.Count-1].myPosition.X
                           + myBackgrounds[myBackgrounds.Count - 1].myTexture.Width;
            }

            }

        public void ScrollBackward()
        {

            for (int i = 0; i < myBackgrounds.Count()-1; i++)
            {
                if (myAsis.myPosition.X < myBackgrounds[i].myPosition.X - myBackgrounds[i].myTexture.Width * 2)
                { 
                    myBackgrounds[i].myPosition.X = myBackgrounds[i + 1].myPosition.X
                    - myBackgrounds[i + 1].myTexture.Width;
                }
            }
            if (myAsis.myPosition.X < myBackgrounds[myBackgrounds.Count - 1].myPosition.X - myBackgrounds[myBackgrounds.Count - 1].myTexture.Width * 2)
            {
                myBackgrounds[myBackgrounds.Count - 1].myPosition.X = myBackgrounds[0].myPosition.X
                           - myBackgrounds[0].myTexture.Width;
            }

        }

        public void Update(double totalSecs)
        {
            myBackgroundScreen.myPosition = new Vector2(myAsis.myPosition.X - myAsis.myScreenSize.X /6, 0);

            /*&& myAsis.myPosition.X < LEFT_INTERVAL*/
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickLeft)
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadLeft))
            {
                ScrollBackward();
                
                foreach (BackgroundSprite bs in myBackgrounds)
                {
                    bs.myPosition += -scrollingDirection * aSpeed;
                }
                
            }
                //&& only if Asis is less than the length of the level 
            /*&& myAsis.myPosition.X < MAX_CAMERA_POS && myAsis.myPosition.X > LEFT_INTERVAL*/
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickRight)
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadRight))
            {
                ScrollForward();
                
                foreach (BackgroundSprite bs in myBackgrounds)
                {
                    bs.myPosition += scrollingDirection * aSpeed;
                }
                
            }
            /*
            // scrolling when Asis is moving left
            //  && charPos < LEFT_INTERVAL
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                //cameraPos = myAsis.myPosition.X - (float)LEFT_INTERVAL;
                //ScrollBackward(); 
                ScrollForward();
                foreach (BackgroundSprite bs in myBackgrounds)
                {
                    //bs.myPosition += -scrollingDirection * aSpeed * (float)totalSecs;
                    bs.myPosition += -scrollingDirection * aSpeed;
                }
            }
            // scrolling when Asis is moving right
            // myAsis.myPosition.X > RIGHT_INTERVAL && 
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                float cameraMovement = charPos + (float) RIGHT_INTERVAL;
                ScrollForward(); 
                foreach (BackgroundSprite bs in myBackgrounds)
                {
                    //bs.myPosition += scrollingDirection * aSpeed * (float)totalSecs; 
                    //bs.myPosition += new Vector2(cameraMovement, 0)*scrollingDirection*aSpeed; 
                   bs.myPosition += scrollingDirection * aSpeed;
                }
            }
             */
            
        }

        public void Draw(SpriteBatch batch)
        {
            myBackgroundScreen.Draw(batch);
            //draws all the background sprites
            foreach (Sprite b in myBackgrounds)
            {
                b.Draw(batch);
            }
        }
    }
}
