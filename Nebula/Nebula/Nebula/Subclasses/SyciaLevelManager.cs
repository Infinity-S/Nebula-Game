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
    class SyciaLevelManager : LevelManager
    {
        public SyciaLevelManager(Texture2D texture, Vector2 position, Vector2 screen, NebulaGame aGame, Level aLevel,
            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Asis aAsis, Screen aInstructions, Screen aGameOverScreen, List<Screen> aVictoryScreens, Screen aCutScene, TimeTravelManager aTimeTravelManager, SoundEffect backgroundMusic)
            : base(texture, position, screen, aGame, aLevel, aSpritesList, aPlatformsList, aFont, aAsis, aInstructions, aGameOverScreen, aVictoryScreens, aCutScene, aTimeTravelManager, backgroundMusic)
        {
            EndOfLevelPos = (xSL / 12) * 117;
            setFinishingTimes(50, 75, 100);

        }

        public override void AddItemsToLevel(Nebula.Sprite sprite, float xSL, float ySL)
        {
            //Platforms
            AddPlatform(new Vector2(xSL / 12, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 2, ySL - myPlatform.myTexture.Height * 2), true);

            AddPlatform(new Vector2((xSL / 12) * 5, ySL - myPlatform.myTexture.Height * 6), true);
            
            AddPlatform(new Vector2((xSL / 12) * 9, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 12, ySL - myPlatform.myTexture.Height * 3), false);

            AddPlatform(new Vector2((xSL / 12) * 10, ySL - myPlatform.myTexture.Height * 9), true);
            AddPlatform(new Vector2((xSL / 12) * 11, ySL - myPlatform.myTexture.Height * 9), true);

            AddPlatform(new Vector2((xSL / 12) * 12, ySL - myPlatform.myTexture.Height * 12), true);
            AddPlatform(new Vector2((xSL / 12) * 12, ySL - myPlatform.myTexture.Height * 15), true);
            AddPlatform(new Vector2((xSL / 12) * 12, ySL - myPlatform.myTexture.Height * 17), true);

            AddPlatform(new Vector2((xSL / 12) * 15, ySL - myPlatform.myTexture.Height * 12), true);
            AddPlatform(new Vector2((xSL / 12) * 16, ySL - myPlatform.myTexture.Height * 12), false);
            AddPlatform(new Vector2((xSL / 12) * 17, ySL - myPlatform.myTexture.Height * 12), false);
            AddPlatform(new Vector2((xSL / 12) * 18, ySL - myPlatform.myTexture.Height * 12), false);

            AddPlatform(new Vector2((xSL / 12) * 22, ySL - myPlatform.myTexture.Height * 9), true);
            AddPlatform(new Vector2((xSL / 12) * 24, ySL - myPlatform.myTexture.Height * 9), true);
            AddPlatform(new Vector2((xSL / 12) * 25, ySL - myPlatform.myTexture.Height * 9), true);

            AddPlatform(new Vector2((xSL / 12) * 30, ySL - myPlatform.myTexture.Height * 13), true);

            AddPlatform(new Vector2((xSL / 12) * 31, ySL - myPlatform.myTexture.Height * 9), true);

            AddPlatform(new Vector2((xSL / 12) * 28, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 29, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 32, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 33, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 36, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 37, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 40, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 41, ySL - myPlatform.myTexture.Height * 5), false);
            AddPlatform(new Vector2((xSL / 12) * 42, ySL - myPlatform.myTexture.Height * 5), false);

            AddPlatform(new Vector2((xSL / 12) * 34, ySL - myPlatform.myTexture.Height * 12), true);
            AddPlatform(new Vector2((xSL / 12) * 39, ySL - myPlatform.myTexture.Height * 15), true);

            AddPlatform(new Vector2((xSL / 12) * 42, ySL - myPlatform.myTexture.Height * 13), true);
            AddPlatform(new Vector2((xSL / 12) * 47, ySL - myPlatform.myTexture.Height * 14), true);

            AddPlatform(new Vector2((xSL / 12) * 50, ySL - myPlatform.myTexture.Height * 12), false);

            AddPlatform(new Vector2((xSL / 12) * 52, ySL - myPlatform.myTexture.Height * 10), true);
            AddPlatform(new Vector2((xSL / 12) * 54, ySL - myPlatform.myTexture.Height * 10), true);
            AddPlatform(new Vector2((xSL / 12) * 56, ySL - myPlatform.myTexture.Height * 10), true);

            AddPlatform(new Vector2((xSL / 12) * 60, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 63, ySL - myPlatform.myTexture.Height * 5), false);
            AddPlatform(new Vector2((xSL / 12) * 64, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 65, ySL - myPlatform.myTexture.Height * 5), true);

            AddPlatform(new Vector2((xSL / 12) * 69, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2((xSL / 12) * 71, ySL - myPlatform.myTexture.Height * 7), false);
            AddPlatform(new Vector2((xSL / 12) * 73, ySL - myPlatform.myTexture.Height * 9), true);
            AddPlatform(new Vector2((xSL / 12) * 75, ySL - myPlatform.myTexture.Height * 11), false);
            AddPlatform(new Vector2((xSL / 12) * 77, ySL - myPlatform.myTexture.Height * 13), true);

            AddPlatform(new Vector2((xSL / 12) * 80, ySL - myPlatform.myTexture.Height * 11), true);

            AddPlatform(new Vector2((xSL / 12) * 84, ySL - myPlatform.myTexture.Height * 3), false);
            AddPlatform(new Vector2((xSL / 12) * 84, ySL - myPlatform.myTexture.Height * 7), false);
            AddPlatform(new Vector2((xSL / 12) * 84, ySL - myPlatform.myTexture.Height * 11), false);
            AddPlatform(new Vector2((xSL / 12) * 84, ySL - myPlatform.myTexture.Height * 15), false);

            AddPlatform(new Vector2((xSL / 12) * 87, ySL - myPlatform.myTexture.Height * 5), true);

            //lower
            AddPlatform(new Vector2((xSL / 12) * 89, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 92, ySL - myPlatform.myTexture.Height * 1), true);
            AddPlatform(new Vector2((xSL / 12) * 94, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 95, ySL - myPlatform.myTexture.Height * 1), false);
            AddPlatform(new Vector2((xSL / 12) * 96, ySL - myPlatform.myTexture.Height * 1), false);
            AddPlatform(new Vector2((xSL / 12) * 97, ySL - myPlatform.myTexture.Height * 1), true);
            AddPlatform(new Vector2((xSL / 12) * 100, ySL - myPlatform.myTexture.Height * 2), false);
            AddPlatform(new Vector2((xSL / 12) * 101, ySL - myPlatform.myTexture.Height * 2), false);
            AddPlatform(new Vector2((xSL / 12) * 102, ySL - myPlatform.myTexture.Height * 2), false);

            //upper
            AddPlatform(new Vector2((xSL / 12) * 90, ySL - myPlatform.myTexture.Height * 8), true);
            AddPlatform(new Vector2((xSL / 12) * 92, ySL - myPlatform.myTexture.Height * 9), false);
            AddPlatform(new Vector2((xSL / 12) * 93, ySL - myPlatform.myTexture.Height * 10), false);
            AddPlatform(new Vector2((xSL / 12) * 94, ySL - myPlatform.myTexture.Height * 10), true);
            AddPlatform(new Vector2((xSL / 12) * 95, ySL - myPlatform.myTexture.Height * 10), false);
            AddPlatform(new Vector2((xSL / 12) * 96, ySL - myPlatform.myTexture.Height * 10), true);
            AddPlatform(new Vector2((xSL / 12) * 97, ySL - myPlatform.myTexture.Height * 10), false);
            AddPlatform(new Vector2((xSL / 12) * 98, ySL - myPlatform.myTexture.Height * 10), false);
            AddPlatform(new Vector2((xSL / 12) * 99, ySL - myPlatform.myTexture.Height * 10), true);
            AddPlatform(new Vector2((xSL / 12) * 100, ySL - myPlatform.myTexture.Height * 10), false);
            AddPlatform(new Vector2((xSL / 12) * 101, ySL - myPlatform.myTexture.Height * 10), false);
            AddPlatform(new Vector2((xSL / 12) * 102, ySL - myPlatform.myTexture.Height * 10), true);

            AddPlatform(new Vector2((xSL / 12) * 106, ySL - myPlatform.myTexture.Height * 9), true);
            AddPlatform(new Vector2((xSL / 12) * 109, ySL - myPlatform.myTexture.Height * 7), true);
            AddPlatform(new Vector2((xSL / 12) * 111, ySL - myPlatform.myTexture.Height * 11), true);
            AddPlatform(new Vector2((xSL / 12) * 113, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 114, ySL - myPlatform.myTexture.Height * 15), true);
            AddPlatform(new Vector2((xSL / 12) * 115, ySL - myPlatform.myTexture.Height * 7), true);
            AddPlatform(new Vector2((xSL / 12) * 117, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 118, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 119, ySL - myPlatform.myTexture.Height * 3), true);


            //Enemies
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 5, ySL - myPlatform.myTexture.Height * 6 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 9, ySL - myPlatform.myTexture.Height * 3 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 11, ySL - myPlatform.myTexture.Height * 9 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 12, ySL - myPlatform.myTexture.Height * 3 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 25, ySL - myPlatform.myTexture.Height * 9 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 36, ySL - myPlatform.myTexture.Height * 5 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 39, ySL - myPlatform.myTexture.Height * 15 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 40, ySL - myPlatform.myTexture.Height * 5 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 54, ySL - myPlatform.myTexture.Height * 10 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 64, ySL - myPlatform.myTexture.Height * 5 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 77, ySL - myPlatform.myTexture.Height * 13 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 80, ySL - myPlatform.myTexture.Height * 11 - aEnemy.myTexture.Height));

            AddEnemy(aEnemy, new Vector2((xSL / 12) * 84, ySL - myPlatform.myTexture.Height * 7 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 84, ySL - myPlatform.myTexture.Height * 11 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 84, ySL - myPlatform.myTexture.Height * 15 - aEnemy.myTexture.Height));

            AddEnemy(aEnemy, new Vector2((xSL / 12) * 94, ySL - myPlatform.myTexture.Height * 3 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 96, ySL - myPlatform.myTexture.Height * 10 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 97, ySL - myPlatform.myTexture.Height * 1 - aEnemy.myTexture.Height));
            
            //final wave
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 106, ySL - myPlatform.myTexture.Height * 9 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 109, ySL - myPlatform.myTexture.Height * 7 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 111, ySL - myPlatform.myTexture.Height * 11 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 113, ySL - myPlatform.myTexture.Height * 6 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 114, ySL - myPlatform.myTexture.Height * 15 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 115, ySL - myPlatform.myTexture.Height * 7 - aEnemy.myTexture.Height));
        }
    }
}