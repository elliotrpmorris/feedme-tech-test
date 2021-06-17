using System;
using Xunit;

namespace FeedMe.Domain.Tests
{
    public class TypeParserTests
    {
        [Fact]  
        public void Handle_Escaped_Pipe_ParseRecord()
        {
            var testOutcome = "|80008|update|outcome|1623962324781|baf96d59-a0a2-46e3-a74c-c04cc37161d1|0179f386-dd58-400e-966f-8bd93e8881bd|\\|Forest Green\\| 1-0|9/1|1|0|";

            var recordParser = new RecordParser();

            var parsedRecord = recordParser.ParseRecord(testOutcome);

            Assert.Equal("80008", parsedRecord[0]);
            Assert.Equal("update", parsedRecord[1]);
            Assert.Equal("outcome", parsedRecord[2]);
            Assert.Equal("1623962324781", parsedRecord[3]);
            Assert.Equal("baf96d59-a0a2-46e3-a74c-c04cc37161d1", parsedRecord[4]);
            Assert.Equal("0179f386-dd58-400e-966f-8bd93e8881bd", parsedRecord[5]);
            Assert.Equal("\\|Forest Green\\| 1-0", parsedRecord[6]);
            Assert.Equal("9/1", parsedRecord[7]);
            Assert.Equal("1", parsedRecord[8]);
            Assert.Equal("0", parsedRecord[9]);
        }

        [Fact]
        public void Handle_No_Escaped_Pipes_ParseRecord()
        {   
            var testOutcome = "|65918|update|outcome|1623959728785|f9ab135f-59e9-486d-837d-72a9a5c50c36|1872c8f9-53c3-4873-adc0-27f57d03a7c8|Draw 0-0|9/4|1|0";

            var recordParser = new RecordParser();

            var parsedRecord = recordParser.ParseRecord(testOutcome);

            Assert.Equal("65918", parsedRecord[0]);
            Assert.Equal("update", parsedRecord[1]);
            Assert.Equal("outcome", parsedRecord[2]);
            Assert.Equal("1623959728785", parsedRecord[3]);
            Assert.Equal("f9ab135f-59e9-486d-837d-72a9a5c50c36", parsedRecord[4]);
            Assert.Equal("1872c8f9-53c3-4873-adc0-27f57d03a7c8", parsedRecord[5]);
            Assert.Equal("Draw 0-0", parsedRecord[6]);
            Assert.Equal("9/4", parsedRecord[7]);
            Assert.Equal("1", parsedRecord[8]);
            Assert.Equal("0", parsedRecord[9]);

        }
    }
}
