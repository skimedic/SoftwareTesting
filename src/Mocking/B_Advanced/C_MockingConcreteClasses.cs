// Copyright Information
// ==================================
// SoftwareTesting - Mocking - C_MockingConcreteClasses.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.B_Advanced;

public class MockingConcreteClasses
{
    [Fact]
    public void Should_Replace_Concrete_Implementation()
    {
        var skimedic = "Fred Flintstone";
        var cust = new Customer { Id = 12, Name = skimedic };
        //var mockRepo = new Mock<IRepo> { CallBase = true};
        var mockRepo = new Mock<FakeRepo> { CallBase = true};

        mockRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(cust);
        var sut = new TestController(mockRepo.Object);
        var cust2 = sut.GetCustomer(13);
        Assert.Equal(cust.Id, cust2.Id);
        Assert.Equal(cust.Name, cust2.Name);
        mockRepo.Verify(x => x.Find(13));
    }

    [Fact]
    public void Should_Mock_Nested_Property_Getters_On_Objects()
    {
        //properties need to be virtual if nested
        var mock = new Mock<FakeRepo>();
        var name = "Fred Flintstone";
        mock.Setup(x => x.CurrentCustomer.Name).Returns(name);
        var controller = new TestController(mock.Object);
        Assert.Equal(name, controller.GetCurrentCustomer.Name);
    }

    [Fact]
    public void Should_Mock_Protected_Members()
    {
        var mock = new Mock<FakeRepo>();
        mock.Protected().Setup<int>("GetNumber").Returns(12);
        Assert.Equal(12, mock.Object.CallProtectedMember());
        mock.Protected().Setup<int>("GetNumberWithParam",ItExpr.IsAny<int>()).Returns(15);
        Assert.Equal(15, mock.Object.CallProtectedMemberWithParam(4));
    }
    [Fact]
    public void Should_Mock_Protected_Members_Using_Lambdas()
    {
        //FakeMockInterface gives us intellisense
        var mock = new Mock<FakeRepo>();
        mock.Protected().As<FakeMockInterface>().Setup(m => m.GetNumber()).Returns(12);
        Assert.Equal(12, mock.Object.CallProtectedMember());
        mock.Protected().As<FakeMockInterface>().Setup(m => m.GetNumberWithParam(It.IsAny<int>())).Returns(15);
        Assert.Equal(15, mock.Object.CallProtectedMemberWithParam(4));
    }
}