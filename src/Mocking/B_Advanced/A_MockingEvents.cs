// Copyright Information
// ==================================
// SoftwareTesting - Mocking - A_MockingEvents.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.B_Advanced;

public class MockingEvents
{
    [Fact]
    public void Should_Mock_Events()
    {
        var mockRepo = new Mock<IRepo>();
        var mockLogger = new Mock<ILogger>();
        Expression<Action<ILogger>> expression = x=>x.Error("An error occurred");
        //Expression<Action<ILogger>> expression = x=>x.Error(It.IsAny<string>());
        mockLogger.Setup(expression).Verifiable();
        var controller = new TestController(mockRepo.Object, mockLogger.Object);
        mockRepo.Raise(m=>m.FailedDatabaseRequest += null,this,EventArgs.Empty);
        mockLogger.Verify(expression);
    }

    [Fact]
    public void Should_Mock_Events_Based_On_Action()
    {
        var mockRepo = new Mock<IRepo>();
        mockRepo.Setup(x => x.AddRecord(null))
            .Raises(m => m.FailedDatabaseRequest += null, this, EventArgs.Empty).Verifiable();
        //mockRepo.Setup(x => x.Find(5)).Returns(new Customer())
        //    .Raises(m => m.FailedDatabaseRequest += null, this, EventArgs.Empty);
        var mockLogger = new Mock<ILogger>();
        Expression<Action<ILogger>> expression = x=>x.Error("An error occurred");
        //Expression<Action<ILogger>> expression = x=>x.Error(It.IsAny<string>());
        mockLogger.Setup(expression).Verifiable();
        var controller = new TestController(mockRepo.Object, mockLogger.Object);
        controller.SaveCustomer(null);
        mockLogger.Verify(expression);
    }
}