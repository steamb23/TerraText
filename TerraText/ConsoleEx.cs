using System;
using System.Drawing;
using System.Linq;
using TerraText.ColorMaps;

namespace TerraText
{
    /// <summary>
    /// 윈도우 콘솔 애플리케이션에 대한 특수 기능을 제공합니다.
    /// <see cref="System.Console"/>과 병행하여 사용합니다.
    /// </summary>
    public static partial class ConsoleEx
    {
        /// <summary>
        /// 현재 플랫폼이 확장 기능을 지원할 수 있는지 여부를 나타내는 값을 가져옵니다.
        /// </summary>
        public static bool IsSupported { get; } = Environment.OSVersion.Platform == PlatformID.Win32NT;

        #region std 핸들 관련 멤버
        private static volatile IntPtr _stdOutputHandle;
        private static volatile IntPtr _stdInputHandle;
        private static IntPtr StdOutputHandle
        {
            get
            {
                if (!IsSupported)
                    throw new PlatformNotSupportedException();
                if (_stdOutputHandle == IntPtr.Zero)
                    _stdOutputHandle = Win32Native.GetStdHandle(Win32Native.StdHandleTypes.Output);
                return _stdOutputHandle;
            }
        }
        private static IntPtr StdInputHandle
        {
            get
            {
                if (!IsSupported)
                    throw new PlatformNotSupportedException();
                if (_stdInputHandle == IntPtr.Zero)
                    _stdInputHandle = Win32Native.GetStdHandle(Win32Native.StdHandleTypes.Input);
                return _stdInputHandle;
            }
        }
        #endregion

        /// <summary>
        /// 현재 콘솔 모드를 나타내는 플래그를 가져오거나 설정합니다.
        /// </summary>
        public static ConsoleModeFlags ConsoleMode
        {
            get => Win32Native.GetConsoleMode(StdOutputHandle, out var mode) ? (ConsoleModeFlags)mode : 0;
            set => Win32Native.SetConsoleMode(StdOutputHandle, (uint)value);
        }

