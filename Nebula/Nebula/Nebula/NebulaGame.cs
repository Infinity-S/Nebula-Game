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
        SpriteBatch mySpriteBatch;
        Tutorial TutorialContent;
        Level level;
        Vulkanis secondLevelContent; 
        Camera camera;
        int levelNumber;

        public int getLevelNumber()
        {
            return levelNumber;
        }

        public void setLevel(int i, Asis asi)
        {
            
            if (i == 1)
            {
                level = new Ceres(this, graphics, asi, mySpriteBatch);
                levelNumber = 1;
            }
            
            if (i == 2)
            {
                level = new Vulkanis(this, graphics, asi, mySpriteBatch);
                levelNumber = 2;
            }
            /*
            if (i == 3)
            {
                level = new Sycia(this, graphics, asi, mySpriteBatch);
                levelNumber = 3;
            }
            */

        }

        public NebulaGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
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

            // TutorialContent = new Tutorial(this, graphics, myAsis, mySpriteBatch);
            level = new Tutorial(this, graphics, myAsis, mySpriteBatch); 
            //secondLevelContent = new Vulkanis(this, graphics, myAsis, mySpriteBatch); 
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
            
            level.Update(gameTime);
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

            level.Draw(gameTime);
            mySpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
