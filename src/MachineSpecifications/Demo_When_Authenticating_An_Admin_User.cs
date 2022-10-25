namespace MachineSpecifications;
public class When_Using_A_Periscope
{
    //Arrange - only executes once for the class
    Establish _context = () => {
    };

    //Context Teardown
    private Cleanup _after = () =>
    {
    };

    //Act
    Because _of = () => {
    };

    //Asserts
    It Should_Allow_Boat_To_Stay_Submerged;

    It Should_See_Above_The_Water;

}

//[Ignore("This is a skipped test")]
[Tags("Basic Tests")]
[Subject("Authentication")]
//[Subject(typeof(bool))]
public class Demo_When_Authenticating_An_Admin_User
{
    //Arrange - only executes once for the class
    Establish _context = () => {
    };

    //Context Teardown
    private Cleanup _after = () =>
    {
    };

    //Act
    Because _of = () => {
    };

    //Asserts
    It Should_indicate_the_users_name;

    It Should_have_a_unique_session_id;

    It Should_report_as_not_implemented;
}