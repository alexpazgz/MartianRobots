using Application.Common.Exceptions;

namespace Application.Common.Models
{
    public class InputResource : CoordinatesResource
    {
        public List<RobotResource> Robots { get; set; }

        public InputResource(string inputRequest)
        {
            try
            {
                inputRequest = inputRequest.Trim();
                var surfaceline = inputRequest.Substring(0, inputRequest.IndexOf(Environment.NewLine));

                if (!string.IsNullOrEmpty(surfaceline))
                {
                    var input = surfaceline.Trim();
                    var index = input.IndexOf(" ", StringComparison.Ordinal);
                    var xCoordinate = int.Parse(input.Substring(0, index));
                    var yCoordinate = int.Parse(input.Substring(index + 1));

                    XCoordinate = xCoordinate;
                    YCoordinate = yCoordinate;
                }

                var RobotInstrucionLines = inputRequest.Substring(inputRequest.IndexOf(Environment.NewLine) + 2);

                if (!string.IsNullOrEmpty(RobotInstrucionLines))
                {
                    Robots = new List<RobotResource>();
                    var inputRobotsSplited = RobotInstrucionLines.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    if(inputRobotsSplited.Length % 2 == 0)
                    {
                        for (int i = 0; i < inputRobotsSplited.Length; i += 2)
                        {
                            Robots.Add(new RobotResource(inputRobotsSplited[i], inputRobotsSplited[i + 1]));
                        }
                    }
                    else
                    {
                        throw new InputException("Invalid input request.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InputException("Invalid input request.", ex);
            }
        }
    }
}
