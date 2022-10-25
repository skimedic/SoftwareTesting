// Copyright Information
// ==================================
// SoftwareTesting - Mocking - TestController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.SystemsUnderTest;

public class TestController
{
    private readonly IRepo _repo;
    private readonly ILogger _logger;

    public TestController(IRepo repo, ILogger logger = null)
    {
        _repo = repo;
        _logger = logger;
        _repo.FailedDatabaseRequest += Repo_FailedDatabaseRequest;
    }

    private void Repo_FailedDatabaseRequest(object sender, EventArgs e)
    {
        _logger.Error("An error occurred");
    }

    public int TenantId() => _repo.TenantId;
    public void SetTenantId(int id) => _repo.TenantId = id;

    public Customer GetCustomer(int id, string name) => _repo.Get(12, "Fred");
    public Customer GetCurrentCustomer => _repo.CurrentCustomer;
    public Customer GetCustomer(int id)
    {
        try
        {
            id++;
            //_repo.AddRecord(new Customer());
            //var c = _repo.Find(id);
            //return new Customer { Id = 12, Name = "Fred Flintstone" };
            return _repo.Find(id);
        }
        catch (Exception ex)
        {
            if (_logger is not null)
            {
                _logger.Debug("There was an exception");
            }
            throw;
        }
    }

    public Address GetCustomersAddress(int id) => _repo.Find(id).AddressNavigation;

    public async Task<int> GetCustomerCountAsync() => await _repo.GetCountAsync();

    public void SaveCustomer(Customer customer)
    {
        _repo.AddRecord(customer);
    }
}