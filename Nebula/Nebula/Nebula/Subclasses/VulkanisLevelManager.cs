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
        public VulkanisLevelManager(Texture2D texture, Vector2 position, Vector2 screen, Game1 aGame, Level aLevel,
            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Asis aAsis, Screen aInstructions, Screen aGameOverScreen, Screen aVictoryScreen, SpriteManager aSpriteManager)
            : base(texture, position, screen, aGame, aLevel, aSpritesList, aPlatformsList, aFont, aAsis, aInstructions, aGameOverScreen, aVictoryScreen, aSpriteManager)
        {
            EndOfLevelPos = xSL * 7 + xSL / 2 + xSL / 8;
        }

        public override void AddItemsToLevel(Sprite sprite, float xSL, float ySL)
        {
            
        }
    }
}
