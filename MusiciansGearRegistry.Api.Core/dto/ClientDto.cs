using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.dto;

public class ClientDto : Client
{
    public ICollection<ClientContactDto> ClientContacts { get; set; }
    public ICollection<LocationDto> ClientLocations { get; set; }

    public ClientDto()
    {
        this.ClientContacts = new List<ClientContactDto>();
        this.ClientLocations = new List<LocationDto>();
    }
}
