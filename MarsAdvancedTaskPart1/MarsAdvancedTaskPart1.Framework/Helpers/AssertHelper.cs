using NUnit.Framework;
using AventStack.ExtentReports;
using NUnit.Framework.Legacy;

namespace MarsAdvancedTaskPart1.Framework.Helpers
{
    public class AssertHelper(TestState state)
    {
        public void IsEqualTo(string expected, string actual, string message)
        {
            Assert.That(actual, Is.EqualTo(expected));
            state.Test.Log(Status.Pass, $"Assertion Passed:  Expected: '{expected}', Actual:'{actual}'");
        }

        public void ListsMatch(List<string> actualList, List<string?> expectedList)
        {
            CollectionAssert.AreEqual(expectedList, actualList,
                $"Mismatch!\nExpected: {string.Join(", ", expectedList)}\nActual: {string.Join(", ", actualList)}");
            state.Test.Log(Status.Pass, $"Assertion Passed: Actual list matches expected list.");
        }

        public void AssertToastMessageForInvalid(List<(string messageText, string messageType)> actualMessages, string? expected)
        {
            Assert.Multiple(() =>
            {
                foreach (var (text, type) in actualMessages)
                {
                    Assert.That(type, Is.EqualTo("error"), "Error message should have shown");
                    Assert.That(text, Does.Contain(expected), $"Message contains {expected}, but not found");
                }
            });
        }

        public void AssertMultipleContain(List<string> actualMessages, string expected)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actualMessages, Is.Not.Null.And.Not.Empty, "Actual messages list is null or empty.");
                Assert.That(actualMessages.All(m => m.Contains(expected)), Is.True, $"Expected all messages to contain '{expected}', but got:\n - {string.Join("\n - ", actualMessages)}");
            });
            state.Test.Log(Status.Pass, $"Assertion Passed: '{actualMessages}' contains '{expected}'");
        }

        public void IsNotEqualTo(List<string> actualMessages, string expected)
        {
            foreach (var actual in actualMessages)
            {
                Assert.That(actual, Is.Not.EqualTo(expected));
                state.Test.Log(Status.Pass, $"Assertion Passed:  Expected: '{expected}', Actual:'{actual}'");
            }
        }

        public void Contains(string actual, string expectedSubstring, string message)
        {
            Assert.That(actual.Contains(expectedSubstring));
            state.Test.Log(Status.Pass, $"Assertion Passed:{message} - '{actual}' contains '{expectedSubstring}");
        }

        public void IsNotNullOrEmpty(string actual, string message)
        {
            Assert.That(actual, Is.Not.Null.And.Not.Empty, "Actual value is null or empty");
            state.Test.Log(Status.Info, $"Actual Message:{actual}");
        }

        public void IsNullOrEmpty(string actual, string expected)
        {
            Assert.That(actual, Is.Null.And.Empty, "Actual value is null or empty");
            state.Test.Log(Status.Info, $"Expected Message:{expected}");
        }

        public void AssertAllMessagesContain(List<string> actualMessages, string? expected)
        {
            Assert.That(actualMessages, Is.Not.Null.And.Not.Empty, "Actual messages list is null or empty.");
            Assert.That(actualMessages.Any(m => m.Contains(expected)), Is.True, $"Expected message contains'{expected}',but not found");
            state.Test.Log(Status.Pass, $"Assertion Passed: '{actualMessages}' contains '{expected}'");
        }

        public void ListContainsString(List<string> actualMessages, string? expected)
        {
            foreach (var actual in actualMessages)
            {
                Assert.That(actual, Does.Contain(expected), $"Message:{actualMessages} doesn't contain {expected}");
            }
        }

        public void IsTrue(List<bool> actual)
        {
            Assert.That(actual, Is.Not.Null.And.Not.Empty, "The list is null or empty.");

            // Ensure all values are true
            Assert.That(actual.All(x => x), Is.True, "Message: One or more items in the list are false (cancel failed)");
        }

        public void AssertListContainsAll(List<string> actualMessages, List<string?> expectedMessages)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actualMessages, Is.Not.Null.And.Not.Empty, "Actual messages list is null or empty.");

                foreach (var expected in expectedMessages)
                {
                    Assert.That(actualMessages.Any(m => m.Contains(expected)), Is.True, $"Expected message containing '{expected}' was not found. " +
                        $"Actual messages: {string.Join(", ", actualMessages)}"
                    );
                }
            });

            state.Test.Log(Status.Pass, $"Assertion Passed: All expected messages found in actual messages.");
        }

        public void AssertToastMessage(List<(string messageText, string messageType)> actualMessages, string? expected)
        {
            Assert.Multiple(() =>
            {
                foreach (var (text, type) in actualMessages)
                {
                    if (string.Equals(type, "Success", StringComparison.OrdinalIgnoreCase))
                    {
                        Assert.That(type, Is.EqualTo("success"), "Success message should have shown");
                    }
                    else if (string.Equals(type, "Error", StringComparison.OrdinalIgnoreCase))
                    {
                        Assert.That(type, Is.EqualTo("error"), "Error message should have shown");
                        Assert.That(text, Does.Contain(expected), $"Message contains {expected}, but not found");
                    }
                }
            });
        }

        public void IsTrueBool(bool actual)
        {
            Assert.That(actual, Is.Not.Null.And.Not.Empty, "The list is null or empty.");
        }
    }

}