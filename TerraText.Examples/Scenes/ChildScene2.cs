using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.Examples.Scenes
{
    class ChildScene2 : Scene
    {
        public override void Execute()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("하위 장면2입니다.");
            ConsoleEx.WaitKeyWithCursor();
            Console.WriteLine();
            Console.WriteLine("이렇게 장면 관리자를 통해 장면 관리를 효율적으로 할 수 있습니다.");
            Console.WriteLine("이번엔 루트 장면으로 넘어가기 위해 아무 예약도 하지않습니다.");
            Console.WriteLine();
            Console.WriteLine("아무 키를 누르면 장면이 종료됩니다.");
            ConsoleEx.WaitKeyWithCursor();
        }
    }
}
