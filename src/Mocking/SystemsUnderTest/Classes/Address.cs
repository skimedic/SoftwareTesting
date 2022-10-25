// Copyright Information
// ==================================
// SoftwareTesting - Mocking - Address.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.SystemsUnderTest.Classes;

public class Address
{
    public virtual int Id { get; set; }
    public virtual int StreetNumber { get; set; }
    public virtual string StreetName { get; set; }
    public virtual string StateCode { get; set; }
    public virtual string Country { get; set; }
}