﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.UI
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Option : OptionBase, ITable
    {
        private int rowCount = 1;

        /// <summary>
        /// 옵션을 보여주며 유저가 선택한 옵션의 번호를 가져옵니다.
        /// </summary>
        /// <returns>유저가 선택한 번호입니다.</returns>
        public int Select()
        {
            while (true)
            {
                Show();

                var input = Console.ReadKey();
                // 제어권을 반환합니다.
                if (input.Key == ConsoleKey.Enter) break;
                Input(input);
            }
            return Result;
        }

        /// <summary>
        /// 옵션과 입력 폼을 보여주며 유저가 선택한 옵션의 번호를 가져옵니다.
        /// </summary>
        /// <returns>유저가 선택한 번호입니다.</returns>
        public int SelectWithInputForm()
        {
            var inputForm = new InputForm(InputForm.Types.Netural)
            {
                Result = Result.ToString()
            };

            // 결과 변경 감지용 변수
            int previousOptionResult = Result;
            string previousInputFormResult = inputForm.Result;

            while (true)
            {
                Show();
                Console.Write('>');
                inputForm.SetBasePosition();
                inputForm.Show();

                var input = Console.ReadKey();
                // 제어권을 반환합니다.
                if (input.Key == ConsoleKey.Enter) break;

                Input(input);
                inputForm.Input(input);
                // 입력 폼에 값 설정
                if (previousOptionResult != Result)
                {
                    inputForm.Result = Result.ToString();
                }
                else if (previousInputFormResult != inputForm.Result)
                {
                    if (int.TryParse(inputForm.Result, out int inputFormResult))
                        Result = inputFormResult;
                }
                previousOptionResult = Result;
                previousInputFormResult = inputForm.Result;
            }

            return Result;
        }

        /// <summary>
        /// 옵션으로 출력될 텍스트의 최소 폭을 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 출력되는 텍스트의 폭이 이 값보다 크면 가장 큰 값으로 재설정됩니다.
        /// </remarks>
        public int TextWidth { get; set; }

        /// <summary>
        /// 옵션으로 출력될 텍스트 열의 갯수를 가져오거나 설정합니다.
        /// </summary>
        public int RowCount { get => rowCount; set => rowCount = value > 0 ? value : 1; }

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
        /// 키 입력을 처리합니다.
        /// </summary>
        /// <param name="keyInfo"></param>
        public override void Input(ConsoleKeyInfo keyInfo)
        {

            void AddCurrentSelectedIndex(int add)
            {
                Result = (Result + add + Items.Count) % Items.Count;
            }

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    AddCurrentSelectedIndex(-RowCount);
                    break;
                case ConsoleKey.DownArrow:
                    AddCurrentSelectedIndex(+RowCount);
                    break;
                case ConsoleKey.LeftArrow:
                    AddCurrentSelectedIndex(-1);
                    break;
                case ConsoleKey.RightArrow:
                    AddCurrentSelectedIndex(+1);
                    break;
            }
        }

        /// <summary>
        /// 요소를 출력합니다.
        /// </summary>
        public override void Show()
        {
            Console.SetCursorPosition(BaseLeft, BaseTop);
            for (int i = 0; i < Items.Count;)
            {
                if (BaseLeft > 0)
                    Console.CursorLeft = BaseLeft;
                for (int j = 0; j < RowCount && i < Items.Count; j++, i++)
                {
                    if (i == Result)
                    {
                        Console.Write(SGR.Negative);
                        ConsoleEx.BlockWrite($"{i}.{Items[i]}", TextAlign.Left, TextWidth);
                        Console.Write(SGR.Positive);
                    }
                    else
                    {
                        ConsoleEx.BlockWrite($"{i}.{Items[i]}", TextAlign.Left, TextWidth);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
