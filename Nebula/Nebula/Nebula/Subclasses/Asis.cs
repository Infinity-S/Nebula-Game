using System;
using System.Collections.Generic;
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
using Nebula.SuperClasses;

namespace Nebula
{
    public class Asis : Hero

    {
        public Asis(Texture2D image, Vector2 position, Vector2 screen, NebulaGame myGame)
            : base(image, position, screen, myGame)
        {
        }
        
    }
}
