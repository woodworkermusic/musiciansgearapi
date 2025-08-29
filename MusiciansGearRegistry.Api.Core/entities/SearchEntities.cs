namespace MusiciansGearRegistry.Api.Core.Entities;

public class CommonSearchEntity
{
    public string startsWith { get; set; }
    public int pageNumber { get; set; }
    public int pageCount { get; set; }
}
