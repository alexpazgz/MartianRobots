using Application.Common.Models;
using Application.Services;

namespace Application.UnitTests.Services
{
    public class OutputTextFormatterServiceTests
    {
        [Test]
        public async Task OutputTextFormatterService_OK()
        {
            var outputTextFormatterService = new OutputTextFormatterService();

            List<OutputResource> outputResource = new List<OutputResource>();
            outputResource.Add(new OutputResource(1, 1, Domain.Enums.Orientation.E, false));
            outputResource.Add(new OutputResource(3, 3, Domain.Enums.Orientation.N, true));
            outputResource.Add(new OutputResource(4, 2, Domain.Enums.Orientation.N, false));
            outputResource.Add(new OutputResource(3, 2, Domain.Enums.Orientation.N, false));


            var formatedText = outputTextFormatterService.FormatText(outputResource);
            var expectedText = "1 1 E\r\n3 3 N LOST\r\n4 2 N\r\n3 2 N";

            Assert.That(formatedText, Is.EqualTo(expectedText));
        }

        [Test]
        public async Task OutputTextFormatterService_KO()
        {
            var outputTextFormatterService = new OutputTextFormatterService();

            List<OutputResource> outputResource = new List<OutputResource>();
            outputResource.Add(new OutputResource(1, 1, Domain.Enums.Orientation.E, false));
            outputResource.Add(new OutputResource(3, 3, Domain.Enums.Orientation.N, true));
            outputResource.Add(new OutputResource(4, 2, Domain.Enums.Orientation.N, false));
            outputResource.Add(new OutputResource(3, 2, Domain.Enums.Orientation.N, false));
            outputResource.Add(new OutputResource(1, 2, Domain.Enums.Orientation.W, false));


            var formatedText = outputTextFormatterService.FormatText(outputResource);
            var expectedText = "1 1 E\r\n3 3 N LOST\r\n4 2 N\r\n3 2 N";

            Assert.That(formatedText, Is.Not.EqualTo(expectedText));
        }
    }
}
