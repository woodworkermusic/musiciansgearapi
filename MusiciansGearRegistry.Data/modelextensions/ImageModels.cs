using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansGearRegistry.Data.Models;

public partial class GearModelImage : ExtensionBase 
{
    [NotMapped]
    public int ImageId { get; set; }
}

public partial class GearTypeImage : ExtensionBase
{
    [NotMapped]
    public int ImageId { get; set; }
}


public partial class UserGearImage : ExtensionBase
{
    [NotMapped]
    public int ImageId { get; set; }
}