        #region AlignedWrite 오버로딩 메서드
        /// <summary>
        /// 현재 위치와 지정한 길이 안에서 지정한 부호 있는 32비트 정수 값의 텍스트 표현을 정렬해 출력합니다. 지정된 길이가 문자열의 길이보다 짧으면 무시됩니다.
        /// </summary>
        /// <param name="value">출력할 부호 있는 32비트 정수 값입니다.</param>
        /// <param name="textAlign">정렬할 위치입니다. 기본값은 왼쪽입니다.</param>
        /// <param name="length">정렬 기준으로 사용되는 길이입니다. 기본값은 0입니다.</param>
        public static void AlignedWrite(int value, TextAlign textAlign = TextAlign.Left, int length = 0) => AlignedWrite(value.ToString(), textAlign, length);
        /// <summary>
        /// 현재 위치와 지정한 길이 안에서 지정한 부호 없는 32비트 정수 값의 텍스트 표현을 정렬해 출력합니다. 지정된 길이가 문자열의 길이보다 짧으면 무시됩니다.
        /// </summary>
        /// <param name="value">출력할 부호 없는 32비트 정수 값입니다.</param>
        /// <param name="textAlign">정렬할 위치입니다. 기본값은 왼쪽입니다.</param>
        /// <param name="length">정렬 기준으로 사용되는 길이입니다. 기본값은 0입니다.</param>
        public static void AlignedWrite(uint value, TextAlign textAlign = TextAlign.Left, int length = 0) => AlignedWrite(value.ToString(), textAlign, length);
        /// <summary>
        /// 현재 위치와 지정한 길이 안에서 지정한 부호 있는 64비트 정수 값의 텍스트 표현을 정렬해 출력합니다. 지정된 길이가 문자열의 길이보다 짧으면 무시됩니다.
        /// </summary>
        /// <param name="value">출력할 부호 있는 64비트 정수 값입니다.</param>
        /// <param name="textAlign">정렬할 위치입니다. 기본값은 왼쪽입니다.</param>
        /// <param name="length">정렬 기준으로 사용되는 길이입니다. 기본값은 0입니다.</param>
        public static void AlignedWrite(long value, TextAlign textAlign = TextAlign.Left, int length = 0) => AlignedWrite(value.ToString(), textAlign, length);
        /// <summary>
        /// 현재 위치와 지정한 길이 안에서 지정한 부호 없는 64비트 정수 값의 텍스트 표현을 정렬해 출력합니다. 지정된 길이가 문자열의 길이보다 짧으면 무시됩니다.
        /// </summary>
        /// <param name="value">출력할 부호 없는 64비트 정수 값입니다.</param>
        /// <param name="textAlign">정렬할 위치입니다. 기본값은 왼쪽입니다.</param>
        /// <param name="length">정렬 기준으로 사용되는 길이입니다. 기본값은 0입니다.</param>
        public static void AlignedWrite(ulong value, TextAlign textAlign = TextAlign.Left, int length = 0) => AlignedWrite(value.ToString(), textAlign, length);
        /// <summary>
        /// 현재 위치와 지정한 길이 안에서 지정한 단정밀도 부동소수점 값의 텍스트 표현을 정렬해 출력합니다. 지정된 길이가 문자열의 길이보다 짧으면 무시됩니다.
        /// </summary>
        /// <param name="value">출력할 단정밀도 부동소수점 값입니다.</param>
        /// <param name="textAlign">정렬할 위치입니다. 기본값은 왼쪽입니다.</param>
        /// <param name="length">정렬 기준으로 사용되는 길이입니다. 기본값은 0입니다.</param>
        public static void AlignedWrite(float value, TextAlign textAlign = TextAlign.Left, int length = 0) => AlignedWrite(value.ToString(), textAlign, length);
        /// <summary>
        /// 현재 위치와 지정한 길이 안에서 지정한 배정밀도 부동소수점 값의 텍스트 표현을 정렬해 출력합니다. 지정된 길이가 문자열의 길이보다 짧으면 무시됩니다.
        /// </summary>
        /// <param name="value">출력할 배정밀도 부동소수점 값입니다.</param>
        /// <param name="textAlign">정렬할 위치입니다. 기본값은 왼쪽입니다.</param>
        /// <param name="length">정렬 기준으로 사용되는 길이입니다. 기본값은 0입니다.</param>
        public static void AlignedWrite(double value, TextAlign textAlign = TextAlign.Left, int length = 0) => AlignedWrite(value.ToString(), textAlign, length);
        /// <summary>
        /// 현재 위치와 지정한 길이 안에서 지정한 부울 값의 텍스트 표현을 정렬해 출력합니다. 지정된 길이가 문자열의 길이보다 짧으면 무시됩니다.
        /// </summary>
        /// <param name="value">출력할 부울 값입니다.</param>
        /// <param name="textAlign">정렬할 위치입니다. 기본값은 왼쪽입니다.</param>
        /// <param name="length">정렬 기준으로 사용되는 길이입니다. 기본값은 0입니다.</param>
        public static void AlignedWrite(bool value, TextAlign textAlign = TextAlign.Left, int length = 0) => AlignedWrite(value.ToString(), textAlign, length);
        #endregion

        /// <summary>
        /// 현재 위치와 지정한 길이 안에서 지정한 문자열을 정렬해 출력합니다. 지정된 길이가 문자열의 길이보다 짧으면 무시됩니다.
        /// </summary>
        /// <param name="value">출력할 문자열입니다.</param>
        /// <param name="textAlign">정렬할 위치입니다. 기본값은 왼쪽입니다.</param>
        /// <param name="length">정렬 기준으로 사용되는 길이입니다. 기본값은 0입니다.</param>
        public static void AlignedWrite(string value, TextAlign textAlign = TextAlign.Left, int length = 0)
        {
            var textWidth = UnicodeWidth.GetWidth(value);

            // textWidth나 length 중 더 큰쪽으로 길이를 갱신한다.
            length = Math.Max(length, UnicodeWidth.GetWidth(value));

            switch (textAlign)
            {
                case TextAlign.Left:
                    {
                        // 값을 출력한다.
                        Console.Write(value);

                        // 빈 공간을 계산한다.
                        var space = length - textWidth;

                        // 빈 공간을 채운다.
                        for (var i = 0; i < space; i++)
                        {
                            Console.Write(' ');
                        }
                    }
                    break;
                case TextAlign.Center:
                    {
                        // 좌측 빈 공간을 계산한다.
                        var leftSpace = (length - textWidth) / 2;
                        // 우측 빈 공간을 계산한다.
                        var rightSpace = length - leftSpace - textWidth;

                        // 좌측 빈공간을 채운다.
                        for (var i = 0; i < leftSpace; i++)
                        {
                            Console.Write(' ');
                        }
                        // 값을 출력한다.
                        Console.Write(value);
                        // 우측 빈공간을 채운다.
                        for (var i = 0; i < rightSpace; i++)
                        {
                            Console.Write(' ');
                        }
                    }
                    break;
                case TextAlign.Right:
                    {
                        // 빈 공간을 계산한다.
                        var space = length - textWidth;

                        // 빈 공간을 채운다.
                        for (var i = 0; i < space; i++)
                        {
                            Console.Write(' ');
                        }

                        // 값을 출력한다.
                        Console.Write(value);
                    }
                    break;
            }
        }

