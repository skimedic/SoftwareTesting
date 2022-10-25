// Copyright Information
// ==================================
// SoftwareTesting - DALSample - IBaseViewRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================


namespace DALSample.Repos.Base;

public interface IBaseViewRepo<T> : IDisposable where T : class, new()
{
    ApplicationDbContext Context { get; }
    IEnumerable<T> ExecuteSqlString(string sql);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAllIgnoreQueryFilters();
}
