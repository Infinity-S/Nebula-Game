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
        bool canStandOn = true;
        bool movingHorz = false;
        bool movingVert = false;
        bool stationary = true;
        float positionMoveTo = 0f;
        float speed = 0f;
        Texture2D badPlatform; 
        public Platform(Texture2D image, Texture2D image2, Vector2 position, Vector2 screen)
            : base(image, position)
        {
            myPosition = position;
            myScreenSize = screen;
            myState = new ExistState(this);
            badPlatform = image2;
        }

        public Platform Clone()
        {
            return new Platform(this.myTexture, this.badPlatform, this.myPosition, this.myScreenSize);
        }

        //public bool getCanStandOn()
        //{
        //    return canStandOn;
        //}

        public void setBadPlatformImage()
        {
            if (!canStandOn)
            {
                myTexture = badPlatform;
            }
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

        public float getPositionMoveTo()
        {
            return positionMoveTo;
        }

        public void setPositionMoveTo(float position)
        {
            positionMoveTo = position;
        }

        public float getSpeed()
        {
            return speed;
        }

        public void setSpeed(float aSpeed)
        {
            speed = aSpeed;
        }

        //     public void movePlatformVert (Platform aPlatform, Vector2 AsisPos)
        //{
        //    //start moving when asis is 1 platform lengths away 
        //    if (AsisPos.X >= aPlatform.myPosition.X - aPlatform.myTexture.Width)
        //    {
        //        aPlatform.setMovingVelocity(aPlatform.getSpeed());
        //        aPlatform.move(aPlatform.getPositionMoveTo()); 
        //    } 
        //    //aPlatform.move(aPlatform.getPositionMoveTo());
        //    if (AsisPos.X <= aPlatform.myPosition.X - aPlatform.myTexture.Width)
        //    {
        //        aPlatform.setMovingVelocity(0f);
        //    }

        //}

        //public void setMovingVelocity(float speed)
        //{
        //    if (movingHorz)
        //    {
        //        myVelocity = new Vector2(speed, 0);
        //    }
        //    else
        //    {
        //        myVelocity = new Vector2(0, -speed);
        //    }
        //}

        //public void move(float position)
        //{
        //    if (movingHorz)
        //    {
        //        if (myPosition.X >= position)
        //        {
        //            setMovingVelocity(0f);
        //        }
        //    }
        //    else
        //    {
        //       if (myPosition.Y <= position) 
        //       {
        //            setMovingVelocity(0f);
        //       }

        //    }
        // }



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
