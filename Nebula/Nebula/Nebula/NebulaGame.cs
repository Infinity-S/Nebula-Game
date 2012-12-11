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
using Nebula.Subclasses;
using Nebula.BaseClasses;

namespace Nebula
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class NebulaGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        List<double> playerScore = new List<double>();
        List<Level> myLevels = new List<Level>(); 
        SpriteBatch mySpriteBatch;
        Screen FinishTimes;
        SpriteFont timesFont; 
        //Tutorial TutorialContent;
        //Ceres firstLevelContent; 
        //Level level;
        //Vulkanis secondLevelContent; 
        Camera camera;
        int levelNumber;
        int levelNum = 0; 

        public NebulaGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
        }

        public int getLevelNum()
        {
            return levelNum;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            mySpriteBatch = new SpriteBatch(GraphicsDevice);

            Asis myAsis = new Asis(Content.Load<Texture2D>("Asis"), new Vector2(0, 0),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), this);

            camera = new Camera(GraphicsDevice.Viewport, myAsis);

            Tutorial TutorialContent = new Tutorial(this, graphics, myAsis, mySpriteBatch);
            Ceres firstLevelContent = new Ceres(this, graphics, myAsis, mySpriteBatch); 
            //level = new Tutorial(this, graphics, myAsis, mySpriteBatch); 
            Vulkanis secondLevelContent = new Vulkanis(this, graphics, myAsis, mySpriteBatch);
            Sycia thirdLevelContent = new Sycia(this, graphics, myAsis, mySpriteBatch);
            myLevels.Add(TutorialContent);
            myLevels.Add(firstLevelContent);
            myLevels.Add(secondLevelContent);
            myLevels.Add(thirdLevelContent);
            //add another screen for the finishing times!!!
            FinishTimes = new Screen(Content.Load<Texture2D>("FinalTimes"), new Vector2(0, 0), new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
            timesFont = Content.Load<SpriteFont>("FinishTimesFont"); 

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (levelNum < myLevels.Count)
            {
                myLevels[levelNum].Update(gameTime);
                if (myLevels[levelNum].myLevelManager.getIsFinished())
                {
                    playerScore.Add(myLevels[levelNum].myLevelManager.finishingTime);
                    levelNum++;
                }
            }
            else
            {
                //if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Start))
                //{
                //    levelNum = 0;
                //    playerScore = new List<double>();
                //}
            }
            camera.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            mySpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);

            if (levelNum < myLevels.Count)
            {
                myLevels[levelNum].Draw(gameTime);
            }
            else
            {
                FinishTimes.myPosition = new Vector2(myLevels[myLevels.Count-1].myLevelManager.myHero.myPosition.X - myLevels[2].myLevelManager.xSL / 6, 0); 
                FinishTimes.Draw(mySpriteBatch);
                //tutorial Score
                //mySpriteBatch.DrawString(timesFont, Convert.ToString(Convert.ToInt32(playerScore[0]))+"s", new Vector2(500, 300), Color.White);
                //Ceres Score
                mySpriteBatch.DrawString(timesFont, Convert.ToString(Convert.ToInt32(playerScore[1])) +"s", new Vector2(550, 375), Color.White);
                //Vulkanis Score 
                mySpriteBatch.DrawString(timesFont, Convert.ToString(Convert.ToInt32(playerScore[2]))+"s", new Vector2(550, 500), Color.White);
                //Sycia Score
                mySpriteBatch.DrawString(timesFont, Convert.ToString(Convert.ToInt32(playerScore[3]))+"s", new Vector2(550, 625), Color.White);

                //restarting game 
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Start))
                {
                    levelNum = 0;
                    playerScore = new List<double>();
                }
            }

            mySpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
