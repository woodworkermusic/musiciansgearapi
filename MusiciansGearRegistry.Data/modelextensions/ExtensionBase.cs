using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansGearRegistry.Data.Models;

public abstract class ExtensionBase
{
    [NotMapped]
    public Guid MapKey { get; set; }

    public ExtensionBase() { MapKey = Guid.NewGuid(); }
}
