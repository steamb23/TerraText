﻿using System;
using System.Drawing;

namespace TerraText
{

    /// <summary>
    /// 시스템 콘솔과 호환되는 컬러 맵을 나타냅니다.
    /// </summary>
    /// <remarks>
    /// 시스템 콘솔 호환 컬러 맵 설정은 생성자 재정의를 이용합니다. 자세한 구현은 <see cref="ColorMaps.ModernConsoleColor"/>의 구현을 참조하세요.
    /// </remarks>
    public abstract class ColorMap
    {
        /// <summary>
        /// 기본 컬러 맵을 나타냅니다.
        /// </summary>
        /// <remarks>
        /// 초기 값은 <see cref="ColorMaps.ModernConsoleColor"/>로 설정됩니다.
        /// </remarks>
        public static class Default
        {
            static Default()
            {
                ColorMap = new ColorMaps.ModernConsoleColor();
            }

            /// <summary>
            /// 기본적으로 사용하는 컬러맵을 설정하거나 가져옵니다.
            /// </summary>
            public static ColorMap ColorMap
            {
                get;
                set;
            }

            /// <summary>
            /// 현재 콘솔 색상 팔레트를 현재 기본값으로 초기화합니다.
            /// </summary>
            public static void SetConsoleDefault() => ColorMap.SetConsoleDefault();

            /// <summary>
            /// <see cref="ConsoleColor.Black"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color Black => ColorMap.Black;

            /// <summary>
            /// <see cref="ConsoleColor.DarkBlue"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color DarkBlue => ColorMap.DarkBlue;

            /// <summary>
            /// <see cref="ConsoleColor.DarkGreen"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color DarkGreen => ColorMap.DarkGreen;

            /// <summary>
            /// <see cref="ConsoleColor.DarkCyan"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color DarkCyan => ColorMap.DarkCyan;

            /// <summary>
            /// <see cref="ConsoleColor.DarkRed"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color DarkRed => ColorMap.DarkRed;

            /// <summary>
            /// <see cref="ConsoleColor.DarkMagenta"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color DarkMagenta => ColorMap.DarkMagenta;

            /// <summary>
            /// <see cref="ConsoleColor.DarkYellow"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color DarkYellow => ColorMap.DarkYellow;

            /// <summary>
            /// <see cref="ConsoleColor.Gray"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color Gray => ColorMap.Gray;

            /// <summary>
            /// <see cref="ConsoleColor.DarkGray"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color DarkGray => ColorMap.DarkGray;

            /// <summary>
            /// <see cref="ConsoleColor.Blue"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color Blue => ColorMap.Blue;

            /// <summary>
            /// <see cref="ConsoleColor.Green"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color Green => ColorMap.Green;

            /// <summary>
            /// <see cref="ConsoleColor.Cyan"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color Cyan => ColorMap.Cyan;

            /// <summary>
            /// <see cref="ConsoleColor.Red"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color Red => ColorMap.Red;

            /// <summary>
            /// <see cref="ConsoleColor.Magenta"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color Magenta => ColorMap.Magenta;

            /// <summary>
            /// <see cref="ConsoleColor.Yellow"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color Yellow => ColorMap.Yellow;

            /// <summary>
            /// <see cref="ConsoleColor.White"/>에 대응되는 색상의 RGB 값을 가져옵니다.
            /// </summary>
            public static Color White => ColorMap.White;
        }

        /// <summary>
        /// 현재 콘솔 색상 팔레트를 이 객체의 내용으로 초기화합니다.
        /// </summary>
        public virtual void SetConsoleDefault()
        {
            ConsoleEx.SetPaletteColors(new Color[]
            {
                Black,
                DarkBlue,
                DarkGreen,
                DarkCyan,
                DarkRed,
                DarkMagenta,
                DarkYellow,
                Gray,
                DarkGray,
                Blue,
                Green,
                Cyan,
                Red,
                Magenta,
                Yellow,
                White
            });
        }

        /// <summary>
        /// <see cref="ConsoleColor.Black"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color Black
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.DarkBlue"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color DarkBlue
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.DarkGreen"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color DarkGreen
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.DarkCyan"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color DarkCyan
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.DarkRed"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color DarkRed
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.DarkMagenta"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color DarkMagenta
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.DarkYellow"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color DarkYellow
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.Gray"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color Gray
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.DarkGray"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color DarkGray
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.Blue"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color Blue
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.Green"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color Green
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.Cyan"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color Cyan
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.Red"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color Red
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.Magenta"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color Magenta
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.Yellow"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color Yellow
        {
            get;
            protected set;
        }

        /// <summary>
        /// <see cref="ConsoleColor.White"/>에 대응되는 색상의 RGB 값을 설정하거나 가져옵니다.
        /// </summary>
        public Color White
        {
            get;
            protected set;
        }
    }
}
