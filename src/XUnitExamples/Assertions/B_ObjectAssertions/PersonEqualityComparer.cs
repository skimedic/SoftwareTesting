// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - PersonEqualityComparer.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Assertions.B_ObjectAssertions;

public class PersonEqualityComparer : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.FirstName == y.FirstName && x.LastName == y.LastName;
    }

    public int GetHashCode(Person obj)
    {
        return HashCode.Combine(obj.FirstName, obj.LastName);
    }
}