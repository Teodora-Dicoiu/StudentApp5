using Microsoft.AspNetCore.Mvc.Testing;
using StudentsAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace StudentsAPIClient.Integration.Tests
{
    public class StudentsStatisticsControllerTests : IntegrationTestsBase
    {

        public StudentsStatisticsControllerTests(WebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        async Task TestGetStudentsStatisticsStatus()
        {
            var response = await client.GetAsync("clientapi/StudentsStatistics");
            response.EnsureSuccessStatusCode();
      

        }

        [Fact]
        async Task TestGetStudentsStatistics()
        {
            var response = await client.GetAsync("clientapi/StudentsStatistics");
            using var responseStream = await response.Content.ReadAsStreamAsync();
            List<StudentStatistics> students = await JsonSerializer.DeserializeAsync<List<StudentStatistics>>(responseStream);
            Assert.Equal(5, students.Count);
        }
    }
}
