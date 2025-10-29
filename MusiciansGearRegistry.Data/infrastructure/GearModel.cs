using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansGearRegistry.Data.Models;

public partial class GearModel
{
    [NotMapped]
    public List<int> ImageIdList { get; set; } = new();
}
