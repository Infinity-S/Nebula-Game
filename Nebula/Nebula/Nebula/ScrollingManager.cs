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
        private Vector2 aSpeed = new Vector2(4, 0);

        public ScrollingManager(Asis MainChar, List<BackgroundSprite> backgroundsList, float ScreenWidth)
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

        }

        public void SwitchDirection()
        {
            scrollingDirection = -scrollingDirection;
        }

        public void ScrollForward()
        {

            //float one = myBackgrounds[0].myPosition.X;
            //float two = myBackgrounds[1].myPosition.X;
            //float three = myBackgrounds[2].myPosition.X;
            //float four = myBackgrounds[3].myPosition.X;
            //float five = myBackgrounds[4].myPosition.X;
            //float acePos = myAsis.myPosition.X;

            // BackgroundSprite[] myBackgrounds = myBackgroundss.ToArray();
            // for (int i = 0; i < backgroundSprites.Length; i++)
            // {
                //BackgroundSprite b = backgroundSprites[i];

            //for (int i = 0; i < myBackgrounds.Count(); i++)
            //{
            //    if (myAsis.myPosition.X > myBackgrounds[i].myPosition.X + myBackgrounds[i].myTexture.Width * 2)
            //    {
            //        if (i == 0)
            //        {
            //            myBackgrounds[i].myPosition.X = myBackgrounds[4].myPosition.X
            //            + myBackgrounds[4].myTexture.Width;
            //        }
            //        else myBackgrounds[i].myPosition.X = myBackgrounds[i--].myPosition.X
            //            + myBackgrounds[i--].myTexture.Width;
            //    }
            //}

            for (int i = 1; i < myBackgrounds.Count(); i++)
            {
                if (myAsis.myPosition.X > myBackgrounds[i].myPosition.X + myBackgrounds[i].myTexture.Width * 2)
                {
                    //if (i == 0)
                    //{
                    //    myBackgrounds[i].myPosition.X = myBackgrounds[4].myPosition.X
                    //    + myBackgrounds[4].myTexture.Width;
                    //}
                    //else 
                        myBackgrounds[i].myPosition.X = myBackgrounds[i-1].myPosition.X
                        + myBackgrounds[i-1].myTexture.Width;
                }
            }
            if (myAsis.myPosition.X > myBackgrounds[0].myPosition.X + myBackgrounds[0].myTexture.Width * 2)
            {
                myBackgrounds[0].myPosition.X = myBackgrounds[4].myPosition.X
                           + myBackgrounds[4].myTexture.Width;
            }



            //if (myAsis.myPosition.X > myBackgrounds[0].myPosition.X + myBackgrounds[0].myTexture.Width * 2)
            //{
            //    myBackgrounds[0].myPosition.X = myBackgrounds[4].myPosition.X
            //        + myBackgrounds[4].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X > myBackgrounds[1].myPosition.X + myBackgrounds[1].myTexture.Width * 2)
            //{
            //    myBackgrounds[1].myPosition.X = myBackgrounds[0].myPosition.X
            //        + myBackgrounds[0].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X > myBackgrounds[2].myPosition.X + myBackgrounds[2].myTexture.Width * 2)
            //{
            //    myBackgrounds[2].myPosition.X = myBackgrounds[1].myPosition.X
            //        + myBackgrounds[1].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X > myBackgrounds[3].myPosition.X + myBackgrounds[3].myTexture.Width * 2)
            //{
            //    myBackgrounds[3].myPosition.X = myBackgrounds[2].myPosition.X
            //        + myBackgrounds[2].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X > myBackgrounds[4].myPosition.X + myBackgrounds[4].myTexture.Width * 2)
            //{
            //    myBackgrounds[4].myPosition.X = myBackgrounds[3].myPosition.X
            //        + myBackgrounds[3].myTexture.Width;
            //}
            }

        public void ScrollBackward()
        {
            float one = myBackgrounds[0].myPosition.X;
            float two = myBackgrounds[1].myPosition.X;
            float three = myBackgrounds[2].myPosition.X;
            float four = myBackgrounds[3].myPosition.X;
            float five = myBackgrounds[4].myPosition.X;
            float acePos = myAsis.myPosition.X;

            //if (myAsis.myPosition.X < myBackgrounds[4].myPosition.X + myBackgrounds[4].myTexture.Width * 2)
            //{
            //    myBackgrounds[4].myPosition.X = myBackgrounds[0].myPosition.X
            //        - myBackgrounds[0].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X < myBackgrounds[3].myPosition.X + myBackgrounds[3].myTexture.Width * 2)
            //{
            //    myBackgrounds[3].myPosition.X = myBackgrounds[4].myPosition.X
            //        - myBackgrounds[4].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X < myBackgrounds[2].myPosition.X + myBackgrounds[2].myTexture.Width * 2)
            //{
            //    myBackgrounds[2].myPosition.X = myBackgrounds[3].myPosition.X
            //        - myBackgrounds[3].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X < myBackgrounds[1].myPosition.X + myBackgrounds[1].myTexture.Width * 2)
            //{
            //    myBackgrounds[1].myPosition.X = myBackgrounds[2].myPosition.X
            //        - myBackgrounds[2].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X < myBackgrounds[0].myPosition.X + myBackgrounds[0].myTexture.Width * 2)
            //{
            //    myBackgrounds[0].myPosition.X = myBackgrounds[1].myPosition.X
            //        - myBackgrounds[1].myTexture.Width;
            //}

            for (int i = 0; i < myBackgrounds.Count()-1; i++)
            {
                if (myAsis.myPosition.X < myBackgrounds[i].myPosition.X - myBackgrounds[i].myTexture.Width * 2)
                { 
                    myBackgrounds[i].myPosition.X = myBackgrounds[i - 1].myPosition.X
                    + myBackgrounds[i - 1].myTexture.Width;
                }
            }
            if (myAsis.myPosition.X > myBackgrounds[0].myPosition.X + myBackgrounds[0].myTexture.Width * 2)
            {
                myBackgrounds[0].myPosition.X = myBackgrounds[4].myPosition.X
                           + myBackgrounds[4].myTexture.Width;
            }

            //
            //if (myAsis.myPosition.X < myBackgrounds[0].myPosition.X - myBackgrounds[0].myTexture.Width * 2)
            //{
            //    myBackgrounds[0].myPosition.X = myBackgrounds[1].myPosition.X
            //        - myBackgrounds[1].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X < myBackgrounds[1].myPosition.X - myBackgrounds[1].myTexture.Width * 2)
            //{
            //    myBackgrounds[1].myPosition.X = myBackgrounds[2].myPosition.X
            //        - myBackgrounds[2].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X < myBackgrounds[2].myPosition.X - myBackgrounds[2].myTexture.Width * 2)
            //{
            //    myBackgrounds[2].myPosition.X = myBackgrounds[3].myPosition.X
            //        - myBackgrounds[3].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X < myBackgrounds[3].myPosition.X - myBackgrounds[3].myTexture.Width * 2)
            //{
            //    myBackgrounds[3].myPosition.X = myBackgrounds[4].myPosition.X
            //        - myBackgrounds[4].myTexture.Width;
            //}
            //else if (myAsis.myPosition.X < myBackgrounds[4].myPosition.X - myBackgrounds[4].myTexture.Width * 2)
            //{
            //    myBackgrounds[4].myPosition.X = myBackgrounds[0].myPosition.X
            //        - myBackgrounds[0].myTexture.Width;
            //}
        }

        public void Update(double totalSecs)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left) /*&& myAsis.myPosition.X < LEFT_INTERVAL*/)
            {
                ScrollBackward();
                foreach (BackgroundSprite bs in myBackgrounds)
                {
                    bs.myPosition += -scrollingDirection * aSpeed;
                }
            }
                //&& only if Asis is less than the length of the level 
            else if (Keyboard.GetState().IsKeyDown(Keys.Right)/*&& myAsis.myPosition.X < MAX_CAMERA_POS && myAsis.myPosition.X > LEFT_INTERVAL*/)
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

            //updates all the background sprites 
            //foreach (Sprite b in myBackgrounds)
            //{
            //    b.Update(totalSecs);
            //}
            
        }

        public void Draw(SpriteBatch batch)
        {
            //draws all the background sprites
            foreach (Sprite b in myBackgrounds)
            {
                b.Draw(batch);
            }
        }
    }
}
