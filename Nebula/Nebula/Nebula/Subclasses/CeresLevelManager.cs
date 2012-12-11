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

        public CeresLevelManager(Texture2D texture, Vector2 position, Vector2 screen, NebulaGame aGame, Level aLevel,
            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Asis aAsis, Screen aInstructions, Screen aGameOverScreen, List<Screen> aVictoryScreens, TimeTravelManager aTimeTravelManager, SoundEffect backgroundMusic)
            : base(texture, position, screen, aGame, aLevel, aSpritesList, aPlatformsList, aFont, aAsis, aInstructions, aGameOverScreen, aVictoryScreens, aTimeTravelManager, backgroundMusic)
        {
            EndOfLevelPos = xSL * 7 + xSL / 2 + xSL / 8;
            setFinishingTimes(50, 70, 110);
            LevelStoryText.Add("Whe... Where am I?", new Vector2(xSL / 12, ySL / 2 + ySL/8));
            LevelStoryText.Add("...How did I get here?", new Vector2(xSL / 2, ySL / 2 + ySL / 8));
            LevelStoryText.Add("What planet is this?", new Vector2(xSL + xSL / 2 + xSL / 24, ySL / 4));
            LevelStoryText.Add("Why are these people so hostile? \n This can't be my planet...", new Vector2(xSL * 4 + xSL/2, ySL / 2 + ySL/8));
             }

        public override void AddItemsToLevel(Nebula.Sprite sprite, float xSL, float ySL)
        {
            //ADDING PLATFORMS 
            AddPlatform(new Vector2(xSL / 12, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12)*2, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL / 2, ySL - ySL / 8), true); 
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
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 12, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 12, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 13, ySL - myPlatform.myTexture.Height * 10), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 14, ySL - myPlatform.myTexture.Height * 14), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 17, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 18, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 19, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 22, ySL - myPlatform.myTexture.Height * 4), true);

            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 23, ySL - myPlatform.myTexture.Height * 4), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 24, ySL - myPlatform.myTexture.Height * 4), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 25, ySL - myPlatform.myTexture.Height * 4), true);

            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 28, ySL - myPlatform.myTexture.Height * 7), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 29, ySL - myPlatform.myTexture.Height * 8), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 30, ySL - myPlatform.myTexture.Height * 8), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 31, ySL - myPlatform.myTexture.Height * 8), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 32, ySL - myPlatform.myTexture.Height * 8), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 32, ySL - myPlatform.myTexture.Height * 10), true);

            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 37, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 38, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 39, ySL - myPlatform.myTexture.Height * 5), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 40, ySL - myPlatform.myTexture.Height * 5), true);

            //ADDING ENEMIES 
            AddEnemy(aEnemy, new Vector2(xSL + xSL / 4 - aHero.myTexture.Width / 2,
                   ySL / 2 + ySL / 4 - ySL / 8)); 

            AddEnemy(aEnemy, new Vector2(xSL * 2 + myPlatform.myTexture.Width * 7,
                    ySL / 2 + ySL / 4 - aEnemy.myTexture.Height / 4));

            AddEnemy(aEnemy, new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 25,
                ySL - myPlatform.myTexture.Height * 4 - aEnemy.myTexture.Height));

            AddEnemy(aEnemy, new Vector2(xSL * 3 + xSL / 4 + myPlatform.myTexture.Width * 32,
                ySL - myPlatform.myTexture.Height * 10 - aEnemy.myTexture.Height)); 
        }
  
    }
}
