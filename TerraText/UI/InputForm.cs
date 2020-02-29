using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.UI
{
    /// <summary>
    /// 입력 폼을 나타냅니다.
    /// </summary>
    public sealed class InputForm : UIBase
    {
        public static string ReadLineNormal(int maxWidth = int.MaxValue) => new InputForm(Types.Normal, maxWidth).ReadLine();
        public static string ReadLineNumber(int maxWidth = int.MaxValue) => new InputForm(Types.Number, maxWidth).ReadLine();
        public static string ReadLineInteger(int maxWidth = int.MaxValue) => new InputForm(Types.Integer, maxWidth).ReadLine();
        public static string ReadLinePassword(int maxWidth = int.MaxValue) => new InputForm(Types.Password, maxWidth).ReadLine();

        public string ReadLine()
        {
            var cursorVisible = Console.CursorVisible;
            Console.CursorVisible = true;
            while (IsInput)
            {
                Input(Console.ReadKey(true));
                Show();
            }
            Console.WriteLine();
            Console.CursorVisible = cursorVisible;

            return Result;
        }


        /// <summary>
        /// 입력 폼이 입력을 필터링 하는 방법을 지정합니다.
        /// </summary>
        public enum Types
        {
            /// <summary>
            /// 모든 문자를 입력할 수 있습니다.
            /// </summary>
            Normal,
            /// <summary>
            /// 실수만 입력할 수 있습니다.
            /// </summary>
            Number,
            /// <summary>
            /// 정수만 입력할 수 있습니다.
            /// </summary>
            Integer,
            /// <summary>
            /// 자연수만 입력할 수 있습니다.
            /// </summary>
            Netural,
            /// <summary>
            /// 입력값을 *문자로 표시합니다.
            /// </summary>
            Password
        }

        /// <summary>
        /// 입력 폼이 입력을 필터링 하는 방법을 가져옵니다.
        /// </summary>
        public Types Type { get; }

        public int MaxWidth { get; set; }
        private int textWidth;

        /// <summary>
        /// 입력된 결과를 가져옵니다.
        /// </summary>
        public string? Result { get; private set; }

        public bool IsInput { get; set; } = true;

        private StringBuilder stringBuilder = new StringBuilder();


        public InputForm(Types type = Types.Normal, int maxWidth = int.MaxValue)
        {
            MaxWidth = maxWidth;
            Type = type;
        }

        private void Backspace()
        {
            if (stringBuilder.Length > 0)
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }

        public void Input(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    IsInput = false;
                    break;
                case ConsoleKey.Backspace:
                    Backspace();
                    break;
                default:
                    var currentText = stringBuilder.ToString();
                    if (Type == Types.Number || Type == Types.Integer || Type == Types.Netural)
                    {
                        if (keyInfo.KeyChar >= '0' && keyInfo.KeyChar <= '9')
                        {
                            stringBuilder.Append(keyInfo.KeyChar);
                        }
                        else if (keyInfo.KeyChar == '-' && Type != Types.Netural && currentText.Length == 0)
                        {
                            stringBuilder.Append('-');
                        }
                        else if (keyInfo.KeyChar == '.' && Type == Types.Number)
                        {
                            if (!currentText.Contains('.'))
                                stringBuilder.Append('.');
                        }
                    }
                    else
                    {
                        stringBuilder.Append(keyInfo.KeyChar);
                    }
                    break;
            }
            Result = stringBuilder.ToString();
            // 글자 제한 처리
            var text = Type != Types.Password ? Result : new string('*', Result.Length);

            var drawTextWidth = UnicodeWidth.GetWidth(text);
            var currentTextWidth = UnicodeWidth.GetWidth(Result);
            var finalCursorPos = BaseLeft + Math.Max(drawTextWidth, 0);
            if (finalCursorPos >= Console.BufferWidth || currentTextWidth > MaxWidth)
            {
                Backspace();
                Result = stringBuilder.ToString();
            }
        }

        public override void Show()
        {
            if (Result != null)
            {
                var text = Type != Types.Password ? Result : new string('*', Result.Length);
                var drawTextWidth = UnicodeWidth.GetWidth(text);
                if (drawTextWidth > textWidth)
                    textWidth = drawTextWidth;
                Console.CursorLeft = BaseLeft;
                ConsoleEx.BlockWrite(text, TextAlign.Left, textWidth);
                Console.CursorLeft = BaseLeft + Math.Max(drawTextWidth, 0);
            }
        }

        //public override void Show()
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    bool defaultCursorVisible = Console.CursorVisible;
        //    Console.CursorVisible = true;
        //    void Backspace()
        //    {
        //        if (stringBuilder.Length > 0)
        //            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        //    }
        //    void ShowText(string text)
        //    {
        //        if (Type == Types.Password)
        //            text = new string('*', text.Length);
        //        var currentTextWidth = UnicodeWidth.GetWidth(text);
        //        if (currentTextWidth > TextWidth)
        //            TextWidth = currentTextWidth;
        //        Console.CursorLeft = BaseLeft;
        //        ConsoleEx.BlockWrite(text, TextAlign.Left, TextWidth);
        //        Console.CursorLeft = BaseLeft + UnicodeWidth.GetWidth(text);
        //    }

        //    bool isInput = true;
        //    while (isInput)
        //    {
        //        var input = Console.ReadKey(true);
        //        switch (input.Key)
        //        {
        //            case ConsoleKey.Enter:
        //                Result = stringBuilder.ToString();
        //                isInput = false;
        //                Console.WriteLine();
        //                Console.CursorVisible = defaultCursorVisible;
        //                continue;
        //            case ConsoleKey.Backspace:
        //                Backspace();
        //                ShowText(stringBuilder.ToString());
        //                continue;
        //        }

        //        if (Type == Types.Number)
        //        {
        //            if (input.KeyChar >= '0' && input.KeyChar <= '9')
        //            {
        //                stringBuilder.Append(input.KeyChar);
        //            }
        //        }
        //        else
        //        {
        //            stringBuilder.Append(input.KeyChar);
        //        }

        //        ShowText(stringBuilder.ToString());
        //    }
        //}
    }
}
