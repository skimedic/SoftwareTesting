// Copyright Information
// ==================================
// SoftwareTesting - DALSample - CarRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.Repos;

public class CarRepo : BaseRepo<Car>, ICarRepo
{
    public CarRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal CarRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal IOrderedQueryable<Car> BuildBaseQuery()
        => Table.Include(x => x.MakeNavigation).OrderBy(p => p.PetName);

    public override IEnumerable<Car> GetAll()
        => BuildBaseQuery();

    public override IEnumerable<Car> GetAllIgnoreQueryFilters()
        => BuildBaseQuery().IgnoreQueryFilters();

    public override Car Find(int? id)
        => Table
            .IgnoreQueryFilters()
            .Where(x => x.Id == id)
            .Include(m => m.MakeNavigation)
            .FirstOrDefault();
    public IEnumerable<Car> GetAllBy(int makeId)
        => BuildBaseQuery().Where(x => x.MakeId == makeId);

}