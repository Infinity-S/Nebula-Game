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
    class BackgroundSprite : Sprite
    {
        //Size object will be used to store the height and width of the scaled sprite
        protected internal Rectangle size; 
        //Scale object will be used to increase or decrease the size of the sprite from the original image.
        protected internal float backgroundScale = 1.0f;

        public BackgroundSprite (Texture2D myImage, Vector2 position, float scale)
            : base(myImage, position)
        {
            size = new Rectangle(0, 0, (int)(myTexture.Width * backgroundScale), (int)(myTexture.Height * backgroundScale));
            backgroundScale = scale; 
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(myTexture, myPosition, new Rectangle(0, 0, myTexture.Width, myTexture.Height),
                Color.White, myAngle, myOrigin, backgroundScale, SpriteEffects.None, 0);
        }
        


    }
}
