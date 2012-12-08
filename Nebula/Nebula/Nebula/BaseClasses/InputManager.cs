// Shannon Duvall
// This object keeps up with a mapping of Keys to actions, handling keyboard input and mouse input

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Nebula
{
    // This is a static object.  Only one exists, (you can't say "new") and
    // it is accessible by anyone.
    static class InputManager
    {
        // XNA doesn't provide me with a collection of mouse things, so I ennumerate them here.
        public const int LEFT_BUTTON = 0;
        public const int RIGHT_BUTTON = 1;
        public const int POSITION = 2;

        // I now let one key or mouse position map to lots of actions.
        static Dictionary<int, List<GameAction>> myMouseMap = new Dictionary<int, List<GameAction>>();

        // This is the mapping from Keyboard Keys to GameAction objects
        static Dictionary<Keys, List<GameAction>> myKeyboardMap = new Dictionary<Keys, List<GameAction>>();

        // This is the mapping from Gamepad Buttons to GameAction objects
        static Dictionary<Buttons, List<GameAction>> myButtonsMap = new Dictionary<Buttons, List<GameAction>>();

        // Anyone can add a new mapping from key to action.  This method is generic, since I don't
        // want to copy and paste this method for the two different types of Dictionaries I deal with.
        public static void AddToMap<T>(Dictionary<T, List<GameAction>> map, T key, GameAction action)
        {

            List<GameAction> keyList = new List<GameAction>();

            if (map.ContainsKey(key))
            {
                keyList = map[key];
                map.Remove(key);
            }
            keyList.Add(action);
            map.Add(key, keyList);
        }

        public static void AddToMouseMap(int button, GameAction action)
        {
            AddToMap<int>(myMouseMap, button, action);
        }

        public static void AddToKeyboardMap(Keys key, GameAction action)
        {
            AddToMap<Keys>(myKeyboardMap, key, action);
        }

        public static void AddToButtonsMap(Buttons button, GameAction action)
        {
            AddToMap<Buttons>(myButtonsMap, button, action);
        }

        // Perform the functions in the MouseDictionary, given the current MouseState.
        public static void ActMouse(MouseState mouseState)
        {
            // I'm predicting that any method that cares about the mouse clicks will also care WHERE
            // the mouse click happened.
            object[] parameterList = new object[1];
            parameterList[0] = new Vector2(mouseState.X, mouseState.Y);

            // There's no ennumeration for the mouse buttons, so I have to have separate if statements.
            // The good news is that more buttons aren't likely to be added to the mouse any time soon.
            if (mouseState.LeftButton == ButtonState.Pressed && myMouseMap.ContainsKey(LEFT_BUTTON))
            {
                foreach (GameAction a in myMouseMap[LEFT_BUTTON])
                {
                    a.Invoke(parameterList);
                }
            }
            if (mouseState.RightButton == ButtonState.Pressed && myMouseMap.ContainsKey(RIGHT_BUTTON))
            {
                foreach (GameAction a in myMouseMap[RIGHT_BUTTON])
                {
                    a.Invoke(parameterList);
                }
            }
            if (myMouseMap.ContainsKey(POSITION))
            {
                foreach (GameAction a in myMouseMap[POSITION])
                {
                    a.Invoke(parameterList);
                }
            }
        }

        public static void ActGamePad(GamePadState gamePadState)
        {
            if (gamePadState.Buttons.A == ButtonState.Pressed && myButtonsMap.ContainsKey(Buttons.A))
            {
                foreach (GameAction a in myButtonsMap[Buttons.A])
                {
                    a.Invoke();
                }
            }
            if (gamePadState.Buttons.B == ButtonState.Pressed && myButtonsMap.ContainsKey(Buttons.B))
            {
                foreach (GameAction a in myButtonsMap[Buttons.B])
                {
                    a.Invoke();
                }
            }
            if (gamePadState.Buttons.X == ButtonState.Pressed && myButtonsMap.ContainsKey(Buttons.X))
            {
                foreach (GameAction a in myButtonsMap[Buttons.X])
                {
                    a.Invoke();
                }
            }
            if (gamePadState.Buttons.Y == ButtonState.Pressed && myButtonsMap.ContainsKey(Buttons.Y))
            {
                foreach (GameAction a in myButtonsMap[Buttons.Y])
                {
                    a.Invoke();
                }
            }
            if (gamePadState.Buttons.Start == ButtonState.Pressed && myButtonsMap.ContainsKey(Buttons.Start))
            {
                foreach (GameAction a in myButtonsMap[Buttons.Start])
                {
                    a.Invoke();
                }
            }
            if (gamePadState.Buttons.Back == ButtonState.Pressed && myButtonsMap.ContainsKey(Buttons.Back))
            {
                foreach (GameAction a in myButtonsMap[Buttons.Back])
                {
                    a.Invoke();
                }
            }
            if (gamePadState.DPad.Left == ButtonState.Pressed && myButtonsMap.ContainsKey(Buttons.DPadLeft))
            {
                foreach (GameAction a in myButtonsMap[Buttons.DPadLeft])
                {
                    a.Invoke();
                }
            }
            if (gamePadState.DPad.Right == ButtonState.Pressed && myButtonsMap.ContainsKey(Buttons.DPadRight))
            {
                foreach (GameAction a in myButtonsMap[Buttons.DPadRight])
                {
                    a.Invoke();
                }
            }
            if (gamePadState.Triggers.Right > 0 && myButtonsMap.ContainsKey(Buttons.RightTrigger))
            {
                foreach (GameAction a in myButtonsMap[Buttons.RightTrigger])
                {
                    a.Invoke();
                }
            }
            if (gamePadState.Buttons.LeftShoulder == ButtonState.Pressed && myButtonsMap.ContainsKey(Buttons.LeftShoulder))
            {
                foreach (GameAction a in myButtonsMap[Buttons.LeftShoulder])
                {
                    a.Invoke();
                }
            }
            if (gamePadState.Buttons.RightShoulder == ButtonState.Pressed && myButtonsMap.ContainsKey(Buttons.RightShoulder))
            {
                foreach (GameAction a in myButtonsMap[Buttons.RightShoulder])
                {
                    a.Invoke();
                }
            }
        }

        // This is called by the game - it gives the current 
        // state of the keyboard and makes the corresponding actions happen.
        public static void ActKeyboard(KeyboardState keyState)
        {
            Keys[] allPressed = keyState.GetPressedKeys();
            foreach (Keys k in allPressed)
            {
                if (myKeyboardMap.ContainsKey(k))
                {
                    List<GameAction> actionList = myKeyboardMap[k];
                    foreach (GameAction action in actionList)
                    {
                        action.Invoke();
                    }
                }
            }
        }
    }
}
