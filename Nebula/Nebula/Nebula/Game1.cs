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

namespace Nebula
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Camera camera;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Sprite> mySprites = new List<Sprite>();
        //adding a sprite list for the scrolling background images 
        List<BackgroundSprite> myBackgroundSprites = new List<BackgroundSprite>();
       ScrollingManager manager; 

        public Game1()
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Asis Asis = new Asis(Content.Load<Texture2D>("Asis"), new Vector2(0, 0),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            Laser Laser = new Laser(Content.Load<Texture2D>("Laser"), new Vector2(0, 0),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            Enemy redEnemy = new Enemy(Content.Load<Texture2D>("enemy-red"), new Vector2(0, 0),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));


            camera = new Camera(GraphicsDevice.Viewport, Asis);


            mySprites.Add(Asis);
            mySprites.Add(Laser);
            mySprites.Add(redEnemy); 

            //adding the test background images/Sprites
            //their positions are tacked on to each other, so they form one long background image 
            BackgroundSprite b1 = new BackgroundSprite(Content.Load<Texture2D>("Background01"), 
                new Vector2(0,0), 2.0f);
            BackgroundSprite b2 = new BackgroundSprite(Content.Load<Texture2D>("Background02"), 
                new Vector2(b1.myPosition.X + b1.size.Width, 0), 2.0f); 
            BackgroundSprite b3 = new BackgroundSprite(Content.Load<Texture2D>("Background03"),
                new Vector2(b2.myPosition.X + b2.size.Width, 0), 2.0f); 
            BackgroundSprite b4 = new BackgroundSprite(Content.Load<Texture2D>("Background04"),
                new Vector2(b3.myPosition.X + b3.size.Width, 0), 2.0f); 
            BackgroundSprite b5 = new BackgroundSprite(Content.Load<Texture2D>("Background05"),
                new Vector2(b4.myPosition.X + b4.size.Width, 0), 2.0f);

            myBackgroundSprites.Add(b1);
            myBackgroundSprites.Add(b2);
            myBackgroundSprites.Add(b3);
            myBackgroundSprites.Add(b4);
            myBackgroundSprites.Add(b5);

            manager = new ScrollingManager(Asis, myBackgroundSprites, graphics.PreferredBackBufferWidth);

            SpriteManager SpriteManager = new SpriteManager(Content.Load<Texture2D>("Laser"), new Vector2(-1000, -1000),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), this, Asis, Laser,
                redEnemy, Content.Load<SoundEffect>("LaserSoundEffect"), Content.Load<SoundEffect>("LaserSoundEffectBackwards"), manager);
            mySprites.Add(SpriteManager);

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

            InputManager.ActKeyboard(Keyboard.GetState());
            InputManager.ActMouse(Mouse.GetState());

            // TODO: Add your update logic here
            foreach (Sprite s in mySprites)
            {
                s.Update(gameTime.ElapsedGameTime.TotalSeconds);
            }
            //updating the background for scrolling 
            //manager.Update(gameTime.ElapsedGameTime.TotalSeconds); 

            camera.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);
            manager.Draw(spriteBatch); 
            foreach (Sprite s in mySprites)
            {
                s.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
