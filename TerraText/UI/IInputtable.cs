using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText.UI
{
    /// <summary>
    /// 키 입력을 공용으로 받을 수 있는 UI를 나타냅니다.
    /// </summary>
    /// <remarks>
    /// 이 인터페이스를 상속 받아 구현시 <see cref="Input(ConsoleKeyInfo)"/> 메서드외에 추가적인 유틸리티 함수를 구현하시는 것도 좋습니다.
    /// </remarks>
    public interface IInputtable
    {
        /// <summary>
        /// 키 입력을 처리합니다.
        /// </summary>
        /// <param name="keyInfo">공용으로 처리되는 입력된 키 정보입니다.</param>
        void Input(ConsoleKeyInfo keyInfo);
    }
}
