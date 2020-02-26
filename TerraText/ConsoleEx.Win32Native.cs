﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TerraText
{
    partial class ConsoleEx
    {
        internal static class Win32Native
        {
            #region kernal32.dll Console Functions
            // http://pinvoke.net/default.aspx/kernel32/AddConsoleAlias.html
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern bool AddConsoleAlias(
                string Source,
                string Target,
                string ExeName
                );

            // http://pinvoke.net/default.aspx/kernel32/AllocConsole.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool AllocConsole();

            // http://pinvoke.net/default.aspx/kernel32/AttachConsole.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool AttachConsole(
                uint dwProcessId
                );

            // http://pinvoke.net/default.aspx/kernel32/CreateConsoleScreenBuffer.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr CreateConsoleScreenBuffer(
                uint dwDesiredAccess,
                uint dwShareMode,
                IntPtr lpSecurityAttributes,
                uint dwFlags,
                IntPtr lpScreenBufferData
                );

            // http://pinvoke.net/default.aspx/kernel32/FillConsoleOutputAttribute.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool FillConsoleOutputAttribute(
                IntPtr hConsoleOutput,
                ushort wAttribute,
                uint nLength,
                COORD dwWriteCoord,
                out uint lpNumberOfAttrsWritten
                );

            // http://pinvoke.net/default.aspx/kernel32/FillConsoleOutputCharacter.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool FillConsoleOutputCharacter(
                IntPtr hConsoleOutput,
                char cCharacter,
                uint nLength,
                COORD dwWriteCoord,
                out uint lpNumberOfCharsWritten
                );

            // http://pinvoke.net/default.aspx/kernel32/FlushConsoleInputBuffer.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool FlushConsoleInputBuffer(
                IntPtr hConsoleInput
                );

            // http://pinvoke.net/default.aspx/kernel32/FreeConsole.html
            [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
            internal static extern bool FreeConsole();

            // http://pinvoke.net/default.aspx/kernel32/GenerateConsoleCtrlEvent.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GenerateConsoleCtrlEvent(
                uint dwCtrlEvent,
                uint dwProcessGroupId
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleAlias.html
            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern bool GetConsoleAlias(
                string Source,
                out StringBuilder TargetBuffer,
                uint TargetBufferLength,
                string ExeName
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleAliases.html
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern uint GetConsoleAliases(
                StringBuilder[] lpTargetBuffer,
                uint targetBufferLength,
                string lpExeName
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleAliasesLength.html
            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern uint GetConsoleAliasesLength(
                string ExeName
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleAliasExes.html
            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern uint GetConsoleAliasExes(
                out StringBuilder ExeNameBuffer,
                uint ExeNameBufferLength
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleAliasExesLength.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern uint GetConsoleAliasExesLength();

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleCP.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern uint GetConsoleCP();

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleCursorInfo.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetConsoleCursorInfo(
                IntPtr hConsoleOutput,
                out CONSOLE_CURSOR_INFO lpConsoleCursorInfo
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleDisplayMode.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetConsoleDisplayMode(
                out uint ModeFlags
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleFontSize.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern COORD GetConsoleFontSize(
                IntPtr hConsoleOutput,
                Int32 nFont
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleHistoryInfo.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetConsoleHistoryInfo(
                out CONSOLE_HISTORY_INFO ConsoleHistoryInfo
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleMode.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetConsoleMode(
                IntPtr hConsoleHandle,
                out uint lpMode
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleOriginalTitle.html
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern uint GetConsoleOriginalTitle(
                out StringBuilder ConsoleTitle,
                uint Size
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleOutputCP.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern uint GetConsoleOutputCP();

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleProcessList.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern uint GetConsoleProcessList(
                uint[] ProcessList,
                uint ProcessCount
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleScreenBufferInfo.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetConsoleScreenBufferInfo(
                IntPtr hConsoleOutput,
                out CONSOLE_SCREEN_BUFFER_INFO lpConsoleScreenBufferInfo
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleScreenBufferInfoEx.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetConsoleScreenBufferInfoEx(
                IntPtr hConsoleOutput,
                ref CONSOLE_SCREEN_BUFFER_INFO_EX ConsoleScreenBufferInfo
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleSelectionInfo.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetConsoleSelectionInfo(
                CONSOLE_SELECTION_INFO ConsoleSelectionInfo
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleTitle.html
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern uint GetConsoleTitle(
                [Out] StringBuilder lpConsoleTitle,
                uint nSize
                );

            // http://pinvoke.net/default.aspx/kernel32/GetConsoleWindow.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr GetConsoleWindow();

            // http://pinvoke.net/default.aspx/kernel32/GetCurrentConsoleFont.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetCurrentConsoleFont(
                IntPtr hConsoleOutput,
                bool bMaximumWindow,
                out CONSOLE_FONT_INFO lpConsoleCurrentFont
                );

            // http://pinvoke.net/default.aspx/kernel32/GetCurrentConsoleFontEx.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetCurrentConsoleFontEx(
                IntPtr ConsoleOutput,
                bool MaximumWindow,
                ref CONSOLE_FONT_INFO_EX ConsoleCurrentFont
                );

            // http://pinvoke.net/default.aspx/kernel32/GetLargestConsoleWindowSize.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern COORD GetLargestConsoleWindowSize(
                IntPtr hConsoleOutput
                );

            // http://pinvoke.net/default.aspx/kernel32/GetNumberOfConsoleInputEvents.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetNumberOfConsoleInputEvents(
                IntPtr hConsoleInput,
                out uint lpcNumberOfEvents
                );

            // http://pinvoke.net/default.aspx/kernel32/GetNumberOfConsoleMouseButtons.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetNumberOfConsoleMouseButtons(
                ref uint lpNumberOfMouseButtons
                );

            // http://pinvoke.net/default.aspx/kernel32/GetStdHandle.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr GetStdHandle(
                StdHandleTypes nStdHandle
                );

            // http://pinvoke.net/default.aspx/kernel32/HandlerRoutine.html
            // Delegate type to be used as the Handler Routine for SCCH
            internal delegate bool ConsoleCtrlDelegate(CtrlTypes CtrlType);

            // http://pinvoke.net/default.aspx/kernel32/PeekConsoleInput.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool PeekConsoleInput(
                IntPtr hConsoleInput,
                [Out] INPUT_RECORD[] lpBuffer,
                uint nLength,
                out uint lpNumberOfEventsRead
                );

            // http://pinvoke.net/default.aspx/kernel32/ReadConsole.html
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern bool ReadConsole(
                IntPtr hConsoleInput,
                [Out] StringBuilder lpBuffer,
                uint nNumberOfCharsToRead,
                out uint lpNumberOfCharsRead,
                IntPtr lpReserved
                );

            // http://pinvoke.net/default.aspx/kernel32/ReadConsoleInput.html
            [DllImport("kernel32.dll", EntryPoint = "ReadConsoleInputW", CharSet = CharSet.Unicode)]
            internal static extern bool ReadConsoleInput(
                IntPtr hConsoleInput,
                [Out] INPUT_RECORD[] lpBuffer,
                uint nLength,
                out uint lpNumberOfEventsRead
                );

            // http://pinvoke.net/default.aspx/kernel32/ReadConsoleOutput.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool ReadConsoleOutput(
                IntPtr hConsoleOutput,
                [Out] CHAR_INFO[] lpBuffer,
                COORD dwBufferSize,
                COORD dwBufferCoord,
                ref SMALL_RECT lpReadRegion
                );

            // http://pinvoke.net/default.aspx/kernel32/ReadConsoleOutputAttribute.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool ReadConsoleOutputAttribute(
                IntPtr hConsoleOutput,
                [Out] ushort[] lpAttribute,
                uint nLength,
                COORD dwReadCoord,
                out uint lpNumberOfAttrsRead
                );

            // http://pinvoke.net/default.aspx/kernel32/ReadConsoleOutputCharacter.html
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern bool ReadConsoleOutputCharacter(
                IntPtr hConsoleOutput,
                [Out] StringBuilder lpCharacter,
                uint nLength,
                COORD dwReadCoord,
                out uint lpNumberOfCharsRead
                );

            // http://pinvoke.net/default.aspx/kernel32/ScrollConsoleScreenBuffer.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool ScrollConsoleScreenBuffer(
                IntPtr hConsoleOutput,
               [In] ref SMALL_RECT lpScrollRectangle,
                IntPtr lpClipRectangle,
               COORD dwDestinationOrigin,
                [In] ref CHAR_INFO lpFill
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleActiveScreenBuffer.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleActiveScreenBuffer(
                IntPtr hConsoleOutput
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleCP.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleCP(
                uint wCodePageID
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleCtrlHandler.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleCtrlHandler(
                ConsoleCtrlDelegate HandlerRoutine,
                bool Add
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleCursorInfo.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleCursorInfo(
                IntPtr hConsoleOutput,
                [In] ref CONSOLE_CURSOR_INFO lpConsoleCursorInfo
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleCursorPosition.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleCursorPosition(
                IntPtr hConsoleOutput,
               COORD dwCursorPosition
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleDisplayMode.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleDisplayMode(
                IntPtr ConsoleOutput,
                uint Flags,
                out COORD NewScreenBufferDimensions
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleHistoryInfo.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleHistoryInfo(
                CONSOLE_HISTORY_INFO ConsoleHistoryInfo
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleMode.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleMode(
                IntPtr hConsoleHandle,
                uint dwMode
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleOutputCP.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleOutputCP(
                uint wCodePageID
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleScreenBufferInfoEx.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleScreenBufferInfoEx(
                IntPtr ConsoleOutput,
                ref CONSOLE_SCREEN_BUFFER_INFO_EX ConsoleScreenBufferInfoEx
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleScreenBufferSize.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleScreenBufferSize(
                IntPtr hConsoleOutput,
                COORD dwSize
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleTextAttribute.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleTextAttribute(
                IntPtr hConsoleOutput,
               ushort wAttributes
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleTitle.html
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern bool SetConsoleTitle(
                string lpConsoleTitle
                );

            // http://pinvoke.net/default.aspx/kernel32/SetConsoleWindowInfo.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetConsoleWindowInfo(
                IntPtr hConsoleOutput,
                bool bAbsolute,
                [In] ref SMALL_RECT lpConsoleWindow
                );

            // http://pinvoke.net/default.aspx/kernel32/SetCurrentConsoleFontEx.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetCurrentConsoleFontEx(
                IntPtr ConsoleOutput,
                bool MaximumWindow,
                ref CONSOLE_FONT_INFO_EX ConsoleCurrentFontEx
                );

            // http://pinvoke.net/default.aspx/kernel32/SetStdHandle.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetStdHandle(
                StdHandleTypes nStdHandle,
                IntPtr hHandle
                );

            // http://pinvoke.net/default.aspx/kernel32/WriteConsole.html
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern bool WriteConsole(
                IntPtr hConsoleOutput,
                string lpBuffer,
                uint nNumberOfCharsToWrite,
                out uint lpNumberOfCharsWritten,
                IntPtr lpReserved
                );

            // http://pinvoke.net/default.aspx/kernel32/WriteConsoleInput.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool WriteConsoleInput(
                IntPtr hConsoleInput,
                INPUT_RECORD[] lpBuffer,
                uint nLength,
                out uint lpNumberOfEventsWritten
                );

            // http://pinvoke.net/default.aspx/kernel32/WriteConsoleOutput.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool WriteConsoleOutput(
                IntPtr hConsoleOutput,
                CHAR_INFO[] lpBuffer,
                COORD dwBufferSize,
                COORD dwBufferCoord,
                ref SMALL_RECT lpWriteRegion
                );

            // http://pinvoke.net/default.aspx/kernel32/WriteConsoleOutputAttribute.html
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool WriteConsoleOutputAttribute(
                IntPtr hConsoleOutput,
                ushort[] lpAttribute,
                uint nLength,
                COORD dwWriteCoord,
                out uint lpNumberOfAttrsWritten
                );

            // http://pinvoke.net/default.aspx/kernel32/WriteConsoleOutputCharacter.html
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern bool WriteConsoleOutputCharacter(
                IntPtr hConsoleOutput,
                string lpCharacter,
                uint nLength,
                COORD dwWriteCoord,
                out uint lpNumberOfCharsWritten
                );

            [StructLayout(LayoutKind.Sequential)]
            internal struct COORD
            {

                internal short X;
                internal short Y;

            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct SMALL_RECT
            {

                internal short Left;
                internal short Top;
                internal short Right;
                internal short Bottom;

            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct CONSOLE_SCREEN_BUFFER_INFO
            {

                internal COORD dwSize;
                internal COORD dwCursorPosition;
                internal short wAttributes;
                internal SMALL_RECT srWindow;
                internal COORD dwMaximumWindowSize;

            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct CONSOLE_SCREEN_BUFFER_INFO_EX
            {
                internal uint cbSize;
                internal COORD dwSize;
                internal COORD dwCursorPosition;
                internal short wAttributes;
                internal SMALL_RECT srWindow;
                internal COORD dwMaximumWindowSize;

                internal ushort wPopupAttributes;
                internal bool bFullscreenSupported;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
                internal COLORREF[] ColorTable;

                internal static CONSOLE_SCREEN_BUFFER_INFO_EX Create()
                {
                    return new CONSOLE_SCREEN_BUFFER_INFO_EX { cbSize = (uint)Marshal.SizeOf<CONSOLE_SCREEN_BUFFER_INFO_EX>() };
                }
            }

            //[StructLayout(LayoutKind.Sequential)]
            //struct COLORREF
            //{
            //    internal byte R;
            //    internal byte G;
            //    internal byte B;
            //}

            [StructLayout(LayoutKind.Explicit)]
            internal struct COLORREF
            {
                [FieldOffset(0)]
                internal uint ColorDWORD;
                [FieldOffset(0)]
                internal byte R;
                [FieldOffset(1)]
                internal byte G;
                [FieldOffset(2)]
                internal byte B;

                internal COLORREF(System.Drawing.Color color)
                {
                    ColorDWORD = 0; // 빈 값
                    R = color.R;
                    G = color.G;
                    B = color.B;
                }

                internal System.Drawing.Color GetColor()
                {
                    return System.Drawing.Color.FromArgb(R, G, B);
                }

                internal void SetColor(System.Drawing.Color color)
                {
                    R = color.R;
                    G = color.G;
                    B = color.B;
                }

                public static explicit operator System.Drawing.Color(COLORREF unmanagedColor) => unmanagedColor.GetColor();
                public static explicit operator COLORREF(System.Drawing.Color managedColor) => new COLORREF(managedColor);
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct CONSOLE_FONT_INFO
            {
                internal int nFont;
                internal COORD dwFontSize;
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            internal unsafe struct CONSOLE_FONT_INFO_EX
            {
                internal uint cbSize;
                internal uint nFont;
                internal COORD dwFontSize;
                internal FontFamilyTypes FontFamily;
                internal int FontWeight;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                internal string FaceName;

                internal static CONSOLE_FONT_INFO_EX Create()
                {
                    return new CONSOLE_FONT_INFO_EX() { cbSize = (uint)Marshal.SizeOf<CONSOLE_FONT_INFO_EX>() };
                }
            }

            [StructLayout(LayoutKind.Explicit)]
            internal struct INPUT_RECORD
            {
                [FieldOffset(0)]
                internal ushort EventType;
                [FieldOffset(4)]
                internal KEY_EVENT_RECORD KeyEvent;
                [FieldOffset(4)]
                internal MOUSE_EVENT_RECORD MouseEvent;
                [FieldOffset(4)]
                internal WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;
                [FieldOffset(4)]
                internal MENU_EVENT_RECORD MenuEvent;
                [FieldOffset(4)]
                internal FOCUS_EVENT_RECORD FocusEvent;
            };

            [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
            internal struct KEY_EVENT_RECORD
            {
                [FieldOffset(0), MarshalAs(UnmanagedType.Bool)]
                internal bool bKeyDown;
                [FieldOffset(4), MarshalAs(UnmanagedType.U2)]
                internal ushort wRepeatCount;
                [FieldOffset(6), MarshalAs(UnmanagedType.U2)]
                //internal VirtualKeys wVirtualKeyCode;
                internal ushort wVirtualKeyCode;
                [FieldOffset(8), MarshalAs(UnmanagedType.U2)]
                internal ushort wVirtualScanCode;
                [FieldOffset(10)]
                internal char UnicodeChar;
                [FieldOffset(12), MarshalAs(UnmanagedType.U4)]
                //internal ControlKeyState dwControlKeyState;
                internal uint dwControlKeyState;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct MOUSE_EVENT_RECORD
            {
                internal COORD dwMousePosition;
                internal uint dwButtonState;
                internal uint dwControlKeyState;
                internal uint dwEventFlags;
            }

            internal struct WINDOW_BUFFER_SIZE_RECORD
            {
                internal COORD dwSize;

                internal WINDOW_BUFFER_SIZE_RECORD(short x, short y)
                {
                    dwSize = new COORD();
                    dwSize.X = x;
                    dwSize.Y = y;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct MENU_EVENT_RECORD
            {
                internal uint dwCommandId;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct FOCUS_EVENT_RECORD
            {
                internal uint bSetFocus;
            }

            //CHAR_INFO struct, which was a union in the old days
            // so we want to use LayoutKind.Explicit to mimic it as closely
            // as we can
            [StructLayout(LayoutKind.Explicit)]
            internal struct CHAR_INFO
            {
                [FieldOffset(0)]
                char UnicodeChar;
                [FieldOffset(0)]
                char AsciiChar;
                [FieldOffset(2)] //2 bytes seems to work properly
                UInt16 Attributes;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct CONSOLE_CURSOR_INFO
            {
                uint Size;
                bool Visible;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct CONSOLE_HISTORY_INFO
            {
                ushort cbSize;
                ushort HistoryBufferSize;
                ushort NumberOfHistoryBuffers;
                uint dwFlags;
                internal static CONSOLE_HISTORY_INFO Create()
                {
                    return new CONSOLE_HISTORY_INFO { cbSize = (ushort)Marshal.SizeOf<CONSOLE_HISTORY_INFO>() };
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct CONSOLE_SELECTION_INFO
            {
                uint Flags;
                COORD SelectionAnchor;
                SMALL_RECT Selection;

                // Flags values:
                const uint CONSOLE_MOUSE_DOWN = 0x0008; // Mouse is down
                const uint CONSOLE_MOUSE_SELECTION = 0x0004; //Selecting with the mouse
                const uint CONSOLE_NO_SELECTION = 0x0000; //No selection
                const uint CONSOLE_SELECTION_IN_PROGRESS = 0x0001; //Selection has begun
                const uint CONSOLE_SELECTION_NOT_EMPTY = 0x0002; //Selection rectangle is not empty
            }

            internal static readonly IntPtr InvalidHandleValue = new IntPtr(-1);

            internal enum StdHandleTypes : int
            {
                Input = -10,
                Output = -11,
                Error = -12
            }
            [Flags]
            internal enum FontFamilyTypes : int
            {
                FixedPitch = 0x1,
                Vector = 0x2,
                TrueType = 0x4,
                Device = 0x8
            }

            // Enumerated type for the control messages sent to the handler routine
            internal enum CtrlTypes : uint
            {
                CTRL_C_EVENT = 0,
                CTRL_BREAK_EVENT,
                CTRL_CLOSE_EVENT,
                CTRL_LOGOFF_EVENT = 5,
                CTRL_SHUTDOWN_EVENT
            }
        }
    }
    #endregion
}
