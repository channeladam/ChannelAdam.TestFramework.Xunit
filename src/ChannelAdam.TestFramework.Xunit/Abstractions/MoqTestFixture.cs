//-----------------------------------------------------------------------
// <copyright file="MoqTestFixture.cs">
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

namespace ChannelAdam.TestFramework.Xunit.Abstractions
{
    using System;
    using System.Threading.Tasks;
    using ChannelAdam.Logging.Abstractions;
    using Xunit = global::Xunit;

    /// <summary>
    /// Abstract class to inherit for using Moq.
    /// </summary>
    public abstract class MoqTestFixture : ChannelAdam.TestFramework.Moq.Abstractions.MoqTestFixture, Xunit.IAsyncLifetime
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoqTestFixture" /> class.
        /// </summary>
        protected MoqTestFixture(Xunit.Abstractions.ITestOutputHelper output) : base(new LogAssert(output))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoqTestFixture" /> class.
        /// </summary>
        /// <param name="logger">The logger to use.</param>
        protected MoqTestFixture(ISimpleLogger logger) : base(logger, new LogAssert(logger))
        {
        }

        #region Xunit.IAsyncLifetime Implementation

        public virtual async Task InitializeAsync()
        {
            await SetupTestAsync().ConfigureAwait(false);
        }

        public virtual async Task DisposeAsync()
        {
            try
            {
                PerformFinalTestAssertions();
            }
            finally
            {
                try
                {
                    await TeardownTestAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Do NOT throw exceptions from a teardown so we don't affect the outcome of the test.
                    Logger.Log($"An unexpected error occurred during the test teardown. This will NOT affect the outcome of the test.{Environment.NewLine}{ex}");
                }
            }
        }

        #endregion

        #region Protected Virtual Methods

        protected virtual Task SetupTestAsync() => Task.CompletedTask;
        protected virtual Task TeardownTestAsync() => Task.CompletedTask;
        protected virtual void PerformFinalTestAssertions() {}

        #endregion
    }
}
