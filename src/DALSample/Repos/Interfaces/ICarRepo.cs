// Copyright Information
// ==================================
// SoftwareTesting - DALSample - ICarRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.Repos.Interfaces;

public interface ICarRepo : IBaseRepo<Car>
{
    IEnumerable<Car> GetAllBy(int makeId);
}
