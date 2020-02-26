using System;
using System.Drawing;

namespace TerraText.ColorMaps
{
    /// <summary>
    /// 현대적인 시스템 콘솔 컬러를 나타냅니다.
    /// </summary>
    /// <remarks>
    /// 해당 컬러 목록에 대해서는 'https://devblogs.microsoft.com/commandline/updating-the-windows-console-colors/'를 참조하세요.
    /// </remarks>
    public sealed class ModernConsoleColor : ColorMap
    {
        /// <summary>
        /// <see cref="ModernConsoleColor"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public ModernConsoleColor()
        {
            Black = Color.FromArgb(12, 12, 12);
            DarkBlue = Color.FromArgb(0, 55, 218);
            DarkGreen = Color.FromArgb(19, 161, 14);
            DarkCyan = Color.FromArgb(58, 150, 221);
            DarkRed = Color.FromArgb(197, 15, 31);
            DarkMagenta = Color.FromArgb(136, 23, 152);
            DarkYellow = Color.FromArgb(193, 156, 0);
            Gray = Color.FromArgb(204, 204, 204);
            DarkGray = Color.FromArgb(118, 118, 118);
            Blue = Color.FromArgb(59, 120, 255);
            Green = Color.FromArgb(22, 198, 12);
            Cyan = Color.FromArgb(97, 214, 214);
            Red = Color.FromArgb(231, 72, 86);
            Magenta = Color.FromArgb(180, 0, 158);
            Yellow = Color.FromArgb(249, 241, 165);
            White = Color.FromArgb(242, 242, 242);
        }
    }
}
