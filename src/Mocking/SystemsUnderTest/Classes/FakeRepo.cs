// Copyright Information
// ==================================
// SoftwareTesting - Mocking - FakeRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.SystemsUnderTest.Classes;

public class FakeRepo : IRepo
{
    //Must be virtual
    protected virtual int GetNumber() => 5;
    protected virtual int GetNumberWithParam(int param) => 5;

    public int CallProtectedMember() => GetNumber();

    public int CallProtectedMemberWithParam(int param) => GetNumberWithParam(param);


    public event EventHandler FailedDatabaseRequest;
    public int TenantId { get; set; }
    public virtual Customer CurrentCustomer { get; set; }

    public virtual Customer Find(int id) => new Customer {Id = id, Name = "Fred Flintstone"};

    public IList<Customer> GetSomeRecords(Expression<Func<Customer, bool>> @where) 
	  => throw new NotImplementedException();

    public void AddRecord(Customer customer) => throw new NotImplementedException();

    public async Task<int> GetCountAsync() => throw new NotImplementedException();
    public Customer Get(int id, string name) => throw new NotImplementedException();
}