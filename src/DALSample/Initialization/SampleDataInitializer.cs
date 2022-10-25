// Copyright Information
// ==================================
// SoftwareTesting - DALSample - SampleDataInitializer.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================
namespace DALSample.Initialization;

public static class SampleDataInitializer
{
    internal static void ClearData(ApplicationDbContext context)
    {
        var entities = new[]
        {
            typeof(Car).FullName,
            typeof(Make).FullName
        };
        foreach (var entityName in entities)
        {
            var entity = context.Model.FindEntityType(entityName);
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            context.Database.ExecuteSqlRaw($"DELETE FROM {schemaName}.{tableName}");
            context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 1);");
        }
    }

    internal static void SeedData(ApplicationDbContext context)
    {
        ProcessInsert(context, context.Makes, SampleData.Makes);
        ProcessInsert(context, context.Cars, SampleData.Inventory);

        static void ProcessInsert<TEntity>(
            ApplicationDbContext context, DbSet<TEntity> table, List<TEntity> records) where TEntity : BaseEntity
        {
            if (table.Any())
            {
                return;
            }

            IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
                using var transaction = context.Database.BeginTransaction();
                var metaData = context.Model.FindEntityType(typeof(TEntity).FullName);
                context.Database.ExecuteSqlRaw(
                    $"SET IDENTITY_INSERT {metaData.GetSchema()}.{metaData.GetTableName()} ON");
                table.AddRange(records);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw(
                    $"SET IDENTITY_INSERT {metaData.GetSchema()}.{metaData.GetTableName()} OFF");
                transaction.Commit();
            });
        }
    }

    public static void ClearAndReseedDatabase(ApplicationDbContext context)
    {
        ClearData(context);
        SeedData(context);
    }
}