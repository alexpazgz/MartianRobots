using Application.Common.Models;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRobot
    {
        void DoMovement(Instruction instruction, List<ScentResource> scents);
    }
}
