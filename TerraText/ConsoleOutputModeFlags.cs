using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText
{
    /// <summary>
    /// 콘솔 출력 모드의 플래그입니다.
    /// </summary>
    [Flags]
    public enum ConsoleOutputModeFlags : uint
    {
        /// <summary>
        /// 입출력시 ASCII 컨트롤 시퀀스를 검사하여 올바른 조치가 수행됩니다. 백스페이스, 탭, 경고음, 캐리지 리턴 및 줄 바꿈 문자가 처리됩니다.
        /// </summary>
        EnableProcessedOutput = 0x0001,
        /// <summary>
        /// 입출력시 커서가 현재 행의 끝에 도달하면 다음 행의 시작 부분으로 이동합니다. 커서가 창과 버퍼의 마지막 행을 넘어가면 콘솔창에 표시된 행이 자동으로 위로 스크롤됩니다. 이 모드를 사용하지 않으면 행의 마지막 문자가 후속 문자로 덮어씌워집니다.
        /// </summary>
        EnableWrapAtEOLOutput = 0x0002,
        /// <summary>
        /// 출력시 커서 이동, 색상/글꼴 모드와 기존 콘솔 API를 통해 수행할 수 있는 기타 작업을 제어하는 VT100와 유사한 제어 문자 시퀀스를 파싱합니다. 자세한 내용은 <a href="https://docs.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences">Console Virtual Terminal Sequences</a>를 참조하십시오.
        /// </summary>
        EnableVirtualTerminalProcessing = 0x0004,
        /// <summary>
        /// 출력시 커서 이동 및 버퍼 스크롤을 지연 시킬 수 있는 추가 상태를 추가합니다.
        /// </summary>
        /// <remarks>
        /// <para>보통 <see cref="EnableWrapAtEOLOutput"/>를 설정하고 텍스트가 줄 끝에 이르면 커서가 즉시 다음 행으로 이동하고 버퍼의 내용이 한 줄씩 위로 스크롤됩니다. 이 플래그 세트와 대조적으로 스크롤 작업과 커서 이동은 다음 문자가 도착할 때까지 지연됩니다. 기록된 문자는 줄의 마지막 위치에 출력되고 <see cref="EnableWrapAtEOLOutput"/>이 꺼져있는 것처럼 이 문자 위에 유지되지만 다음 출력 가능한 문자는 <see cref="EnableWrapAtEOLOutput"/>이 켜져 있는 것처럼 출력됩니다. 덮어쓰기는 발생하지 않으며 구체적으로는 커서가 재빨리 내려가고 필요하면 스크롤이 수행되며 문자가 인쇄되고 커서가 한 위치 더 앞으로 이동합니다.</para>
        /// <para>이 플래그의 일반적인 사용법은 즉각적인 스크롤을 트리거하지 않고 화면 (마지막 오른쪽 하단)에 최종 문자를 출력하는 것이 의도된 동작인 터미널 에뮬레이터를 더 잘 에뮬레이트하는 <see cref="EnableVirtualTerminalProcessing"/> 설정과 함께 사용는 것입니다.</para>
        /// </remarks>
        DisableNewlineAutoReturn = 0x0010,
        /// <summary>
        /// 문자 속성의 플래그를 사용하여 텍스트의 전경색과 배경색을 조정할 수 있습니다. 또한 DBCS 플래그 범위는 COMMON_LVB접두사로 지정되었습니다. 역사적으로 이 플래그는 중국어, 일본어, 한국어 코드 페이지에서만 작동했습니다.
        /// </summary>
        /// <remarks>
        /// <para>선행 바이트와 후행 바이트를 제외하고, 선그리기와 영상 반전(전면 및 배경색 교환)을 설명하는 나머지 플래그는 다른 언어에서 출력의 일부를 강조하는데 유용할 수 있습니다.</para>
        /// <para>이 콘솔 모드 플래그를 설정하면 모든 언어의 모든 코드 페이지에서 이러한 속성을 사용할 수 있습니다.</para>
        /// <para>비 CJK 시스템에서 이러한 플래그를 무시하여 고유한 목적 또는 이 필드에 비트를 저장하는 콘솔을 이용하는 알려진 응용프로그램과의 호환성을 유지하기 위해 기본적으로 해제되어있습니다.</para>
        /// <para><see cref="EnableVirtualTerminalProcessing"/> 모드를 사용하면 연결된 응용 프로그램이 <a href="https://docs.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences">Console Virtual Terminal Sequences</a>를 통해 밑줄 또는 영상 반전을 요청하면 이 플래그가 여전히 꺼져 있는 동안 LVB 그리드와 영상 반전 플래그가 설정될 수 있다는 점에 유의하십시오.</para>
        /// </remarks>
        EnableLVBGridWorldwide = 0x0020
    }
}
