using EYEEXAMAPI_Parser.Model;
using EYEEXAMAPI_Parser.Services;
using FluentAssertions;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace EYEEXAMAPI_Parser_Tests
{
    public class FunctionalTests
    {
        [Fact]
        public async Task SuccessfulParsingTest()
        {
            var externalClient = HttpClientFactory.CreateClient("https://localhost:7203/");
            var client = HttpClientFactory.CreateClient("https://localhost:7234/");


            var expectedScheduleResponse = await externalClient.GetAsync("results");
            var parsedScheduleResponse = await externalClient.GetAsync("results");

            var expectedSchedule = await expectedScheduleResponse.Content.ReadFromJsonAsync<List<ParsedScheduleNoticeOfLease>>();
            var parsedSchedule = await parsedScheduleResponse.Content.ReadFromJsonAsync<List<ParsedScheduleNoticeOfLease>>();

            parsedSchedule.Count.Should().Be(expectedSchedule.Count);
        }
    }
}
