using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.Examples.Scenes
{
    sealed class RootScene : Scene
    {
        private int excuteCount = 0;
        public override void Execute()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("루트 장면입니다.");
            ConsoleEx.WaitKeyWithCursor();
            Console.WriteLine();
            switch (excuteCount++)
            {
                case 0:
                    // 초기
                    Console.WriteLine("각 장면에서는 SceneManager(장면 관리자) 프로퍼티에 접근할 수 있습니다.");
                    Console.WriteLine("장면 관리자에 하위 장면, 장면 변경, 장면 관리 종료등을 예약한 후 해당 장면의 실행이 종료되면");
                    Console.WriteLine("가장 마지막에 예약된 명령을 처리합니다.");
                    ConsoleEx.WaitKeyWithCursor();
                    Console.WriteLine();
                    Console.WriteLine("장면 관리는 내부적으로 스택 기반으로 작동하며 하위 장면의 실행이 아무 작업 예약 없이 종료되면");
                    Console.WriteLine("스택에서 하위 단계 장면이 제거되고 하위 단계 장면을 추가했던 상위 단계 장면을 다시 실행합니다.");
                    ConsoleEx.WaitKeyWithCursor();
                    Console.WriteLine();
                    Console.WriteLine("하위 단계 장면에서 장면 변경이 예약되면 예약을 호출한 장면은 제거되고 해당 단계에서");
                    Console.WriteLine("예약된 장면이 실행됩니다.");
                    ConsoleEx.WaitKeyWithCursor();
                    Console.WriteLine();
                    Console.WriteLine("마지막으로 루트 장면은 실행이 종료되면 다시 실행됩니다. 최종적으로 장면 관리 프로세스를 중단");
                    Console.WriteLine("하려면 장면 관리 종료를 예약해야합니다.");
                    Console.WriteLine("장면 관리 종료가 예약되면 장면 관리자는 스택에서 모든 장면을 제거하고 장면 관리를 중단합니다.");
                    break;
                case 1:
                    // 1회차
                    Console.WriteLine("루트 장면이 종료되었고 다시 실행되었습니다.");
                    ConsoleEx.WaitKeyWithCursor();
                    Console.WriteLine();
                    Console.WriteLine("이 처럼 루트 장면이 아무 작업 예약 없이 종료되면 장면 관리자는 해당 장면을 처음 부터 다시 실행");
                    Console.WriteLine("합니다. 예제의 루트 장면은 실행 횟수를 카운팅하고 있기 때문에 분기된 메시지를 보여주고 있습니다.");
                    ConsoleEx.WaitKeyWithCursor();
                    Console.WriteLine();
                    SceneManager.ReserveChildScene(new ChildScene1());
                    Console.WriteLine("이번엔 하위 장면을 예약하였습니다.");
                    Console.WriteLine("하위 장면은 즉시 실행되지 않고 반드시 현재 실행 중인 장면이 종료되어야 실행됩니다.");
                    break;
                case 2:
                    Console.WriteLine("하위 장면에서 아무 작업도 예약하지 않아 루트 장면으로 돌아왔습니다.");
                    Console.WriteLine("다음은 하위 장면에서 하위 장면을 예약하도록 하겠습니다.");
                    SceneManager.ReserveChildScene(new SwallowChildScene());
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("아무 키를 누르면 장면이 종료됩니다.");
            ConsoleEx.WaitKeyWithCursor();
            return;
        }
    }
}
