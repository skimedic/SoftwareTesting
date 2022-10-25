// Copyright Information
// ==================================
// SoftwareTesting - Mocking - ILogger.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.SystemsUnderTest.Interfaces;

public interface ILogger
{
    public void Error(string message);
    public void Debug(string message);
}