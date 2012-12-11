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
using Nebula.BaseClasses; 
using Nebula.Subclasses; 


namespace Nebula.Subclasses
{
    public class LevelManager : TimeTravelManager
    {
        protected internal bool runOnce = true; 
        protected internal List<Sprite> spritesList;
        protected internal HeroLaser aLaser;
        protected internal Enemy aEnemy;
        protected internal EnemyLaser eLaser;
        protected internal Hero aHero;
        protected internal List<Sprite> platformsList = new List<Sprite>();
        protected internal List<Enemy> EnemiesList = new List<Enemy>();
        int textIndex = 0;


        protected internal Platform myPlatform;
        protected internal float xSL;
        protected internal float ySL;
        protected internal Level myLevel;
        protected internal double enemyWeaponFireTime = 1.5;
        protected internal TimeTravelManager myTimeTravelManager;

        protected internal Dictionary<String, Vector2> OnScreenText = new Dictionary<String, Vector2>();
        protected internal Dictionary<String, Vector2> LevelStoryText = new Dictionary<String, Vector2>(); 
        protected internal SpriteFont myFont;

        protected internal  SoundEffect LaserSoundEffect;
        protected internal SoundEffect BackwardsLaserSoundEffect;
        protected internal SoundEffectInstance GameOverSoundInstance;
        protected internal  SoundEffectInstance LevelMusic;
        protected internal SoundEffectInstance StageClearInstance;
        private bool playOnce = true; 
        protected internal double finishingTime;

        private bool runOnce2 = true;

        private int levelCounter;

        Screen InstructionScreen;
        Screen GameOverScreen;

        private double bestTime;
        private double middleTime;
        private double worstTime;

        private bool isFinished = false; 

        protected internal List<Screen> VictoryScreenList = new List<Screen>();

        // can change when victory screen displays if have a longer/shorter level 
        protected internal float EndOfLevelPos;

        protected Screen myCutScene;
        protected bool cutSceenDisplay = false;
        protected bool finishCutSceen = false;
  

        private Sprite[] BoostBar = new Sprite[5];

        public LevelManager(Texture2D texture, Vector2 position, Vector2 screen, NebulaGame aGame, Level aLevel,
            List<Sprite> aSpritesList, List<Sprite> aPlatformsList, SpriteFont aFont, Hero anHero,
             Screen aInstructions, Screen aGameOverScreen, List<Screen> aVictoryScreenList, Screen aCutScene, TimeTravelManager aTimeTravelManager, SoundEffect backgroundMusic)
            : base(texture, position, screen, aGame, aPlatformsList, anHero)
        {
            myTexture = texture;
            myPosition = position;
            myScreenSize = screen;
            myGame = aGame;
            myLevel = aLevel;
            spritesList = aSpritesList;

            //Music for the level 
            LaserSoundEffect = myGame.Content.Load<SoundEffect>("LaserSoundEffect");
            BackwardsLaserSoundEffect = myGame.Content.Load<SoundEffect>("LaserSoundEffectBackwards");
            SoundEffect GameOverSound = myGame.Content.Load<SoundEffect>("breathofdeath");
            GameOverSoundInstance = GameOverSound.CreateInstance();
            SoundEffect BackgroundMusic = backgroundMusic;
            LevelMusic = BackgroundMusic.CreateInstance();
            LevelMusic.IsLooped = true;
            SoundEffect StageClear = myGame.Content.Load<SoundEffect>("Stage1-soundclear");
            StageClearInstance = StageClear.CreateInstance();

            BoostBar[0] = new Sprite(myGame.Content.Load<Texture2D>("boost-bar1"), new Vector2(0, 0));
            BoostBar[1] = new Sprite(myGame.Content.Load<Texture2D>("boost-bar2"), new Vector2(0, 0));
            BoostBar[2] = new Sprite(myGame.Content.Load<Texture2D>("boost-bar3"), new Vector2(0, 0));
            BoostBar[3] = new Sprite(myGame.Content.Load<Texture2D>("boost-bar4"), new Vector2(0, 0));
            BoostBar[4] = new Sprite(myGame.Content.Load<Texture2D>("boost-bar5"), new Vector2(0, 0));

            foreach (Sprite s in BoostBar)
            {
                myLevel.AddSprite(s);
            }

            GameOverScreen = aGameOverScreen;
            VictoryScreenList = aVictoryScreenList;
            myCutScene = aCutScene; 
            myTimeTravelManager = aTimeTravelManager;

            for (int i = 0; i < aPlatformsList.Count; i++)
            {
                platformsList.Add(aPlatformsList[i]);
            }

            myFont = aFont;
            InstructionScreen = aInstructions;

            //should we pass these in as indivdual items?? 
            setUpSprites((Platform)platformsList[0], (Hero)spritesList[0], (HeroLaser)spritesList[1], 
                (Enemy)spritesList[2], (EnemyLaser)spritesList[3]); 

            EnemiesList.Add(aEnemy); 

            myState = new GameState(this);
            SetUpInput2();
        }

