namespace Mocking;

public class TestUsingFake
{
    private UseADependency _sut = new UseADependency(new FakeRepo());

    [Theory]
    [InlineData(1, "Fred")]
    [InlineData(2, "Wilma")]
    [InlineData(3, "Pebbles")]
    public void ShouldGetACustomer(int id, string name)
    {
        Assert.Equal(name,_sut.GetCustomer(id).Name);
        switch (_sut.GetCustomer(id).Name)
        {
            case "Fred":
                break;
        }
    }

}
public class TestUsingMock
{
    private Mock<IRepo> _mockRepo = new Mock<IRepo>();
    private UseADependency _sut;

    public TestUsingMock()
    {
        _sut = new UseADependency(_mockRepo.Object);
    }

    [Theory]
    [InlineData(1, "Fred")]
    [InlineData(2, "Wilma")]
    [InlineData(3, "Pebbles")]
    public void ShouldGetACustomer(int id, string name)
    {
        _mockRepo.Setup(x=>x.Find(id)).Returns(new Customer{Id=id, Name = name});
        Assert.Equal(name,_sut.GetCustomer(id).Name);
    }

}


public class UseADependency
{
    private readonly IRepo _repo;

    public UseADependency(IRepo repo)
    {
        _repo = repo;
    }

    public Customer GetCustomer(int id)
    {
        return _repo.Find(id);
    }
}

