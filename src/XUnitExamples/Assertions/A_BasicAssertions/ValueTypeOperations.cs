// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - ValueTypeOperations.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Assertions.A_BasicAssertions;

public class ValueTypeOperations 
{
    [Fact]
    public void AssertsForBooleans()
    {
        bool nonNullableBool = false;
        bool? nullableBool = false;

        Assert.False(nonNullableBool);
        Assert.False(nullableBool);
        nonNullableBool.Should().BeFalse("it's set to false");
        nonNullableBool.Should().NotBe(true);

        Assert.False(nonNullableBool, "Custom Message");
        Assert.False(nullableBool, "Custom Message");

        nonNullableBool = true;
        nullableBool = true;

        Assert.True(nonNullableBool);
        Assert.True(nullableBool);
        Assert.True(nonNullableBool, "Custom Message");
        Assert.True(nullableBool, "Custom Message");

        nonNullableBool.Should().BeTrue();
        nonNullableBool.Should().NotBe(false);
        nonNullableBool.Should().Be(nullableBool.Value);

    }

    [Fact]
    public void NumericEqualityAssertions()
    {
        var intNumber1 = 5;
        var intNumber2 = 5;
        Assert.Equal(intNumber1, intNumber2);

        var doubleNumber1 = 5d;
        var doubleNumber2 = 5d;
        Assert.Equal(doubleNumber1, doubleNumber2);


        var decimalNumber1 = 5M;
        var decimalNumber2 = 5M;
        Assert.Equal(decimalNumber1, decimalNumber2);

        //mixing types
        Assert.Equal(decimalNumber1, intNumber2);

        //specify rounding precision
        doubleNumber1 = 5.1d;
        doubleNumber2 = 4.9d;
        Assert.Equal(doubleNumber1, doubleNumber2, 0);

        //half numbers round to even number
        doubleNumber1 = 3.5d; //rounds up to 4 (even)
        doubleNumber2 = 4.5d; // rounds down to 4
        Assert.Equal(doubleNumber1, doubleNumber2, 0);


        //not equal works the same way
        doubleNumber1 = 4.3d;
        doubleNumber2 = 4.6d;
        Assert.NotEqual(doubleNumber1, doubleNumber2);
        Assert.NotEqual(doubleNumber1, doubleNumber2, 0);
    }

    [Fact]
    public void NumericRangeAssertions()
    {
        var number1 = 5;
        Assert.InRange(number1, 3, 10);
        Assert.InRange(number1, 5, 10);
        Assert.InRange(number1, 3, 5);
        Assert.NotInRange(number1, 7, 10);
    }


    [Fact]
    public void FluentNumericAssertions()
    {
        int theInt = 5;
        theInt.Should().BeGreaterThanOrEqualTo(5);
        theInt.Should().BeGreaterThanOrEqualTo(3);
        theInt.Should().BeGreaterThan(4);
        theInt.Should().BeLessThanOrEqualTo(5);
        theInt.Should().BeLessThan(6);
        theInt.Should().BePositive();
        theInt.Should().Be(5);
        theInt.Should().NotBe(10);
        theInt.Should().BeInRange(1, 10);
        theInt.Should().NotBeInRange(6, 10);
        theInt.Should().Match(x => x % 2 == 1);

        theInt = 0;
        //theInt.Should().BePositive(); => Expected positive value, but found 0
        //theInt.Should().BeNegative(); => Expected negative value, but found 0

        theInt = -8;
        theInt.Should().BeNegative();

        int? nullableInt = 3;
        nullableInt.Should().Be(3);

        double theDouble = 5.1;
        theDouble.Should().BeGreaterThan(5);
        byte theByte = 2;
        theByte.Should().Be(2);
        
        //Notice that Should().Be() and Should().NotBe() are not available for floats and doubles.
        //Floating point variables are inheritably inaccurate and should never be compared for equality.
        //Instead, either use the Should().BeInRange() method or the following method specifically designed for
        //floating point or decimal variables.

        float value1 = 3.1415927F;
        value1.Should().BeApproximately(3.14F, 0.01F);


        float value2 = 3.5F;
        value2.Should().NotBeApproximately(2.5F, 0.5F);

        int value3 = 6;
        value3.Should().BeOneOf(new[] { 3, 6});
    }
}