// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - TestDataClass.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Theories;

public class TestDataClass : IEnumerable<object[]>

{
    private readonly List<object[]> _data = new()
    {
        new object[] { new RecordForTestData(1, "1") },
        new object[] { new RecordForTestData(2, "2") },
        new object[] { new RecordForTestData(3, "Fizz") },
        new object[] { new RecordForTestData(4, "4") },
        new object[] { new RecordForTestData(5, "Buzz") },
        new object[] { new RecordForTestData(6, "Fizz") },
        new object[] { new RecordForTestData(15, "FizzBuzz") }
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}