        public void setLevelCounter(int integer)
        {
            levelCounter = integer;
        }


        //this is virtual so you can override it if you want. 
        //like if have more than the "basic" sprites of the level
        //EG 1 Asis and her laser, 1 Platform type of platform, and 1 type of enemy and it's Laser
        public virtual void setUpSprites(Platform aPlatform, Hero anHero, HeroLaser anLaser, Enemy anEnemy, EnemyLaser anELaser)
        {
            myPlatform = aPlatform;
            aHero = anHero;
            aLaser = anLaser;
            aEnemy = anEnemy;
            eLaser = anELaser; 
        }


        public void AddPlatform(Vector2 position, bool canLandOn)
        {
            Platform newPlatform = myPlatform.Clone();
            newPlatform.myPosition = position;
            newPlatform.setCanStandOn(canLandOn);
            newPlatform.setBadPlatformImage();
            myLevel.AddSprite(newPlatform);

            // If we want Asis to be able to land on the platform and not fall through - add it to the platformsList
            if (canLandOn)
            {
                platformsList.Add(newPlatform);
            }
        }

        public virtual void AddItemsToLevel(Sprite sprite, float xSL, float ySL)
        {
        }

        public void PlayLevelMusic()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.X) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.X))
            {
                LevelMusic.Stop();
            }
            else LevelMusic.Play();
        }


        public void AddEnemy(Enemy aEnemy, Vector2 position)
        {
                Sprite newEnemy = aEnemy.Clone();
                newEnemy.myPosition = position;
                myTimeTravelManager.addToPositionsList(newEnemy);
                myLevel.AddSprite(newEnemy);
                EnemiesList.Add((Enemy)newEnemy);
        }

        public void StartGame()
        {
            InstructionScreen.myPosition = new Vector2(xSL * -3, 0);
        }

        public void DisplayInstructions()
        {
            if (myGame.getLevelNum() == 0)
            {
                InstructionScreen.myPosition = new Vector2(aHero.myPosition.X - xSL / 6, 0);
            }
        }

        public void SetUpInput2()
        {
            xSL = myScreenSize.X;
            ySL = myScreenSize.Y;

            GameAction fire = new GameAction(
                this, this.GetType().GetMethod("Fire"),
                new object[0]);

            GameAction instruct = new GameAction(this, this.GetType().GetMethod("StartGame"), new object[0]);
            GameAction displayInstruct = new GameAction(this, this.GetType().GetMethod("DisplayInstructions"), new object[0]);

            InputManager.AddToKeyboardMap(Keys.I, instruct);
            InputManager.AddToButtonsMap(Buttons.Start, instruct);
            InputManager.AddToKeyboardMap(Keys.Y, displayInstruct);
            InputManager.AddToButtonsMap(Buttons.Y, displayInstruct);
            InputManager.AddToKeyboardMap(Keys.F, fire);
            InputManager.AddToButtonsMap(Buttons.RightTrigger, fire);

            GameAction timerReset = new GameAction(
                this, this.GetType().GetMethod("ResetTimer"),
                new object[0]);

            InputManager.AddToKeyboardMap(Keys.I, timerReset);
            InputManager.AddToButtonsMap(Buttons.Start, timerReset);

        }

        public void ResetTimer()
        {
            if (runOnce == true)
            {
                time = 0;
            }
            runOnce = false;
        }

        // Helper method that returns true if Asis's laser is offscreen, false otherwise
        private bool aLaserOffScreen()
        {
            if (aLaser.myPosition.X + aLaser.myTexture.Width < aHero.myPosition.X - myScreenSize.X / 6
                || aLaser.myPosition.X > aHero.myPosition.X + myScreenSize.X
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
                if (aHero.getDirection().Equals("left"))
                {
                    aLaser.myPosition = new Vector2(aHero.myPosition.X - aLaser.myTexture.Width, aHero.myPosition.Y + aHero.myTexture.Height / 4);
                    LaserSoundEffect.Play();
                    aLaser.myVelocity.X = -24;
                }
                // Otherwise fire to the right
                else
                {
                    aLaser.myPosition = new Vector2(aHero.myPosition.X + aHero.myTexture.Width, aHero.myPosition.Y + aHero.myTexture.Height / 4);
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

        public void HeroKillEnemies()
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

        public void PlatformLogic()
        {
            // For each platform, if Asis jumps on it - set her y velocity to 0
            for (int i = 0; i < platformsList.Count; i++)
            {
                if (aHero.myPosition.Y + aHero.myTexture.Height >= platformsList[i].myPosition.Y
                    && aHero.myPosition.Y + aHero.myTexture.Height <= platformsList[i].myPosition.Y + platformsList[i].myTexture.Height
                    && aHero.myPosition.X + aHero.myTexture.Width / 2 >= platformsList[i].myPosition.X
                    && aHero.myPosition.X + aHero.myTexture.Width / 2 <= platformsList[i].myPosition.X + platformsList[i].myTexture.Width)
                {
                    aHero.myVelocity.Y = 0;
                    // Allows hero to jump off platforms
                    if (Keyboard.GetState().IsKeyDown(Keys.Space) 
                        || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.A) 
                        || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftShoulder))
                    {
                        aHero.myVelocity.Y = -7f;
                    }
                //}
                }
            }
        }

        public void HeroLaserOffScreenLogic()
        {
            if (aLaserOffScreen())
            {
                aLaser.myPosition = new Vector2(aLaser.myPosition.X, aLaser.myPosition.Y + ySL);
            }
        }

        public void EnemyShootingAI()
        {
            //make it so that whenever asis is in a specific proximity to a enemy, they attack
            foreach (Sprite enemy in EnemiesList)
            {
                //attack if Asis is in range between 5 texture widths before enemy position to enemy position 
                if ((aHero.myPosition.X > (enemy.myPosition.X - (myPlatform.myTexture.Width * 4))
                    && aHero.myPosition.X < enemy.myPosition.X))
                {
                    //Fire a laser every 1.5 seconds, will be an instance varible, so can be changed 
                    if (enemy.time > enemyWeaponFireTime)
                    {
                        eLaser.myPosition = new Vector2(enemy.myPosition.X - eLaser.myTexture.Width, enemy.myPosition.Y + (enemy.myTexture.Height) / 5);
                        eLaser.myVelocity.X = -16;
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
                if (myPlatform.time > .5)
                {
                    float xFireFromLeft = aHero.myPosition.X - (aLaser.myTexture.Width * 2) - myScreenSize.X / 2;
                    // sm.myScreenSize.X/8 = size of x range
                    float xFireFromLeftPlus = xFireFromLeft - myScreenSize.X/8;
                    if (aLaser.myPosition.X <= xFireFromLeft && aLaser.myPosition.X >= xFireFromLeftPlus)
                    {
                        BackwardsLaserSoundEffect.Play();
                        myPlatform.time = 0;
                    }
                    float xFireFromRight = aHero.myPosition.X + (aHero.myTexture.Width * 2) + myScreenSize.X / 2;
                    // sm.myScreenSize.X/8 = size of x range
                    float xFireFromRightPlus = xFireFromRight + myScreenSize.X/8;
                    if (aLaser.myPosition.X >= xFireFromRight && aLaser.myPosition.X <= xFireFromRightPlus)
                    {
                        BackwardsLaserSoundEffect.Play();
                        myPlatform.time = 0;
                    }
                }
            }
        }

        public void BoostAbility()
        {
            for (int i = 0; i < BoostBar.Length; i++)
            {
                if (aHero.time >= i + 1)
                {
                    BoostBar[i].myPosition = new Vector2(aHero.myPosition.X + xSL / 2 + xSL / 6, 0);
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
            if (Hit(aHero, eLaser) || aHero.myPosition.Y > ySL + ySL / 2)
            {
                aHero.myPosition.Y = aHero.myPosition.Y + ySL;
                GameOverScreen.myPosition = new Vector2(aHero.myPosition.X - xSL / 6, 0);
            }
            else GameOverScreen.myPosition = new Vector2(xSL * -3, ySL * -3);

            if (aHero.myPosition.Y > ySL)
            {
                GameOverSoundInstance.Play();
                LevelMusic.Stop();
            }
            else GameOverSoundInstance.Stop();
        }

        public void setFinishingTimes(double bestTime, double middleTime, double worstTime)
        {
            this.bestTime = bestTime;
            this.middleTime = middleTime;
            this.worstTime = worstTime;
        }


        public virtual void FinishLevelDisplay()
        {
            if (finishingTime <= bestTime)
            {
                VictoryScreenList[0].myPosition = new Vector2(aHero.myPosition.X - xSL / 6, 0);
                cutSceenDisplay = true;
            }
 
            else if (finishingTime <= middleTime)
            {
                VictoryScreenList[1].myPosition = new Vector2(aHero.myPosition.X - xSL / 6, 0);
                cutSceenDisplay = true;
            }
 
            else if (finishingTime <= worstTime)
            {
                VictoryScreenList[2].myPosition = new Vector2(aHero.myPosition.X - xSL / 6, 0);
                cutSceenDisplay = true;
            }
            else VictoryScreenList[3].myPosition = new Vector2(aHero.myPosition.X - xSL / 6, 0);
            cutSceenDisplay = true;
        }
        public bool DisplayVictoryScreen()
        {
            // If player has reached the end of the level
            if (aHero.myPosition.X > EndOfLevelPos)
            {
                FinishLevelDisplay();

                if (playOnce == true)
                {
                    StageClearInstance.Play();
                }
                playOnce = false;
                LevelMusic.Stop();

                // If they press N on the keyboard or start on the gamepad go to the next level
                if (cutSceenDisplay == true && ((Keyboard.GetState().IsKeyDown(Keys.N)) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Start)))
                {
                    myCutScene.myPosition = new Vector2(aHero.myPosition.X - xSL / 6, 0);
                    finishCutSceen = true;
                }
                if (finishCutSceen == true && ((Keyboard.GetState().IsKeyDown(Keys.N)) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Start)))
                {
                    aHero.myPosition = new Vector2(myScreenSize.X / 12, myScreenSize.Y - myScreenSize.Y / 4);
                    isFinished = true;
                }
                return true;
            } 
            return false;
        }

        public bool getIsFinished()
        {
            return isFinished;
        }

        public void setIsFinished(bool levelFinished)
        {
            isFinished = levelFinished; 
        }

        class GameState : State
        {
            //for each new level, the only thing we will need to change is the constructor.
            //and only the update if we add in more 'powers' 
            public GameState(Sprite sprite)
            {
                LevelManager sm = (LevelManager)sprite;
                float xSL = sprite.myScreenSize.X;
                float ySL = sprite.myScreenSize.Y;

                sm.AddItemsToLevel(sprite, xSL, ySL); 

            }
            public void Update(double elapsedTime, Sprite sprite)
            {
                LevelManager sm = (LevelManager)sprite;

                sm.BoostAbility(); 

                sm.PlayLevelMusic();

                sm.HeroLaserOffScreenLogic(); 

                sm.HeroKillEnemies();

                sm.EnemyShootingAI();

                sm.GameOverLogic();

                sm.LaserTimeTravelSound(sprite);

                if (!Keyboard.GetState().IsKeyDown(Keys.X) && (!GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.X)))
                {
                    sm.PlatformLogic();
                }

                if (sm.DisplayVictoryScreen())
                {
                    if (sm.runOnce2)
                    {
                        sm.finishingTime = sprite.time;
                        sm.runOnce2 = false;
                    }
                }
            }
            public void Draw(Sprite sprite, SpriteBatch batch)
            {
                LevelManager sm = (LevelManager)sprite;

                batch.Draw(sprite.myTexture, sprite.myPosition,
                null, Color.White,
                sprite.myAngle, sprite.myOrigin,
                sprite.myScale, SpriteEffects.None, 0f);

                if (!sm.DisplayVictoryScreen())
                {
                    // Timer gets drawn here - unaffected by time travel ability
                    batch.DrawString(sm.myFont, "Time: " + Convert.ToString(Convert.ToInt32(sprite.time)), 
                        new Vector2(sm.aHero.myPosition.X - sm.xSL / 6, 0),
                        Color.White, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 0.5f);

                    batch.DrawString(sm.myFont, "Boost Bar",
                   new Vector2(sm.aHero.myPosition.X + sm.xSL - 2 * sm.myPlatform.myTexture.Width - sm.myPlatform.myTexture.Width / 2, sm.myPlatform.myTexture.Height + sm.myPlatform.myTexture.Height / 3),
                   Color.White, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 0.5f);
                }
                if (sm.DisplayVictoryScreen())
                {
                    batch.DrawString(sm.myFont, "Time Completed In: " + Convert.ToString(Convert.ToInt32(sm.finishingTime)), 
                        new Vector2(sm.aHero.myPosition.X - sm.xSL / 6, 0), Color.White, 0, 
                        new Vector2(0, 0), 1.3f, SpriteEffects.None, 0.5f);
                }

                foreach (KeyValuePair<String, Vector2> entry in sm.OnScreenText)
                {
                    batch.DrawString(sm.myFont, entry.Key,entry.Value, Color.Yellow);
                }

                foreach (KeyValuePair<String, Vector2> entry in sm.LevelStoryText)
                {
                    batch.DrawString(sm.myFont, entry.Key, entry.Value, Color.Yellow);
                }
                    sm.InstructionScreen.Draw(batch);
            }
        }
    }
}
