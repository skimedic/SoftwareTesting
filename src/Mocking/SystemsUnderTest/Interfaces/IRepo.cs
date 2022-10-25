// Copyright Information
// ==================================
// SoftwareTesting - Mocking - IRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.SystemsUnderTest.Interfaces;

public interface IRepo
{
    event EventHandler FailedDatabaseRequest;
    int TenantId { get; set; }
    Customer CurrentCustomer { get; set; }
    Customer Find(int id);
    IList<Customer> GetSomeRecords(Expression<Func<Customer, bool>> where);
    void AddRecord(Customer customer);
    Task<int> GetCountAsync();
    Customer Get(int id, string name);
}