// Copyright Information
// ==================================
// SoftwareTesting - Mocking - E_Arguments.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.A_Basics;

public class Arguments
{
    [Fact]
    public void Should_Return_Null_When_No_Argument_Match()
    {
        var id = 12;
        var name = "Fred Flintstone";
        var customer = new Customer { Id = id, Name = name };
        var mock = new Mock<IRepo>();
        mock.Setup(x => x.Find(id)).Returns(customer);
        var controller = new TestController(mock.Object);
        var actual = controller.GetCustomer(id);
        Assert.Null(actual);
    }

    [Fact]
    public void Should_Return_When_Arguments_Match()
    {
        var id = 11;
        var name = "Fred Flintstone";
        var customer = new Customer { Id = id, Name = name };
        var mock = new Mock<IRepo>();
        mock.Setup(x => x.Find(It.IsAny<int>())).Returns(customer);
        //mock.Setup(x => x.Find(It.IsInRange(0,100,Range.Inclusive))).Returns(customer);
        var controller = new TestController(mock.Object);
        var actual = controller.GetCustomer(id);
        Assert.Same(customer, actual);
        Assert.Equal(id, actual.Id);
        Assert.Equal(name, actual.Name);
    }

    [Fact]
    public void Should_Evaluate_At_Runtime()
    {
        var id = 12;
        var name = "Fred Flintstone";
        var customer = new Customer { Id = id, Name = name };
        var mock = new Mock<IRepo>();
        mock.Setup(x => x.Find(It.Is<int>(i=> i%2 == 0))).Returns(customer);
        var controller = new TestController(mock.Object);
        var actual = controller.GetCustomer(6);
        Assert.Same(customer, actual);
        Assert.Equal(id, actual.Id);
        Assert.Equal(name, actual.Name);
        actual = controller.GetCustomer(13);
        Assert.Null(actual);
    }

    [Fact]
    public void Should_Allow_Wildcards_On_Setters()
    {
        var mock = new Mock<IRepo>();
        var tenantId = 5;
        mock.SetupSet(SetAction);
        var controller = new TestController(mock.Object);
        controller.SetTenantId(tenantId);
        mock.VerifySet(SetAction);

        void SetAction(IRepo x) => x.TenantId = It.IsAny<int>();
    }

    [Fact]
    public void Should_Execute_With_Complex_Argument()
    {
        var id = 12;
        var name = "Fred Flintstone";
        var customer = new Customer { Id = id, Name = name };
        var mock = new Mock<IRepo>();
        mock.Setup(x => 
            x.AddRecord(It.Is<Customer>(x => x.Id == 12 && 
                  x.Name.StartsWith("Fred",StringComparison.OrdinalIgnoreCase)))).Verifiable();

        var controller = new TestController(mock.Object);
        controller.SaveCustomer(customer);
        mock.VerifyAll();
    }
}