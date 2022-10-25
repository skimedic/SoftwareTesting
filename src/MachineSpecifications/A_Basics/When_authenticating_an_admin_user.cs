// Copyright Information
// ==================================
// SoftwareTesting - MachineSpecifications - When_authenticating_an_admin_user.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace MachineSpecifications.A_Basics;

//[Ignore("This is a skipped test")]
[Tags("Basic Tests")]
[Subject("Authentication")]
public class When_authenticating_an_admin_user
{
    static SampleService _subject;
    static SampleToken _token;

    //Arrange - only executes once for the class
    Establish _context = () => {
        _subject = new SampleService();
    };

    //Context Teardown
    private Cleanup _after = () =>
    {
        _subject.Dispose();
    };

    //Act
    Because _of = () => _token = _subject.Authenticate("username", "password");

    //Asserts
    It Should_indicate_the_users_name = () 
        => _token.UserName.ShouldEqual("username");

    It Should_have_a_unique_session_id = () 
        => _token.Password.ShouldNotBeNull();

    //It Should_indicate_the_users_name = () => {
    //    _token.UserName.ShouldEqual("username");
    //};

    //It Should_have_a_unique_session_id = () => {
    //    _token.Password.ShouldNotBeNull();
    //};

    It Should_report_as_not_implemented;
}