        #region 입력 관련 멤버
        /// <summary>
        /// 문자열을 입력 받을 때 커서가 숨겨져 있으면 커서를 표시합니다.
        /// </summary>
        /// <returns></returns>
        public static string ReadLineWithCursor()
        {
            bool consoleCursorVisible = Console.CursorVisible;

            Console.CursorVisible = true;
            var input = Console.ReadLine();
            Console.CursorVisible = consoleCursorVisible;

            return input;
        }

        /// <summary>
        /// 아무 키 입력을 대기하며 커서를 반드시 표시합니다.
        /// </summary>
        /// <param name="isFlush">true이면 입력 버퍼를 비워 이전 입력이 영향을 미치는 것을 방지합니다. 기본값은 true입니다.</param>
        public static void WaitKeyWithCursor(bool isFlush = true)
        {
            bool consoleCursorVisible = Console.CursorVisible;

            Console.CursorVisible = true;
            if (isFlush) ReadFlush();
            Console.ReadKey(true);
            Console.CursorVisible = consoleCursorVisible;
        }

        /// <summary>
        /// 특정 키 입력을 대기하며 커서를 반드시 표시합니다.
        /// </summary>
        /// <param name="key">반환 차단을 해제할 키입니다.</param>
        /// <param name="isFlush">true이면 입력 버퍼를 비워 이전 입력이 영향을 미치는 것을 방지합니다. 기본값은 true입니다.</param>
        public static void WaitKeyWithCursor(ConsoleKey key, bool isFlush = true)
        {
            bool consoleCursorVisible = Console.CursorVisible;

            Console.CursorVisible = true;
            if (isFlush) ReadFlush();
            while (Console.ReadKey(true).Key != key) ;
            Console.CursorVisible = consoleCursorVisible;
        }

        /// <summary>
        /// 아무 키 입력을 대기합니다.
        /// </summary>
        /// <param name="isFlush">true이면 입력 버퍼를 비워 이전 입력이 영향을 미치는 것을 방지합니다. 기본값은 true입니다.</param>
        public static void WaitKey(bool isFlush = true)
        {
            if (isFlush) ReadFlush();
            Console.ReadKey(true);
        }

        /// <summary>
        /// 특정 키 입력을 대기합니다.
        /// </summary>
        /// <param name="key">반환 차단을 해제할 키입니다.</param>
        /// <param name="isFlush">true이면 입력 버퍼를 비워 이전 입력이 영향을 미치는 것을 방지합니다. 기본값은 true입니다.</param>
        public static void WaitKey(ConsoleKey key, bool isFlush = true)
        {
            if (isFlush) ReadFlush();
            while (Console.ReadKey(true).Key != key) ;
        }

