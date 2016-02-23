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
using System.Configuration;

namespace InvertedSoftware.PLogger
{
    /// <summary>
    /// The main class to be called by the program.
    /// </summary>
    public static class Plogger
    {
        /// <summary>
        /// The configuration section.
        /// </summary>
        private static PloggerConfiguration pConfig = null;
        /// <summary>
        /// The current log provider based on configuration.
        /// </summary>
        private static readonly Lazy<ILogProvider> logProvider = null;

        /// <summary>
        /// Constructor
        /// </summary>
        static Plogger()
        {
            try
            {
                // Read the custom section.
                pConfig = ConfigurationManager.GetSection("PloggerConfiguration") as PloggerConfiguration;
                // Select provider
                if (pConfig.PLogType.ToLower() == "file")
                    logProvider = new Lazy<ILogProvider>(() => new RollingFileLogProvider(pConfig), true);
                else
                    logProvider = new Lazy<ILogProvider>(() => new SqlLogProvider(pConfig), true);
            }
            catch (ConfigurationErrorsException err)
            {
                throw new Exception("Plogger Configuration Exception", err);
            }
        }

        /// <summary>
        /// Log a message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="useTemplate">Use a formatted template</param>
        /// <param name="logLevelAndOver">The level of messages to log</param>
        /// <param name="e">An exception</param>
        /// <param name="templateValues">The values to format using the template</param>
        public static void Log(string message, bool useTemplate = false, int logLevelAndOver = 0, Exception e = null, params string[] templateValues)
        {
            logProvider.Value.Log(message, useTemplate, logLevelAndOver, e, templateValues);
        }
    }
}