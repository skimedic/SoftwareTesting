// Copyright Information
// ==================================
// SoftwareTesting - Mocking - B_Verification.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.A_Basics;

public class Verification
{
    internal Times GetExecutionCount(int i)
    {
        return Times.Exactly(i);
    }

    [Fact]
    public void Should_Verify_Mock_Functions_Executed_Marked_Verifiable()
    {
        var id = 12;
        var name = "Fred Flintstone";
        var customer = new Customer { Id = id, Name = name };
        var mock = new Mock<IRepo>();
        Expression<Func<IRepo, Customer>> call = x => x.Find(id);
        mock.Setup(call).Returns(customer).Verifiable("Method not called");
        var controller = new TestController(mock.Object);
        var actual = controller.GetCustomer(id);
        Assert.Same(customer, actual);
        Assert.Equal(id, actual.Id);
        Assert.Equal(name, actual.Name);
        mock.Verify(call);
        //mock.Verify(call, Times.Never);
        //mock.Verify(call, Times.Exactly(5));
        //mock.Verify(call,()=>GetExecutionCount(5));
    }

    [Fact]
    public void Should_Verify_All_Mock_Functions()
    {
        var id = 12;
        var name = "Fred Flintstone";
        var customer = new Customer { Id = id, Name = name };
        var mock = new Mock<IRepo>();
        mock.Setup(x => x.Find(id)).Returns(customer);
        //Throws exception since method wasn't called
        var ex = Assert.Throws<MockException>(() => mock.VerifyAll());
        Assert.Contains("This setup was not matched.",ex.Message);
    }

    [Fact]
    public void Should_Verify_Mock_Functions_Not_Executed_Marked_Verifiable()
    {
        var id = 12;
        var name = "Fred Flintstone";
        var customer = new Customer { Id = id, Name = name };
        var mock = new Mock<IRepo>();
        Expression<Func<IRepo, Customer>> call = x => x.Find(id);
        var errorMessage = "Method not called";
        mock.Setup(call).Returns(customer).Verifiable(errorMessage);
        var ex = Assert.Throws<MockException>(() => mock.Verify(call));
    }

    [Fact]
    public void Should_Verify_No_Other_Calls_Were_Made()
    {
        var mock = new Mock<IRepo>();
        var tenantId = 5;
        mock.Setup(x => x.TenantId).Returns(tenantId).Verifiable();
        mock.SetupAdd(x => x.FailedDatabaseRequest += It.IsAny<EventHandler>()).Verifiable();
        var controller = new TestController(mock.Object);
        Assert.Equal(tenantId, controller.TenantId());
        //mock.VerifyGet(x=>x.TenantId, Times.Once);
        mock.VerifyAll();
        mock.VerifyNoOtherCalls();
    }
    [Fact]
    public void Should_Verify_No_Other_Calls_Were_Made_With_Strict_Except_For_Event_Handlers()
    {
        var mock = new Mock<IRepo>(MockBehavior.Strict);
        var tenantId = 5;
        mock.Setup(x => x.TenantId).Returns(tenantId);
        mock.SetupAdd(x => x.FailedDatabaseRequest += It.IsAny<EventHandler>()).Verifiable();
        var controller = new TestController(mock.Object);
        Assert.Equal(tenantId, controller.TenantId());
        //mock.VerifyGet(x=>x.TenantId, Times.Once);
        mock.VerifyAll();
    }

}