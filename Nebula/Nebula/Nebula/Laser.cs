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

namespace Nebula
{
    class Laser : Sprite
    {
        public Laser(Texture2D texture, Vector2 position, Vector2 screen) 
            : base(texture, position)   
        {
            myScreenSize = screen;
            myPosition.X = myScreenSize.X * -2;
            myPosition.Y = myScreenSize.Y * -2;
        }
    }
}
