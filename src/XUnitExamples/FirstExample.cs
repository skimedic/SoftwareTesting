// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - FirstExample.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples;

/*
Put all test classes into a single test collection by default:
  [assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
Default: CollectionBehavior.CollectionPerClass
Set the maximum number of threads to use when running test in parallel:
  [assembly: CollectionBehavior(MaxParallelThreads = n)]
Default: number of virtual CPUs in the PC
Turn off parallelism inside the assembly:
  [assembly: CollectionBehavior(DisableTestParallelization = true)]
Default: false
*/

//Tests in a class or a collection are run in serial
//Tests in different classes or different collections are run in parallel
[Collection("MyTests")]
public class FirstExample : IDisposable
{
    //This allows for output in the test runner
    private readonly ITestOutputHelper _output;

    //Constructor is test setup
    public FirstExample(ITestOutputHelper output)
    {
        this._output = output;
    }

    //dispose is test teardown
    public void Dispose()
    {
    }

    [Fact]
    public void FirstFact()
    {
        //throw new NotImplementedException("Foo");
        _output.WriteLine("First fact passed on VS Toolbox");
        Assert.Equal(5, 3 + 2);
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(7, 3, 4)]
    [InlineData(-1, -3, 2)]
    //[InlineData(-1, int.MaxValue, int.MaxValue)]
    public void FirstTheory(int expected, int addend1, int addend2)
    {
        _output.WriteLine($"First Theory {expected},{addend1},{addend2}");
        Assert.Equal(expected, addend1 + addend2);
    }

    [Fact(Skip = "Passing over because it has to fail to show the message")]
    //[Fact]
    public void ShowCustomMessage()
    {
        //Custom messages only show when a test fails
        Assert.True(false, "Custom Message shown here");
    }

    [Fact(Skip = "Passing over because it has to fail to show the message")]
    //[Fact]
    public void ShowDefaultMessage()
    {
        //Custom messages only show when a test fails
        Assert.True(false);
    }

    [Fact(Skip = "Passing over because it has to fail to show the message")]
    //[Fact]
    public void ShowCustomFluentMessage()
    {
        //Custom messages only show when a test fails
        IEnumerable<int> numbers = new[] { 1, 2, 3 };
        numbers.Should().HaveCount(4, "because we thought we put four items in the collection");
    }

    [Fact(DisplayName = "Ignored Test - Custom Display Name")]
    public void ThisWasRenamed()
    {
    }
}