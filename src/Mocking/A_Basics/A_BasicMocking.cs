// Copyright Information
// ==================================
// SoftwareTesting - Mocking - A_BasicMocking.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.A_Basics;

public class BasicMocking
{
    [Fact]
    public void Should_Mock_Function_With_Return_Value()
    {
        //Arrange
        var id = 12;
        var name = "Fred Flintstone";
        var customer = new Customer { Id = id, Name = name };
        var mockRepo = new Mock<IRepo>();

        mockRepo.Setup(x => x.Find(id)).Returns(customer);
        
        var controller = new TestController(mockRepo.Object);
        //var controller = new TestController(new FakeRepo());
        //Act
        var actual = controller.GetCustomer(id);
        //Assert
        Assert.Same(customer, actual);
        Assert.Equal(id, actual.Id);
        Assert.Equal(name, actual.Name);
    }

    [Fact]
    public void Should_Mock_Void_Functions()
    {
        var id = 12;
        var name = "Fred FlintStone";
        var customer = new Customer { Id = id, Name = name };
        var mock = new Mock<IRepo>();
        mock.Setup(x => x.AddRecord(customer));

        var controller = new TestController(mock.Object);
        controller.SaveCustomer(customer);
    }

    [Fact]
    public void Should_Not_Fail_With_Loose_Mock()
    {
        var id = 12;
        var name = "Fred FlintStone";
        var customer = new Customer { Id = id, Name = name };
        var mock = new Mock<IRepo>(MockBehavior.Loose);
        var controller = new TestController(mock.Object);
        controller.SaveCustomer(customer);
    }
    [Fact]
    public void Should_Fail_With_Strict_Mock()
    {
        var id = 12;
        var name = "Fred FlintStone";
        var customer = new Customer { Id = id, Name = name };
        var mock = new Mock<IRepo>(MockBehavior.Strict);
        var controller = new TestController(mock.Object);
        Assert.Throws<MockException>(()=>controller.SaveCustomer(customer));
    }

    [Fact]
    public void Should_Lazy_Return()
    {
        var id = 12;
        var name = "Fred Flintstone";
        var customer = new Customer { Id = 7, Name = "Wilma Flintstone"};
        var mock = new Mock<IRepo>();
        mock.Setup(x => x.Find(It.IsAny<int>())).Returns(()=>customer);
        var controller = new TestController(mock.Object);
        customer = new Customer { Id = id, Name = name };
        var actual = controller.GetCustomer(id);
        Assert.Same(customer, actual);
        Assert.Equal(id, actual.Id);
        Assert.Equal(name, actual.Name);
    }

    [Fact]
    public async Task Should_Mock_Async_Functions_Async()
    {
        var count = 12;
        var mock = new Mock<IRepo>();
        //mock.Setup(x => x.GetCountAsync().Result).Returns(count);
        //mock.Setup(x => x.GetCountAsync()).Returns(async() => count); //generates compiler warning
        mock.Setup(x => x.GetCountAsync()).ReturnsAsync(count);

        var controller = new TestController(mock.Object);
        var result = await controller.GetCustomerCountAsync();
        Assert.Equal(count, result);
    }
}