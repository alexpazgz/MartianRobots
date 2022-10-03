using Application.Common.ViewModel.CommonVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModel.GetExploredSurface
{
    public class ExploredSurfaceVm
    {
        public SurfaceVm Surface { get; set; }      
        public List<ExploredVm> ExploredSurface { get; set; }
    }
}
