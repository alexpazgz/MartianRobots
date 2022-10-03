using Application.Common.Models;
using Application.Common.ViewModel.CommonVm;
using Application.Common.ViewModel.GetExploredSurface;
using Application.Common.ViewModel.GetLostRobotsQuery;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;

namespace Application.AutoMapper
{
    public class MappingProfile : Profile    
    {
        public MappingProfile()
        {
            CreateMap<OutputResponse, Surface>()
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.Surface.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.Surface.YCoordinate))
                .ForMember(dest => dest.Robots, act => act.MapFrom(src => src.Robots))
                .ForMember(dest => dest.ExploredSurfaces, act => act.MapFrom(src => src.ExploredSurface));

            CreateMap<RobotResource, Robot>()
                .ForMember(dest => dest.Orientation, act => act.MapFrom(src => src.Orientation))
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.YCoordinate))
                .ForMember(dest => dest.Instruction, act => act.MapFrom(src => string.Join("", src.Instructions)))
                .ForMember(dest => dest.Output, act => act.MapFrom(src => src.Output));

            CreateMap<OutputResource, Output>()
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.YCoordinate))
                .ForMember(dest => dest.Orientation, act => act.MapFrom(src => src.Orientation))
                .ForMember(dest => dest.Lost, act => act.MapFrom(src => src.Lost));

            CreateMap<ExploredSurfaceResource, ExploredSurface>()
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.YCoordinate));

            CreateMap<Surface, SurfaceResource>()
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.YCoordinate))
                .ForMember(dest => dest.Robots, act => act.MapFrom(src => src.Robots))
                .ForMember(dest => dest.ExploredSurfaces, act => act.MapFrom(src => src.ExploredSurfaces));

            CreateMap<Robot, RobotResource>()
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.YCoordinate))
                .ForMember(dest => dest.Orientation, act => act.MapFrom(src => src.Orientation))
                .ForMember(dest => dest.Instructions, act => act.MapFrom(src => 
                                        src.Instruction.AsEnumerable()
                                        .Select(s => (Instruction)Enum.Parse(typeof(Instruction), s.ToString()))
                                        .ToList()));

            CreateMap<Output, OutputResource>()
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.YCoordinate))
                .ForMember(dest => dest.Orientation, act => act.MapFrom(src => src.Orientation))
                .ForMember(dest => dest.Lost, act => act.MapFrom(src => src.Lost));

            CreateMap<ExploredSurface, ExploredSurfaceResource>()
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.YCoordinate));

            CreateMap<Surface, CoordinatesResource>()
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.YCoordinate));

            CreateMap<Robot, LostRobotsVm>()
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.YCoordinate))
                .ForMember(dest => dest.Orientation, act => act.MapFrom(src => src.Orientation.ToString()))
                .ForMember(dest => dest.Instruction, act => act.MapFrom(src => src.Instruction));

            CreateMap<Surface, SurfaceVm>()
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.YCoordinate));

            CreateMap<ExploredSurface, ExploredVm>()
                .ForMember(dest => dest.XCoordinate, act => act.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, act => act.MapFrom(src => src.YCoordinate));
        }
    }
}
