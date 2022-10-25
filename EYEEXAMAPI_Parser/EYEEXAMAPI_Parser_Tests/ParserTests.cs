using EYEEXAMAPI_Parser.Parsers;
using EYEEXAMAPI_Parser_Tests.Data;
using FluentAssertions;
using Xunit;

namespace EYEEXAMAPI_Parser_Tests
{
    public class ParserTests
    {
        [Fact]
        public void SuccessfulParsingTest()
        {
            var expected = ParsedSchedules.ParsedSchedulesList;

            var rawSchedule = RawSchedules.RawSchedulesList;

            var parser = new ScheduleParser();

            var parsedSchedule = parser.Parse(rawSchedule);

            parsedSchedule.Count.Should().Be(rawSchedule.Count);

            // parsedSchedule.Should().BeEquivalentTo(expected);
        }  
    }
}
