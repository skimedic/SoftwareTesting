// Copyright Information
// ==================================
// SoftwareTesting - Mocking - C_Properties.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.A_Basics;

public class Properties
{
    [Fact]
    public void Should_Mock_Property_Getters()
    {
        var mock = new Mock<IRepo>(MockBehavior.Strict);
        var tenantId = 5;
        mock.Setup(x => x.TenantId).Returns(tenantId);
        var controller = new TestController(mock.Object);
        Assert.Equal(tenantId, controller.TenantId());
        //This will fail because it's not set up
        Assert.Throws<MockException>(()=>mock.Object.TenantId = 12);
    }

    [Fact]
    public void Should_Setup_Property_Setter_And_Getter()
    {
        var mock = new Mock<IRepo>(MockBehavior.Strict);
        mock.SetupProperty(x => x.TenantId);
        var controller = new TestController(mock.Object);
        Assert.Equal(0, controller.TenantId());

        var newTenantId = 12;
        //This works because it's set up
        mock.Object.TenantId = newTenantId;
        Assert.Equal(newTenantId, controller.TenantId());
    }

    [Fact]
    public void Should_Setup_Property_Setter_And_Getter_With_Default_Value()
    {
        var mock = new Mock<IRepo>(MockBehavior.Strict);
        var tenantId = 5;
        mock.SetupProperty(x => x.TenantId, tenantId);
        var controller = new TestController(mock.Object);
        Assert.Equal(tenantId, controller.TenantId());

        var newTenantId = 12;
        mock.Object.TenantId = newTenantId;
        Assert.Equal(newTenantId, controller.TenantId());
    }

    [Fact]
    public void Should_Do_Nothing_When_Property_Not_Stubbed()
    {
        var mock = new Mock<IRepo>(MockBehavior.Loose);
        var controller = new TestController(mock.Object);
        
        Assert.Equal(0, controller.TenantId());
        var newTenantId = 12;
        controller.SetTenantId(newTenantId);
        
        Assert.NotEqual(newTenantId, controller.TenantId());
    }

    [Fact]
    public void Should_Stub_All_Properties()
    {
        var mock = new Mock<IRepo>(MockBehavior.Strict);
        mock.SetupAllProperties();

        var controller = new TestController(mock.Object);
        Assert.Equal(0, controller.TenantId());

        var newTenantId = 12;
        mock.Object.TenantId = newTenantId;
        Assert.Equal(newTenantId, controller.TenantId());
    }

    [Fact]
    public void Should_Setup_Getter_With_SetupGet()
    {
        var tenantId = 12;
        var mock = new Mock<IRepo>(MockBehavior.Strict);
        mock.SetupGet(x => x.TenantId).Returns(tenantId);
        var controller = new TestController(mock.Object);
        Assert.Equal(tenantId, controller.TenantId());
    }
    [Fact]
    public void Should_Setup_Setter_With_SetupSet()
    {
        var tenantId = 12;
        var mock = new Mock<IRepo>(MockBehavior.Strict);
        mock.SetupSet(x => x.TenantId=tenantId);
        var controller = new TestController(mock.Object);
        //Fails due to no set up
        Assert.ThrowsAny<Exception>(()=>Assert.Equal(0, controller.TenantId()));
        Assert.Throws<MockException>(()=>Assert.Equal(0, controller.TenantId()));
        Assert.Throws<MockException>(()=>mock.Object.TenantId = 15);
    }

}