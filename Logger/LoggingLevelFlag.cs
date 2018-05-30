using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
    /// <summary>
    /// Specifies what types of logs should be saved.
    /// </summary>
    public enum LoggingLevelFlag
    {
        /// <summary>
        /// Means that Debug type logs should be saved.
        /// </summary>
        Debug = 1,
        /// <summary>
        /// Means that Info type logs should be saved.
        /// </summary>
        Info = 2,
        /// <summary>
        /// Means that Warning type logs should be saved.
        /// </summary>
        Warning = 4,
        /// <summary>
        /// Means that Error type logs should be saved.
        /// </summary>
        Error = 8,
        /// <summary>
        /// Means that Fatal type logs should be saved.
        /// </summary>
        Fatal = 16,
        /// <summary>
        /// Means that all types of logs should be saved.
        /// </summary>
        All = 31,
        /// <summary>
        /// Means that no types of logs should be saved.
        /// </summary>
        None = 0
    }
}