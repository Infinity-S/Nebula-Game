using System;
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
using Nebula.BaseClasses; 

namespace Nebula.Subclasses
{
    class Ceres : Level
    {
        //Game1 myGame;
        //GraphicsDeviceManager myGraphics;
        //Asis asis;
        //SpriteBatch spriteBatch;
        //List<Sprite> allSprites = new List<Sprite>();
        //List<Sprite> movingSpritesList = new List<Sprite>();
        //List<Sprite> platformsList = new List<Sprite>();
        //List<BackgroundSprite> myBackgroundSprites = new List<BackgroundSprite>();
        //ScrollingManager scrollingManager;
        //SpriteFont myFont;

        public Ceres(Game1 aGame, GraphicsDeviceManager aGraphics, Asis anAsis, SpriteBatch aSpriteBatch)
            : base (aGame, aGraphics, anAsis, aSpriteBatch)
        {
            //myGraphics = aGraphics;
            //myGame = aGame;
            //asis = anAsis;
            //spriteBatch = aSpriteBatch;
            //LoadCeresSprites();
        }

        public override void LoadSprites()
        {
            AsisLaser aLaser = new AsisLaser(myGame.Content.Load<Texture2D>("blueLaser"), new Vector2(0, 0),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            Enemy dEnemy = new Enemy(myGame.Content.Load<Texture2D>("enemy-red"),
                new Vector2(myGraphics.PreferredBackBufferWidth + myGraphics.PreferredBackBufferWidth / 4 - myAsis.myTexture.Width / 2,
                    myGraphics.PreferredBackBufferHeight / 2 + myGraphics.PreferredBackBufferHeight / 4 - myGraphics.PreferredBackBufferHeight / 8),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            DraconisLaser dLaser = new DraconisLaser(myGame.Content.Load<Texture2D>("redLaser"), new Vector2(myGraphics.PreferredBackBufferWidth * -1, myGraphics.PreferredBackBufferHeight * -1),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            // Initial grass platform, others are cloned in the Manager class 
            GrassPlatform grassPlatform = new GrassPlatform((myGame.Content.Load<Texture2D>("grass")),
                new Vector2(myGraphics.PreferredBackBufferWidth / 2, myGraphics.PreferredBackBufferHeight - myGraphics.PreferredBackBufferHeight / 8),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            Enemy dEnemy2 = new Enemy(myGame.Content.Load<Texture2D>("enemy-red"),
                new Vector2(myGraphics.PreferredBackBufferWidth * 2 + grassPlatform.myTexture.Width * 7,
                    myGraphics.PreferredBackBufferHeight / 2 + myGraphics.PreferredBackBufferHeight / 4 - dEnemy.myTexture.Height / 4),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            myFont = myGame.Content.Load<SpriteFont>("SpriteFont1");

            movingSpritesList.Add(myAsis);
            movingSpritesList.Add(aLaser);
            movingSpritesList.Add(dEnemy);
            movingSpritesList.Add(dLaser);
            movingSpritesList.Add(dEnemy2);

            platformsList.Add(grassPlatform);

            allSprites.Add(myAsis);
            allSprites.Add(dLaser);
            allSprites.Add(dEnemy);
            allSprites.Add(aLaser);
            allSprites.Add(grassPlatform);
            allSprites.Add(dEnemy2);

            //adding the test background images/Sprites
            //their positions are tacked on to each other, so they form one long background image 
            BackgroundSprite b1 = new BackgroundSprite(myGame.Content.Load<Texture2D>("Background01"),
                new Vector2(0 - myGraphics.PreferredBackBufferWidth/12, 0), 1.0f);
            BackgroundSprite b2 = new BackgroundSprite(myGame.Content.Load<Texture2D>("Background02"),
                new Vector2(b1.myPosition.X + b1.myTexture.Width, 0), 1.0f);
            BackgroundSprite b3 = new BackgroundSprite(myGame.Content.Load<Texture2D>("Background03"),
                new Vector2(b2.myPosition.X + b2.size.Width, myGraphics.PreferredBackBufferHeight - b2.myTexture.Height), 1.0f);
            BackgroundSprite b4 = new BackgroundSprite(myGame.Content.Load<Texture2D>("Background04"),
                new Vector2(b3.myPosition.X + b3.size.Width, myGraphics.PreferredBackBufferHeight - b3.myTexture.Height), 1.0f);
            BackgroundSprite b5 = new BackgroundSprite(myGame.Content.Load<Texture2D>("Background05"),
                new Vector2(b4.myPosition.X + b4.size.Width, myGraphics.PreferredBackBufferHeight - b4.myTexture.Height), 1.0f);

            myBackgroundSprites.Add(b1);
            myBackgroundSprites.Add(b2);
            myBackgroundSprites.Add(b3);
            myBackgroundSprites.Add(b4);
            myBackgroundSprites.Add(b5);

            // Add each BackgroundSprite to the movingSpritesList
            foreach (BackgroundSprite s in myBackgroundSprites)
            {
                movingSpritesList.Add(s);
            }

            GameOver gameOverScreen = new GameOver(myGame.Content.Load<Texture2D>("death-screen"), new Vector2(0, 0), 
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            scrollingManager = new ScrollingManager(myAsis, myBackgroundSprites, myGraphics.PreferredBackBufferWidth);

            SpriteManager spriteManager = new SpriteManager(myGame.Content.Load<Texture2D>("timet-background"), new Vector2(0, 0),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight), myGame, movingSpritesList, myAsis);

            Manager manager = new Manager(myGame.Content.Load<Texture2D>("blueLaser"), new Vector2(-1000, -1000),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight),
                myGame, this, movingSpritesList, platformsList, myFont, myAsis, gameOverScreen, spriteManager);

            allSprites.Add(gameOverScreen);
            allSprites.Add(spriteManager);
            allSprites.Add(manager);
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            scrollingManager.Update(gameTime.ElapsedGameTime.TotalSeconds); 
        }

        public void Draw(GameTime gameTime)
        {
            scrollingManager.Draw(spriteBatch); 
            base.Draw(gameTime); 
        }

        //public void AddSprite(Sprite s)
        //{
        //    allSprites.Add(s);
        //}

        //public void Update(GameTime gameTime)
        //{

        //    InputManager.ActKeyboard(Keyboard.GetState());
        //    InputManager.ActMouse(Mouse.GetState());
        //    InputManager.ActGamePad(GamePad.GetState(PlayerIndex.One));

        //    // TODO: Add your update logic here
        //    foreach (Sprite s in allSprites)
        //    {
        //        s.Update(gameTime.ElapsedGameTime.TotalSeconds);
        //    }
        //    //updating the background for scrolling 
        //    scrollingManager.Update(gameTime.ElapsedGameTime.TotalSeconds); 
        //}

        //public void Draw(GameTime gameTime)
        //{
        //    scrollingManager.Draw(spriteBatch);
        //    foreach (Sprite s in allSprites)
        //    {
        //        s.Draw(spriteBatch);
        //    }
        //}
    }
}
