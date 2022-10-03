using Application.Common.ViewModel.GetLostRobotsQuery;
using Newtonsoft.Json;
using System.Net;

namespace IntegrationTests.Controllers
{
    public class RobotsControllerTests : IntegrationTest 
    {
        public RobotsControllerTests()
            : base()
        {
        }

        [Test]
        public async Task Get_Lost_Robots_OK()
        {
            var response = await _client.GetAsync("/api/Robot/GetLostRobots");
            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Should_Return_All()
        {
            var response = await _client.GetAsync("/api/Robot/GetLostRobots");
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;

            List<LostRobotsVm> vm = JsonConvert.DeserializeObject<List<LostRobotsVm>>(result);

            Assert.That(vm.Count, Is.EqualTo(1));
        }
    }
}