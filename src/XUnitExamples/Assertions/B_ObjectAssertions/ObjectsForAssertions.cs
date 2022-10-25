// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - ObjectsForAssertions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Assertions.B_ObjectAssertions;

public interface IPerson
{
    string FirstName { get; set; }
    string LastName { get; set; }
}

public class Person : IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class HeroPerson : Person
{
    public string HeroSkill { get; set; }
}

public record class PersonRecord(string FirstName, string LastName);