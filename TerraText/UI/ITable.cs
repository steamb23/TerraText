using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.UI
{
    interface ITable
    {
        /// <summary>
        /// 메뉴으로 출력될 텍스트의 최소 폭을 가져오거나 설정합니다.
        /// </summary>
        public int TextWidth { get; set; }

        /// <summary>
        /// 메뉴으로 출력될 텍스트 열의 갯수를 가져오거나 설정합니다.
        /// </summary>
        int RowCount { get; set; }
    }
}
