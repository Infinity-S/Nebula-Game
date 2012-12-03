using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Nebula.SuperClasses;


namespace Nebula.Subclasses
{
    class Manager : SpriteManager
    {
        List<Sprite> spritesList;
        AsisLaser aLaser;
        DraconisEnemy dEnemy;
        DraconisEnemy dEnemy2;
        DraconisLaser dLaser;
        Asis asis;
        // Sprite[] platformsArray = new Sprite[50];
        List<Sprite> platformsList = new List<Sprite>();
        List<DraconisEnemy> EnemiesList = new List<DraconisEnemy>();
        public GrassPlatform grass;
        // Shorthand for X screen length and Y screen length
        float xSL;
        float ySL;
        Ceres myCeres;
        double enemyWeaponFireTime = 1.5;
        SpriteManager mySpriteManager;

        protected internal SpriteFont myFont;

        SoundEffect LaserSoundEffect;
        SoundEffect BackwardsLaserSoundEffect;
        SoundEffectInstance GameOverSoundInstance;
        SoundEffectInstance CeresMusic;

        GameOver GameOverScreen;

        private Sprite[] BoostBar = new Sprite[5];

        public Manager(Texture2D texture, Vector2 position, Vector2 screen, Game1 aGame, Ceres aCeres,
            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Asis asis2, GameOver aGameOverScreen, SpriteManager aSpriteManager)
            : base(texture, position, screen, aGame, aPlatformsList, asis2)
        {
            myTexture = texture;
            myPosition = position;
            myScreenSize = screen;
            myGame = aGame;
            myCeres = aCeres;
            spritesList = aSpritesList;

            LaserSoundEffect = myGame.Content.Load<SoundEffect>("LaserSoundEffect");
            BackwardsLaserSoundEffect = myGame.Content.Load<SoundEffect>("LaserSoundEffectBackwards");
            SoundEffect GameOverSound = myGame.Content.Load<SoundEffect>("breathofdeath");
            GameOverSoundInstance = GameOverSound.CreateInstance();
            SoundEffect Level1Music = myGame.Content.Load<SoundEffect>("CeresMusic");
            CeresMusic = Level1Music.CreateInstance();
            CeresMusic.IsLooped = true;

            BoostBar[0] = new Sprite(myGame.Content.Load<Texture2D>("boost-bar1"), new Vector2(0, 0));
            BoostBar[1] = new Sprite(myGame.Content.Load<Texture2D>("boost-bar2"), new Vector2(0, 0));
            BoostBar[2] = new Sprite(myGame.Content.Load<Texture2D>("boost-bar3"), new Vector2(0, 0));
            BoostBar[3] = new Sprite(myGame.Content.Load<Texture2D>("boost-bar4"), new Vector2(0, 0));
            BoostBar[4] = new Sprite(myGame.Content.Load<Texture2D>("boost-bar5"), new Vector2(0, 0));

            foreach (Sprite s in BoostBar)
            {
                myCeres.AddSprite(s);
            }

            GameOverScreen = aGameOverScreen;
            mySpriteManager = aSpriteManager;

            for (int i = 0; i < aPlatformsList.Count; i++)
            {
                platformsList.Add(aPlatformsList[i]);
            }

            myFont = aFont;

            grass = (GrassPlatform)platformsList[0];

            asis = (Asis)spritesList[0];
            aLaser = (AsisLaser)spritesList[1];
            dEnemy = (DraconisEnemy)spritesList[2];
            dLaser = (DraconisLaser)spritesList[3];
            dEnemy2 = (DraconisEnemy)spritesList[4];

            EnemiesList.Add(dEnemy);
            EnemiesList.Add(dEnemy2);

            myState = new GameState(this);
            SetUpInput2();
        }


        private void AddPlatform(Vector2 position, bool canLandOn)
        {
            Sprite newGrassPlatform = grass.Clone();
            newGrassPlatform.myPosition = position;
            myCeres.AddSprite(newGrassPlatform);
            // If we want Asis to be able to land on the platform and not fall through - add it to the platformsList
            if (canLandOn)
            {
                platformsList.Add(newGrassPlatform);
            }
        }

