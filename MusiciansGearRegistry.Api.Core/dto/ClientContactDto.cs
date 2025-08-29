using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.dto;

public class ClientContactDto : ClientContact
{
    public virtual ClientDto Client { get; set; } = new();
}
