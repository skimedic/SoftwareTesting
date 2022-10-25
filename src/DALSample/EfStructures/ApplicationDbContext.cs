// Copyright Information
// ==================================
// SoftwareTesting - DALSample - ApplicationDbContext.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.EfStructures;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Make> Makes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CarConfiguration().Configure(modelBuilder.Entity<Car>());
        new MakeConfiguration().Configure(modelBuilder.Entity<Make>());
    }

    public override int SaveChanges()
    {
        try
        {
            return base.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            //A concurrency error occurred
            //Should log and handle intelligently
            throw new CustomConcurrencyException("A concurrency error happened.", ex);
        }
        catch (RetryLimitExceededException ex)
        {
            //DbResiliency retry limit exceeded
            //Should log and handle intelligently
            throw new CustomRetryLimitExceededException("There is a problem with SQL Server.", ex);
        }
        catch (DbUpdateException ex)
        {
            //Should log and handle intelligently
            throw new CustomDbUpdateException("An error occurred updating the database", ex);
        }
        catch (Exception ex)
        {
            //Should log and handle intelligently
            throw new CustomException("An error occurred updating the database", ex);
        }
    }
}