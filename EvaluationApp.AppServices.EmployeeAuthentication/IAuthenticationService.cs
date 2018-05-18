namespace EvaluationApp.AppServices.EmployeeAuthentication

{
    public interface IAuthenticationService
    {
        int GetCurrentUserId();
        bool IsUserAuthenticated();
    }
}
