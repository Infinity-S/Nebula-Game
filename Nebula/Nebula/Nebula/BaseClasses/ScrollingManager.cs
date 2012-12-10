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
using Nebula.BaseClasses;
using Nebula.SuperClasses; 

namespace Nebula
{
    public class ScrollingManager
    {
        private Hero myHero;
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
        private Screen myBackgroundScreen;

        public ScrollingManager(Hero anHero, List<BackgroundSprite> backgroundsList, float ScreenWidth, Screen aBackgroundScreen)
        {
            myHero = anHero;
            myBackgrounds = backgroundsList;
            //caculating the size of the whole background put together
            foreach (BackgroundSprite bs in myBackgrounds)
            {
                backgroundLength += bs.size.Width;
            }
            CameraSize = ScreenWidth;
            //left interval is 10% of screen
            LEFT_INTERVAL = CameraSize * .10;
            //right interval is 40% of screen, so the player can see what is coming next
            RIGHT_INTERVAL = CameraSize * .60;
            MAX_CAMERA_POS = backgroundLength;

            myBackgroundScreen = aBackgroundScreen;

        }

        public void ScrollForward()
        {

            for (int i = 1; i < myBackgrounds.Count(); i++)
            {
                if (myHero.myPosition.X > myBackgrounds[i].myPosition.X + myBackgrounds[i].myTexture.Width * 2)
                {
                        myBackgrounds[i].myPosition.X = myBackgrounds[i-1].myPosition.X
                        + myBackgrounds[i-1].myTexture.Width;
                }
            }
            if (myHero.myPosition.X > myBackgrounds[0].myPosition.X + myBackgrounds[0].myTexture.Width * 2)
            {
                myBackgrounds[0].myPosition.X = myBackgrounds[myBackgrounds.Count-1].myPosition.X
                           + myBackgrounds[myBackgrounds.Count - 1].myTexture.Width;
            }

            }

        public void ScrollBackward()
        {

            for (int i = 0; i < myBackgrounds.Count()-1; i++)
            {
                if (myHero.myPosition.X < myBackgrounds[i].myPosition.X - myBackgrounds[i].myTexture.Width * 2)
                { 
                    myBackgrounds[i].myPosition.X = myBackgrounds[i + 1].myPosition.X
                    - myBackgrounds[i + 1].myTexture.Width;
                }
            }
            if (myHero.myPosition.X < myBackgrounds[myBackgrounds.Count - 1].myPosition.X - myBackgrounds[myBackgrounds.Count - 1].myTexture.Width * 2)
            {
                myBackgrounds[myBackgrounds.Count - 1].myPosition.X = myBackgrounds[0].myPosition.X
                           - myBackgrounds[0].myTexture.Width;
            }

        }

        public void Update(double totalSecs)
        {
            myBackgroundScreen.myPosition = new Vector2(myHero.myPosition.X - myHero.myScreenSize.X /6, 0);

            if (Keyboard.GetState().IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickLeft)
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadLeft))
            {
                ScrollBackward();
                
                foreach (BackgroundSprite bs in myBackgrounds)
                {
                    bs.myPosition += -scrollingDirection * aSpeed;
                }
                
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickRight)
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadRight))
            {
                ScrollForward();
                
                foreach (BackgroundSprite bs in myBackgrounds)
                {
                    bs.myPosition += scrollingDirection * aSpeed;
                }
                
            }
            
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
