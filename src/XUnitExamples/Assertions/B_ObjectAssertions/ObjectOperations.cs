// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - ObjectOperations.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Assertions.B_ObjectAssertions;

public class ObjectOperations  
{
    readonly Person _p1;
    readonly Person _p2;
    readonly PersonRecord _r1;
    readonly PersonRecord _r2;

    public ObjectOperations()  
    {
        _p1 = new Person { FirstName = "John", LastName = "Doe" };
        _p2 = new Person { FirstName = "John", LastName = "Doe" };

        _r1 = new PersonRecord("John", "Doe");
        _r2 = new PersonRecord("John", "Doe");
    }

    [Fact]
    public void ObjectComparisons()
    {
        Person p3 = default;
        PersonRecord r3 = default;

        //Nullability
        Assert.Null(p3);
        Assert.Null(r3);
        Assert.NotNull(_p1);

        p3.Should().BeNull("because the value is null");
        _p1.Should().NotBeNull("because the value is not null");


        //Same check - reference types
        Assert.NotSame(_p1, _p2);
        Assert.NotSame(_r1, _r2);
        _r1.Should().NotBeSameAs(_r2);

        //Equal 
        Assert.NotEqual(_p1, _p2);
        _p1.Should().NotBe(_p2);
        //Records provide value type equality checks
        Assert.Equal(_r1, _r2);
        _r1.Should().Be(_r2);

        r3 = _r2 with { LastName = "Doe" };
        Assert.Equal(_r1, r3);

        //Classes are equal with custom comparer
        Assert.Equal(_p1, _p2, new PersonEqualityComparer());

        Assert.NotSame(_p1, _p2);
        Assert.NotSame(_r1, _r2);

        p3 = _p1;
        Assert.Same(_p1, p3);
        p3.Should().BeSameAs(_p1);

        var r4 = _r1;
        Assert.Same(_r1, r4);
        r4.Should().BeSameAs(_r1);

        //Use built in IsEqual
        Assert.StrictEqual(_r1, _r2);
        //Same as this code
        Assert.True(_r1.Equals(_r2));
    }


    [Fact]
    public void InterfacesAndHierarchies()
    {
        Assert.IsType<Person>(_p1);
        _p1.Should().BeOfType<Person>("because a {0} is set", typeof(string));
        _p1.Should().BeOfType(typeof(Person),"because a {0} is set", typeof(string));


        Type T = typeof(Person);
        Assert.IsType(T, _p1);

        var hp1 = new HeroPerson { FirstName = "Clark", LastName = "Kent", HeroSkill = "Fly" };
        Assert.IsNotType(T, hp1);
        Assert.IsNotType<Person>(hp1);

        Assert.IsAssignableFrom(T, hp1);
        Assert.IsAssignableFrom<Person>(hp1);

        hp1.Should().BeAssignableTo<Person>();
    }
}