using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.UI
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Option : OptionBase
    {
        /// <summary>
        /// 옵션으로 출력될 텍스트의 최소 폭입니다.
        /// </summary>
        /// <remarks>
        /// 출력되는 텍스트의 폭의 이 값보다 크면 가장 큰 값으로 재설정됩니다.
        /// </remarks>
        public int TextWidth { get; set; }

        /// <summary>
        /// 옵션 출력시 입력 폼을 포함할지에 대한 여부를 가져오거나 설정합니다.
        /// </summary>
        public bool HasInputForm { get; set; } = true;

        /// <summary>
        /// 옵션으로 출력될 텍스트의 목록으로 <see cref="Option"/> 클래스의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="items">옵션으로 출력될 텍스트의 목록입니다.</param>
        public Option(params string[] items) : base(items)
        {
            // 최대 크기 계산
            foreach (var item in items)
            {
                var itemTextWidth = UnicodeWidth.GetWidth(item);
                if (TextWidth < itemTextWidth)
                    TextWidth = itemTextWidth;
            }
        }

        /// <summary>
        /// 옵션으로 출력될 텍스트의 목록과 텍스트의 길이로 <see cref="Option"/> 클래스의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="textWidth">옵션으로 출력될 텍스트의 최대 폭입니다.</param>
        /// <param name="items">옵션으로 출력될 텍스트의 목록입니다.</param>
        public Option(int textWidth, params string[] items) : this(items)
        {
            if (TextWidth < textWidth)
                TextWidth = textWidth;
        }

        /// <summary>
        /// 옵션으로 출력될 텍스트의 목록 텍스트의 길이, 입력 폼을 포함할지에 대한 여부로 <see cref="Option"/> 클래스의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="textWidth">옵션으로 출력될 텍스트의 최대 폭입니다.</param>
        /// <param name="hasInputForm">입력 폼을 포함할지에 대한 여부를 나타내는 부울 값입니다.</param>
        /// <param name="items">옵션으로 출력될 텍스트의 목록입니다.</param>
        public Option(int textWidth, bool hasInputForm, params string[] items) : this(textWidth, items)
        {
            HasInputForm = hasInputForm;
        }

        /// <summary>
        /// 요소를 출력하고 기능을 수행합니다.
        /// </summary>
        public override void Show()
        {
            int currentSelectedIndex = Result;
            bool isSelected = false;
            bool isCursorVisible = Console.CursorVisible;
            var inputForm = new InputForm(InputForm.Types.Netural);

            void AddCurrentSelectedIndex(int add)
            {
                currentSelectedIndex = (currentSelectedIndex + add + Items.Count) % Items.Count;
            }

            while (!isSelected)
            {
                Console.CursorVisible = isCursorVisible;
                ShowItems(currentSelectedIndex);
                Console.Write('>');
                Console.CursorVisible = HasInputForm;
                if (HasInputForm)
                {
                    inputForm.SetBasePosition();
                    inputForm.Show();
                }

                ConsoleEx.ReadFlush();
                var inputKey = Console.ReadKey(true);
                switch (inputKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        AddCurrentSelectedIndex(-1);
                        break;
                    case ConsoleKey.DownArrow:
                        AddCurrentSelectedIndex(+1);
                        break;
                    case ConsoleKey.Enter:
                        if (int.TryParse(inputForm.Result, out int inputNumber))
                        {
                            if (inputNumber <= Items.Count && inputNumber > 0)
                            {
                                Result = inputNumber - 1;
                                isSelected = true;
                            }
                        }
                        else
                        {
                            Result = currentSelectedIndex;
                            isSelected = true;
                        }
                        break;
                    default:
                        if (HasInputForm) inputForm.Input(inputKey);
                        break;
                }
            }
            Console.CursorVisible = isCursorVisible;
        }
        private void ShowItems(int currentSelectedIndex)
        {
            Console.SetCursorPosition(BaseLeft, BaseTop);
            for (int i = 0; i < Items.Count; i++)
            {
                if (BaseLeft > 0)
                    Console.CursorLeft = BaseLeft;
                if (i == currentSelectedIndex)
                {
                    Console.Write(SGR.Negative);
                    ConsoleEx.BlockWrite($"{i+1}.{Items[i]}", TextAlign.Left, TextWidth);
                    Console.Write(SGR.Positive);
                    Console.WriteLine();
                }
                else
                {
                    ConsoleEx.BlockWrite($"{i+1}.{Items[i]}", TextAlign.Left, TextWidth);
                    Console.WriteLine();
                }
            }
        }
    }
}