        /// <summary>
        /// 루프 문에서 유저가 스킵하기 위해 아무 키를 눌렀는지 확인합니다.
        /// </summary>
        /// <returns>키를 눌렀으면 true, 누르지 않았으면 false입니다.</returns>
        /// <remarks>
        /// <para>이 메서드는 콘솔에서 애니메이션 효과를 구현하거나 많은 처리를 필요로 할때 쓰면 좋습니다.</para>
        /// <para>만약 이전에 잘못 입력된 키에 영향 받는 것을 방지하려면 루프 직전에 <see cref="ReadFlush"/> 메서드를 호출 하세요.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// ConsoleEx.ReadFlush();
        /// while (anotherCondition || ConsoleEx.IsUserSkip())
        /// {
        ///     // code in a loop
        /// }
        /// </code>
        /// </example>
        public static bool IsUserSkip()
        {
            bool result = Console.KeyAvailable;
            if (result)
            {
                // 입력된 키에 대한 정보를 버퍼에서 제거
                Console.ReadKey(true);
            }
            return result;
        }

        /// <summary>
        /// 루프 문에서 유저가 스킵하기 위해 특정 키를 눌렀는지 확인합니다.
        /// </summary>
        /// <param name="key">스킵하기 위한 키입니다.</param>
        /// <returns>키를 눌렀으면 true, 누르지 않았으면 false입니다.</returns>
        /// <remarks>
        /// <para>이 메서드는 콘솔에서 애니메이션 효과를 구현하거나 많은 처리를 필요로 할때 쓰면 좋습니다.</para>
        /// <para>만약 이전에 잘못 입력된 키에 영향 받는 것을 방지하려면 루프 직전에 <see cref="ReadFlush"/> 메서드를 호출 하세요.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// ConsoleEx.ReadFlush();
        /// while (anotherCondition || ConsoleEx.IsUserSkip(ConsoleKey.Enter))
        /// {
        ///     // code in a loop
        /// }
        /// </code>
        /// </example>
        public static bool IsUserSkip(ConsoleKey key)
        {
            bool result = Console.KeyAvailable;
            if (result)
            {
                // 입력된 키에 대한 정보를 버퍼에서 제거
                result = Console.ReadKey(true).Key == key;
            }
            return result;
        }

        /// <summary>
        /// 콘솔 입력 버퍼를 비웁니다.
        /// </summary>
        public static void ReadFlush()
        {
            if (!Win32Native.FlushConsoleInputBuffer(StdInputHandle))
                throw new NotSupportedException();
        }
        #endregion

        #region 오프셋 관련 멤버
        /// <summary>
        /// 현재 저장된 오프셋 커서의 원점 열 위치를 가져오거나 설정합니다.
        /// </summary>
        public static int OffsetLeftOrigin
        {
            get;
            set;
        }

        /// <summary>
        /// 현재 저장된 오프셋 커서의 원점 행 위치를 가져오거나 설정합니다.
        /// </summary>
        public static int OffsetTopOrigin
        {
            get;
            set;
        }

        /// <summary>
        /// 버퍼 영역 내에서 오프셋 커서의 열 위치를 가져오거나 설정합니다.
        /// </summary>
        public static int OffsetLeft
        {
            get => OffsetLeftOrigin - Console.CursorLeft;
            set => Console.CursorLeft = OffsetLeftOrigin + value;
        }

        /// <summary>
        /// 버퍼 영역 내에서 오프셋 커서의 행 위치를 가져오거나 설정합니다.
        /// </summary>
        public static int OffsetTop
        {
            get => OffsetTopOrigin - Console.CursorTop;
            set => Console.CursorTop = OffsetTopOrigin + value;
        }

        /// <summary>
        /// 현재 커서 위치를 오프셋 커서의 원점으로 설정합니다.
        /// </summary>
        public static void SetOffsetCurrentPosition()
        {
            SetOffsetPosition(Console.CursorLeft, Console.CursorTop);
        }

        /// <summary>
        /// 오프셋 커서의 원점을 설정합니다.
        /// </summary>
        /// <param name="left">오프셋 커서 원점의 열 위치입니다. 열은 0부터 시작하여 왼쪽부터 오른쪽까지 번호가 지정됩니다.</param>
        /// <param name="top">오프셋 커서 원점의 행 위치입니다. 행은 0부터 시작하여 위에서 아래로 번호가 지정됩니다.</param>
        public static void SetOffsetPosition(int left, int top)
        {
            OffsetLeftOrigin = left;
            OffsetTopOrigin = top;
        }
        #endregion

        #region 색상 관련 멤버

