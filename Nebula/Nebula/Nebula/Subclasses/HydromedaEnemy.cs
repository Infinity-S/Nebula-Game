﻿using System;
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

namespace Nebula.Subclasses
{
    class HydromedaEnemy : Sprite
    {

        public HydromedaEnemy(Texture2D image, Vector2 position, Vector2 screen)
            : base(image, position)
        {
            myTexture = image;
            myPosition = position;
            myScreenSize = screen;
        }


    }
}
