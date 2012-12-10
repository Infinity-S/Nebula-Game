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
        public VulkanisLevelManager(Texture2D texture, Vector2 position, Vector2 screen, NebulaGame aGame, Level aLevel,
            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Asis aAsis, Screen aInstructions, Screen aGameOverScreen, List<Screen> aVictoryScreens, TimeTravelManager aTimeTravelManager, SoundEffect backgroundMusic)
            : base(texture, position, screen, aGame, aLevel, aSpritesList, aPlatformsList, aFont, aAsis, aInstructions, aGameOverScreen, aVictoryScreens, aTimeTravelManager, backgroundMusic)
        {
            EndOfLevelPos = xSL * 9 - xSL / 4;
            setFinishingTimes(50, 70, 110); 

        }

        public override void AddItemsToLevel(Sprite sprite, float xSL, float ySL)
        {
            AddPlatform(new Vector2(0, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL / 12, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 2, ySL - myPlatform.myTexture.Height * 2), true);

            AddPlatform(new Vector2((xSL / 12) * 3, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 3, ySL - myPlatform.myTexture.Height * 9), true);
            AddPlatform(new Vector2((xSL / 12) * 3, ySL - myPlatform.myTexture.Height * 12), true);
            AddPlatform(new Vector2((xSL / 12) * 3, ySL - myPlatform.myTexture.Height * 15), true);

            AddPlatform(new Vector2((xSL / 12) * 7, ySL - myPlatform.myTexture.Height * 6), true);

            AddPlatform(new Vector2((xSL / 12) * 6, ySL - myPlatform.myTexture.Height * 16), true);
            AddPlatform(new Vector2((xSL / 12) * 7, ySL - myPlatform.myTexture.Height * 16), true);
            AddPlatform(new Vector2((xSL / 12) * 8, ySL - myPlatform.myTexture.Height * 16), true);

            AddPlatform(new Vector2((xSL / 12) * 13, ySL - myPlatform.myTexture.Height * 14), true);
            AddPlatform(new Vector2((xSL / 12) * 17, ySL - myPlatform.myTexture.Height * 16), true);

            //up path
            AddPlatform(new Vector2((xSL / 12) * 19, ySL - myPlatform.myTexture.Height * 10), true);

            AddPlatform(new Vector2((xSL / 12) * 24, ySL - myPlatform.myTexture.Height * 10), true);
            AddPlatform(new Vector2((xSL / 12) * 24, ySL - myPlatform.myTexture.Height * 14), true);
            AddPlatform(new Vector2((xSL / 12) * 29, ySL - myPlatform.myTexture.Height * 12), true);

            AddPlatform(new Vector2((xSL / 12) * 35, ySL - myPlatform.myTexture.Height * 12), true);
            AddPlatform(new Vector2((xSL / 12) * 36, ySL - myPlatform.myTexture.Height * 12), false);
            AddPlatform(new Vector2((xSL / 12) * 37, ySL - myPlatform.myTexture.Height * 12), false);
            AddPlatform(new Vector2((xSL / 12) * 38, ySL - myPlatform.myTexture.Height * 12), false);
            AddPlatform(new Vector2((xSL / 12) * 39, ySL - myPlatform.myTexture.Height * 12), true);
            AddPlatform(new Vector2((xSL / 12) * 40, ySL - myPlatform.myTexture.Height * 12), true);
            AddPlatform(new Vector2((xSL / 12) * 41, ySL - myPlatform.myTexture.Height * 12), false);
            AddPlatform(new Vector2((xSL / 12) * 42, ySL - myPlatform.myTexture.Height * 12), false);
            AddPlatform(new Vector2((xSL / 12) * 43, ySL - myPlatform.myTexture.Height * 12), true);
            AddPlatform(new Vector2((xSL / 12) * 44, ySL - myPlatform.myTexture.Height * 12), false);
            AddPlatform(new Vector2((xSL / 12) * 45, ySL - myPlatform.myTexture.Height * 12), true);
            AddPlatform(new Vector2((xSL / 12) * 46, ySL - myPlatform.myTexture.Height * 12), true);

            //down path 
            AddPlatform(new Vector2((xSL / 12) * 21, ySL - myPlatform.myTexture.Height * 4), true);
            AddPlatform(new Vector2((xSL / 12) * 22, ySL - myPlatform.myTexture.Height), true);
            AddPlatform(new Vector2((xSL / 12) * 23, ySL - myPlatform.myTexture.Height), true);
            AddPlatform(new Vector2((xSL / 12) * 24, ySL - myPlatform.myTexture.Height), true);
            AddPlatform(new Vector2((xSL / 12) * 25, ySL - myPlatform.myTexture.Height), true);
            AddPlatform(new Vector2((xSL / 12) * 26, ySL - myPlatform.myTexture.Height), true);

            AddPlatform(new Vector2((xSL / 12) * 29, ySL - myPlatform.myTexture.Height), true);

            AddPlatform(new Vector2((xSL / 12) * 32, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 34, ySL - myPlatform.myTexture.Height * 3), true);

            AddPlatform(new Vector2((xSL / 12) * 37, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 42, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 47, ySL - myPlatform.myTexture.Height * 6), true);


            //transition back together
            AddPlatform(new Vector2((xSL / 12) * 50, ySL - myPlatform.myTexture.Height * 10), true);
            AddPlatform(new Vector2((xSL / 12) * 56, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 58, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 60, ySL - myPlatform.myTexture.Height * 7), true);
            AddPlatform(new Vector2((xSL / 12) * 62, ySL - myPlatform.myTexture.Height * 9), true);
            AddPlatform(new Vector2((xSL / 12) * 64, ySL - myPlatform.myTexture.Height * 11), true);
            AddPlatform(new Vector2((xSL / 12) * 66, ySL - myPlatform.myTexture.Height * 13), true);
            AddPlatform(new Vector2((xSL / 12) * 68, ySL - myPlatform.myTexture.Height * 15), true);
            AddPlatform(new Vector2((xSL / 12) * 70, ySL - myPlatform.myTexture.Height * 16), true);
            AddPlatform(new Vector2((xSL / 12) * 71, ySL - myPlatform.myTexture.Height * 16), true);
            AddPlatform(new Vector2((xSL / 12) * 75, ySL - myPlatform.myTexture.Height * 13), true);
            AddPlatform(new Vector2((xSL / 12) * 78, ySL - myPlatform.myTexture.Height * 13), true);
            AddPlatform(new Vector2((xSL / 12) * 80, ySL - myPlatform.myTexture.Height * 13), true);

            AddPlatform(new Vector2((xSL / 12) * 84, ySL - myPlatform.myTexture.Height * 13), true);
            AddPlatform(new Vector2((xSL / 12) * 85, ySL - myPlatform.myTexture.Height * 16), true);
            AddPlatform(new Vector2((xSL / 12) * 86, ySL - myPlatform.myTexture.Height * 16), true);
            AddPlatform(new Vector2((xSL / 12) * 88, ySL - myPlatform.myTexture.Height * 14), true);
            AddPlatform(new Vector2((xSL / 12) * 90, ySL - myPlatform.myTexture.Height * 12), true);
            AddPlatform(new Vector2((xSL / 12) * 92, ySL - myPlatform.myTexture.Height * 10), true);
            AddPlatform(new Vector2((xSL / 12) * 94, ySL - myPlatform.myTexture.Height * 8), true);
            AddPlatform(new Vector2((xSL / 12) * 96, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 98, ySL - myPlatform.myTexture.Height * 4), false);
            AddPlatform(new Vector2((xSL / 12) * 99, ySL - myPlatform.myTexture.Height * 4), false);
            AddPlatform(new Vector2((xSL / 12) * 100, ySL - myPlatform.myTexture.Height * 4), false);
            AddPlatform(new Vector2((xSL / 12) * 101, ySL - myPlatform.myTexture.Height * 4), false);
            AddPlatform(new Vector2((xSL / 12) * 102, ySL - myPlatform.myTexture.Height * 4), true);
            AddPlatform(new Vector2((xSL / 12) * 103, ySL - myPlatform.myTexture.Height * 4), true);
            AddPlatform(new Vector2((xSL / 12) * 104, ySL - myPlatform.myTexture.Height * 4), true);
            AddPlatform(new Vector2((xSL / 12) * 105, ySL - myPlatform.myTexture.Height * 4), true);
            AddPlatform(new Vector2((xSL / 12) * 106, ySL - myPlatform.myTexture.Height * 4), true);



            AddEnemy(aEnemy, new Vector2((xSL / 12) * 7, ySL - myPlatform.myTexture.Height * 6 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 32, ySL - myPlatform.myTexture.Height * 2 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 24, ySL - myPlatform.myTexture.Height * 14 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 47, ySL - myPlatform.myTexture.Height * 6 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 80, ySL - myPlatform.myTexture.Height * 13 - aEnemy.myTexture.Height));
        }

    }
}
