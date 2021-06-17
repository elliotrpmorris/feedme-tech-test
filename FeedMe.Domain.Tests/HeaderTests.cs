using System;
using Xunit;
using FeedMe.Domain;

namespace FeedMe.Domain.Tests
{
    public class HeaderTests
    {
        [Fact]
        public void Constructor_Negative_MsgId_ThrowsArgumentException()
        {
            var msgId = -1;

            Assert.Throws<ArgumentException>(() =>
                new Header(
                    msgId,
                    "create",
                    "outcome",
                    2));
        }

        [Fact]
        public void Constructor_Negative_Timestamp_ThrowsArgumentException()
        {
            var timestamp = -1;

            Assert.Throws<ArgumentException>(() =>
                new Header(
                    2,
                    "create",
                    "outcome",
                    timestamp));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_NullOrWhiteSpace_Operation_ThrowsArgumentException(
            string operation)
        {
            
            Assert.Throws<ArgumentException>(() =>
                new Header(
                    2,
                    operation,
                    "outcome",
                    1));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_NullOrWhiteSpace_Type_ThrowsArgumentException(
            string type)
        {

            Assert.Throws<ArgumentException>(() =>
                new Header(
                    2,
                    "create",
                    type,
                    1));
        }

        [Fact]
        public void Constructor_ValidParams_AreAssignedCorrectly()
        {
            // Arrange / Act
            var msgId = 2;
            var operation = "create";
            var type = "outcome";
            var timestamp = 2;

            var ret = new Header(
                msgId,
                operation,
                type,
                timestamp);

            // Assert
            Assert.Equal(msgId, ret.MsgId);
            Assert.Equal(operation, ret.Operation);
            Assert.Equal(type, ret.Type);
            Assert.Equal(timestamp, ret.Timestamp);
        }

    }
}
