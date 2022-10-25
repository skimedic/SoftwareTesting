// Copyright Information
// ==================================
// SoftwareTesting - DALSample - Car.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.Models;

[Table("Inventory", Schema = "dbo")]
[Index(nameof(MakeId), Name = "IX_Inventory_MakeId")]
[EntityTypeConfiguration(typeof(CarConfiguration))]
public class Car : BaseEntity
{
    [Required,StringLength(50)]
    public string Color { get; set; }
    public string Price { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Display { get; set; }

    [Required, StringLength(50)] public string PetName { get; set; }

    [Required] public int MakeId { get; set; }

    [ForeignKey(nameof(MakeId))]
    [InverseProperty(nameof(Make.Cars))]
    public Make MakeNavigation { get; set; }

    [NotMapped]
    public string MakeName => MakeNavigation?.Name ?? "Unknown";
    

        // Since the PetName column could be empty, supply
        // the default name of **No Name**.
    public override string ToString() => $"{PetName ?? "**No Name**"} is a {Color} {MakeNavigation?.Name} with ID {Id}.";
}
