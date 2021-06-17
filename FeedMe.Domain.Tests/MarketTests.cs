using System;
using Xunit;

namespace FeedMe.Domain.Tests
{
    public class MarketTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_NullOrWhiteSpace_EventId_ThrowsArgumentException(
            string eventId)
        {

            Assert.Throws<ArgumentException>(() =>
                new Market(
                    2,
                    "create",
                    "outcome",
                    2,
                    eventId,
                    "test",
                    "test2",
                    true,
                    true));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_NullOrWhiteSpace_MarketId_ThrowsArgumentException(
            string marketId)
        {

            Assert.Throws<ArgumentException>(() =>
                new Market(
                    2,
                    "create",
                    "outcome",
                    2,
                    "test",
                    marketId,
                    "test2",
                    true,
                    true));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_NullOrWhiteSpace_Name_ThrowsArgumentException(
            string name)
        {

            Assert.Throws<ArgumentException>(() =>
                new Market(
                    2,
                    "create",
                    "outcome",
                    2,
                    "test",
                    "test2",
                    name,
                    true,
                    true));
        }

        

        [Fact]
        public void Constructor_ValidParams_AreAssignedCorrectly()
        {
            // Arrange / Act
            var msgId = 2;
            var operation = "create";
            var type = "outcome";
            var timestamp = 2;
            var eventId = "my event";
            var marketId = "my market";
            var name = "my name";
            var displayed = true;
            var suspended = true;

            var ret = new Market(
                    msgId,
                    operation,
                    type,
                    timestamp,
                    eventId,
                    marketId,
                    name,
                    displayed,
                    suspended);

            // Assert
            Assert.Equal(msgId, ret.MsgId);
            Assert.Equal(operation, ret.Operation);
            Assert.Equal(type, ret.Type);
            Assert.Equal(eventId, ret.EventId);
            Assert.Equal(marketId, ret.MarketId);
            Assert.Equal(name, ret.Name);
            Assert.Equal(displayed, ret.Displayed);
            Assert.Equal(suspended, ret.Suspended);
        }
    }
}
