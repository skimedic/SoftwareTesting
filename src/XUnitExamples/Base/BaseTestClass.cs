// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - BaseTestClass.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Base;

public abstract class BaseTestClass : IDisposable
{
    protected readonly ITestOutputHelper TestOutputWriter;

    protected BaseTestClass(ITestOutputHelper output)
    {
        TestOutputWriter = output;
    }

    public virtual void Dispose()
    {
    }
}