using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText
{
    /// <summary>
    /// Windows 10 version 1511부터 지원하는 이스케이프 시퀀스를 나타냅니다.
    /// </summary>
    /// <remarks>
    /// <para>이 클래스에서는 텍스트 포매팅에 필요한 SGR(그래픽 변환 선택)에 대한 편의 함수만 구현하고 있습니다. 다른 윈도우 콘솔 호환 이스케이프 시퀀스에 관해서는 'https://docs.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences'를 참조하세요.</para>
    /// <para>Windows 10 version 1511 이하의 윈도우 콘솔에서는 이스케이프 시퀀스에 반응하지 않기 때문에 사용자에게 적절히 안내하거나 다른 방법을 찾아야합니다.</para>
    /// </remarks>
    public static class EscapeSequence
    {
        static EscapeSequence()
        {
            ConsoleEx.ConsoleMode |= ConsoleMode.EnableVirtualTerminalProcessing;
        }

        public static bool IsSupported => ConsoleEx.ConsoleMode.HasFlag(ConsoleMode.EnableVirtualTerminalProcessing);

        /// <summary>
        /// ASCII와 Unicode의 이스케이프 문자입니다.
        /// </summary>
        public const char EscapeChar = '\u001b';

        /// <summary>
        /// SGR의 접미사입니다.
        /// </summary>
        public const char SelectGraphicsReditionSuffix = 'm';

        /// <summary>
        /// SGR(그래픽 변환 선택)의 파라미터를 나열합니다. 윈도우 콘솔과 호환되지 않는 요소는 제외되어 있습니다.
        /// </summary>
        public enum SGRParameter
        {
            /// <summary>
            /// 수정하기 전에 모든 특성을 기본 상태로 반환합니다.
            /// </summary>
            Default = 0,
            /// <summary>
            /// 전경 색상에 밝기/강도 플래그를 적용합니다.
            /// </summary>
            Bright = 1,
            /// <summary>
            /// 밑줄을 추가합니다.
            /// </summary>
            Underline = 4,
            /// <summary>
            /// 밑줄을 제거합니다.
            /// </summary>
            NoUnderline = 24,
            /// <summary>
            /// 전경색과 배경색을 치환합니다.
            /// </summary>
            Negative = 7,
            /// <summary>
            /// 치환된 전경색과 배경색을 정상화합니다.
            /// </summary>
            Positive = 27,
            /// <summary>
            /// 전경색으로 검은색을 적용합니다.
            /// </summary>
            ForegroundBlack = 30,
            /// <summary>
            /// 전경색으로 붉은색을 적용합니다.
            /// </summary>
            ForegroundRed = 31,
            /// <summary>
            /// 전경색으로 초록색을 적용합니다.
            /// </summary>
            ForegroundGreen = 32,
            /// <summary>
            /// 전경색으로 노란색을 적용합니다.
            /// </summary>
            ForegroundYellow = 33,
            /// <summary>
            /// 전경색으로 파란색을 적용합니다.
            /// </summary>
            ForegroundBlue = 34,
            /// <summary>
            /// 전경색으로 마젠타를 적용합니다.
            /// </summary>
            ForegroundMagenta = 35,
            /// <summary>
            /// 전경색으로 시안을 적용합니다.
            /// </summary>
            ForegroundCyan = 36,
            /// <summary>
            /// 전경색으로 하얀색을 적용합니다.
            /// </summary>
            ForegroundWhite = 37,
            ///// <summary>
            ///// 전경색으로 확장 색상 값을 적용합니다.
            ///// </summary>
            //ForegroundExtended = 38,
            /// <summary>
            /// 전경색을 기본값으로 되돌립니다.
            /// </summary>
            ForegroundDefault = 39,
            /// <summary>
            /// 배경색으로 검은색을 적용합니다.
            /// </summary>
            BackgroundBlack = 40,
            /// <summary>
            /// 배경색으로 붉은색을 적용합니다.
            /// </summary>
            BackgroundRed = 41,
            /// <summary>
            /// 배경색으로 초록색을 적용합니다.
            /// </summary>
            BackgroundGreen = 42,
            /// <summary>
            /// 배경색으로 노란색을 적용합니다.
            /// </summary>
            BackgroundYellow = 43,
            /// <summary>
            /// 배경색으로 파란색을 적용합니다.
            /// </summary>
            BackgroundBlue = 44,
            /// <summary>
            /// 배경색으로 마젠타를 적용합니다.
            /// </summary>
            BackgroundMagenta = 45,
            /// <summary>
            /// 배경색으로 시안을 적용합니다.
            /// </summary>
            BackgroundCyan = 46,
            /// <summary>
            /// 배경색으로 하얀색을 적용합니다.
            /// </summary>
            BackgroundWhite = 47,
            ///// <summary>
            ///// 배경색으로 확장 색상 값을 적용합니다.
            ///// </summary>
            //BackgroundExtended = 48,
            /// <summary>
            /// 배경색을 기본값으로 되돌립니다.
            /// </summary>
            BackgroundDefault = 49,
            /// <summary>
            /// 전경색으로 밝은 검은색을 적용합니다.
            /// </summary>
            BrightForegroundBlack = 90,
            /// <summary>
            /// 전경색으로 밝은 붉은색을 적용합니다.
            /// </summary>
            BrightForegroundRed = 91,
            /// <summary>
            /// 전경색으로 밝은 초록색을 적용합니다.
            /// </summary>
            BrightForegroundGreen = 92,
            /// <summary>
            /// 전경색으로 밝은 노란색을 적용합니다.
            /// </summary>
            BrightForegroundYellow = 93,
            /// <summary>
            /// 전경색으로 밝은 파란색을 적용합니다.
            /// </summary>
            BrightForegroundBlue = 94,
            /// <summary>
            /// 전경색으로 밝은 마젠타를 적용합니다.
            /// </summary>
            BrightForegroundMagenta = 95,
            /// <summary>
            /// 전경색으로 밝은 시안을 적용합니다.
            /// </summary>
            BrightForegroundCyan = 96,
            /// <summary>
            /// 전경색으로 밝은 하얀색을 적용합니다.
            /// </summary>
            BrightForegroundWhite = 97,
            /// <summary>
            /// 배경색으로 밝은 검은색을 적용합니다.
            /// </summary>
            BrightBackgroundBlack = 100,
            /// <summary>
            /// 배경색으로 밝은 붉은색을 적용합니다.
            /// </summary>
            BrightBackgroundRed = 101,
            /// <summary>
            /// 배경색으로 밝은 초록색을 적용합니다.
            /// </summary>
            BrightBackgroundGreen = 102,
            /// <summary>
            /// 배경색으로 밝은 노란색을 적용합니다.
            /// </summary>
            BrightBackgroundYellow = 103,
            /// <summary>
            /// 배경색으로 밝은 파란색을 적용합니다.
            /// </summary>
            BrightBackgroundBlue = 104,
            /// <summary>
            /// 배경색으로 밝은 마젠타를 적용합니다.
            /// </summary>
            BrightBackgroundMagenta = 105,
            /// <summary>
            /// 배경색으로 밝은 시안을 적용합니다.
            /// </summary>
            BrightBackgroundCyan = 106,
            /// <summary>
            /// 배경색으로 밝은 하얀색을 적용합니다.
            /// </summary>
            BrightBackgroundWhite = 107,
        }
        public static string RemoveSequence(string value)
        {
            var stringBuilder = new StringBuilder();
            bool escapeSequence = false;
            for(var i = 0; i < value.Length; i++)
            {
                var character = value[i];
                if (escapeSequence)
                {
                    // 특정 문자를 만날 때까지 넘김
                    switch (character)
                    {
                        case 'm':
                            escapeSequence = false;
                            break;
                    }
                }
                else
                {
                    if (character == EscapeChar)
                        escapeSequence = true;
                    else
                        stringBuilder.Append(character);
                }
            }
            return stringBuilder.ToString();
        }

        public static string SGR(int param)
        {
            // \u001b[<n>m
            return "\u001b[" + param + "m";
        }

        public static string SGR(SGRParameter param) => SGR((int)param);
    }

    /// <summary>
    /// SGR(그래픽 변환 선택)에 빠른 접근을 위한 유틸리티입니다. 일부는 축약되어 표현되며 자세한 내용은 설명(remarks)을 참조하세요.
    /// </summary>
    /// <remarks>
    /// <para>Foreground는 색 명칭만 쓰고 Background는 마지막에 _(언더바)를 붙입니다. 색 명칭은 <see cref="ConsoleColor"/>를 따릅니다.</para>
    /// </remarks>
    public static class SGR
    {
        /// <summary>
        /// 모든 특성을 기본 상태로 되돌립니다.
        /// </summary>
        public readonly static string Default = EscapeSequence.SGR(EscapeSequence.SGRParameter.Default);
        /// <summary>
        /// 밑줄을 추가합니다.
        /// </summary>
        public readonly static string Underline = EscapeSequence.SGR(EscapeSequence.SGRParameter.Underline);
        /// <summary>
        /// 밑줄을 제거합니다.
        /// </summary>
        public readonly static string NoUnderline = EscapeSequence.SGR(EscapeSequence.SGRParameter.NoUnderline);
        /// <summary>
        /// 전경색과 배경색을 치환합니다.
        /// </summary>
        public readonly static string Negative = EscapeSequence.SGR(EscapeSequence.SGRParameter.Negative);
        /// <summary>
        /// 전경색과 배경색을 치환합니다.
        /// </summary>
        public readonly static string Positive = EscapeSequence.SGR(EscapeSequence.SGRParameter.Positive);

        #region 색상 목록

        /// <summary>
        /// 전경색으로 검은색을 적용합니다.
        /// </summary>
        public readonly static string Black = EscapeSequence.SGR(EscapeSequence.SGRParameter.ForegroundBlack);
        /// <summary>
        /// 전경색으로 어두운 파란색을 적용합니다.
        /// </summary>
        public readonly static string DarkBlue = EscapeSequence.SGR(EscapeSequence.SGRParameter.ForegroundBlue);
        /// <summary>
        /// 전경색으로 어두운 초록색을 적용합니다.
        /// </summary>
        public readonly static string DarkGreen = EscapeSequence.SGR(EscapeSequence.SGRParameter.ForegroundGreen);
        /// <summary>
        /// 전경색으로 어두운 시안을 적용합니다.
        /// </summary>
        public readonly static string DarkCyan = EscapeSequence.SGR(EscapeSequence.SGRParameter.ForegroundCyan);
        /// <summary>
        /// 전경색으로 어두운 붉은색을 적용합니다.
        /// </summary>
        public readonly static string DarkRed = EscapeSequence.SGR(EscapeSequence.SGRParameter.ForegroundRed);
        /// <summary>
        /// 전경색으로 어두운 마젠타를 적용합니다.
        /// </summary>
        public readonly static string DarkMagenta = EscapeSequence.SGR(EscapeSequence.SGRParameter.ForegroundMagenta);
        /// <summary>
        /// 전경색으로 어두운 노란색을 적용합니다.
        /// </summary>
        public readonly static string DarkYellow = EscapeSequence.SGR(EscapeSequence.SGRParameter.ForegroundYellow);
        /// <summary>
        /// 전경색으로 회색을 적용합니다.
        /// </summary>
        public readonly static string Gray = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightForegroundWhite);
        /// <summary>
        /// 전경색으로 어두운 회색을 적용합니다.
        /// </summary>
        public readonly static string DarkGray = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightForegroundBlack);
        /// <summary>
        /// 전경색으로 파란색을 적용합니다.
        /// </summary>
        public readonly static string Blue = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightForegroundBlue);
        /// <summary>
        /// 전경색으로 초록색을 적용합니다.
        /// </summary>
        public readonly static string Green = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightForegroundGreen);
        /// <summary>
        /// 전경색으로 시안을 적용합니다.
        /// </summary>
        public readonly static string Cyan = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightForegroundCyan);
        /// <summary>
        /// 전경색으로 붉은색을 적용합니다.
        /// </summary>
        public readonly static string Red = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightForegroundRed);
        /// <summary>
        /// 전경색으로 마젠타를 적용합니다.
        /// </summary>
        public readonly static string Magenta = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightForegroundMagenta);
        /// <summary>
        /// 전경색으로 노란색을 적용합니다.
        /// </summary>
        public readonly static string Yellow = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightForegroundYellow);
        /// <summary>
        /// 전경색으로 하얀색을 적용합니다.
        /// </summary>
        public readonly static string White = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightForegroundWhite);
        /// <summary>
        /// 전경색을 기본값으로 되돌립니다.
        /// </summary>
        public readonly static string DefaultColor = EscapeSequence.SGR(EscapeSequence.SGRParameter.ForegroundDefault);

        /// <summary>
        /// 배경색으로 검은색을 적용합니다.
        /// </summary>
        public readonly static string Black_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BackgroundBlack);
        /// <summary>
        /// 배경색으로 어두운 파란색을 적용합니다.
        /// </summary>
        public readonly static string DarkBlue_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BackgroundBlue);
        /// <summary>
        /// 배경색으로 어두운 초록색을 적용합니다.
        /// </summary>
        public readonly static string DarkGreen_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BackgroundGreen);
        /// <summary>
        /// 배경색으로 어두운 시안을 적용합니다.
        /// </summary>
        public readonly static string DarkCyan_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BackgroundCyan);
        /// <summary>
        /// 배경색으로 어두운 붉은색을 적용합니다.
        /// </summary>
        public readonly static string DarkRed_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BackgroundRed);
        /// <summary>
        /// 배경색으로 어두운 마젠타를 적용합니다.
        /// </summary>
        public readonly static string DarkMagenta_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BackgroundMagenta);
        /// <summary>
        /// 배경색으로 어두운 노란색을 적용합니다.
        /// </summary>
        public readonly static string DarkYellow_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BackgroundYellow);
        /// <summary>
        /// 배경색으로 회색을 적용합니다.
        /// </summary>
        public readonly static string Gray_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightBackgroundWhite);
        /// <summary>
        /// 배경색으로 어두운 회색을 적용합니다.
        /// </summary>
        public readonly static string DarkGray_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightBackgroundBlack);
        /// <summary>
        /// 배경색으로 파란색을 적용합니다.
        /// </summary>
        public readonly static string Blue_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightBackgroundBlue);
        /// <summary>
        /// 배경색으로 초록색을 적용합니다.
        /// </summary>
        public readonly static string Green_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightBackgroundGreen);
        /// <summary>
        /// 배경색으로 시안을 적용합니다.
        /// </summary>
        public readonly static string Cyan_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightBackgroundCyan);
        /// <summary>
        /// 배경색으로 붉은색을 적용합니다.
        /// </summary>
        public readonly static string Red_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightBackgroundRed);
        /// <summary>
        /// 배경색으로 마젠타를 적용합니다.
        /// </summary>
        public readonly static string Magenta_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightBackgroundMagenta);
        /// <summary>
        /// 배경색으로 노란색을 적용합니다.
        /// </summary>
        public readonly static string Yellow_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightBackgroundYellow);
        /// <summary>
        /// 배경색으로 하얀색을 적용합니다.
        /// </summary>
        public readonly static string White_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BrightBackgroundWhite);
        /// <summary>
        /// 배경색을 기본값으로 되돌립니다.
        /// </summary>
        public readonly static string DefaultColor_ = EscapeSequence.SGR(EscapeSequence.SGRParameter.BackgroundDefault);
        #endregion
    }
}
