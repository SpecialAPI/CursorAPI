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
        }

        public override void Exit()
        {
        }
    }
}
