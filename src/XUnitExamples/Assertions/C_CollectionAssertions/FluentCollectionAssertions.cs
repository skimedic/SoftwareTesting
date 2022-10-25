// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - FluentCollectionAssertions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

using XUnitExamples.Assertions.B_ObjectAssertions;

namespace XUnitExamples.Assertions.C_CollectionAssertions;

public class FluentCollectionAssertions
{
    [Fact]
    public void BasicCollectionAssertions()
    {
        IEnumerable<int> collection = new[] { 1, 2, 5, 8 };

        collection.Should().NotBeEmpty()
            .And.HaveCount(4)
            .And.ContainInOrder(new[] { 2, 5 })
            .And.ContainItemsAssignableTo<int>();

        collection.Should().Equal(new List<int> { 1, 2, 5, 8 });
        collection.Should().Equal(1, 2, 5, 8);
        collection.Should().NotEqual(new List<int> { 8, 2, 3, 5 });

        collection.Should().BeEquivalentTo(new[] { 8, 2, 1, 5 });
        collection.Should().NotBeEquivalentTo(new[] { 8, 2, 3, 5 });

        collection.Should().HaveCount(c => c > 3).And.OnlyHaveUniqueItems();

        collection.Should().HaveCountGreaterThan(3);
        collection.Should().HaveCountGreaterThanOrEqualTo(4);
        collection.Should().HaveCountLessThanOrEqualTo(4);
        collection.Should().HaveCountLessThan(5);
        collection.Should().NotHaveCount(3);
        collection.Should().HaveSameCount(new[] { 6, 2, 0, 5 });
        collection.Should().NotHaveSameCount(new[] { 6, 2, 0 });

        collection.Should().StartWith(1);
        collection.Should().StartWith(new[] { 1, 2 });
        collection.Should().EndWith(8);
        collection.Should().EndWith(new[] { 5, 8 });

        collection.Should().BeSubsetOf(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, });

        //collection.Should().ContainSingle();
        collection.Should().ContainSingle(x => x > 5);
        collection.Should().Contain(8)
            .And.HaveElementAt(2, 5)
            .And.NotBeSubsetOf(new[] { 11, 56 });

        collection.Should().Contain(x => x > 3);
        collection.Should().Contain(collection, "", 5, 6); // It should contain the original items, plus 5 and 6.

        collection.Should().OnlyContain(x => x < 10);
        collection.Should().ContainItemsAssignableTo<int>();

        collection.Should().ContainInOrder(new[] { 1, 5, 8 });
        collection.Should().NotContainInOrder(new[] { 5, 1, 2 });

        collection.Should().NotContain(82);
        collection.Should().NotContain(new[] { 82, 83 });
        collection.Should().NotContainNulls();
        collection.Should().NotContain(x => x > 10);

        object boxedValue = 2;
        collection.Should().ContainEquivalentOf(boxedValue); // Compared by object equivalence
        object unexpectedBoxedValue = 82;
        collection.Should().NotContainEquivalentOf(unexpectedBoxedValue); // Compared by object equivalence

        const int successor = 5;
        const int predecessor = 5;
        collection.Should().HaveElementPreceding(successor, 2);
        collection.Should().HaveElementSucceeding(predecessor, 8);

        (new List<int>()).Should().BeEmpty();
        (new List<int>()).Should().BeNullOrEmpty();
        collection.Should().NotBeNullOrEmpty();

        IEnumerable<int> otherCollection = new[] { 1, 2, 5, 8, 1 };
        IEnumerable<int> anotherCollection = new[] { 10, 20, 50, 80, 10 };
        collection.Should().IntersectWith(otherCollection);
        collection.Should().NotIntersectWith(anotherCollection);

        var singleEquivalent = new[] { new { Size = 42 } };
        singleEquivalent.Should().ContainSingle()
            .Which.Should().BeEquivalentTo(new { Size = 42 });
    }

    [Fact]
    public void OrderingAssertions()
    {
        IEnumerable<int> collection = new[] { 1, 2, 5, 8 };

        collection.Should().BeInAscendingOrder();
        //collection.Should().BeInDescendingOrder();
        //collection.Should().NotBeInAscendingOrder();
        collection.Should().NotBeInDescendingOrder();

        List<Person> people = new List<Person>{
                new Person{FirstName="John",LastName= "Smith" },
                new Person{FirstName="Jane",LastName= "Smith"}
        };

        people.Should().BeInAscendingOrder(x => x.LastName);
        //people.Should().BeInDescendingOrder(x => x.LastName);
        //people.Should().NotBeInAscendingOrder(x => x.LastName);
        //people.Should().NotBeInDescendingOrder(x => x.LastName);
    }

    [Fact]
    public void StringCollections()
    {
        //* (asterisk)	Zero or more characters in that position.
        //? (question mark)	Exactly one character in that position.

        IEnumerable<string> stringCollection = new[] { "build succeeded", "test failed" };
        //stringCollection.Should().AllBe("build succeeded");
        stringCollection.Should().ContainMatch("* failed");
    }

    [Fact]
    public void Dictionaries()
    {
        Dictionary<int, string> dictionary = null;
        dictionary.Should().BeNull();

        dictionary = new Dictionary<int, string>();
        dictionary.Should().NotBeNull();
        dictionary.Should().BeEmpty();
        dictionary.Add(1, "first element");
        dictionary.Should().NotBeEmpty();


        var dictionary1 = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" }
        };

        var dictionary2 = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" }
        };

        var dictionary3 = new Dictionary<int, string>
        {
            { 3, "Three" },
        };

        dictionary1.Should().Equal(dictionary2);
        dictionary1.Should().NotEqual(dictionary3);

        dictionary.Should().ContainKey(1);
        //dictionary.Should().ContainKeys(1, 2);
        dictionary.Should().NotContainKey(9);
        dictionary.Should().NotContainKeys(9, 10);
        dictionary1.Should().ContainValue("One");
        dictionary1.Should().ContainValues("One", "Two");
        dictionary1.Should().NotContainValue("Nine");
        dictionary1.Should().NotContainValues("Nine", "Ten");

        dictionary1.Should().HaveCount(2);
        dictionary1.Should().NotHaveCount(3);

        dictionary1.Should().HaveSameCount(dictionary2);
        dictionary1.Should().NotHaveSameCount(dictionary3);

        dictionary1.Should().HaveSameCount(dictionary2.Keys);
        dictionary1.Should().NotHaveSameCount(dictionary3.Keys);

        KeyValuePair<int, string> item1 = new KeyValuePair<int, string>(1, "One");
        KeyValuePair<int, string> item2 = new KeyValuePair<int, string>(2, "Two");

        dictionary1.Should().Contain(item1);
        dictionary1.Should().Contain(item1, item2);
        dictionary1.Should().Contain(2, "Two");
        dictionary.Should().NotContain(item1);
        dictionary.Should().NotContain(item1, item2);
        dictionary.Should().NotContain(9, "Nine");
    }
}