using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CursorAPI
{
    public class ExampleModule : ETGModule
    {
        public override void Init()
        {
        }

        public override void Start()
        {
            CursorMaker.Init();
            CursorMaker.BuildCursor("CursorAPI/Resources/chamber_cursor");
            ETGModConsole.Commands.AddUnit("search_for_cursor_ui", delegate(string[] args)
            {
                ETGModConsole.Log("-------LOOKING FOR BRAVE OPTION MENU ITEMS");
                foreach(BraveOptionsMenuItem menu in UnityEngine.Object.FindObjectsOfType<BraveOptionsMenuItem>())
                {
                    ETGModConsole.Log("---------------FOUND ONE: " + menu.gameObject.name);
                    ETGModConsole.Log("---------------CHECKING FOR THE TYPE");
                    if (menu.optionType == BraveOptionsMenuItem.BraveOptionsOptionType.CURSOR_VARIATION)
                    {
                        ETGModConsole.Log("-------------------TYPE IS CORRECT");
                        Transform currentThing = menu.transform;
                        while (currentThing.parent != null)
                        {
                            ETGModConsole.Log("----------------------CURRENT THING: " + currentThing.gameObject.name + ", IT'S PARENT: " + currentThing.parent.gameObject.name);
                            currentThing = currentThing.parent;
                        }
                        ETGModConsole.Log("-------------------THE FINAL TRANSFORM: " + currentThing);
                        UnityEngine.Object result = CursorTools.LoadAssetFromAnywhere(currentThing.gameObject.name.Replace("(Clone)", ""));
                        ETGModConsole.Log("-------------------TRYING TO LOAD THE FINAL TRANSFORM RESULTS IN " + (result != null ? "NOT NULL (" + result.name + ", " + result.GetType() + ")" : "NULL"));
                        ETGModConsole.Log("-------------------LABEL IS LOCALIZED: " + menu.selectedLabelControl.IsLocalized);
                    }
                    else
                    {
                        ETGModConsole.Log("-------------------TYPE ISNT CORRECT: " + menu.optionType);
                    }
                }
            });
        }

        public override void Exit()
        {
        }
    }
}
