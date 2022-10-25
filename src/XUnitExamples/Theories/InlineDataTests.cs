// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - InlineDataTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Theories;

public class InlineDataTests : BaseTestClass
{
    public InlineDataTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "Fizz")]
    [InlineData(4, "4")]
    [InlineData(5, "Buzz")]
    [InlineData(6, "Fizz")]
    [InlineData(15, "FizzBuzz")]
    public void ShouldReturnProperValue(int input, string expectedResult)
    {
        TestOutputWriter.WriteLine($"{input}:{expectedResult}");
    }
}