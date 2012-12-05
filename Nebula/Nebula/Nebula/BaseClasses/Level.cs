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
using Microsoft.Xna.Framework.Media;
using Nebula.SuperClasses;
using Nebula.Subclasses; 

namespace Nebula.BaseClasses
{
    class Level
    {
        protected internal Game1 myGame;
        protected internal GraphicsDeviceManager myGraphics;
        protected internal Asis myAsis;
        protected internal SpriteBatch spriteBatch;
        protected internal List<Sprite> allSprites = new List<Sprite>();
        protected internal List<Sprite> movingSpritesList = new List<Sprite>();
        protected internal List<Sprite> platformsList = new List<Sprite>();
        protected internal List<BackgroundSprite> myBackgroundSprites = new List<BackgroundSprite>();
        protected internal ScrollingManager scrollingManager;
        protected internal Screen myInstructionScreen;
        protected internal Screen myVictoryScreen; 
        protected internal Screen myBackgroundScreen;
        protected internal Screen myGameOverScreen;
        protected internal SpriteManager spriteManager; 
        protected internal SpriteFont myFont;
         

        public Level(Game1 aGame, GraphicsDeviceManager aGraphics, Asis aAsis, SpriteBatch aSpriteBatch)
        {
            myGame = aGame;
            myGraphics = aGraphics;
            myAsis = aAsis;
            spriteBatch = aSpriteBatch; 
            LoadSprites();
        }

        public virtual void LoadSprites()
        {

        }

        public void AddSprite(Sprite s)
        {
            allSprites.Add(s);
        }

        public virtual void Update(GameTime gameTime)
        {
            InputManager.ActKeyboard(Keyboard.GetState());
            InputManager.ActMouse(Mouse.GetState()); 
            InputManager.ActGamePad(GamePad.GetState(PlayerIndex.One));

            foreach (Sprite s in allSprites)
            {
                s.Update(gameTime.ElapsedGameTime.TotalSeconds);
            }
            //updating the background for scrolling 
           scrollingManager.Update(gameTime.ElapsedGameTime.TotalSeconds);
        }

        public virtual void Draw(GameTime gameTime)
        {
            scrollingManager.Draw(spriteBatch);
            foreach (Sprite s in allSprites)
            {
                s.Draw(spriteBatch);
            }
        }
    }
}
