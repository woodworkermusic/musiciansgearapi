using MusiciansGearRegistry.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansGearRegistry.Api.Core.dto;

[NotMapped]
public class EquipmentTypeDto : EquipmentType
{
    public EquipmentTypeDto(EquipmentType gearType = null,
        bool fullDetail = false)
    {
    }
}
