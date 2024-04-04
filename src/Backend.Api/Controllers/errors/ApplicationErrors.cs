namespace Backend.Api.Controllers.errors;

public static class ApplicationErrors
{
    public const string UserEmailAlreadyExists = "USER_EMAIL_EXISTS";
    public const string FailToCreateUserWithCredential = "FAIL_CREATE_USER_WITH_CREDENTIAL";
    public const string InvalidCredential = "INVALID_CREDENTIAL";
    public const string FailToCreateToken = "FAIL_TO_CREATE_TOKEN";
}
