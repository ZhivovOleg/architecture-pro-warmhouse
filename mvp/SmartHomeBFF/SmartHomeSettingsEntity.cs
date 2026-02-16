using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHomeBFF;

public class SmartHomeSettingsEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public required string SettingName { get; set; }

    public required string SettingValue { get; set; }

    public ICollection<SmartHomeSettingsEntity>? NestedSettings { get; set; }
}