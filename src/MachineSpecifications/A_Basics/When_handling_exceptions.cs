// Copyright Information
// ==================================
// SoftwareTesting - MachineSpecifications - When_handling_exceptions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace MachineSpecifications.A_Basics;

[Tags("RegressionTests")]
[Subject("Authentication")]
public class When_handling_exceptions
{
    static SampleService _subject;
    static Exception _exception;

    //Arrange
    Establish _context = () => _subject = new SampleService(); 

    //Context Teardown
    private Cleanup _after = () => _subject.Dispose();

    //Act
    Because _of = () => _exception = Catch.Exception(() => _subject.Authenticate("", "password"));

    It Should_fail = () => _exception.ShouldBeOfExactType<ArgumentNullException>();
    It Should_have_a_specific_reason = () => _exception.Message.ShouldEqual("Missing userName (Parameter 'userName')");
    It Should_have_a_specific_argument = () => ((ArgumentNullException)_exception).ParamName.ShouldEqual("userName");
}