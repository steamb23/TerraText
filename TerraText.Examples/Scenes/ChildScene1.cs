using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.Examples.Scenes
{
    class ChildScene1 : Scene
    {
        public override void Execute()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("하위 장면1입니다.");
            ConsoleEx.WaitKeyWithCursor();
            Console.WriteLine();
            Console.WriteLine("루트 장면이 최종적으로 종료된 후 하위 장면이 실행되었습니다.");
            Console.WriteLine("이번 장면에서 장면을 교체를 예약하지 않고 실행이 종료되면 장면 관리자는 루트 장면을 실행할 것입니다.");
            Console.WriteLine("그러나 장면 교체를 예약하면 현재 스택 단계에서 장면이 교체됩니다.");
            ConsoleEx.WaitKeyWithCursor();
            Console.WriteLine();
            Console.WriteLine("장면 교체를 예약했습니다.");
            SceneManager.ReserveSceneChange(new ChildScene2());
            Console.WriteLine();
            Console.WriteLine("아무 키를 누르면 장면이 종료됩니다.");
            ConsoleEx.WaitKeyWithCursor();
        }
    }
}
