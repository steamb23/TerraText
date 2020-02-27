using System;
using System.Collections.Generic;
using System.Text;

namespace TerraText
{

    [Flags]
    public enum ConsoleOutputModeFlags : uint
    {
        EnableProcessedOutput = 0x0001,
        EnableWrapAtEOLOutput = 0x0002,
        EnableVirtualTerminalProcessing = 0x0004,
        DisableNewlineAutoReturn = 0x0010,
        EnableLVBGridWorldwide = 0x0020
    }
}
