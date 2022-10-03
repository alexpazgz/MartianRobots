using Application.Common.Models;
using Application.Common.ViewModel.CommonVm;
using Domain.Enums;

namespace Application.Common.ViewModel.GetLostRobotsQuery
{
    public class LostRobotsVm 
    {
        public SurfaceVm Surface { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Orientation { get; set; }
        public string Instruction { get; set; }
    }
}
