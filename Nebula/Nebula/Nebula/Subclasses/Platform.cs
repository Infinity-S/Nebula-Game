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
using System.Threading;

namespace Nebula.Subclasses
{
    public class Platform : Sprite
    {
        public Platform(Texture2D image, Vector2 position, Vector2 screen)
            : base(image, position)
        {
            myPosition = position;
            myScreenSize = screen;
            myState = new ExistState(this);

        }

        public Platform Clone()
        {
            return new Platform(this.myTexture, this.myPosition, this.myScreenSize);
        }

        class ExistState : State
        {
            public ExistState(Sprite sprite)
            {
            }
            public void Update(double elapsedTime, Sprite sprite)
            {
            }
            public void Draw(Sprite sprite, SpriteBatch batch)
            {
                batch.Draw(sprite.myTexture, sprite.myPosition,
                null, Color.White,
                sprite.myAngle, sprite.myOrigin,
                sprite.myScale, SpriteEffects.None, 0f);
            }

        }
    }
}
