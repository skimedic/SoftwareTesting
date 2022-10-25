// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - MemberDataTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Theories;

public class MemberDataTests : BaseTestClass
{
    public MemberDataTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void ShouldReturnProperValue(int input, string expectedResult)
    {
        TestOutputWriter.WriteLine($"{input}:{expectedResult}");
    }

    public static IEnumerable<object[]> TestData
        => new[]
        {
            new object[] { 1, "1" },
            new object[] { 2, "2" },
            new object[] { 3, "Fizz" },
            new object[] { 4, "4" },
            new object[] { 5, "Buzz" },
            new object[] { 6, "Fizz" },
            new object[] { 15, "FizzBuzz" },
        };

    [Theory]
    [MemberData(nameof(TestDataWithObjects))]
    public void ShouldReturnProperValueUsingRecords(RecordForTestData data)
    {
        TestOutputWriter.WriteLine($"{data.Input}:{data.ExpectedResult}");

    }

    public static IEnumerable<object[]> TestDataWithObjects
        => new[]
        {
            new object[] { new RecordForTestData(1, "1" )},
            new object[] { new RecordForTestData(2, "2" )},
            new object[] { new RecordForTestData(3, "Fizz" )},
            new object[] { new RecordForTestData(4, "4" )},
            new object[] { new RecordForTestData(5, "Buzz" )}
        };
}