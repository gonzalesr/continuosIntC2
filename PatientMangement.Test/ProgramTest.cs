using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;

namespace PatientMangement.Test
{
    public class ProgramTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProgramTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        //[Fact]
        //public async Task Get_Endpoints_ReturnsSuccess()
        //{
        //    // Act
        //    var response = await _client.GetAsync("/api/Patient"); // Cambia la ruta a un endpoint válido

        //    // Assert
        //    response.EnsureSuccessStatusCode();
        //    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        //}
    }
}
