using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusiciansGearRegistry.Data.dto;

public class dto_GearSearchResult
{
    // need:
    // model information
    // including manufacturer
    // gear type

    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; }

    public List<dto_GearModelResult> GearModels { get; set; } = new();
}

public class dto_GearModelResult
{
    public int GearModelId { get; set; }
    public string ModelName { get; set; }
}
