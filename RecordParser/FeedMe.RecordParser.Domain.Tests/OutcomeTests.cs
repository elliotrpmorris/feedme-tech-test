using System;
using FeedMe.RecordParser.Domain.Data;
using Xunit;

namespace FeedMe.RecordParser.Domain.Tests
{
    public class OutcomeTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_NullOrWhiteSpace_OutcomeId_ThrowsArgumentException(
            string outcomeId)
        {

            Assert.Throws<ArgumentException>(() =>
                new Outcome(
                    2,
                    "create",
                    "outcome",
                    2,
                    "test",
                    outcomeId,
                    "test2",
                    "test3",
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
                new Outcome(
                    2,
                    "create",
                    "outcome",
                    2,
                    "test",
                    "test2",
                    name,
                    "test3",
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
                new Outcome(
                    2,
                    "create",
                    "outcome",
                    2,
                    marketId,
                    "test",
                    "test2",
                    "test3",
                    true,
                    true));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_NullOrWhiteSpace_Price_ThrowsArgumentException(
            string price)
        {

            Assert.Throws<ArgumentException>(() =>
                new Outcome(
                    2,
                    "create",
                    "outcome",
                    2,
                    "test",
                    "test2",
                    "test3",
                    price,
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
            var outcomeId = "my event";
            var marketId = "my market";
            var name = "my name";
            var price = "my price";
            var displayed = true;
            var suspended = true;

            var ret = new Outcome(
                    msgId,
                    operation,
                    type,
                    timestamp,
                    outcomeId,
                    marketId,
                    name,
                    price,
                    displayed,
                    suspended);

            // Assert
            Assert.Equal(msgId, ret.MsgId);
            Assert.Equal(operation, ret.Operation);
            Assert.Equal(type, ret.Type);
            Assert.Equal(outcomeId, ret.OutcomeId);
            Assert.Equal(marketId, ret.MarketId);
            Assert.Equal(name, ret.Name);
            Assert.Equal(price, ret.Price);
            Assert.Equal(displayed, ret.Displayed);
            Assert.Equal(suspended, ret.Suspended);
        }
    }
}
