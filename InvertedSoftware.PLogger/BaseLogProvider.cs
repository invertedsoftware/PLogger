/* Copyright (c) Year(2013), Inverted Software
 *
 * Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted, 
 * provided that the above copyright notice and this permission notice appear in all copies.
 *
 * THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS.
 * IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE,
 * DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
 */

using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace InvertedSoftware.PLogger
{
    /// <summary>
    /// A base log class for all providers
    /// </summary>
    internal abstract class BaseLogProvider : ILogProvider
    {
        /// <summary>
        /// The configuration section.
        /// </summary>
        protected PloggerConfiguration pConfig = null;

        /// <summary>
        /// The main collaction holding messages.
        /// </summary>
        protected BlockingCollection<string> logItems = new BlockingCollection<string>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pConfig"></param>
        protected BaseLogProvider(PloggerConfiguration pConfig)
        {
            this.pConfig = pConfig;
            StartLogProsessing();
        }

        /// <summary>
        /// On startup start listening to log messages to be processed.
        /// </summary>
        protected void StartLogProsessing()
        {
            Task.Factory.StartNew(() =>
            {
                while (!logItems.IsCompleted)
                {
                    WriteLogItem(logItems.Take());
                }
            });
        }

        /// <summary>
        /// Implement this in each provider
        /// </summary>
        /// <param name="data"></param>
        protected virtual void WriteLogItem(string data)
        {
            throw new NotImplementedException();
        }

        #region ILogProvider
        /// <summary>
        /// Add a log message to logItems
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="useTemplate">Use a formatted template</param>
        /// <param name="logLevelAndOver">The level of messages to log</param>
        /// <param name="e">An exception</param>
        /// <param name="templateValues">The values to format using the template</param>
        public void Log(string message, bool useTemplate = false, int logLevelAndOver = 0, Exception e = null, params string[] templateValues)
        {
            if (!pConfig.PLogEnabled || logLevelAndOver < pConfig.PLogLevel)
                return;
            if (useTemplate && !string.IsNullOrWhiteSpace(pConfig.PLogFileMessageTemplate))
                message += String.Format(pConfig.PLogFileMessageTemplate, templateValues);
            if (e != null)
            {
                message += e.Message;
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                    message += e.Message;
                }
            }
            logItems.Add(message);
        }
        #endregion
    }
}