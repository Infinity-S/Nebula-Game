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
        List<Sprite> spritesList = new List<Sprite>();
        Sprite[] platformsArray;
        //adding a sprite list for the scrolling background images 
        List<BackgroundSprite> myBackgroundSprites = new List<BackgroundSprite>();
        ScrollingManager scrollingManager; 

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
        
        public void AddSprite(Sprite s)
        {
            mySprites.Add(s);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Asis asis = new Asis(Content.Load<Texture2D>("Asis"), new Vector2(0, 0),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            AsisLaser aLaser = new AsisLaser(Content.Load<Texture2D>("blueLaser"), new Vector2(0, 0),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            DraconisEnemy dEnemy = new DraconisEnemy(Content.Load<Texture2D>("enemy-red"), 
                new Vector2(graphics.PreferredBackBufferWidth + graphics.PreferredBackBufferWidth/4 - asis.myTexture.Width/2, 
                    graphics.PreferredBackBufferHeight/2 + graphics.PreferredBackBufferHeight/4 - graphics.PreferredBackBufferHeight/8),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            DraconisLaser dLaser = new DraconisLaser(Content.Load<Texture2D>("redLaser"), new Vector2(0, 0),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            GrassPlatform grassPlatform = new GrassPlatform((Content.Load<Texture2D>("grass")), 
                new Vector2(graphics.PreferredBackBufferWidth/2, graphics.PreferredBackBufferHeight - graphics.PreferredBackBufferHeight/8),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            // grassPlatforms 2 and 3 are traps - Asis will fall through them if she tries to land on them
            GrassPlatform grassPlatform2 = new GrassPlatform((Content.Load<Texture2D>("grass")), 
                new Vector2(graphics.PreferredBackBufferWidth + graphics.PreferredBackBufferWidth / 2 + grassPlatform.myTexture.Width,
               graphics.PreferredBackBufferHeight / 2 + graphics.PreferredBackBufferHeight / 16),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            GrassPlatform grassPlatform3 = new GrassPlatform((Content.Load<Texture2D>("grass")),
                new Vector2(graphics.PreferredBackBufferWidth + graphics.PreferredBackBufferWidth / 2 + grassPlatform.myTexture.Width * 2,
               graphics.PreferredBackBufferHeight / 2 + graphics.PreferredBackBufferHeight / 16),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            DraconisEnemy dEnemy2 = new DraconisEnemy(Content.Load<Texture2D>("enemy-red"),
                new Vector2(graphics.PreferredBackBufferWidth * 2 + grassPlatform.myTexture.Width * 7, 
                    graphics.PreferredBackBufferHeight/2 + graphics.PreferredBackBufferHeight/4 - dEnemy.myTexture.Height/4),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            camera = new Camera(GraphicsDevice.Viewport, asis);

            spritesList.Add(asis);
            spritesList.Add(aLaser);
            spritesList.Add(dEnemy);
            spritesList.Add(dLaser);
            spritesList.Add(dEnemy2);

            platformsArray = new Sprite[1];

            platformsArray[0] = grassPlatform;
            
            mySprites.Add(asis);
            mySprites.Add(dLaser);
            mySprites.Add(dEnemy); 
            mySprites.Add(aLaser);
            mySprites.Add(grassPlatform);
            mySprites.Add(grassPlatform2);
            mySprites.Add(grassPlatform3);
            mySprites.Add(dEnemy2);
            
            //adding the test background images/Sprites
            //their positions are tacked on to each other, so they form one long background image 
            BackgroundSprite b1 = new BackgroundSprite(Content.Load<Texture2D>("Background01"),
                new Vector2(0, 0), 1.0f);
            BackgroundSprite b2 = new BackgroundSprite(Content.Load<Texture2D>("Background02"),
                new Vector2(b1.myPosition.X + b1.myTexture.Width, 0), 1.0f); 
            BackgroundSprite b3 = new BackgroundSprite(Content.Load<Texture2D>("Background03"),
                new Vector2(b2.myPosition.X + b2.size.Width, graphics.PreferredBackBufferHeight - b2.myTexture.Height), 1.0f); 
            BackgroundSprite b4 = new BackgroundSprite(Content.Load<Texture2D>("Background04"),
                new Vector2(b3.myPosition.X + b3.size.Width, graphics.PreferredBackBufferHeight - b3.myTexture.Height), 1.0f); 
            BackgroundSprite b5 = new BackgroundSprite(Content.Load<Texture2D>("Background05"),
                new Vector2(b4.myPosition.X + b4.size.Width, graphics.PreferredBackBufferHeight - b4.myTexture.Height), 1.0f);

            myBackgroundSprites.Add(b1);
            myBackgroundSprites.Add(b2);
            myBackgroundSprites.Add(b3);
            myBackgroundSprites.Add(b4);
            myBackgroundSprites.Add(b5);

            Sprite[] spritesArray = spritesList.ToArray();

            scrollingManager = new ScrollingManager(asis, myBackgroundSprites, graphics.PreferredBackBufferWidth);

            SpriteManager spriteManager = new SpriteManager(Content.Load<Texture2D>("blueLaser"), new Vector2(-1000, -1000),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), this, spritesArray);

            Manager manager = new Manager(Content.Load<Texture2D>("blueLaser"), new Vector2(-1000, -1000),
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), this, spritesArray,
                 Content.Load<SoundEffect>("LaserSoundEffect"), Content.Load<SoundEffect>("LaserSoundEffectBackwards"), platformsArray);

            mySprites.Add(spriteManager);
            mySprites.Add(manager);
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
            scrollingManager.Draw(spriteBatch); 
            foreach (Sprite s in mySprites)
            {
                s.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
