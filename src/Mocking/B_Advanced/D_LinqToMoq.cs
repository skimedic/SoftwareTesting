// Copyright Information
// ==================================
// SoftwareTesting - Mocking - D_LinqToMoq.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.B_Advanced;

public class LinqToMoq
{
    [Fact]
    public void Should_Use_Linq()
    {
        //Arrange
        var id = 12;
        var name = "Fred Flintstone";
        var customer = new Customer { Id = id, Name = name };
        var mockRepo = 
            Mock.Of<IRepo>(r => r.Find(id) == customer && r.TenantId == 5 && r.CurrentCustomer == customer,
                MockBehavior.Strict);

        var controller = new TestController(mockRepo);
        //Act
        var custFromController1 = controller.GetCustomer(id);
        var custFromController2 = controller.GetCurrentCustomer;
        var tenantId = controller.TenantId();
        //Assert
        Assert.Same(customer, custFromController1);
        Assert.Equal(id, custFromController1.Id);
        Assert.Equal(name, custFromController1.Name);
        Mock.Get(mockRepo).VerifyAll();
    }
}