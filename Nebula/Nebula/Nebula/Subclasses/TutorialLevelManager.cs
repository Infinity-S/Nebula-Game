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
    class TutorialLevelManager : LevelManager
    {
        String moveTxt = "Use the D-Pad to move left and right";
        String jumpTxt = "Use the A button to jump";
        String shootTxt = "Use the Right Trigger to shoot the enemy \n\n But don't get too close!!";
        String timeTravelTxt = "Press and HOLD down on the X button to travel back in time. \n\nIf you miss this platform try it out! \n\nDont believe that GameOver screen!";
        String boostTxt = "Use the B button to use your boost ablity. Try it out now!";
        String rechargeTxt = "But don't forget it has to recharge!"; 
        String boostTxt2 = "You can also use it to reach platforms that are too far away!";
        String ttTxt2 = "Don't forget to use that timetravel ability if that enemy \n\nsucceeds in shooting you!";
        String basicsTxt = "Thst concludes the basics of Nebula!"; 
        String instrTxt = "At any time\n\n Press the Y button to display the instructions \n\nand START to exit them"; 

        public TutorialLevelManager(Texture2D texture, Vector2 position, Vector2 screen, Game1 aGame, Level aLevel,
            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Asis aAsis,
            Screen aInstructions, Screen aGameOverScreen, List<Screen> aVictoryScreenList, SpriteManager aSpriteManager)
            : base(texture, position, screen, aGame, aLevel, aSpritesList, aPlatformsList, aFont, aAsis,
            aInstructions, aGameOverScreen, aVictoryScreenList, aSpriteManager)
        {
            EndOfLevelPos = (xSL / 12) * 89; 
        }

        public override void AddItemsToLevel(Sprite sprite, float xSL, float ySL)
        {
            AddPlatform(new Vector2(0, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL / 12, ySL - myPlatform.myTexture.Height * 2), true);
            OnScreenText.Add(moveTxt, new Vector2((xSL / 12) * 2, ySL - ySL/2)); 
            AddPlatform(new Vector2((xSL / 12) * 2, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 3, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 4, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 5, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 6, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 7, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 8, ySL - myPlatform.myTexture.Height * 2), true);
            AddPlatform(new Vector2((xSL / 12) * 9, ySL - myPlatform.myTexture.Height * 2), true);

            OnScreenText.Add(jumpTxt, new Vector2((xSL / 12) * 10, ySL - 2 *(ySL / 4))); 
            AddPlatform(new Vector2((xSL / 12) * 12, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 16, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 17, ySL - myPlatform.myTexture.Height * 6), true);
            OnScreenText.Add(shootTxt, new Vector2((xSL / 12) * 17, ySL - 3 *(ySL / 4))); 
            AddPlatform(new Vector2((xSL / 12) * 18, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 19, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 20, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 21, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 22, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 23, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 24, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 25, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 26, ySL - myPlatform.myTexture.Height * 6), true);


            OnScreenText.Add(timeTravelTxt, new Vector2((xSL / 12) * 27, ySL - 3 * (ySL / 4))); 
            AddPlatform(new Vector2((xSL / 12) * 31, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 36, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 41, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 42, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 43, ySL - myPlatform.myTexture.Height * 6), true);

            OnScreenText.Add(boostTxt, new Vector2((xSL / 12) * 43,  ySL - 3 * (ySL / 4))); 
            AddPlatform(new Vector2((xSL / 12) * 44, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 45, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 46, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 47, ySL - myPlatform.myTexture.Height * 6), true);
            OnScreenText.Add(rechargeTxt, new Vector2((xSL / 12) * 48, ySL - 2 * (ySL / 4)));
            AddPlatform(new Vector2((xSL / 12) * 48, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 49, ySL - myPlatform.myTexture.Height * 6), true);

            OnScreenText.Add(boostTxt2, new Vector2((xSL / 12) * 51, ySL - 3 * (ySL / 4)));
            AddPlatform(new Vector2((xSL / 12) * 55, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 56, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 57, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 58, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 59, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 60, ySL - myPlatform.myTexture.Height * 6), true);
 

            AddPlatform(new Vector2((xSL / 12) * 64, ySL - myPlatform.myTexture.Height * 8), true);
            OnScreenText.Add(ttTxt2, new Vector2((xSL / 12) * 64, ySL - 3 * (ySL / 4)));
            AddPlatform(new Vector2((xSL / 12) * 69, ySL - myPlatform.myTexture.Height * 8), true);


            AddPlatform(new Vector2((xSL / 12) * 74, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 75, ySL - myPlatform.myTexture.Height * 3), true);
            OnScreenText.Add(basicsTxt, new Vector2((xSL / 12) * 75, ySL - 2 * (ySL / 4)));
            AddPlatform(new Vector2((xSL / 12) * 76, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 77, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 78, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 79, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 80, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 81, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 82, ySL - myPlatform.myTexture.Height * 3), true);
            OnScreenText.Add(instrTxt, new Vector2((xSL / 12) * 82, ySL - 3 * (ySL / 4)));
            AddPlatform(new Vector2((xSL / 12) * 83, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 84, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 85, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 86, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 87, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 88, ySL - myPlatform.myTexture.Height * 3), true);
            AddPlatform(new Vector2((xSL / 12) * 89, ySL - myPlatform.myTexture.Height * 3), true);


            AddEnemy(aEnemy, new Vector2((xSL / 12) * 25, ySL - myPlatform.myTexture.Height * 6 - aEnemy.myTexture.Height));
            AddEnemy(aEnemy, new Vector2((xSL / 12) * 69, ySL - myPlatform.myTexture.Height * 8 - aEnemy.myTexture.Height));


        }
    }
}
