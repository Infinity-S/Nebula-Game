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
    public class Sycia : Level
    {
        public Sycia(NebulaGame aGame, GraphicsDeviceManager aGraphics, Asis anAsis, SpriteBatch aSpriteBatch)
            : base(aGame, aGraphics, anAsis, aSpriteBatch)
        {
        }

        public override void LoadSprites()
        {
            HeroLaser aLaser = new HeroLaser(myGame.Content.Load<Texture2D>("blueLaser"), new Vector2(0, 0),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            Enemy hEnemy = new Enemy(myGame.Content.Load<Texture2D>("enemy-purple"),
                new Vector2(myGraphics.PreferredBackBufferWidth + myGraphics.PreferredBackBufferWidth / 4 - myHero.myTexture.Width / 2,
                    myGraphics.PreferredBackBufferHeight / 2 + myGraphics.PreferredBackBufferHeight / 4 - myGraphics.PreferredBackBufferHeight / 8),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            EnemyLaser dLaser = new EnemyLaser(myGame.Content.Load<Texture2D>("purpleLaser"), new Vector2(myGraphics.PreferredBackBufferWidth * -1, myGraphics.PreferredBackBufferHeight * -1),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            // Initial grass platform, others are cloned in the Manager class 
            Platform grassPlatform = new Platform((myGame.Content.Load<Texture2D>("IcePlatform")), myGame.Content.Load<Texture2D>("IcePlatformDead"),
                new Vector2(myGraphics.PreferredBackBufferWidth / 2, myGraphics.PreferredBackBufferHeight - myGraphics.PreferredBackBufferHeight / 8),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            myFont = myGame.Content.Load<SpriteFont>("SpriteFont1");

            movingSpritesList.Add(myHero);
            movingSpritesList.Add(aLaser);
            movingSpritesList.Add(hEnemy);
            movingSpritesList.Add(dLaser);

            platformsList.Add(grassPlatform);

            myBackgroundScreen = new Screen(myGame.Content.Load<Texture2D>("SpaceBackground"), new Vector2(0 - myGraphics.PreferredBackBufferWidth / 12, 0),
               new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));


            allSprites.Add(myHero);
            allSprites.Add(dLaser);
            allSprites.Add(aLaser);

            //adding the test background images/Sprites
            //their positions are tacked on to each other, so they form one long background image 
            BackgroundSprite b1 = new BackgroundSprite(myGame.Content.Load<Texture2D>("IceB1"),
                new Vector2(0 - myGraphics.PreferredBackBufferWidth / 12, 0), 1.0f);
            BackgroundSprite b2 = new BackgroundSprite(myGame.Content.Load<Texture2D>("IceB2"),
                new Vector2(b1.myPosition.X + b1.myTexture.Width, 0), 1.0f);
            BackgroundSprite b3 = new BackgroundSprite(myGame.Content.Load<Texture2D>("IceB3"),
                new Vector2(b2.myPosition.X + b2.size.Width, myGraphics.PreferredBackBufferHeight - b2.myTexture.Height), 1.0f);
            BackgroundSprite b4 = new BackgroundSprite(myGame.Content.Load<Texture2D>("IceB4"),
                new Vector2(b3.myPosition.X + b3.size.Width, myGraphics.PreferredBackBufferHeight - b3.myTexture.Height), 1.0f);

            myBackgroundSprites.Add(b1);
            myBackgroundSprites.Add(b2);
            myBackgroundSprites.Add(b3);
            myBackgroundSprites.Add(b4);

            // Add each BackgroundSprite to the movingSpritesList
            foreach (BackgroundSprite s in myBackgroundSprites)
            {
                movingSpritesList.Add(s);
            }


            myInstructionScreen = new Screen(myGame.Content.Load<Texture2D>("InstructionScreen (2)"), new Vector2(myGraphics.PreferredBackBufferWidth * -3, 0),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            myGameOverScreen = new Screen(myGame.Content.Load<Texture2D>("death-screen"), new Vector2(0, 0),
               new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            myVictoryScreen1 = new Screen(myGame.Content.Load<Texture2D>("Stage1Cleared1st"), new Vector2(myGraphics.PreferredBackBufferWidth * -3, 0),
                  new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            myVictoryScreen2 = new Screen(myGame.Content.Load<Texture2D>("Stage1Cleared2nd"), new Vector2(myGraphics.PreferredBackBufferWidth * -3, 0),
                  new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            myVictoryScreen3 = new Screen(myGame.Content.Load<Texture2D>("Stage1Cleared3rd"), new Vector2(myGraphics.PreferredBackBufferWidth * -3, 0),
                  new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            myVictoryScreen4 = new Screen(myGame.Content.Load<Texture2D>("Stage1Cleared4th"), new Vector2(myGraphics.PreferredBackBufferWidth * -3, 0),
                  new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            myVictoryScreens.Add(myVictoryScreen1);
            myVictoryScreens.Add(myVictoryScreen2);
            myVictoryScreens.Add(myVictoryScreen3);
            myVictoryScreens.Add(myVictoryScreen4);

            myCutScene = new Screen(myGame.Content.Load<Texture2D>("CutScene"), new Vector2(myGraphics.PreferredBackBufferWidth * -3, 0),
                  new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight));

            SoundEffect levelMusic = myGame.Content.Load<SoundEffect>("nephlim");

            scrollingManager = new ScrollingManager(myHero, myBackgroundSprites, myGraphics.PreferredBackBufferWidth, myBackgroundScreen);

            myTimeTravelManager = new TimeTravelManager(myGame.Content.Load<Texture2D>("timet-background"), new Vector2(0, 0),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight), myGame, movingSpritesList, myHero);

            myLevelManager = new SyciaLevelManager(myGame.Content.Load<Texture2D>("blueLaser"), new Vector2(-1000, -1000),
                new Vector2(myGraphics.PreferredBackBufferWidth, myGraphics.PreferredBackBufferHeight),
                myGame, this, movingSpritesList, platformsList, myFont, (Asis)myHero, myInstructionScreen, myGameOverScreen, myVictoryScreens, myCutScene, myTimeTravelManager, levelMusic);

            allSprites.Add(myGameOverScreen);
            allSprites.Add(myVictoryScreen1);
            allSprites.Add(myVictoryScreen2);
            allSprites.Add(myVictoryScreen3);
            allSprites.Add(myVictoryScreen4);
            allSprites.Add(myCutScene);
            allSprites.Add(myTimeTravelManager);
            allSprites.Add(myLevelManager);
        }

    }
}