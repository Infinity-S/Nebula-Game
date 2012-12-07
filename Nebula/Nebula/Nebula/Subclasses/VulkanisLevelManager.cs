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
    class VulkanisLevelManager : LevelManager
    {
        Enemy hEnemy;
        Laser hLaser; 
        public VulkanisLevelManager(Texture2D texture, Vector2 position, Vector2 screen, Game1 aGame, Level aLevel,
            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Asis aAsis, Screen aInstructions, Screen aGameOverScreen, Screen aVictoryScreen, SpriteManager aSpriteManager)
            : base(texture, position, screen, aGame, aLevel, aSpritesList, aPlatformsList, aFont, aAsis, aInstructions, aGameOverScreen, aVictoryScreen, aSpriteManager)
        {
            EndOfLevelPos = xSL * 7 + xSL / 2 + xSL / 8;

        }

        public override void AddItemsToLevel(Sprite sprite, float xSL, float ySL)
        {
            AddPlatform(new Vector2(0, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL / 12, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 2, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 3, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 4, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 5, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 6, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 7, ySL - myPlatform.myTexture.Height * 2), true);

            AddMovingPlatform(new Vector2((xSL / 12) * 8, ySL - myPlatform.myTexture.Height * 2), true, true, false, (xSL / 12) * 12, 5); 
            AddMovingPlatform(new Vector2((xSL / 12) * 8, ySL - myPlatform.myTexture.Height * 2), true, false, true, ySL - myPlatform.myTexture.Height * 8, 5);

            //AddEnemy(hEnemy, new Vector2((xSL / 12) * 5, ySL - myPlatform.myTexture.Height * 2 - aEnemy.myTexture.Height)); 
        }

        public override void setUpSprites(Platform aPlatform, Asis aAsis, AsisLaser anLaser, Enemy anEnemy, EnemyLaser anELaser)
        {
            base.setUpSprites(aPlatform, aAsis, anLaser, anEnemy, anELaser);
            hEnemy = (Enemy)spritesList[4];
            hLaser = (EnemyLaser)spritesList[5];
        }
    }
}
