//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;
//using Nebula.SuperClasses;
//using Nebula.BaseClasses;

//namespace Nebula.Subclasses
//{
//    class VulkanisLevelManager : LevelManager
//    {
//        Enemy hEnemy;
//        Laser hLaser;
//        public VulkanisLevelManager(Texture2D texture, Vector2 position, Vector2 screen, Game1 aGame, Level aLevel,
//            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Asis aAsis, Screen aInstructions, Screen aGameOverScreen, Screen aVictoryScreen, SpriteManager aSpriteManager)
//            : base(texture, position, screen, aGame, aLevel, aSpritesList, aPlatformsList, aFont, aAsis, aInstructions, aGameOverScreen, aVictoryScreen, aSpriteManager)
//        {
//            EndOfLevelPos = xSL * 7 + xSL / 2 + xSL / 8;

//        }

//        public override void AddItemsToLevel(Sprite sprite, float xSL, float ySL)
//        {
//            AddPlatform(new Vector2(0, ySL - myPlatform.myTexture.Height * 2), true);
//            AddPlatform(new Vector2(xSL / 12, ySL - myPlatform.myTexture.Height * 2), true);
//            AddPlatform(new Vector2((xSL / 12) * 2, ySL - myPlatform.myTexture.Height * 2), true);

//            //AddPlatform(new Vector2((xSL / 12) * 3, ySL - myPlatform.myTexture.Height * 6), true);
//            AddMovingPlatform(new Vector2((xSL / 12) * 3, ySL - myPlatform.myTexture.Height * 6), true, false, true,
//               ySL - myPlatform.myTexture.Height * 16, 3);
//            AddPlatform(new Vector2((xSL / 12) * 7, ySL - myPlatform.myTexture.Height * 6), true);

//            AddPlatform(new Vector2((xSL / 12) * 6, ySL - myPlatform.myTexture.Height * 16), true);
//            AddPlatform(new Vector2((xSL / 12) * 7, ySL - myPlatform.myTexture.Height * 16), true);
//            AddPlatform(new Vector2((xSL / 12) * 8, ySL - myPlatform.myTexture.Height * 16), true);

//            AddPlatform(new Vector2((xSL / 12) * 13, ySL - myPlatform.myTexture.Height * 14), true);
//            AddPlatform(new Vector2((xSL / 12) * 17, ySL - myPlatform.myTexture.Height * 17), true);

//            //up path
//            AddPlatform(new Vector2((xSL / 12) * 19, ySL - myPlatform.myTexture.Height * 10), true);
//            AddPlatform(new Vector2((xSL / 12) * 25, ySL - myPlatform.myTexture.Height * 9), true);
//            AddPlatform(new Vector2((xSL / 12) * 25, ySL - myPlatform.myTexture.Height * 12), true);
//            AddPlatform(new Vector2((xSL / 12) * 25, ySL - myPlatform.myTexture.Height * 16), true);
//            AddPlatform(new Vector2((xSL / 12) * 25, ySL - myPlatform.myTexture.Height * 18), true);

//            AddPlatform(new Vector2((xSL / 12) * 31, ySL - myPlatform.myTexture.Height * 12), true);
//            AddPlatform(new Vector2((xSL / 12) * 32, ySL - myPlatform.myTexture.Height * 12), true);
//            AddPlatform(new Vector2((xSL / 12) * 33, ySL - myPlatform.myTexture.Height * 12), true);
//            AddPlatform(new Vector2((xSL / 12) * 34, ySL - myPlatform.myTexture.Height * 12), true);

//            AddPlatform(new Vector2((xSL / 12) * 49, ySL - myPlatform.myTexture.Height * 12), true);


//            //down path 
//            AddPlatform(new Vector2((xSL / 12) * 21, ySL - myPlatform.myTexture.Height * 4), true);
//            AddPlatform(new Vector2((xSL / 12) * 22, ySL - myPlatform.myTexture.Height), true);
//            AddPlatform(new Vector2((xSL / 12) * 23, ySL - myPlatform.myTexture.Height), true);
//            AddPlatform(new Vector2((xSL / 12) * 24, ySL - myPlatform.myTexture.Height), true);
//            AddPlatform(new Vector2((xSL / 12) * 25, ySL - myPlatform.myTexture.Height), true);
//            AddPlatform(new Vector2((xSL / 12) * 26, ySL - myPlatform.myTexture.Height), true);

//            AddPlatform(new Vector2((xSL / 12) * 29, ySL - myPlatform.myTexture.Height), true);
//            AddPlatform(new Vector2((xSL / 12) * 30, ySL - myPlatform.myTexture.Height * 2), true);
//            AddPlatform(new Vector2((xSL / 12) * 31, ySL - myPlatform.myTexture.Height * 3), true);
//            AddPlatform(new Vector2((xSL / 12) * 36, ySL - myPlatform.myTexture.Height * 5), true);
//            AddPlatform(new Vector2((xSL / 12) * 41, ySL - myPlatform.myTexture.Height * 5), true);
//            AddPlatform(new Vector2((xSL / 12) * 47, ySL - myPlatform.myTexture.Height * 6), true);
//            //moving platform here to reach up to the up path 
//            AddMovingPlatform(new Vector2((xSL / 12) * 49, ySL - myPlatform.myTexture.Height * 6), true, false, true, ySL - myPlatform.myTexture.Height * 12, 3);

//            //AddPlatform(new Vector2((xSL / 12) * 3, ySL - myPlatform.myTexture.Height * 2), true);
//            //AddPlatform(new Vector2((xSL / 12) * 4, ySL - myPlatform.myTexture.Height * 2), true);
//            //AddPlatform(new Vector2((xSL / 12) * 5, ySL - myPlatform.myTexture.Height * 2), true);
//            //AddPlatform(new Vector2((xSL / 12) * 6, ySL - myPlatform.myTexture.Height * 2), true);
//            //AddPlatform(new Vector2((xSL / 12) * 7, ySL - myPlatform.myTexture.Height * 2), true);

//            //AddMovingPlatform(new Vector2((xSL / 12) * 8, ySL - myPlatform.myTexture.Height * 2), true, true, false, (xSL / 12) * 12, 5); 
//            //AddMovingPlatform(new Vector2((xSL / 12) * 8, ySL - myPlatform.myTexture.Height * 2), true, false, true, ySL - myPlatform.myTexture.Height * 8, 5);

//            //AddEnemy(hEnemy, new Vector2((xSL / 12) * 5, ySL - myPlatform.myTexture.Height * 2 - aEnemy.myTexture.Height)); 
//            AddEnemy(aEnemy, new Vector2((xSL / 12) * 7, ySL - myPlatform.myTexture.Height * 6 - aEnemy.myTexture.Height));
//            AddEnemy(aEnemy, new Vector2((xSL / 12) * 29, ySL - myPlatform.myTexture.Height - aEnemy.myTexture.Height));
//            AddEnemy(aEnemy, new Vector2((xSL / 12) * 31, ySL - myPlatform.myTexture.Height * 12 - aEnemy.myTexture.Height));
//        }

//        public override void setUpSprites(Platform aPlatform, Asis aAsis, AsisLaser anLaser, Enemy anEnemy, EnemyLaser anELaser)
//        {
//            base.setUpSprites(aPlatform, aAsis, anLaser, anEnemy, anELaser);
//            hEnemy = (Enemy)spritesList[4];
//            hLaser = (EnemyLaser)spritesList[5];
//        }
//    }
//}
