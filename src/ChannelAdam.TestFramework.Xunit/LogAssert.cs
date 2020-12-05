//-----------------------------------------------------------------------
// <copyright file="LogAssert.cs">
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
    /// Assertion helper that outputs the specified name of the object being asserted - for better traceability in the test output.
    /// </summary>
    public class LogAssert : ChannelAdam.TestFramework.Abstractions.ILogAsserter
    {
        private readonly ISimpleLogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogAssert"/> class.
        /// </summary>
        public LogAssert(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.logger = new SimpleXunitLogger(output);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogAssert"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public LogAssert(ISimpleLogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Asserts that the value is <c>true</c>" />.
        /// </summary>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="actual">The actual value to test.</param>
        public void IsTrue(string itemName, bool actual)
        {
            this.logger.Log("Asserting {0} is True", itemName);
            Xunit.Assert.True(actual, itemName + " is True");
        }

        /// <summary>
        /// Asserts that the value is <c>false</c>.
        /// </summary>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="actual">The actual value to test.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void IsFalse(string itemName, bool actual)
        {
            this.logger.Log("Asserting {0} is False", itemName);
            Xunit.Assert.False(actual, itemName + " is False");
        }

        /// <summary>
        /// Asserts that the value is <c>null</c>.
        /// </summary>
        /// <typeparam name="T">The type of the object being asserted.</typeparam>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="actual">The actual value to assert.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void IsNull<T>(string itemName, T? actual)
        {
            this.logger.Log("Asserting {0} is Null", itemName);
            Xunit.Assert.Null(actual);
        }

        /// <summary>
        /// Asserts that the value is NOT <c>null</c>.
        /// </summary>
        /// <typeparam name="T">The type of the object being asserted.</typeparam>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="actual">The actual value to assert.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void IsNotNull<T>(string itemName, T? actual)
        {
            this.logger.Log("Asserting {0} is NOT Null", itemName);
            Xunit.Assert.NotNull(actual);
        }

        /// <summary>
        /// Asserts the given values are equal.
        /// </summary>
        /// <typeparam name="T">The type of the object being asserted.</typeparam>
        /// <param name="itemName">Name of the field.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="actual">The actual.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void AreEqual<T>(string itemName, T? expected, T? actual)
        {
            this.logger.Log("Asserting {0} is equal to: {1}", itemName, expected is null ? "null" : expected);
            Xunit.Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Asserts the given values are equal.
        /// </summary>
        /// <typeparam name="T">The type of the object being asserted.</typeparam>
        /// <param name="itemName">Name of the field.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="actual">The actual.</param>
        /// <param name="ignoreCase">If set to <c>true</c> then the case is ignored.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void AreEqual<T>(string itemName, T? expected, T? actual, bool ignoreCase)
        {
            string? expectedString = expected as string;
            string? actualString = actual as string;
            string ignore = ignoreCase ? " (ignoring case)" : string.Empty;
            this.logger.Log("Asserting {0}{1} is equal to: {2}", itemName, ignore, expected is null ? "null": expected);
            Xunit.Assert.True(string.Compare(expectedString, actualString, ignoreCase) == 0, itemName);
        }

        /// <summary>
        /// Asserts the given values are NOT equal.
        /// </summary>
        /// <typeparam name="T">The type of the object being asserted.</typeparam>
        /// <param name="itemName">Name of the field.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="actual">The actual.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void AreNotEqual<T>(string itemName, T? expected, T? actual)
        {
            this.logger.Log("Asserting {0} is NOT equal to: {1}", itemName, expected is null ? "null" : expected);
            Xunit.Assert.NotEqual(expected, actual);
        }

        /// <summary>
        /// Asserts the given values are NOT equal.
        /// </summary>
        /// <typeparam name="T">The type of the object being asserted.</typeparam>
        /// <param name="itemName">Name of the field.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="actual">The actual.</param>
        /// <param name="ignoreCase">If set to <c>true</c> then the case is ignored.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void AreNotEqual<T>(string itemName, T? expected, T? actual, bool ignoreCase)
        {
            string? expectedString = expected as string;
            string? actualString = actual as string;
            string ignore = ignoreCase ? " (ignoring case)" : string.Empty;
            this.logger.Log("Asserting {0}{1} is NOT equal to: {2}", itemName, ignore, expected is null ? "null" : expected);
            Xunit.Assert.True(string.Compare(expectedString, actualString, ignoreCase) == 0, itemName);
        }

        /// <summary>
        /// Asserts that the given actual string contains the given expected text.
        /// </summary>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="expectedText">The expected text to be contained within the actual text.</param>
        /// <param name="actualText">The actual text that should contain the expected text.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void StringContains(string itemName, string? expectedText, string? actualText)
        {
            this.logger.Log(
                "Asserting {0} - that the text '{1}' contains the text '{2}'",
                itemName,
                actualText ?? "null",
                expectedText ?? "null");

            if (actualText is null)
            {
                Fail($"Actual text is null and does NOT contain the expected text '{expectedText}'");
            }
            else if (expectedText is null)
            {
                Fail("Expected text is null and cannot be contained in the actual text");
            }
            else
            {
                Xunit.Assert.True(actualText.Contains(expectedText), $"Actual text '{actualText}' does NOT contain expected text '{expectedText}'");
            }
        }

        /// <summary>
        /// Asserts that two object variables refer to the same underlying object.
        /// </summary>
        /// <typeparam name="T">The type of the object being asserted.</typeparam>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="actual">The actual.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void AreSame<T>(string itemName, T? expected, T? actual)
        {
            this.logger.Log("Asserting {0} is same as: {1}", itemName, expected is null ? "null" : expected);
            Xunit.Assert.Same(expected as object, actual as object);
        }

        /// <summary>
        /// Asserts that two object variables do NOT refer to the same underlying object.
        /// </summary>
        /// <typeparam name="T">The type of the object being asserted.</typeparam>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="actual">The actual.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void AreNotSame<T>(string itemName, T? expected, T? actual)
        {
            this.logger.Log("Asserting {0} is NOT same as: {1}", itemName, expected is null ? "null" : expected);
            Xunit.Assert.NotSame(expected as object, actual as object);
        }

        /// <summary>
        /// Asserts that the given object is an instance of the given type.
        /// </summary>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="actual">The actual object.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void IsInstanceOfType(string itemName, Type expectedType, object? actual)
        {
            if (expectedType == null)
            {
                throw new ArgumentNullException(nameof(expectedType));
            }

            this.logger.Log("Asserting {0} is an instance of: {1}", itemName, expectedType.Name);
            Xunit.Assert.IsType(expectedType, actual);
        }

        /// <summary>
        /// Asserts that the given object is NOT an instance of the given type.
        /// </summary>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="actual">The actual object.</param>
        /// <remarks>
        /// Outputs the name of the object being asserted for better traceability in the test output.
        /// </remarks>
        public void IsNotInstanceOfType(string itemName, Type expectedType, object? actual)
        {
            if (expectedType == null)
            {
                throw new ArgumentNullException(nameof(expectedType));
            }

            this.logger.Log("Asserting {0} is NOT an instance of: {1}", itemName, expectedType.Name);
            Xunit.Assert.IsNotType(expectedType, actual);
        }

        /// <summary>
        /// Indicates that an assertion cannot be verified.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void Inconclusive(string message, params object?[] args)
        {
            this.logger.Log("Inconclusive: " + message, args);
            Xunit.Assert.True(false, $"INCONCLUSIVE - {string.Format(message, args)}");
        }

        /// <summary>
        /// Fails with the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void Fail(string message, params object?[] args)
        {
            this.logger.Log("Failing: " + message, args);
            Xunit.Assert.True(false, $"FAIL - {string.Format(message, args)}");
        }
    }
}
