﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ESC = TerraText.EscapeSequence;
namespace TerraText.Examples
{
    static class Example
    {
        public static void TestColor()
        {
            //Console.WriteLine("[컬러 테스트]");
            Console.CursorTop = 4;
            Console.ResetColor();
            for (var i = 0; i < 16; i++)
            {
                Console.Write(i.ToString("00"));
                Console.Write(':');
                Console.BackgroundColor = (ConsoleColor)i;

                for (var j = 0; j < 16; j++)
                {
                    Console.ForegroundColor = (ConsoleColor)j;
                    Console.Write(j.ToString(" 00 "));
                }

                Console.ResetColor();
                Console.WriteLine();
            }
        }
        public static void ColorChange()
        {
            Console.Clear();

            Console.WriteLine("기본 컬러 출력입니다.");
            TestColor();
            ConsoleEx.WaitKeyWithCursor();
            Console.Clear();
            //----------

            Console.WriteLine("현재 폰트를 파랗게 바꾸겠습니다.");
            TestColor();
            ConsoleEx.WaitKeyWithCursor();
            Console.Clear();
            //----------

            ConsoleEx.ForegroundPaletteColor = ColorMap.Default.Blue;

            Console.WriteLine("ConsoleEx.ForegroundPaletteColor = ColorMaps.ColorMap.Default.Blue;");
            TestColor();
            ConsoleEx.WaitKeyWithCursor();
            Console.Clear();
            //----------

            Console.WriteLine("다음은 1번과 2번 팔레트의 컬러를 각각 (40,40,40), (100, 100, 100)으로 수정해보겠습니다.");
            TestColor();
            ConsoleEx.WaitKeyWithCursor();
            Console.Clear();
            //----------

            ConsoleEx.SetPaletteColor(System.Drawing.Color.FromArgb(40, 40, 40), 1);
            ConsoleEx.SetPaletteColor(System.Drawing.Color.FromArgb(100, 100, 100), 2);

            Console.WriteLine("ConsoleEx.SetPaletteColor(System.Drawing.Color.FromArgb(40, 40, 40), 1);");
            Console.WriteLine("ConsoleEx.SetPaletteColor(System.Drawing.Color.FromArgb(100, 100, 100), 2);");
            TestColor();
            ConsoleEx.WaitKeyWithCursor();
            Console.Clear();
            //----------

            Console.WriteLine("다음은 기본 컬러로 바꿉니다.");
            TestColor();
            ConsoleEx.WaitKeyWithCursor();
            Console.Clear();
            //----------

            ConsoleEx.SetDefaultColor();

            Console.WriteLine("ConsoleEx.SetDefaultColor();");
            TestColor();
            ConsoleEx.WaitKeyWithCursor();
            Console.Clear();
            //----------

            Console.WriteLine("다음은 연속 컬러 변경 예제입니다.");
            TestColor();
            ConsoleEx.WaitKeyWithCursor();
            Console.Clear();
            //----------

            ConsoleEx.ReadFlush();
            for (int i = 0; i < byte.MaxValue; i++)
            {
                if (ConsoleEx.IsUserSkip())
                {
                    Console.WriteLine("스킵되었습니다.");
                    break;
                }
                Console.CursorTop = 0;
                Console.WriteLine("아무 키나 입력하면 스킵됩니다.");
                ConsoleEx.AutoForegroundPaletteColor = System.Drawing.Color.FromArgb(i, i, i);
                ConsoleEx.AutoBackgroundPaletteColor = System.Drawing.Color.FromArgb(byte.MaxValue - i, byte.MaxValue - i, byte.MaxValue - i);
                Console.WriteLine("다람쥐 헌 쳇바퀴에 타고파");
                ConsoleEx.AutoForegroundPaletteColor = System.Drawing.Color.FromArgb(byte.MaxValue - i, 0, 0);
                ConsoleEx.AutoBackgroundPaletteColor = System.Drawing.Color.FromArgb(i, 0, 0);
                Console.WriteLine("The quick brown fox jumps over a lazy dog.");
                TestColor();
                Thread.Sleep(10);
            }
            Console.WriteLine("연속 컬러 변경이 끝났습니다.");
            ConsoleEx.WaitKeyWithCursor();
            Console.Clear();
            //----------

            Console.WriteLine("색상 변경 예제는 여기까지입니다.");
            TestColor();
            ConsoleEx.WaitKeyWithCursor();
            Console.Clear();
            //----------
        }

        public static void FontChange()
        {
            Console.Clear();
            Console.WriteLine($"현재 설정된 글꼴은 '{ConsoleEx.FontName}'입니다.");
            ConsoleEx.WaitKeyWithCursor();
            Console.WriteLine();

            // 글꼴 변경시 화면에 표시된 모든 문자에 적용이 되며, 이전에 출력된 텍스트들도 현재 팔레트를 사용하여 다시 그리게됩니다.
            // 가능하면 변경 전이나 변경 후 Console.Clear()를 호출하는 것을 추천합니다.
            Console.WriteLine($"글꼴 설정 테스트입니다. 글꼴 설치여부도 동시에 확인합니다.");
            Console.Write('>');
            string input = ConsoleEx.ReadLineWithCursor();
            if (string.IsNullOrEmpty(input))
            {
                input = "맑은 고딕";
                Console.WriteLine($"아무 것도 입력하지 않아 '{input}'(으)로 변경됩니다.");
                ConsoleEx.WaitKeyWithCursor();
            }
            if (!ConsoleEx.IsInstalledFont(input))
            {
                Console.WriteLine($"'{input}'은 설치되지 않은 글꼴입니다. 시스템 기본 글꼴로 변경됩니다.");
                ConsoleEx.WaitKeyWithCursor();
            }
            //Console.Clear();
            ConsoleEx.FontName = input;
            Console.WriteLine($"'{ConsoleEx.FontName}'(으)로 변경되었습니다.");
            ConsoleEx.WaitKeyWithCursor();
            Console.WriteLine();
        }

        public static void EscapeSequenceExample()
        {
            Console.Clear();
            Console.WriteLine($"윈도우 10 버전 1511의 콘솔부터 지원하기 시작한 {SGR.Underline}이스케이프 시퀀스{SGR.NoUnderline}를 간편하게 사용할 수 있습니다.");
            ConsoleEx.WaitKeyWithCursor();
            Console.WriteLine($"{SGR.Underline}언더라인{SGR.Default}, {SGR.DarkRed}색상 변경{SGR.Default}, {SGR.Negative}전경색 배경색 치환{SGR.Default} 등을 출력과 함께 동시 처리할 수 있습니다.");
            ConsoleEx.WaitKeyWithCursor();
        }
    }
}
