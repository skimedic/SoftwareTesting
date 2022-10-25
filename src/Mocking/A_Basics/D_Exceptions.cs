// Copyright Information
// ==================================
// SoftwareTesting - Mocking - D_Exceptions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.A_Basics;

public class Exceptions
{
    [Fact]
    public void Should_Mock_General_Exceptions()
    {
        var id = 12;
        var mock = new Mock<IRepo>();
        mock.Setup(x => x.Find(id)).Throws<ArgumentException>();
        var controller = new TestController(mock.Object);
        Assert.Throws<ArgumentException>(() => controller.GetCustomer(id));
        mock.SetupGet(x => x.TenantId).Throws<ArgumentException>();
        Assert.Throws<ArgumentException>(() => controller.TenantId());
        mock.SetupSet(x => x.TenantId = id).Throws<ArgumentException>();
        Assert.Throws<ArgumentException>(() => controller.SetTenantId(12));
    }

    [Fact]
    public void Should_Mock_Specific_Exception_Instances()
    {
        var id = 12;
        var mock = new Mock<IRepo>();
        var param = "Id";
        var message = "Missing parameter";
        var argumentException = new ArgumentException(message, param);
        mock.Setup(x => x.Find(id)).Throws(argumentException);
        var controller = new TestController(mock.Object);
        var ex = Assert.Throws<ArgumentException>(() => controller.GetCustomer(id));
        Assert.Same(argumentException, ex);
        Assert.Equal($"{message} (Parameter '{param}')", ex.Message);
        Assert.Equal(param, ex.ParamName);
    }
}