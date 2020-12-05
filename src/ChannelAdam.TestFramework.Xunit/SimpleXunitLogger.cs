//-----------------------------------------------------------------------
// <copyright file="SimpleXunitLogger.cs">
//     Copyright (c) 2020 Adam Craven. All rights reserved.
// </copyright>
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

namespace ChannelAdam.TestFramework.Xunit
{
    using System;
    using ChannelAdam.Logging.Abstractions;
    using Xunit = global::Xunit;

    /// <summary>
    /// Implementation of ISimpleLogger for xUnit.
    /// </summary>
    public class SimpleXunitLogger : ISimpleLogger
    {
        private readonly Xunit.Abstractions.ITestOutputHelper output;

        public SimpleXunitLogger(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.output = output;
        }

        #region ISimpleLogger Implementation

        public void Log()
        {
            output.WriteLine(string.Empty);
        }

        public void Log(string message)
        {
            output.WriteLine(GetMessagePrefix() + message);
        }

        public void Log(string messageFormat, params object?[] arguments)
        {
            output.WriteLine(GetMessagePrefix() + messageFormat, arguments);
        }

        #endregion

        /// <summary>
        /// Gets a message's prefix - the current date followed by a dash.
        /// </summary>
        /// <returns>The message prefix.</returns>
        private static string GetMessagePrefix()
        {
            return string.Format("{0:dd/MM/yy hh:mm:ss tt} - ", DateTime.Now);
        }
    }
}