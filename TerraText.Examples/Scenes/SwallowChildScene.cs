using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.Examples.Scenes
{
    class SwallowChildScene : Scene
    {
        int excuteCount = 0;
        public override void Execute()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("얕은 하위 장면입니다.");
            ConsoleEx.WaitKeyWithCursor();
            Console.WriteLine();
            switch (excuteCount++)
            {
                case 0:
                    Console.WriteLine("이 장면에서는 깊은 하위 장면을 예약합니다.");
                    SceneManager.ReserveChildScene(new DeepChildScene());
                    break;
                case 1:
                    Console.WriteLine("하위 장면에서 종료를 예약하면 루트 장면을 거치지 않고 바로 종료됩니다.");
                    Console.WriteLine("종료를 예약했습니다.");
                    SceneManager.ReserveExit();
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("아무 키를 누르면 장면이 종료됩니다.");
            ConsoleEx.WaitKeyWithCursor();
        }
    }
}
