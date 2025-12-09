using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansGearRegistry.Data.Models;

public abstract class ImageModel
{
    [NotMapped]
    public int ImageId { get; set; }
}

public partial class GearModelImage : ImageModel { }

public partial class GearTypeImage : ImageModel { }

public partial class UserGearImage : ImageModel { }