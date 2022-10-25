// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - DateTimeOperations.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Assertions.A_BasicAssertions;

public class DateTimeOperations
{
    [Fact]
    public void DateEqualityAssertions()
    {
        var date1 = new DateTime(2022, 06, 01, 12, 0, 0);
        var date2 = new DateTime(2022, 06, 01, 12, 0, 30);

        //Compare date values exactly
        Assert.NotEqual(date1, date2);
        //Use a timespan to allow for precision
        Assert.Equal(date1, date2, TimeSpan.FromSeconds(30));
    }

    [Fact]
    public void FluentDateComparisons()
    {
        var theDatetime = 1.March(2010).At(22, 15).AsLocal();
        var otherDatetime = 1.March(2010).At(22, 20).AsLocal();

        theDatetime.Should().BeLessThan(10.Minutes()).Before(otherDatetime); // Equivalent to <
        otherDatetime.Should().BeWithin(2.Hours()).After(theDatetime);       // Equivalent to <=
        //theDatetime.Should().BeMoreThan(1.Days()).Before(otherDatetime);          // Equivalent to >
        //theDatetime.Should().BeAtLeast(2.Days()).Before(otherDatetime);       // Equivalent to >=
        //theDatetime.Should().BeExactly(24.Hours()).Before(otherDatetime);      // Equivalent to ==
    }

    [Fact]
    public void FluentDateAssertions()
    {
        var theDatetime = 1.March(2010).At(22, 15).AsLocal();

        theDatetime.Should().Be(1.March(2010).At(22, 15));
        theDatetime.Should().BeAfter(1.February(2010));
        theDatetime.Should().BeBefore(2.March(2010));
        theDatetime.Should().BeOnOrAfter(1.March(2010));
        theDatetime.Should().BeOnOrBefore(2.March(2010));
        theDatetime.Should().BeSameDateAs(1.March(2010).At(22, 16));
        theDatetime.Should().BeIn(DateTimeKind.Local);

        theDatetime.Should().NotBe(1.March(2010).At(22, 16));
        theDatetime.Should().NotBeAfter(2.March(2010));
        theDatetime.Should().NotBeBefore(1.February(2010));
        theDatetime.Should().NotBeOnOrAfter(2.March(2010));
        theDatetime.Should().NotBeOnOrBefore(1.February(2010));
        theDatetime.Should().NotBeSameDateAs(2.March(2010));

        theDatetime.Should().BeOneOf(
            1.March(2010).At(21, 15),
            1.March(2010).At(22, 15),
            1.March(2010).At(23, 15)
        );

        DateTimeOffset theDatetimeOffset1 = 1.March(2010).At(22, 15).WithOffset(2.Hours());

        // Asserts the point in time. 
        theDatetimeOffset1.Should().Be(1.March(2010).At(21, 15).WithOffset(1.Hours()));
        theDatetimeOffset1.Should().NotBe(2.March(2010).At(21, 15).WithOffset(1.Hours()));

        //Asserts the calendar date/time and the offset
        //theDatetimeOffset1.Should().BeExactly(1.March(2010).At(23, 15).WithOffset(1.Hours()));
        theDatetimeOffset1.Should().NotBeExactly(1.March(2010).At(21, 15).WithOffset(1.Hours()));

        //Date Parts
        theDatetime.Should().HaveDay(1);
        theDatetime.Should().HaveMonth(3);
        theDatetime.Should().HaveYear(2010);
        theDatetime.Should().HaveHour(22);
        theDatetime.Should().HaveMinute(15);
        theDatetime.Should().HaveSecond(0);

        theDatetime.Should().NotHaveDay(2);
        theDatetime.Should().NotHaveMonth(4);
        theDatetime.Should().NotHaveYear(2011);
        theDatetime.Should().NotHaveHour(23);
        theDatetime.Should().NotHaveMinute(16);
        theDatetime.Should().NotHaveSecond(1);

        DateTimeOffset theDatetimeOffset2 = 1.March(2010).AsUtc().WithOffset(2.Hours());

        theDatetimeOffset2.Should().HaveOffset(TimeSpan.FromHours(2));
        theDatetimeOffset2.Should().NotHaveOffset(TimeSpan.FromHours(3));
    }

    [Fact]
    public void FluentTimeSpans()
    {
        var timeSpan = new TimeSpan(12, 59, 59);
        timeSpan.Should().BePositive();
       // timeSpan.Should().BeNegative();
        //timeSpan.Should().Be(12.Hours());
        timeSpan.Should().NotBe(1.Days());

        //timeSpan.Should().BeLessThan(someOtherTimeSpan);
        //timeSpan.Should().BeLessThanOrEqualTo(someOtherTimeSpan);
        //timeSpan.Should().BeGreaterThan(someOtherTimeSpan);
        //timeSpan.Should().BeGreaterThanOrEqualTo(someOtherTimeSpan);

        timeSpan.Should().BeCloseTo(new TimeSpan(13, 0, 0), 5.Seconds());
        timeSpan.Should().NotBeCloseTo(new TimeSpan(14, 0, 0), 10.Ticks());
    }
}