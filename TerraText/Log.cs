using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

using Debug_ = System.Diagnostics.Debug;

namespace TerraText
{
    /// <summary>
    /// 로그 출력을 나타냅니다.
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// INFO 단계로 로그를 출력합니다.
        /// </summary>
        /// <param name="text">출력할 텍스트입니다.</param>
        [Conditional("TRACE")]
        public static void Info(string text)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} INFO  {text}");
        }

        /// <summary>
        /// WARN 단계로 로그를 출력합니다.
        /// </summary>
        /// <param name="text">출력할 텍스트입니다.</param>
        [Conditional("TRACE")]
        public static void Warn(string text)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} WARN  {text}");
        }

        /// <summary>
        /// ERROR 단계로 로그를 출력합니다.
        /// </summary>
        /// <param name="text">출력할 텍스트입니다.</param>
        [Conditional("TRACE")]
        public static void Error(string text)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} ERROR {text}");
        }

        /// <summary>
        /// DEBUG 단계로 로그를 출력합니다.
        /// </summary>
        /// <param name="text">출력할 텍스트입니다.</param>
        [Conditional("DEBUG")]
        public static void Debug(string text)
        {
            Debug_.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} DEBUG {text}");
        }
    }
}
