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

namespace Nebula
{
    class Enemy : Sprite
    {
        bool alive = true;
        public Enemy(Texture2D image, Vector2 position, Vector2 screen)
            : base(image, position)
        {
            myScreenSize = screen;
            myState = new ExistState(this);
            // Start in lower right hand of screen

            myPosition.X = myScreenSize.X + myScreenSize.X / 2;
            myPosition.Y = myScreenSize.Y - myTexture.Height;
        }

        public void Resurrect()
        {
            myState = new ExistState(this);
            alive = true;
        }

        public void Die()
        {
            myState = new DeadState(this);
            alive = false;
        }
        public bool getAlive()
        {
            return alive;
        }

        class ExistState : State
        {
            public ExistState(Sprite sprite)
            {
                //place the enemy on a certain position
                //have them do something 
                //have them walk towards Asis 
            }
            public void Update(double elapsedTime, Sprite sprite)
            {
                //Enemy aEnemy = (Enemy)sprite;

                ////until a laser gets my position 
                ////then I get the dead state 
                ////we need to decide what the part of the enemy you have to hit in order to kill them 
                //Vector2 laserPos = aEnemy.aLaserOnScreen.myPosition;

                //if (laserPos.X >= sprite.myPosition.X && laserPos.X <= sprite.myPosition.X+sprite.myTexture.Width)
                //{
                //    aEnemy.aLaserOnScreen.myPosition = new Vector2(0 - sprite.myScreenSize.X * 2, 0 - sprite.myScreenSize.Y * 2); 
                //    sprite.myState = new DeadState(sprite);
                //}

            }
            public void Draw(Sprite sprite, SpriteBatch batch)
            {
                batch.Draw(sprite.myTexture, sprite.myPosition,
                    null, Color.White, sprite.myAngle,
                    sprite.myOrigin, sprite.myScale, SpriteEffects.None, 0f);
            }
        }

        class DeadState : State
        {
            // Place enemy of screen
            public DeadState(Sprite sprite)
            {
                sprite.myPosition = new Vector2(sprite.myScreenSize.X * -2, sprite.myScreenSize.Y * -2); 
            }
            public void Update(double elapsedTime, Sprite sprite)
            {
            }
            public void Draw(Sprite sprite, SpriteBatch batch)
            {
                batch.Draw(sprite.myTexture, sprite.myPosition,
                    null, Color.White, sprite.myAngle,
                    sprite.myOrigin, sprite.myScale, SpriteEffects.None, 0f);
            }
        }
    }
}
