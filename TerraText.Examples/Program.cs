using System;
using System.Threading;

namespace TerraText.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var option = new UI.Option(30, "색상 변경", "글꼴 변경", "이스케이프 시퀀스", "정렬 출력", "InputForm")
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
                option.Show();
                switch (option.Result+1)
                {
                    case 1:
                        Example.ColorChange();
                        break;
                    case 2:
                        Example.FontChange();
                        break;
                    case 3:
                        Example.EscapeSequenceExample();
                        break;
                    case 4:
                        Example.BlockWriteExample();
                        break;
                    case 5:
                        Example.InputFormExample();
                        break;
                }
            }

            //#region 기본 출력 테스트
            //Console.WriteLine("기본 출력 테스트입니다.");
            //ConsoleEx.WaitKey();
            //Console.WriteLine();
            //#endregion

            //#region 다국어 출력 테스트
            //Console.WriteLine("こんにちは。기본 출력 테스트입니다.");
            //ConsoleEx.WaitKey();
            //Console.WriteLine();
            //#endregion

            //#region 컬러 변경 테스트
            //#endregion

            //#region 오토 컬러 변경 테스트
            //ConsoleEx.SetCurrentOffsetPosition();
            //for (int i = 0; i < byte.MaxValue; i++)
            //{
            //    ConsoleEx.AutoForegroundPaletteColor = System.Drawing.Color.FromArgb(i, i, i);
            //    ConsoleEx.AutoBackgroundPaletteColor = System.Drawing.Color.FromArgb(byte.MaxValue - 1, byte.MaxValue - i, byte.MaxValue);
            //    ConsoleEx.OffsetTop = 0;
            //    Console.WriteLine("오토 컬러 변경 테스트입니다.");
            //    ConsoleEx.AutoForegroundPaletteColor = System.Drawing.Color.FromArgb(byte.MaxValue - i, 0, 0);
            //    ConsoleEx.AutoBackgroundPaletteColor = System.Drawing.Color.FromArgb(i, 0, 0);
            //    Console.WriteLine("빨간색!");
            //    Thread.Sleep(5);
            //}
            //// 여기서 바로 ConsoleEx.SetDefaultColor()를 호출할 경우 위의 출력 중인 내용의 색상이 오작동하는 현상이 있을 수 있습니다.
            //// 적절한 트릭을 이용하여 차후에 호출하도록 하십시오.
            //Thread.Sleep(100); // 오작동 현상 방지용 텀
            //ConsoleEx.SetDefaultColor();
            //// Sleep 후 SetDefaultColor 호출시 이미 그려진 문자의 색상은 유지되지만 콘솔창의 리사이즈가 발생하면 다시 그려지며 초기화될 수 있습니다.

            //// 기본컬러 (Black, Gray)로 회귀.
            ////Console.ResetColor();
            //Console.WriteLine("오토 컬러 변경 테스트가 끝났습니다.");
            //ConsoleEx.ReadFlush();
            //ConsoleEx.WaitKey();
            //Console.WriteLine();
            //#endregion

            //#region 글꼴 조회 테스트
            //Console.WriteLine($"현재 설정된 글꼴은 '{ConsoleEx.FontName}'입니다.");
            //ConsoleEx.WaitKey();
            //Console.WriteLine();
            //#endregion

            //#region 글꼴 설정 테스트
            //// 글꼴 변경시 화면에 표시된 모든 문자에 적용이 되며, 이전에 출력된 텍스트들도 현재 팔레트를 사용하여 다시 그리게됩니다.
            //// 가능하면 변경 전이나 변경 후 Console.Clear()를 호출하는 것을 추천합니다.
            //Console.WriteLine($"글꼴 설정 테스트입니다. 글꼴 설치여부도 동시에 확인합니다.");
            //Console.Write('>');
            //string input = ConsoleEx.ReadLineWithCursor();
            //if (string.IsNullOrEmpty(input))
            //{
            //    input = "맑은 고딕";
            //    Console.WriteLine($"아무 것도 입력하지 않아 '{input}'(으)로 변경됩니다.");
            //    ConsoleEx.WaitKey();
            //}
            //if (!ConsoleEx.IsInstalledFont(input))
            //{
            //    Console.WriteLine($"'{input}'은 설치되지 않은 글꼴입니다. 시스템 기본 글꼴로 변경됩니다.");
            //    ConsoleEx.WaitKey();
            //}
            ////Console.Clear();
            //ConsoleEx.FontName = input;
            //Console.WriteLine($"'{ConsoleEx.FontName}'(으)로 변경되었습니다.");
            //ConsoleEx.WaitKey();
            //Console.WriteLine();
            //#endregion
        }
    }
}