        public void AddItemsToLevel(Sprite sprite, float xSL, float ySL)
        {
            // ADD MORE PLATFORMS/ENEMIES HERE
            AddPlatform(new Vector2(xSL / 12, ySL - grass.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL / 2 + xSL / 4 + grass.myTexture.Width / 8, ySL / 2 + ySL / 4), true);
            AddPlatform(new Vector2(xSL + xSL / 4 - sprite.myTexture.Width, ySL / 2 + ySL / 4), true);
            AddPlatform(new Vector2(xSL + xSL / 2, ySL / 2 + ySL / 16), true);
            AddPlatform(new Vector2(xSL + xSL / 2 + grass.myTexture.Width, ySL / 2 + ySL / 16), false);
            AddPlatform(new Vector2(xSL + xSL / 2 + grass.myTexture.Width * 2, ySL / 2 + ySL / 16), false);
            AddPlatform(new Vector2(xSL + xSL / 2 + grass.myTexture.Width * 3, ySL / 2 + ySL / 16), true);
            AddPlatform(new Vector2(xSL * 2 + grass.myTexture.Width * 3, ySL / 2 + ySL / 4 + grass.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL * 2 + grass.myTexture.Width * 4, ySL / 2 + ySL / 4 + grass.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL * 2 + grass.myTexture.Width * 5, ySL / 2 + ySL / 4 + grass.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL * 2 + grass.myTexture.Width * 6, ySL / 2 + ySL / 4 + grass.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL * 2 + grass.myTexture.Width * 7, ySL / 2 + ySL / 4 + grass.myTexture.Height * 2), true);

            // ySL / 2 + ySL / 4 + sm.grass.myTexture.Height * 2
            AddPlatform(new Vector2(xSL * 3 + xSL / 16, ySL / 2 + ySL / 4), true);
            AddPlatform(new Vector2(xSL * 3 - xSL / 16, ySL / 2 + ySL / 32), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + grass.myTexture.Width / 2, ySL / 2), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + grass.myTexture.Width, ySL / 2 - grass.myTexture.Height), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + grass.myTexture.Width * 2, ySL / 2 - grass.myTexture.Height * 2), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + grass.myTexture.Width * 3, ySL / 2 - grass.myTexture.Height * 3), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + grass.myTexture.Width * 4, ySL / 2 - grass.myTexture.Height * 4), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + grass.myTexture.Width * 5, ySL / 2 - grass.myTexture.Height * 5), true);
            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + grass.myTexture.Width * 6, ySL / 2 - grass.myTexture.Height * 5), true);

            AddPlatform(new Vector2(xSL * 3 + xSL / 4 + grass.myTexture.Width * 11, ySL - grass.myTexture.Height * 2), true);

            AddEnemy(new Vector2(400, 400), 'd');
        }

        public void PlayLevelMusic()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.X) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.X))
            {
                CeresMusic.Stop();
            }
            else CeresMusic.Play();
        }


        private void AddEnemy(Vector2 position, char c)
        {
            if (c == 'd')
            {
                Sprite newEnemy = dEnemy.Clone();
                newEnemy.myPosition = position;
                mySpriteManager.addToPositionsList(newEnemy);
                myCeres.AddSprite(newEnemy);
                EnemiesList.Add((DraconisEnemy)newEnemy);
            }
            if (c == 'h')
            {
                // Change to match HydromedaEnemy instead of DraconisEnemy
                Sprite newEnemy = dEnemy.Clone();
                newEnemy.myPosition = position;
                mySpriteManager.addToPositionsList(newEnemy);
                myCeres.AddSprite(newEnemy);
                EnemiesList.Add((DraconisEnemy)newEnemy);
            }
        }


        public void SetUpInput2()
        {
            xSL = myScreenSize.X;
            ySL = myScreenSize.Y;

            GameAction fire = new GameAction(
                this, this.GetType().GetMethod("Fire"),
                new object[0]);

            InputManager.AddToKeyboardMap(Keys.F, fire);
            InputManager.AddToButtonsMap(Buttons.RightTrigger, fire);

        }

        // Helper method that returns true if Asis's laser is offscreen, false otherwise
        private bool aLaserOffScreen()
        {
            if (aLaser.myPosition.X + aLaser.myTexture.Width < asis.myPosition.X - myScreenSize.X / 6
                || aLaser.myPosition.X > asis.myPosition.X + myScreenSize.X
                || aLaser.myPosition.Y < 0
                || aLaser.myPosition.Y > myScreenSize.Y)
            {
                return true;
            }
            else return false;
        }

        public void Fire()
        {
            // Only one laser beam from Asis is allowed on the screen at a time - this makes it so the player cannot just spam the fire button
            if (aLaserOffScreen())
            {
                // If the direction they were last moving was to the left, then fire to the left
                if (asis.getDirection().Equals("left"))
                {
                    aLaser.myPosition = new Vector2(asis.myPosition.X - aLaser.myTexture.Width, asis.myPosition.Y + asis.myTexture.Height / 4);
                    LaserSoundEffect.Play();
                    aLaser.myVelocity.X = -24;
                }
                // Otherwise fire to the right
                else
                {
                    aLaser.myPosition = new Vector2(asis.myPosition.X + asis.myTexture.Width, asis.myPosition.Y + asis.myTexture.Height / 4);
                    LaserSoundEffect.Play();
                    aLaser.myVelocity.X = 24;
                }
            }
        }

        // Helper method that takes Asis and a laser as objects and returns true if it hits her, false otherwise
        private bool Hit(Sprite person, Sprite laser)
        {
            if (laser.myPosition.X + laser.myTexture.Width / 2 > person.myPosition.X
                && laser.myPosition.X + laser.myTexture.Width / 2 < person.myPosition.X + person.myTexture.Width
                && laser.myPosition.Y > person.myPosition.Y && laser.myPosition.Y < person.myPosition.Y + person.myTexture.Height)
            {
                return true;
            }
            else return false;
        }

        public void AsisKillEnemies()
        {
            // For each enemy, if Asis's laser hits them, kill them
            for (int i = 0; i < EnemiesList.Count; i++)
            {
                if (Hit(EnemiesList[i], aLaser))
                {
                    EnemiesList[i].Die();
                }
            }
        }

        public void AsisPlatformLogic()
        {
            // For each platform, if Asis jumps on it - set her y velocity to 0
            for (int i = 0; i < platformsList.Count; i++)
            {
                if (asis.myPosition.Y + asis.myTexture.Height >= platformsList[i].myPosition.Y
                    && asis.myPosition.Y + asis.myTexture.Height <= platformsList[i].myPosition.Y + platformsList[i].myTexture.Height
                    && asis.myPosition.X + asis.myTexture.Width / 2 >= platformsList[i].myPosition.X
                    && asis.myPosition.X + asis.myTexture.Width / 2 <= platformsList[i].myPosition.X + platformsList[i].myTexture.Width)
                {
                    /*
                    // If statement helps avoid a glitch when going back in time Asis would get stuck below a platform
                    if (Keyboard.GetState().IsKeyDown(Keys.X)
                        && sm.asis.myPosition.Y + sm.asis.myTexture.Height <= sm.platformsList[i].myPosition.Y + sm.platformsList[i].myTexture.Height
                        && sm.asis.myPosition.Y + sm.asis.myTexture.Height >= sm.platformsList[i].myPosition.Y)
                    {
                        sm.asis.myPosition.Y -= 5;
                    }
                    */
                    asis.myVelocity.Y = 0;
                    // Allows hero to jump off platforms
                    if (Keyboard.GetState().IsKeyDown(Keys.Space) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.A))
                    {
                        asis.myVelocity.Y = -7f;
                    }
                }
            }
        }

        public void AsisLaserOffScreenLogic()
        {
            if (aLaserOffScreen())
            {
                aLaser.myPosition = new Vector2(aLaser.myPosition.X, aLaser.myPosition.Y + ySL);
            }
        }

        public void EnemyShootingAI()
        {
            //Schuyler worked on this!! to make it so that whener asis is in a specific proximity to a enemy, they attack
            foreach (Sprite enemy in EnemiesList)
            {
                //attack if Asis is in range between 5 texture widths before enemy position to enemy position 
                if ((asis.myPosition.X > (enemy.myPosition.X - (enemy.myTexture.Width * 4))
                    && asis.myPosition.X < enemy.myPosition.X))
                {
                    //Fire a laser every 1.5 seconds, will be an instance varible, so can be changed 
                    if (enemy.time > enemyWeaponFireTime)
                    {
                        dLaser.myPosition = new Vector2(enemy.myPosition.X - dLaser.myTexture.Width, enemy.myPosition.Y);
                        dLaser.myVelocity.X = -16;
                        enemy.time = 0;
                    }
                }
            }
        }

        public void LaserTimeTravelSound(Sprite sprite)
        {
            // Plays the laser sound effect in reverse when it falls into a certain range of x pixels 
            // depending on which direction they were facing when they fired it (when going back in time)
            if (Keyboard.GetState().IsKeyDown(Keys.X) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.X))
            {
                double t = sprite.time;
                // Using the arbitrary grass timer here instead of Asis's because hers is one being displayed on screen and we don't want to reset that one
                // even when she is going back in time
                if (grass.time > .5)
                {
                    float xFireFromLeft = asis.myPosition.X - (aLaser.myTexture.Width * 2) - myScreenSize.X / 2;
                    // sm.myScreenSize.X/8 = size of x range
                    float xFireFromLeftPlus = xFireFromLeft - myScreenSize.X / 8;
                    if (aLaser.myPosition.X <= xFireFromLeft && aLaser.myPosition.X >= xFireFromLeftPlus)
                    {
                        BackwardsLaserSoundEffect.Play();
                        grass.time = 0;
                    }
                    float xFireFromRight = asis.myPosition.X + (asis.myTexture.Width * 2) + myScreenSize.X / 2;
                    // sm.myScreenSize.X/8 = size of x range
                    float xFireFromRightPlus = xFireFromRight + myScreenSize.X / 8;
                    if (aLaser.myPosition.X >= xFireFromRight && aLaser.myPosition.X <= xFireFromRightPlus)
                    {
                        BackwardsLaserSoundEffect.Play();
                        grass.time = 0;
                    }
                }
            }
        }

        public void BoostAbility()
        {
            for (int i = 0; i < BoostBar.Length; i++)
            {
                if (asis.time >= i + 1)
                {
                    BoostBar[i].myPosition = new Vector2(asis.myPosition.X + xSL / 2 + xSL / 6, 0);
                }
                else
                {
                    BoostBar[i].myPosition = new Vector2(xSL * -2, ySL * -2);
                }
            }
        }

        public void GameOverLogic()
        {
            // If Asis gets hit by Enemy laser, display GameOverScreen - otherwise hide it
            if (Hit(asis, dLaser) || asis.myPosition.Y > ySL + ySL / 2)
            {
                asis.myPosition.Y = asis.myPosition.Y + ySL;
                GameOverScreen.myPosition = new Vector2(asis.myPosition.X - xSL / 6, 0);
            }
            else GameOverScreen.myPosition = new Vector2(xSL * -3, ySL * -3);

            if (asis.myPosition.Y > ySL)
            {
                GameOverSoundInstance.Play();
                CeresMusic.Stop();
            }
            else GameOverSoundInstance.Stop();
        }

        class GameState : State
        {
            //for each new level, the only thing we will need to change is the constructor.
            //and only the update if we add in more 'powers' 
            public GameState(Sprite sprite)
            {
                Manager sm = (Manager)sprite;
                float xSL = sprite.myScreenSize.X;
                float ySL = sprite.myScreenSize.Y;

                sm.AddItemsToLevel(sprite, xSL, ySL); 

            }
            public void Update(double elapsedTime, Sprite sprite)
            {
                Manager sm = (Manager)sprite;

                sm.BoostAbility(); 

                sm.PlayLevelMusic();

                sm.AsisLaserOffScreenLogic(); 

                sm.AsisPlatformLogic();

                sm.AsisKillEnemies();

                sm.EnemyShootingAI();

                sm.GameOverLogic();

                sm.LaserTimeTravelSound(sprite);
            }
            public void Draw(Sprite sprite, SpriteBatch batch)
            {
                Manager sm = (Manager)sprite;

                batch.Draw(sprite.myTexture, sprite.myPosition,
                null, Color.White,
                sprite.myAngle, sprite.myOrigin,
                sprite.myScale, SpriteEffects.None, 0f);
                // Timer gets drawn here - unaffected by time travel ability
                batch.DrawString(sm.myFont, "Time: " + Convert.ToString(Convert.ToInt32(sprite.time)), new Vector2(sm.asis.myPosition.X - sm.xSL / 6, 0),
                    Color.Black, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 0.5f);
            }
        }
    }
}
