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
using Microsoft.Xna.Framework.Media;
using Nebula.SuperClasses;
using Nebula.BaseClasses; 

namespace Nebula.Subclasses
{
    class CeresLevelManager : LevelManager
    {

        public CeresLevelManager(Texture2D texture, Vector2 position, Vector2 screen, Game1 aGame, Level aLevel, 
            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Asis aAsis, GameOver aGameOverScreen, SpriteManager aSpriteManager)
            : base (texture, position, screen, aGame, aLevel, aSpritesList, aPlatformsList, aFont, aAsis, aGameOverScreen, aSpriteManager)
        {

        }

        public override void AddItemsToLevel(Nebula.Sprite sprite, float xSL, float ySL)
        {
            //ADDING PLATFORMS 
            AddPlatform(new Vector2(xSL / 12, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL / 2 + xSL / 4 + myPlatform.myTexture.Width / 8, ySL / 2 + ySL / 4), true);
            AddPlatform(new Vector2(xSL + xSL / 4 - sprite.myTexture.Width, ySL / 2 + ySL / 4), true);
            AddPlatform(new Vector2(xSL + xSL / 2, ySL / 2 + ySL / 16), true);
            AddPlatform(new Vector2(xSL + xSL / 2 + myPlatform.myTexture.Width, ySL / 2 + ySL / 16), false);
            AddPlatform(new Vector2(xSL + xSL / 2 + myPlatform.myTexture.Width * 2, ySL / 2 + ySL / 16), false);
            AddPlatform(new Vector2(xSL + xSL / 2 + myPlatform.myTexture.Width * 3, ySL / 2 + ySL / 16), true);
            AddPlatform(new Vector2(xSL * 2 + myPlatform.myTexture.Width * 3, ySL / 2 + ySL / 4 + myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL * 2 + myPlatform.myTexture.Width * 4, ySL / 2 + ySL / 4 + myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL * 2 + myPlatform.myTexture.Width * 5, ySL / 2 + ySL / 4 + myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL * 2 + myPlatform.myTexture.Width * 6, ySL / 2 + ySL / 4 + myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL * 2 + myPlatform.myTexture.Width * 7, ySL / 2 + ySL / 4 + myPlatform.myTexture.Height * 2), true);

            AddPlatform(new Vector2(xSL * 3 + xSL / 16, ySL / 2 + ySL / 4), true);
            AddPlatform(new Vector2(xSL * 3 - xSL / 16, ySL / 2 + ySL / 32), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width / 2, ySL / 2), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width, ySL / 2 - myPlatform.myTexture.Height), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 2, ySL / 2 - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 3, ySL / 2 - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 4, ySL / 2 - myPlatform.myTexture.Height * 4), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 5, ySL / 2 - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 6, ySL / 2 - myPlatform.myTexture.Height * 5), true);

            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 11, ySL - myPlatform.myTexture.Height * 2), true);

            //ADDING ENEMIES 
            AddEnemy(new Vector2(400, 400), 'd');
            AddEnemy(new Vector2(xSL * 2 + myPlatform.myTexture.Width * 7,
                    ySL / 2 + ySL / 4 - aEnemy.myTexture.Height / 4), 'd'); 
        }
  
    }
}
