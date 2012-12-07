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
        bool canStandOn;
        bool movingHorz;
        bool movingVert;
        bool stationary;
        public Platform(Texture2D image, Vector2 position, Vector2 screen)
            : base(image, position)
        {
            myPosition = position;
            myScreenSize = screen;
            myState = new ExistState(this);

            canStandOn = false;
            movingHorz = false;
            movingVert = false;
            stationary = true; 
        }

        public Platform Clone()
        {
            return new Platform(this.myTexture, this.myPosition, this.myScreenSize);
        }

        public bool getCanStandOn()
        {
            return canStandOn;
        }

        public void setCanStandOn(bool canStand)
        {
            canStandOn = canStand;
        }

        public bool getMovingHorz()
        {
            return movingHorz;
        }

        public void setmovingHorz(bool movingHorizonal)
        {
            movingHorz = movingHorizonal;
        }

        public bool getMovingVert()
        {

            return movingVert;
        }

        public void setmovingVert(bool movingVertical)
        {
            movingVert = movingVertical;
        }

        public bool getStationary()
        {
            return stationary;
        }

        public void setStationary(bool isStationary)
        {
            stationary = isStationary;
        }

        //position of asis
        //posMovTo - either x or y position for platform to move to and then stay there
        //speed - speed to move at 
        public void movePlatform(Vector2 AsisPos, float PositionMoveTo, float speed)
        {
            //start moving when asis is 1 platform lengths away 
            if (AsisPos.X >= myPosition.X - this.myTexture.Width)
            {
                setSpeed(speed);
            }
            move(PositionMoveTo); 
        }

        private void setSpeed(float speed)
        {
            if (movingHorz)
            {
                myVelocity = new Vector2(speed, 0);
            }
            else
            {
                myVelocity = new Vector2(0, speed);
            }
        }

        private void move(float position)
        {
            if (movingHorz)
            {
                if (myPosition.X >= position)
                {
                    setSpeed(0f);
                }
            }
            else
            {
               if (myPosition.Y >= position) 
               {
                    setSpeed(0f);
               }

            }
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
