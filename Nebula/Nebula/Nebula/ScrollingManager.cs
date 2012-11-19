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
        private float globalPos = 0f;
        private float backgroundLength;
        private float charPos;
        private float CameraSize;
        private float cameraPos = 0f;
        private double LEFT_INTERVAL;
        private double RIGHT_INTERVAL;
        private float MAX_CAMERA_POS; 
        private Vector2 scrollingDirection = new Vector2(-1, 0);
        private Vector2 aSpeed = new Vector2(160, 0); 


        public ScrollingManager(Asis MainChar, List<BackgroundSprite> backgroundsList, float ScreenWidth)
        {
            myAsis = MainChar;
            myBackgrounds = backgroundsList;
            //caculating the size of the whole background put together
            foreach (BackgroundSprite bs in myBackgrounds)
            {
                backgroundLength += bs.size.Width;
            }
            myAsis.myPosition.X = 200f; 
            charPos = myAsis.myPosition.X;
            CameraSize = ScreenWidth;
            //left interval is 10% of screen
            LEFT_INTERVAL = CameraSize * .10;
            //right interval is 40% of screen, so the player can see what is coming next
            RIGHT_INTERVAL = CameraSize * .40;
            MAX_CAMERA_POS = backgroundLength; 

        }

        private void changeDirection()
        {
            scrollingDirection = new Vector2(1, 0);
        }

        public void Update(double totalSecs)
        {
            //Setting up so if the image that goes off the screen (player has 'passed' it)
            //it will be added back on to the end of the images. 

            BackgroundSprite[] backgroundSprites = myBackgrounds.ToArray();
            for (int i = 0; i < backgroundSprites.Length; i++)
            {
                BackgroundSprite b = backgroundSprites[i];
                if (b.myPosition.X < -b.size.Width)
                {
                    //if it is the first image in the array, 
                    // it should be added on the last image in the array
                    if (i == 0)
                    {
                        b.myPosition.X = backgroundSprites[backgroundSprites.Length - 1].myPosition.X
                            + backgroundSprites[backgroundSprites.Length - 1].size.Width;
                    }
                    else
                    {
                        b.myPosition.X = backgroundSprites[i - 1].myPosition.X + backgroundSprites[i - 1].size.Width;
                    }
                }
            }

            //putting the result of these positions back into the list holding all the sprites 
            myBackgrounds = backgroundSprites.ToList();

            //
            if (charPos < LEFT_INTERVAL)
            {
                //cameraPos = charPos - (float)LEFT_INTERVAL;
                foreach (BackgroundSprite bs in myBackgrounds)
                {
                    bs.myPosition += scrollingDirection * aSpeed * (float)totalSecs;
                }
            }
            //foreach (BackgroundSprite bs in myBackgrounds)
            //{
            //    bs.myPosition += scrollingDirection * aSpeed * (float)totalSecs;
            //}

            //updates all the background sprites 
            foreach (Sprite b in myBackgrounds)
            {
                b.Update(totalSecs);
            }

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
