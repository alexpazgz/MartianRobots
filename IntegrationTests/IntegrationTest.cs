using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public abstract class IntegrationTest : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly HttpClient _client;
        public IntegrationTest()
        {
            var fixture = new ApiWebApplicationFactory();
            _client = fixture.CreateClient();
        }
    }
}
