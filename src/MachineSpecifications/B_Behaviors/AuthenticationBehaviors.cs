// Copyright Information
// ==================================
// SoftwareTesting - MachineSpecifications - AuthenticationBehaviors.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace MachineSpecifications.B_Behaviors;

[Behaviors]
public class AuthenticationBehaviors
{
    protected static SampleToken _token;

    It Should_indicate_the_users_name = () => _token.UserName.ShouldEqual("username");

    It Should_have_a_unique_session_id = () => _token.Password.ShouldNotBeNull();
}