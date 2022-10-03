using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Output : CoordinatesOrientationBase
    {
        public bool Lost { get; set; }

        [ForeignKey("Robot")]
        public int RobotId { get; set; }
        public virtual Robot Robot { get; set; }

    }
}
