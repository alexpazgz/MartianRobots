namespace IntegrationTests.Controllers
{
    public class InputControllerTests : IntegrationTest 
    {
        public InputControllerTests()
            : base()
        {
        }

        [Test]
        public async Task Create_Input_Request_OK()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Input");

            postRequest.Content = new StringContent("5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL\r\n3 2 N\r\nFRRFLLFFRRFLL");

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var expectedResult = "1 1 E\r\n3 3 N LOST\r\n4 2 N\r\n3 2 N";

            Assert.That(responseString, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task Create_Input_Request_KO()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Input");

            postRequest.Content = new StringContent("5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL\r\n3 2 N\r\nFRRFLLFFRRFLL");

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var expectedResult = "1 1 E\r\n3 2 N LOST\r\n0 3 W LOST\r\n3 1 N";

            Assert.That(responseString, Is.Not.EqualTo(expectedResult));
        }
    }
}


