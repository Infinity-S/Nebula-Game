using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Nebula
{
    class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 center;
        protected Asis myAsis; 

        public Camera(Viewport newView, Asis anAsis)
        {
            view = newView;
            myAsis = anAsis;
        }

        public void Update(GameTime gameTime)
        {
            // (Asis.myTexture.Width / 2) - (Asis.myScreenSize.X /2)
            center = new Vector2(myAsis.myPosition.X - myAsis.myScreenSize.X/6, 0);
            // 1, 1 = 100%, 100%
            transform = Matrix.CreateScale(new Vector3(1,1,0)) * Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
