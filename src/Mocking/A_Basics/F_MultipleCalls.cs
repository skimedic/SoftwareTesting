// Copyright Information
// ==================================
// SoftwareTesting - Mocking - F_MultipleCalls.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.A_Basics;

public class MultipleCalls
{
    [Fact]
    public void Should_Mock_Repetitive_Function_Calls_With_Return_Values()
    {
        var id1 = 12;
        var name1 = "Fred FlintStone";
        var customer1 = new Customer { Id = id1, Name = name1 };
        var id2 = 1;
        var name2 = "Wilma FlintStone";
        var customer2 = new Customer { Id = id2, Name = name2 };
        var mock = new Mock<IRepo>();
        mock.SetupSequence(x => x.Find(It.IsAny<int>()))
            .Returns(customer1)
            .Returns(customer2);
        var controller = new TestController(mock.Object);
        var actual = controller.GetCustomer(id1);
        Assert.Same(customer1, actual);
        Assert.Equal(id1, actual.Id);
        Assert.Equal(name1, actual.Name);
        actual = controller.GetCustomer(id2);
        Assert.Same(customer2, actual);
        Assert.Equal(id2, actual.Id);
        Assert.Equal(name2, actual.Name);
        actual = controller.GetCustomer(id2);
        Assert.Null(actual);
        mock.Verify(x=>x.Find(It.IsAny<int>()), Times.Exactly(3));
    }
    [Theory]
    [InlineData(0,12,"Bob")]
    [InlineData(1,17,"Sue")]
    [InlineData(2,100065,"Tony")]
    public void Should_Enable_Rolling_Mocks(int index, int id, string name)
    {
        var customers = new List<Customer>
        {
            new Customer {Id = 12, Name = "Bob"},
            new Customer {Id = 17, Name = "Sue"},
            new Customer {Id = 100065, Name = "Tony"},
        };
        var mock = new Mock<IRepo>();
        mock.Setup(x => x.Find(It.IsInRange(0, 2, Moq.Range.Inclusive)))
            .Returns((int x) => customers[x]);

        var controller = new TestController(mock.Object);
        var cust = controller.GetCustomer(index);
        Assert.Equal(id,cust.Id);
        Assert.Equal(name,cust.Name);
    }

    [Fact]
    public void Should_Call_In_Order()
    {
        var customers = new List<Customer>
        {
            new Customer {Id = 12, Name = "Bob"},
            new Customer {Id = 17, Name = "Sue"},
            new Customer {Id = 65, Name = "Tony"},
        };
        var sequence = new MockSequence();
        var mock1 = new Mock<IRepo>(MockBehavior.Strict);
        var mock2 = new Mock<IRepo>(MockBehavior.Strict);
        var mock3 = new Mock<IRepo>(MockBehavior.Strict);
        mock1.InSequence(sequence).Setup(x => x.Find(12)).Returns(customers[0]);
        mock2.InSequence(sequence).Setup(x => x.Find(17)).Returns(customers[1]);
        mock3.InSequence(sequence).Setup(x => x.Find(65)).Returns(customers[2]);

        var controller1 = new TestController(mock1.Object);
        var controller2 = new TestController(mock2.Object);
        var controller3 = new TestController(mock3.Object);
        _ = controller1.GetCustomer(12);
        _ = controller2.GetCustomer(17);
        _ = controller3.GetCustomer(65);
        mock1.VerifyAll();
        mock2.VerifyAll();
        mock3.VerifyAll();
    }
}