// Copyright Information
// ==================================
// SoftwareTesting - DALSample - BaseViewRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.Repos.Base;

public abstract class BaseViewRepo<T> : IBaseViewRepo<T> where T : class, new()
{
    private readonly bool _disposeContext;
    public DbSet<T> Table { get; }
    public ApplicationDbContext Context { get; }

    protected BaseViewRepo(ApplicationDbContext context)
    {
        Context = context;
        Table = Context.Set<T>();
        _disposeContext = false;
    }

    protected BaseViewRepo(DbContextOptions<ApplicationDbContext> options)
    : this(new ApplicationDbContext(options))
    {
        _disposeContext = true;
    }

    public virtual void Dispose()
    {
        if (_disposeContext)
        {
            Context.Dispose();
        }
    }

    public virtual IEnumerable<T> GetAll()
        => Table.AsQueryable();

    public virtual IEnumerable<T> GetAllIgnoreQueryFilters()
        => Table.IgnoreQueryFilters();

    public IEnumerable<T> ExecuteSqlString(string sql) => Table.FromSqlRaw(sql);

}
