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
    class Sycia : Level
    {
        Game1 myGame;
        GraphicsDeviceManager myGraphics;

        public Sycia(Game1 aGame, GraphicsDeviceManager aGraphics, Asis anAsis, SpriteBatch aSpriteBatch)
            : base (aGame, aGraphics, anAsis, aSpriteBatch)
        {
            myGame = aGame;
            myGraphics = aGraphics;
            LoadSyciaSprites();
        }

        private void LoadSyciaSprites() 
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {

        }

    }
}