        /// <summary>
        /// 현재 콘솔 색상 팔레트를 지정된 기본값으로 초기화합니다.
        /// </summary>
        public static void SetDefaultColor()
        {
            ColorMap.Default.SetConsoleDefault();
            Console.ResetColor();
        }

        /// <summary>
        /// 현재 사용중인 전경색 팔레트의 색상을 가져오거나 설정합니다.
        /// </summary>
        public static Color ForegroundPaletteColor
        {
            get => GetPaletteColor(Console.ForegroundColor);
            set => SetPaletteColor(value, Console.ForegroundColor);
        }

        /// <summary>
        /// 현재 사용중인 배경색 팔레트의 색상을 가져오거나 설정합니다.
        /// </summary>
        public static Color BackgroundPaletteColor
        {
            get => GetPaletteColor(Console.BackgroundColor);
            set => SetPaletteColor(value, Console.BackgroundColor);
        }

        private static int _foregorundColorPick = 0;
        private static int _backgorundColorPick = 0;

        /// <summary>
        /// 일반적으로 기본 전경색으로 사용되는 7번을 제외한 8~15번까지 순회하며 콘솔의 전경색을 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// <para>콘솔 출력 직후, 너무 빨리 이 프로퍼티를 호출할 경우 호출 전 출력의 색상 값이 같이 변경되는 의도치 않은 현상이 발생할 수 있습니다. 이러한 현상을 방지하려면 이 프로퍼티의 호출을 8회 이하로 제한하고, 출력 후 적절히 블로킹 메서드를 호출하십시오. 이러한 조치 후에도 콘솔 창 리사이즈 등 화면 전체가 다시 그려지면 색상 값이 초기화되어 의도치 않은 색상으로 표시될 수 있습니다.</para>
        /// </remarks>
        public static Color AutoForegroundPaletteColor
        {
            get
            {
                return GetPaletteColor(Console.ForegroundColor);
            }
            set
            {
                var colorPick = _foregorundColorPick + 1 + 7;
                SetPaletteColor(value, colorPick);
                Console.ForegroundColor = (ConsoleColor)colorPick;
                _foregorundColorPick = (_foregorundColorPick + 1) % 8;
            }
        }

        /// <summary>
        /// 일반적으로 기본 배경색으로 사용되는 0번을 제외한 1~6번까지 순회하며 콘솔의 배경색을 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// <para>콘솔 출력 직후, 너무 빨리 이 프로퍼티를 호출할 경우 호출 전 출력의 색상 값이 같이 변경되는 의도치 않은 현상이 발생할 수 있습니다. 이러한 현상을 방지하려면 이 프로퍼티의 호출을 6회 이하로 제한하고, 출력 후 적절히 블로킹 메서드를 호출하십시오. 이러한 조치 후에도 콘솔 창 리사이즈 등 화면 전체가 다시 그려지면 색상 값이 초기화되어 의도치 않은 색상으로 표시될 수 있습니다.</para>
        /// </remarks>
        public static Color AutoBackgroundPaletteColor
        {
            get
            {
                return GetPaletteColor(Console.BackgroundColor);
            }
            set
            {
                var colorPick = _backgorundColorPick + 1;
                SetPaletteColor(value, colorPick);
                Console.BackgroundColor = (ConsoleColor)colorPick;
                _backgorundColorPick = (_backgorundColorPick + 1) % 6;
            }
        }

        /// <summary>
        /// 지정된 콘솔 컬러 팔레트에 RGB 컬러 값을 설정합니다.
        /// </summary>
        /// <param name="color">RGB 컬러 값입니다.</param>
        /// <param name="PaletteColor">변경할 팔레트의 이름입니다.</param>
        /// <remarks>
        /// <para>콘솔 출력 직후, 너무 빨리 이 메서드를 호출할 경우 호출 전 출력의 색상 값이 같이 변경되는 의도치 않은 현상이 발생할 수 있습니다. 이러한 현상을 방지하려면 출력 후 적절히 블로킹 메서드를 호출하십시오.</para>
        /// </remarks>
        public static void SetPaletteColor(Color color, ConsoleColor PaletteColor) => SetPaletteColor(color, (int)PaletteColor);


