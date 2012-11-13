/*
 * Authors: Shannon Duvall & Geoffrey Pisarkiewicz
 * 
 * This is the base class for all Sprites. All variables and methods 
 * that are common to sprites go here.  In particular, Sprites should 
 * at least be able to update and draw.
 */

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
using System.Collections;

namespace Nebula
{
    class Sprite
    {
        // These are the basic state variables for sprites.
        // They are "protected" so they are accessible by the subclasses
        // They are "internal" so they are accessible by the internal classes 
        // - namely the states.

        protected internal Texture2D myTexture;
        protected internal Vector2 myPosition;
        protected internal Vector2 myVelocity = new Vector2(0, 0);
        protected internal float myAngle = 0f;
        protected internal float myAngularVelocity = 0f;
        protected internal Vector2 myScreenSize = new Vector2(0, 0);
        protected internal Vector2 myOrigin = new Vector2(0, 0);
        protected internal Vector2 myScale = new Vector2(1, 1);
        protected internal Vector2 myScaleVelocity = new Vector2(0, 0);
        protected internal State myState;
        protected internal bool gravity = false;
        protected internal bool hasJumped = true;
        protected internal double time = 0;
        protected internal int counter = 0;



        // The base constructor.
        public Sprite(Texture2D texture, Vector2 position)
        {
            myTexture = texture;
            myPosition = position;
        }

        public bool getHasJumped()
        {
            return hasJumped;
        }
        public void setHasJumped(bool b)
        {
            hasJumped = b;
        }

        // getter method for the counter
        public virtual int getCounter()
        {
            return counter;
        }

        //setter method for the counter
        public virtual void setCounter(int aCounter)
        {
            counter = aCounter;
        }


        // This method is virtual because it can be overridden by the subclasses.  
        // In this method I will do the basic updating of my variables based on their
        // velocities.
        public virtual void Update(double elapsedTime)
        {

            time += elapsedTime;
            myPosition += myVelocity;
            myAngle += myAngularVelocity;
            myScale += myScaleVelocity;
            // Let the state do its updating as well.
            if (myState != null)
            {
                myState.Update(elapsedTime, this);
            }
        }

        public virtual void Draw(SpriteBatch batch)
        {

            batch.Draw(myTexture, myPosition,
                null, Color.White,
                myAngle, myOrigin,
                myScale, SpriteEffects.None, 0f);

            if (myState != null)
            {
                // How the sprite draws depends on the state the sprite is in.
                myState.Draw(this, batch);
            }
        }

        // This is a basic test for whether or not a sprite is off screen.
        public bool OutOfBounds()
        {
            return (myPosition.X + myTexture.Width > myScreenSize.X) ||
                   (myPosition.X < 0) ||
                   (myPosition.Y + myTexture.Height > myScreenSize.Y) ||
                   (myPosition.Y < 0);
        }
    }
}
