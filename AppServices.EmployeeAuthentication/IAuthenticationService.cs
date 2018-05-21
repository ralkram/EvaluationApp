namespace AppServices.EmployeeAuthentication

{
    public interface IAuthenticationService
    {
        int GetCurrentUserId();
        bool IsUserAuthenticated();
    }
}
