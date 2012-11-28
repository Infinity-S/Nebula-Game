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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Collections;

namespace Nebula
{
    class BackgroundLayer
    {
        public Texture2D[] textures { get; private set; }
        public float scrollRate { get; private set; }

        public BackgroundLayer(Texture2D[] backgrounds, float rate)
        {
            //assuming only 2 backgrounds 
            textures = backgrounds;
            scrollRate = rate; 
        }

        public void Draw(SpriteBatch batch, float cameraPosition)
        {
            //Assume each texture is the same width 
            int segmentWidth = textures[0].Width; 

            //Calculate which textures to draw, and how to offset them 
            float x = cameraPosition * scrollRate; 
            int leftSegment = (int)Math.Floor(x/segmentWidth);
            int rightSegment = leftSegment + 1;
            x = (x / segmentWidth - leftSegment) * -segmentWidth;

            batch.Draw(textures[leftSegment % textures.Length], new Vector2(x, 0.0f), Color.White);
            batch.Draw(textures[rightSegment % textures.Length], new Vector2(x + segmentWidth, 0.0f), Color.White); 
        }
    }
}
