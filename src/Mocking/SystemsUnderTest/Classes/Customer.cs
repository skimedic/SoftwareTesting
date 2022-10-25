// Copyright Information
// ==================================
// SoftwareTesting - Mocking - Customer.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace Mocking.SystemsUnderTest.Classes;

public class Customer
{
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }

    public virtual Address AddressNavigation { get; set; }
}