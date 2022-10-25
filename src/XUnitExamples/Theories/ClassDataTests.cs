// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - ClassDataTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Theories;

public class ClassDataTests : BaseTestClass
{
    public ClassDataTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }


    [Theory]
    [ClassData(typeof(TestDataClass))]
    public void ShouldReturnProperValue(RecordForTestData data)
    {
        TestOutputWriter.WriteLine($"{data.Input}:{data.ExpectedResult}");
    }
}