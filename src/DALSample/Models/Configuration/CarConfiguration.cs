// Copyright Information
// ==================================
// SoftwareTesting - DALSample - CarConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.Models.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(e => e.Display)
            .HasComputedColumnSql("[PetName] + ' (' + [Color] + ')'", stored: true);

        CultureInfo provider = new("en-us");
        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        builder.Property(p => p.Price)
          .HasConversion(
              v => decimal.Parse(v, style, provider),
              v => v.ToString("C2"));


        builder.HasOne(d => d.MakeNavigation)
                      .WithMany(p => p.Cars)
                      .HasForeignKey(d => d.MakeId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Inventory_Makes_MakeId");

    }
}
