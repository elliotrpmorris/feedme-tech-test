using System;
using Xunit;

namespace FeedMe.Domain.Tests
{
    public class EventTests
    {
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_NullOrWhiteSpace_EventId_ThrowsArgumentException(
            string eventId)
        {

            Assert.Throws<ArgumentException>(() =>
                new Event(
                    2,
                    "create",
                    "outcome",
                    2,
                    eventId,
                    "test",
                    "test2",
                    "test3",
                    3,
                    true,
                    true));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_NullOrWhiteSpace_Category_ThrowsArgumentException(
            string category)
        {

            Assert.Throws<ArgumentException>(() =>
                new Event(
                    2,
                    "create",
                    "outcome",
                    2,
                    "test",
                    category,
                    "test2",
                    "test3",
                    3,
                    true,
                    true));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_NullOrWhiteSpace_SubCategory_ThrowsArgumentException(
            string subCategory)
        {

            Assert.Throws<ArgumentException>(() =>
                new Event(
                    2,
                    "create",
                    "outcome",
                    2,
                    "test",
                    "test2",
                    subCategory,
                    "test3",
                    3,
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
                new Event(
                    2,
                    "create",
                    "outcome",
                    2,
                    "test",
                    "test2",
                    "test3",
                    name,
                    3,
                    true,
                    true));
        }

        [Fact]
        public void Constructor_Negative_Timestamp_ThrowsArgumentException()
        {
            var startTime = -1;

            Assert.Throws<ArgumentException>(() =>
                new Event(
                    2,
                    "create",
                    "outcome",
                    2,
                    "test",
                    "test2",
                    "test3",
                    "test4",
                    startTime,
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
            var category = "my category";
            var subCategory = "my sub category";
            var startTime = 2;
            var name = "my name";
            var displayed = true;
            var suspended = true;

           var ret = new Event(
                   msgId,
                   operation,
                   type,
                   timestamp,
                   eventId,
                   category,
                   subCategory,
                   name,
                   startTime,
                   displayed,
                   suspended);

            // Assert
            Assert.Equal(msgId, ret.MsgId);
            Assert.Equal(operation, ret.Operation);
            Assert.Equal(type, ret.Type);
            Assert.Equal(eventId, ret.EventId);
            Assert.Equal(category, ret.Category);
            Assert.Equal(subCategory, ret.SubCategory);
            Assert.Equal(startTime, ret.StartTime);
            Assert.Equal(name, ret.Name);
            Assert.Equal(displayed, ret.Displayed);
            Assert.Equal(suspended, ret.Suspended);
        }
    }
}
