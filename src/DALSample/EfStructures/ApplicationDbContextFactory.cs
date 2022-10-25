// Copyright Information
// ==================================
// SoftwareTesting - DALSample - ApplicationDbContextFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.EfStructures;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = @"server=(localdb)\MsSqlLocalDb;Database=SoftwareTesting;Integrated Security=true";
        optionsBuilder.UseSqlServer(connectionString);
        Console.WriteLine(connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}