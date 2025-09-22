using System.ComponentModel;

namespace MusiciansGearRegistry.Data.entities;

public class CommonSearchEntity
{
    [DefaultValue("")]
    public string startsWith { get; set; }
    [DefaultValue(1)]
    public int pageNumber { get; set; }
    [DefaultValue(10)]
    public int pageSize { get; set; }

    public bool includeDeleted { get; set; }
}
