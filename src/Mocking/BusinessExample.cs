namespace Mocking;

public class TestBusinessRulesUsingMock
{
    private Mock<IRepo> _mockRepo = new Mock<IRepo>(MockBehavior.Strict);
    private Mock<IErrorHandler> _mockErrorHandler = new Mock<IErrorHandler>(MockBehavior.Strict);
    private BetterExample _sut;

    public TestBusinessRulesUsingMock()
    {
        _sut = new BetterExample(_mockRepo.Object,_mockErrorHandler.Object);
    }

    [Theory]
    [InlineData(1, "Fred", CharacterStatusEnum.Father)]
    [InlineData(2, "Wilma", CharacterStatusEnum.Mother)]
    [InlineData(3, "Pebbles", CharacterStatusEnum.Child)]
    public void ShouldGetACustomer(int id, string name, CharacterStatusEnum status)
    {
        _mockRepo.Setup(x => x.Find(id)).Returns(new Customer { Id = id, Name = name });
        _mockErrorHandler.Setup(x => x.HandleIt()).Verifiable();
        Assert.Equal(status, _sut.GetCustomerStatus(id));
        _mockErrorHandler.Verify(x => x.HandleIt(),Times.Never);
    }
    [Theory]
    [InlineData(1, "Grand Poobah", CharacterStatusEnum.Child)]
    public void ShouldFailToGetACustomer(int id, string name, CharacterStatusEnum status)
    {
        
        var ex1 = new Exception("Unable to locate");
        _mockRepo.Setup(x => x.Find(id)).Throws(ex1);       
        _mockErrorHandler.Setup(x => x.HandleIt());
        var ex2 = Assert.Throws<Exception>(()=>_sut.GetCustomerStatus(id));
        Assert.Equal(ex1.Message,ex2.Message);
        _mockErrorHandler.Verify(x => x.HandleIt(),Times.Once);
    }

}

public enum CharacterStatusEnum
{
    Father,
    Mother,
    Child,
    Boss,
    Unkown
}

public interface IErrorHandler
{
    void HandleIt();
}
public class BetterExample
{
    private readonly IRepo _repo;
    private readonly IErrorHandler _errorHandler;

    public BetterExample(IRepo repo, IErrorHandler errorHandler)
    {
        _repo = repo;
        _errorHandler = errorHandler;
    }

    public CharacterStatusEnum GetCustomerStatus(int id)
    {
        Customer character;
        try
        {
            character = _repo.Find(id);
        }
        catch (Exception ex)
        {
            _errorHandler.HandleIt();
            //_errorHandler.HandleIt();
            throw;
        }
        switch (character.Name)
        {
            case "Fred":
            case "Barney":
                return CharacterStatusEnum.Father;
            case "Betty":
            case "Wilma":
                return CharacterStatusEnum.Mother;
            case "Pebbles":
            case "BamBam":
                return CharacterStatusEnum.Child;
            case "Slate":
                return CharacterStatusEnum.Boss;
            default:
                throw new Exception("Unable to locate status");
        }
    }
}

