using Application.Common.ViewModel.GetExploredSurface;
using System.Net;
using Newtonsoft.Json;

namespace IntegrationTests.Controllers
{
    public  class ExploredSurfaceControllerTests : IntegrationTest
    {
        public ExploredSurfaceControllerTests() 
            : base()
        {
        }

        [Test]
        public async Task Get_Explored_Surface_OKKK()
        {
            var response = await _client.GetAsync("/api/ExploredSurface");
            
            response.EnsureSuccessStatusCode();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Should_Return_All()
        {
            var response = await _client.GetAsync("/api/ExploredSurface");
            
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadAsStringAsync().Result;

            List<ExploredSurfaceVm> vm = JsonConvert.DeserializeObject<List<ExploredSurfaceVm>>(result);
            var surfaceExploredCount = vm.SelectMany(s => s.ExploredSurface).Count();

            Assert.That(vm.Count, Is.EqualTo(1));
            Assert.That(surfaceExploredCount, Is.EqualTo(10));
        }
    }
}
