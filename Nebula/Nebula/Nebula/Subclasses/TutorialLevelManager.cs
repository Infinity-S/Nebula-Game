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
        String shootTxt = "Use the Right Trigger to shoot the enemy \n But don't get too close!!";
        String timeTravelTxt = "Continuouly press down on the X button to travel back in time. \nIf you miss this platform try it out! \nDont believe that GameOver screen!";
        String boostTxt = "Use the B button to use your boost ablity. Try it out now!";
        String boostTxt2 = "You can also use it to reach platforms that are too far away to reach just by jump!"; 
        String instrTxt = "Press the Y button to display the instructions. Press START to exit them"; 

        public TutorialLevelManager(Texture2D texture, Vector2 position, Vector2 screen, Game1 aGame, Level aLevel,
            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Asis aAsis, Screen aInstructions, Screen aGameOverScreen, Screen aVictoryScreen, SpriteManager aSpriteManager)
            : base(texture, position, screen, aGame, aLevel, aSpritesList, aPlatformsList, aFont, aAsis, aInstructions, aGameOverScreen, aVictoryScreen, aSpriteManager)
        {
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
            AddPlatform(new Vector2((xSL / 12) * 48, ySL - myPlatform.myTexture.Height * 6), true);
            AddPlatform(new Vector2((xSL / 12) * 49, ySL - myPlatform.myTexture.Height * 6), true);





            AddEnemy(new Vector2((xSL / 12) * 25, ySL - myPlatform.myTexture.Height * 6 - aEnemy.myTexture.Height),'d'); 


        }
    }
}
