using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.dto;

public class IncidentReportDto : IncidentReport
{
    public ICollection<IncidentReportHistoryDto> IncidentReportHistory { get; set; }
    public UserEquipment UserEquipment { get; set; } = new();

    public IncidentReportDto()
    {
        this.IncidentReportHistory = new List<IncidentReportHistoryDto>();
    }
}
