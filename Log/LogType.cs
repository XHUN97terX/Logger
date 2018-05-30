using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
    /// <summary>
    /// Specifies the type of logs.
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// Means that this Log is of type Debug.
        /// Use for anything that can be useful for debugging.
        /// </summary>
        Debug = 1,
        /// <summary>
        /// Means that this Log is of type Info.
        /// Use for anything that can be useful outside debugging.
        /// </summary>
        Info = 2,
        /// <summary>
        /// Means that this Log is of type Warning.
        /// Use for cases where something can pose minor risk.
        /// </summary>
        Warning = 4,
        /// <summary>
        /// Means that this Log is of type Error.
        /// Use when an Exception has occured that can be recovered from.
        /// </summary>
        Error = 8,
        /// <summary>
        /// Means that this Log is of type Fatal.
        /// Use when an Exception has occured that couldn't be handled.
        /// </summary>
        Fatal = 16
    }
}