using Application.Common.Interfaces;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OutputTextFormatterService : IOutputTextFormatterService
    {
        public string FormatText(List<OutputResource> outputResource)
        {
            string formattedText = string.Empty;
            var lines = new List<string>();
            foreach (var output in outputResource)
            {
                if (output.Lost)
                {
                    lines.Add(string.Format("{0} {1} {2} LOST",
                                            output.XCoordinate,
                                            output.YCoordinate,
                                            output.Orientation));
                }
                else
                {
                    lines.Add(string.Format("{0} {1} {2}",
                                            output.XCoordinate,
                                            output.YCoordinate,
                                            output.Orientation));
                }
            }


            if (lines.Any())
                formattedText = string.Join(Environment.NewLine, lines);
            

            return formattedText;
        }
    }
}
