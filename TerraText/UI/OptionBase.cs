using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TerraText.UI
{
    /// <summary>
    /// 옵션에 대한 기본 클래스를 나타냅니다.
    /// </summary>
    public abstract class OptionBase : UIBase
    {

        /// <summary>
        /// 유저가 선택한 값을 가져옵니다. 선택된 값이 없으면 -1입니다.
        /// </summary>
        public int Result
        {
            get;
            protected set;
        } = -1;

        /// <summary>
        /// 옵션으로 출력될 텍스트의 목록입니다.
        /// </summary>
        public IReadOnlyCollection<string> Items { get; }
        protected OptionBase(params string[] items)
        {
            Items = items;
        }
    }
}
