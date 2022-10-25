// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - CollectionOperations.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Assertions.C_CollectionAssertions;

public class CollectionOperations : BaseTestClass
{
    public CollectionOperations(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void SimpleCollectionAsserts()
    {
        List<int> list1 = new();

        Assert.Empty(list1);
        list1.Add(0);
        Assert.NotEmpty(list1);
        Assert.Single(list1);

        Assert.Single(list1, 0);
        Assert.Single<int>(list1);
        list1.Add(1);
        Assert.Single<int>(list1, x => x < 1);
        Assert.All<int>(list1, x => Assert.True(x >= 0));

        Assert.Contains<int>(1, list1);
        Assert.DoesNotContain<int>(2, list1);
    }

    [Fact]
    public void DictionaryAsserts()
    {
        //Getting compile error if using var
        IDictionary<int, int> dictionary1 = new Dictionary<int, int>();
        Assert.DoesNotContain<int, int>(1, dictionary1);
        dictionary1.Add(0, 0);
        Assert.Contains<int, int>(0, dictionary1);

        IReadOnlyDictionary<int, int> readOnly = new ReadOnlyDictionary<int, int>(dictionary1);

        Assert.Contains<int, int>(0, readOnly);
        Assert.DoesNotContain<int, int>(1, readOnly);
    }

}