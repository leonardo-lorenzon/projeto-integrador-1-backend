using Backend.Api.Controllers.User.Requests;

namespace Backend.UnitTest.Builders;

public class UserRequestBuilder
{
    private readonly UserRequest _userRequest;

    public UserRequestBuilder()
    {
        _userRequest = BuildDefault();
    }

    public UserRequest Build()
    {
        return _userRequest;
    }

    private static UserRequest BuildDefault()
    {
        return new UserRequest(
            "José",
            "Carlos",
            "jcarlos@test.com",
            "pass1234"
        );
    }
}
