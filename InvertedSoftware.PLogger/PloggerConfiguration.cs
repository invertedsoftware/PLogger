/* Copyright (c) Year(2013), Inverted Software
 *
 * Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted, 
 * provided that the above copyright notice and this permission notice appear in all copies.
 *
 * THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS.
 * IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE,
 * DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
 */

using System.Configuration;

namespace InvertedSoftware.PLogger
{
    /// <summary>
    /// Configuration section
    /// </summary>
    public class PloggerConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("PLogType", DefaultValue = "file", IsRequired = false)]
        public string PLogType
        {
            get
            {
                return (string)this["PLogType"];
            }
            set
            {
                this["PLogType"] = value;
            }
        }

        [ConfigurationProperty("PLogEnabled", DefaultValue = (bool)true, IsRequired = false)]
        public bool PLogEnabled
        {
            get
            {
                return (bool)this["PLogEnabled"];
            }
            set
            {
                this["PLogEnabled"] = value;
            }
        }

        [ConfigurationProperty("EnvironmentSpecialFolder", DefaultValue = "", IsRequired = false)]
        public string EnvironmentSpecialFolder
        {
            get
            {
                return (string)this["EnvironmentSpecialFolder"];
            }
            set
            {
                this["EnvironmentSpecialFolder"] = value;
            }
        }

        [ConfigurationProperty("BaseNameFile", DefaultValue = "rolling.log", IsRequired = false)]
        public string BaseNameFile
        {
            get
            {
                return (string)this["BaseNameFile"];
            }
            set
            {
                this["BaseNameFile"] = value;
            }
        }

        [ConfigurationProperty("PLogFileMaxSizeKB", DefaultValue = (int)1024, IsRequired = false)]
        [IntegerValidator(MinValue = 0)]
        public int PLogFileMaxSizeKB
        {
            get
            {
                return (int)this["PLogFileMaxSizeKB"];
            }
            set
            {
                this["PLogFileMaxSizeKB"] = value;
            }
        }

        [ConfigurationProperty("PLogFileMessageTemplate", DefaultValue = "", IsRequired = false)]
        public string PLogFileMessageTemplate
        {
            get
            {
                return (string)this["PLogFileMessageTemplate"];
            }
            set
            {
                this["PLogFileMessageTemplate"] = value;
            }
        }

        [ConfigurationProperty("PLogLevel", DefaultValue = (int)0, IsRequired = false)]
        [IntegerValidator(MinValue = 0)]
        public int PLogLevel
        {
            get
            {
                return (int)this["PLogLevel"];
            }
            set
            {
                this["PLogLevel"] = value;
            }
        }

        [ConfigurationProperty("StringConnectionName", DefaultValue = "", IsRequired = false)]
        public string StringConnectionName
        {
            get
            {
                return (string)this["StringConnectionName"];
            }
            set
            {
                this["StringConnectionName"] = value;
            }
        }

        [ConfigurationProperty("StoredProcedureName", DefaultValue = "", IsRequired = false)]
        public string StoredProcedureName
        {
            get
            {
                return (string)this["StoredProcedureName"];
            }
            set
            {
                this["StoredProcedureName"] = value;
            }
        }

        [ConfigurationProperty("MessageParameterName", DefaultValue = "", IsRequired = false)]
        public string MessageParameterName
        {
            get
            {
                return (string)this["MessageParameterName"];
            }
            set
            {
                this["MessageParameterName"] = value;
            }
        }

        [ConfigurationProperty("PLogDeleteFilesOlderThanDays", DefaultValue = (int)60, IsRequired = false)]
        [IntegerValidator(MinValue = 0)]
        public int PLogDeleteFilesOlderThanDays
        {
            get
            {
                return (int)this["PLogDeleteFilesOlderThanDays"];
            }
            set
            {
                this["PLogDeleteFilesOlderThanDays"] = value;
            }
        }

        [ConfigurationProperty("PLogStopLoggingIfSpaceSmallerThanMB", DefaultValue = (long)10, IsRequired = false)]
        [LongValidator(MinValue = 0)]
        public long PLogStopLoggingIfSpaceSmallerThanMB
        {
            get
            {
                return (long)this["PLogStopLoggingIfSpaceSmallerThanMB"];
            }
            set
            {
                this["PLogStopLoggingIfSpaceSmallerThanMB"] = value;
            }
        }
    }
}