using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Nebula.SuperClasses; 

namespace Nebula
{
    class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 center;
        protected Hero myHero; 

        public Camera(Viewport newView, Hero anHero)
        {
            view = newView;
            myHero = anHero;
        }

        public void Update(GameTime gameTime)
        {
            // (Asis.myTexture.Width / 2) - (Asis.myScreenSize.X /2)
            center = new Vector2(myHero.myPosition.X - myHero.myScreenSize.X/6, 0);
            // 1, 1 = 100%, 100%
            transform = Matrix.CreateScale(new Vector3(1,1,0)) * Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
