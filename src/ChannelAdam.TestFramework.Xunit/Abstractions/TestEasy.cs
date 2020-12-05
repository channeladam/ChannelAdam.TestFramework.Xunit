﻿//-----------------------------------------------------------------------
// <copyright file="TestEasy.cs">
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
    using ChannelAdam.Logging.Abstractions;
    using Xunit = global::Xunit;

    /// <summary>
    /// Abstract class to inherit for using the TestEasy base class.
    /// </summary>
    public abstract class TestEasy : ChannelAdam.TestFramework.Abstractions.TestEasy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestEasy" /> class.
        /// </summary>
        protected TestEasy(Xunit.Abstractions.ITestOutputHelper output) : base(new LogAssert(output))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestEasy" /> class.
        /// </summary>
        /// <param name="logger">The logger to use.</param>
        protected TestEasy(ISimpleLogger logger) : base(logger, new LogAssert(logger))
        {
        }
    }
}
