namespace WebApplication1.Dto.Entities;

public class LocationInfo
{
    public string Address { get; set; }
    
    public AddressDetail AddressDetail { get; set; }

    public List<double> Bbox { get; set; }
    
    public Geometry Geometry { get; set; }

    public string Name { get; set; }

    public List<double> Pin { get; set; }

    public string Type { get; set; }
}