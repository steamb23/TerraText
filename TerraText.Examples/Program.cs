using System;
using System.Threading;

namespace TerraText.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var option = new UI.Option(30, "색상 변경", "글꼴 변경", "이스케이프 시퀀스", "정렬 출력", "InputForm", "장면 과 장면관리자")
            {
                HasInputForm = true,
                RowCount = 3
            };
            while (true)
            {
                Console.CursorVisible = false;
                ConsoleEx.SetDefaultColor();
                Console.Clear();

                Console.WriteLine("실행할 예제를 선택하세요.");
                option.SetBasePosition();
                switch (option.SelectWithInputForm())
                {
                    case 0:
                        Example.ColorChange();
                        break;
                    case 1:
                        Example.FontChange();
                        break;
                    case 2:
                        Example.EscapeSequenceExample();
                        break;
                    case 3:
                        Example.BlockWriteExample();
                        break;
                    case 4:
                        Example.InputFormExample();
                        break;
                    case 5:
                        Example.SceneExample();
                        break;
                }
            }
        }
    }
}
