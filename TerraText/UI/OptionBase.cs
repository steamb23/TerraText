using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TerraText.UI
{
    /// <summary>
    /// 옵션에 대한 기본 클래스를 나타냅니다.
    /// </summary>
    public abstract class OptionBase : UIBase, IInputtable
    {

        /// <summary>
        /// 유저가 선택한 값을 가져오거나 설정합니다. 기본값은 0입니다.
        /// </summary>
        public int Result
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// 옵션으로 출력될 텍스트의 목록입니다.
        /// </summary>
        public IReadOnlyList<string> Items { get; }

        /// <summary>
        /// 옵션으로 출력될 텍스트의 목록으로 <see cref="OptionBase"/> 클래스를 초기화합니다.
        /// </summary>
        /// <param name="items">옵션으로 출력될 텍스트의 목록입니다.</param>
        protected OptionBase(params string[] items)
        {
            Items = items;
        }

        /// <summary>
        /// 키 입력을 처리합니다.
        /// </summary>
        /// <param name="keyInfo">공용으로 처리되는 입력된 키 정보입니다.</param>
        public abstract void Input(ConsoleKeyInfo keyInfo);
    }
}
