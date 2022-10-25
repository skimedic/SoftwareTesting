// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - StringOperations.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Assertions.A_BasicAssertions;

public class StringOperations
{
    [Fact]
    public void StringAssertions()
    {
        Assert.Contains("CDE", "ABCDEF");
        Assert.Contains("def", "ABCDEF", StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("XYZ", "ABCDEF");
        Assert.DoesNotContain("def", "ABCDEF");
        Assert.DoesNotContain("XYZ", "ABCDEF", StringComparison.OrdinalIgnoreCase);
        Assert.StartsWith("ABC", "ABCDEF");
        Assert.StartsWith("abc", "ABCDEF", StringComparison.OrdinalIgnoreCase);
        Assert.EndsWith("DEF", "ABCDEF");
        Assert.EndsWith("def", "ABCDEF", StringComparison.OrdinalIgnoreCase);
        var string1 = "this is a string";
        var string2 = @"this  is  a  string";
        Assert.Equal(string1, string2, true, true, true);
        //Assert.Equal(string expected, string actual, bool ignoreCase = false, bool ignoreLineEndingDifferences = false, bool ignoreWhiteSpaceDifferences = false)
    }

    [Fact]
    public void FluentStringAssertions()
    {
        string theString = "";
        theString.Should().NotBeNull();
        //theString.Should().BeNull();
        theString.Should().BeEmpty();
        //theString.Should().NotBeEmpty("because the string is not empty");
        theString.Should().HaveLength(0);
        theString.Should().BeNullOrWhiteSpace(); // either null, empty or whitespace only
        //theString.Should().NotBeNullOrWhiteSpace();

        theString = "This is a String";

        //Casing - fails with numbers since numbers don't have casing
        //theString.Should().BeUpperCased();
        theString.Should().NotBeUpperCased();
        //theString.Should().BeLowerCased();
        theString.Should().NotBeLowerCased();

        theString.Should().Be("This is a String");
        theString.Should().NotBe("This is another String");
        theString.Should().BeEquivalentTo("THIS IS A STRING");
        theString.Should().NotBeEquivalentTo("THIS IS ANOTHER STRING");

        theString.Should().BeOneOf("That is a String", "This is a String");

        theString.Should().Contain("is a");
        theString.Should().Contain("is a", Exactly.Once());
        //theString.Should().Contain("is a", AtLeast.Twice());
        //theString.Should().Contain("is a", MoreThan.Thrice());
        theString.Should().Contain("is a", AtMost.Times(5));
        theString.Should().Contain("is a", LessThan.Twice());
        //theString.Should().ContainAll("should", "contain", "all", "of", "these");
        theString.Should().ContainAny("any", "of", "these", "will", "do", "is");
        theString.Should().NotContain("was a");
        theString.Should().NotContain("IS A");
        theString.Should().NotContainAll("can", "contain", "some", "but", "not", "all", "is","a");
        theString.Should().NotContainAny("can't", "contain", "any", "of", "these");

        //Case insensitive
        theString.Should().ContainEquivalentOf("THIS IS A STRING");
        theString.Should().ContainEquivalentOf("THIS IS A STRING", Exactly.Once());
        //theString.Should().ContainEquivalentOf("THIS IS A STRING", AtLeast.Twice());
        //theString.Should().ContainEquivalentOf("THIS IS A STRING", MoreThan.Thrice());
        theString.Should().ContainEquivalentOf("THIS IS A STRING", AtMost.Times(5));
        theString.Should().ContainEquivalentOf("THIS IS A STRING", LessThan.Twice());
        theString.Should().NotContainEquivalentOf("HeRe ThE CaSiNg Is IgNoReD As WeLl");

        theString.Should().StartWith("This");
        theString.Should().NotStartWith("this");
        theString.Should().StartWithEquivalentOf("this");
        theString.Should().NotStartWithEquivalentOf("that");

        theString.Should().EndWith("a String");
        theString.Should().NotEndWith("a string");
        theString.Should().EndWithEquivalentOf("a string");
        theString.Should().NotEndWithEquivalentOf("a strings");

        "ABCDEFGHI".Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);
    }

    [Fact]
    public void FluentWithWildCards()
    {
        /*
        Wilcard specifier	Matches
        * (asterisk)	    Zero or more characters in that position.
        ? (question mark)	Exactly one character in that position.
        */

        //Case Sensitive matches
        var emailAddress = "foo@foo.com";
        emailAddress.Should().Match("*@*.com");
        "123 Elm".Should().NotMatch("*@*.com");

        //Case insensitive matches
        emailAddress.Should().MatchEquivalentOf("*@*.COM");
        emailAddress.Should().NotMatchEquivalentOf("*@*.NET");
    }

    [Theory]
    [InlineData("foo@foo.com",
        "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
    public void RegularExpressionAssertions(string email, string regexPattern)
    {
        Assert.Matches(regexPattern, email);
        Assert.Matches(new Regex(regexPattern), email);

        //Assert.DoesNotMatch(regexPattern, email);
        //Assert.DoesNotMatch(new Regex(regexPattern), email);
    }

    [Fact]
    public void FluentRegularExpressions()
    {
        "hello world ".Should().MatchRegex("h.*\\sworld.$", Exactly.Once());
        "hello world ".Should().MatchRegex(new Regex("h.*\\sworld.$"), AtLeast.Once());
        @"hello people".Should().NotMatchRegex("h.*\\sworld.$");
    }
}