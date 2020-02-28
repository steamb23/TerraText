using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.UI
{
    /// <summary>
    /// UI의 기본 클래스를 나타냅니다.
    /// </summary>
    public abstract class UIBase
    {
        /// <summary>
        /// 기준점의 열 위치를 가져오거나 설정합니다.
        /// </summary>
        public int BaseLeft { get; set; }
        /// <summary>
        /// 기준점의 행 위치를 가져오거나 설정합니다.
        /// </summary>
        public int BaseTop { get; set; }
        /// <summary>
        /// 기준점의 위치를 설정합니다.
        /// </summary>
        /// <param name="left">기준점의 열 위치입니다.</param>
        /// <param name="top">기준점의 행 위치입니다.</param>
        public void SetBasePosition(int left, int top)
        {
            BaseLeft = left;
            BaseTop = top;
        }

        /// <summary>
        /// <see cref="UIBase"/> 클래스의 인스턴스를 초기화합니다.
        /// </summary>
        protected UIBase()
        {
            BaseLeft = Console.CursorLeft;
            BaseTop = Console.CursorTop;
        }
        /// <summary>
        /// UI요소를 출력하고 기능을 수행합니다.
        /// </summary>
        public abstract void Show();
    }
}
