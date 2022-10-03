using Application.AutoMapper;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using System.Runtime.Serialization;

namespace Application.UnitTests.Common.Mapping
{
    public class MappingTest
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTest()
        {
            _configuration = new MapperConfiguration(config =>
            config.AddProfile<MappingProfile>());

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        [TestCase(typeof(OutputResponse), typeof(Surface))]
        [TestCase(typeof(RobotResource), typeof(Robot))]
        [TestCase(typeof(OutputResource), typeof(Output))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);

            _mapper.Map(instance, source, destination);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type)!;

            // Type without parameterless constructor
            return FormatterServices.GetUninitializedObject(type);
        }
    }
}
