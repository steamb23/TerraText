using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

using Debug_ = System.Diagnostics.Debug;

namespace TerraText
{
    public static class Log
    {
        [Conditional("TRACE")]
        public static void Info(string text)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} INFO  {text}");
        }

        [Conditional("TRACE")]
        public static void Warn(string text)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} WARN  {text}");
        }

        [Conditional("TRACE")]
        public static void Error(string text)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} ERROR {text}");
        }

        [Conditional("DEBUG")]
        public static void Debug(string text)
        {
            Debug_.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} DEBUG {text}");
        }
    }
}
