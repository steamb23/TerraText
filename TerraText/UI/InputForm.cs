using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.UI
{
    /// <summary>
    /// 입력 폼을 나타냅니다.
    /// </summary>
    public sealed class InputForm : UIBase, IInputtable
    {
        /// <summary>
        /// 입력 폼에서 문자열을 읽습니다.
        /// </summary>
        /// <param name="maxWidth">입력받을 문자열의 최대 폭입니다.</param>
        /// <returns>입력받은 문자열을 반환합니다.</returns>
        public static string ReadLineNormal(int maxWidth = int.MaxValue) => new InputForm(Types.Normal, maxWidth).ReadLine();

        /// <summary>
        /// 입력 폼에서 실수 형식의 문자열을 읽습니다.
        /// </summary>
        /// <param name="maxWidth">입력받을 문자열의 최대 폭입니다.</param>
        /// <returns>입력받은 문자열을 반환합니다.</returns>
        public static string ReadLineNumber(int maxWidth = int.MaxValue) => new InputForm(Types.Number, maxWidth).ReadLine();

        /// <summary>
        /// 입력 폼에서 정수 형식의 문자열을 읽습니다.
        /// </summary>
        /// <param name="maxWidth">입력받을 문자열의 최대 폭입니다.</param>
        /// <returns>입력받은 문자열을 반환합니다.</returns>
        public static string ReadLineInteger(int maxWidth = int.MaxValue) => new InputForm(Types.Integer, maxWidth).ReadLine();

        /// <summary>
        /// 입력 폼에서 자연수 형식의 문자열을 읽습니다.
        /// </summary>
        /// <param name="maxWidth">입력받을 문자열의 최대 폭입니다.</param>
        /// <returns>입력받은 문자열을 반환합니다.</returns>
        public static string ReadLineNetural(int maxWidth = int.MaxValue) => new InputForm(Types.Netural, maxWidth).ReadLine();

        /// <summary>
        /// 입력 폼에서 문자열을 읽으며 입력 내용을 표시하지 않습니다.
        /// </summary>
        /// <param name="maxWidth">입력받을 문자열의 최대 폭입니다.</param>
        /// <returns>입력받은 문자열을 반환합니다.</returns>
        public static string ReadLinePassword(int maxWidth = int.MaxValue) => new InputForm(Types.Password, maxWidth).ReadLine();

        /// <summary>
        /// 입력 폼에서 문자열을 읽습니다.
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
        {
            var cursorVisible = Console.CursorVisible;
            Console.CursorVisible = true;
            while (!IsComplete)
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

        /// <summary>
        /// 입력받을 문자열의 최대폭입니다.
        /// </summary>
        public int MaxWidth { get; set; }
        private int textWidth;
        private string result = "";

        /// <summary>
        /// 입력된 결과를 가져옵니다.
        /// </summary>
        public string Result
        {
            get => result;
            set
            {
                stringBuilder = new StringBuilder(value);
                result = value;
            }
        }
        /// <summary>
        /// 입력이 완료되었는지에 대한 여부를 가져옵니다.
        /// </summary>
        public bool IsComplete { get; set; } = false;

        private StringBuilder stringBuilder = new StringBuilder();

        /// <summary>
        /// 입력을 필터링할 방법과 입력받을 문자열의 최대폭을 사용해 <see cref="InputForm"/>의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="type">입력을 필터링할 방법입니다.</param>
        /// <param name="maxWidth">입력받을 문자열의 최대폭</param>
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

        /// <summary>
        /// 지정된 콘솔 키 정보를 입력 폼에 입력합니다.
        /// </summary>
        /// <param name="keyInfo">입력할 콘솔 키 정보입니다.</param>
        public void Input(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    IsComplete = true;
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
            result = stringBuilder.ToString();
            // 글자 제한 처리
            var text = Type != Types.Password ? Result : new string('*', Result.Length);

            var drawTextWidth = UnicodeWidth.GetWidth(text);
            var currentTextWidth = UnicodeWidth.GetWidth(Result);
            var finalCursorPos = BaseLeft + Math.Max(drawTextWidth, 0);
            if (finalCursorPos >= Console.BufferWidth || currentTextWidth > MaxWidth)
            {
                Backspace();
                result = stringBuilder.ToString();
            }
        }

        /// <summary>
        /// 입력된 문자열을 출력합니다.
        /// </summary>
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
