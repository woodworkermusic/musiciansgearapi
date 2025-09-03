namespace MusiciansGearRegistry.Data.entities;

public class CommonSearchEntity
{
    public string startsWith { get; set; }
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
    public bool includeDeleted { get; set; }
}
