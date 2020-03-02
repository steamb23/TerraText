using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.Examples.Scenes
{
    class DeepChildScene : Scene
    {
        public override void Execute()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("깊은 하위 장면입니다.");
            ConsoleEx.WaitKeyWithCursor();
            Console.WriteLine();
            Console.WriteLine("현재 장면 계층은 " + SceneManager.CurrentSceneDepth + "입니다.");
            Console.WriteLine("상위 장면으로 되돌아갑니다.");
            Console.WriteLine();
            Console.WriteLine("아무 키를 누르면 장면이 종료됩니다.");
            ConsoleEx.WaitKeyWithCursor();
        }
    }
}
