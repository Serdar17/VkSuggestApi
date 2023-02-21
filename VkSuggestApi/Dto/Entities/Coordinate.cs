using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto.Entities;

public class Coordinate
{
    [Range(0, 90)] [DefaultValue(0)] public double Lat { get; set; } = 0;

    [Range(0, 180)] [DefaultValue(0)] public double Lon { get; set; } = 0;
}