        /// <summary>
        /// 지정된 콘솔 컬러 팔레트에 RGB 컬러 값을 설정합니다.
        /// </summary>
        /// <param name="color">RGB 컬러 값입니다.</param>
        /// <param name="PaletteNumber">변경할 팔레트의 번호입니다.</param>
        /// <remarks>
        /// <para>콘솔 출력 직후, 너무 빨리 이 메서드를 호출할 경우 호출 전 출력의 색상 값이 같이 변경되는 의도치 않은 현상이 발생할 수 있습니다. 이러한 현상을 방지하려면 출력 후 적절히 블로킹 메서드를 호출하십시오.</para>
        /// </remarks>
        public static void SetPaletteColor(Color color, int PaletteNumber)
        {
            Win32Native.CONSOLE_SCREEN_BUFFER_INFO_EX screenBufferInfo = Win32Native.CONSOLE_SCREEN_BUFFER_INFO_EX.Create();
            var stdHandle = StdOutputHandle;
            if (Win32Native.GetConsoleScreenBufferInfoEx(stdHandle, ref screenBufferInfo))
            {
                screenBufferInfo.ColorTable[PaletteNumber] = (Win32Native.COLORREF)color;

                screenBufferInfo.srWindow.Bottom++;
                screenBufferInfo.srWindow.Right++;
                if (!Win32Native.SetConsoleScreenBufferInfoEx(stdHandle, ref screenBufferInfo))
                    throw new NotSupportedException(); // 실패 상황
            }
            else throw new NotSupportedException();
        }

        /// <summary>
        /// RGB 컬러 배열을 콘솔 컬러 팔레트에 설정합니다.
        /// </summary>
        /// <remarks>
        /// <para><paramref name="colors"/>의 각 인덱스는 팔레트 번호에 대응되며 부족한 값은 (0, 0, 0)으로 채워집니다.</para>
        /// 
        /// <para>콘솔 출력 직후, 너무 빨리 이 메서드를 호출할 경우 호출 전 출력의 색상 값이 같이 변경되는 의도치 않은 현상이 발생할 수 있습니다. 이러한 현상을 방지하려면 출력 후 적절히 블로킹 메서드를 호출하십시오.</para>
        /// </remarks>
        /// <param name="colors">RGB 컬러 값에 대한 목록입니다. 길이가 16이 넘어가면 무시됩니다.</param>
        public static void SetPaletteColors(params Color[] colors)
        {
            Win32Native.CONSOLE_SCREEN_BUFFER_INFO_EX screenBufferInfo = Win32Native.CONSOLE_SCREEN_BUFFER_INFO_EX.Create();
            var stdHandle = StdOutputHandle;
            if (Win32Native.GetConsoleScreenBufferInfoEx(stdHandle, ref screenBufferInfo))
            {
                // colors의 길이가 16이 아닐 경우의 처리
                if (colors.Length != 16)
                {
                    var newColors = new Color[16];
                    Array.Copy(colors, newColors, 16);

                    colors = newColors;
                }
                screenBufferInfo.ColorTable = Array.ConvertAll(colors, item => (Win32Native.COLORREF)item);

                screenBufferInfo.srWindow.Bottom++;
                screenBufferInfo.srWindow.Right++;
                if (!Win32Native.SetConsoleScreenBufferInfoEx(stdHandle, ref screenBufferInfo))
                    throw new NotSupportedException(); // 실패 상황
            }
            else throw new NotSupportedException();
        }

        /// <summary>
        /// 지정된 콘솔 컬러 팔레트의 RGB 컬러 값을 가져옵니다.
        /// </summary>
        /// <param name="PaletteColor">대상 컬러 팔레트입니다.</param>
        /// <returns></returns>
        public static Color GetPaletteColor(ConsoleColor PaletteColor) => GetPaletteColor((int)PaletteColor);

        /// <summary>
        /// 지정된 콘솔 컬러 팔레트의 RGB 컬러 값을 가져옵니다.
        /// </summary>
        /// <param name="PaletteNumber">대상 컬러 팔레트입니다.</param>
        /// <returns></returns>
        public static Color GetPaletteColor(int PaletteNumber) => GetPaletteColors()[PaletteNumber];

