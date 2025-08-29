using MusiciansGearRegistry.Data.Models;

namespace MusiciansGearRegistry.Api.Core.dto;

public class IncidentReportHistoryDto : IncidentReportHistory
{
    public virtual IncidentReportDto IncidentReport { get; set; }
}