        /// <summary>
        /// 0에서 15번까지의 RGB 컬러 값의 배열을 가져옵니다.
        /// </summary>
        /// <returns>0에서 15까지의 RGB 컬러 값 배열입니다.</returns>
        public static Color[] GetPaletteColors()
        {
            Win32Native.CONSOLE_SCREEN_BUFFER_INFO_EX screenBufferInfo = Win32Native.CONSOLE_SCREEN_BUFFER_INFO_EX.Create();
            if (Win32Native.GetConsoleScreenBufferInfoEx(Win32Native.GetStdHandle(Win32Native.StdHandleTypes.Output), ref screenBufferInfo))
            {
                var result = Array.ConvertAll(screenBufferInfo.ColorTable, item => (Color)item);

                return result;
            }
            else throw new NotSupportedException();
        }
        #endregion

        #region 폰트 관련 멤버
        private static volatile System.Drawing.Text.InstalledFontCollection? installedFontCollection;

        /// <summary>
        /// 지정된 폰트 이름이 시스템에 설치된 폰트인지 확인합니다.
        /// </summary>
        /// <param name="fontName">확인할 폰트 이름입니다.</param>
        /// <returns>지정된 폰트 이름이 설치되어 있으면 true를 반환하고 아니면 false를 반환합니다.</returns>
        public static bool IsInstalledFont(string fontName)
        {
            if (installedFontCollection == null)
                installedFontCollection = new System.Drawing.Text.InstalledFontCollection();

            return installedFontCollection.Families.FirstOrDefault(item => item.Name == fontName) != null;
        }

        /// <summary>
        /// 폰트 이름을 가져오거나 설정합니다. 설정된 폰트 이름은 콘솔 폰트에 바로 반영됩니다.
        /// </summary>
        public static string FontName
        {
            get => GetFont().fontName;
            set => SetFont(fontName: value);
        }

        /// <summary>
        /// 폰트 크기를 가져오거나 설정합니다.
        /// </summary>
        public static int FontSize
        {
            get => GetFont().fontSize;
            set => SetFont(fontSize: value);
        }

        /// <summary>
        /// 폰트 목록을 이용해 폰트를 변경합니다. 입력된 리스트 중 설치된 폰트가 없으면 시스템 기본 글꼴을 사용합니다.
        /// </summary>
        /// <param name="fontNames"></param>
        /// <returns></returns>
        public static void SetFont(params string[] fontNames)
        {
            foreach (var fontName in fontNames)
            {
                if (IsInstalledFont(fontName))
                {
                    FontName = fontName;
                    return;
                }
            }
            FontName = "";
        }

        /// <summary>
        /// 폰트 이름이나 폰트 크기를 설정합니다.
        /// </summary>
        /// <param name="fontName">설정할 폰트 이름</param>
        /// <param name="fontSize">설정할 폰트 사이즈</param>
        public static void SetFont(string? fontName = null, int? fontSize = null)
        {
            var fontInfo = Win32Native.CONSOLE_FONT_INFO_EX.Create();
            var stdHandle = StdOutputHandle;
            if (!Win32Native.GetCurrentConsoleFontEx(stdHandle, false, ref fontInfo))
                throw new NotSupportedException();

            if (fontName != null)
                fontInfo.FaceName = fontName;
            if (fontSize != null)
                fontInfo.dwFontSize = new Win32Native.COORD() { Y = (short)fontSize };  // X값은 Windows Console 내부적으로 자동 설정됨.

            if (!Win32Native.SetCurrentConsoleFontEx(stdHandle, false, ref fontInfo))
                throw new NotSupportedException();
        }

        /// <summary>
        /// 폰트 이름과 폰트 사이즈를 가져옵니다.
        /// </summary>
        /// <returns>폰트 이름과 폰트 사이즈의 튜플입니다.</returns>
        public static (string fontName, int fontSize) GetFont()
        {
            var fontInfo = Win32Native.CONSOLE_FONT_INFO_EX.Create();
            var stdHandle = StdOutputHandle;
            if (!Win32Native.GetCurrentConsoleFontEx(stdHandle, false, ref fontInfo))
                throw new NotSupportedException();

            return (fontName: fontInfo.FaceName, fontSize: fontInfo.dwFontSize.Y);
        }
        #endregion
    }
}
