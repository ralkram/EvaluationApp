using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Core.Shared
{
    public interface IAuthenticationService
    {
        int GetCurrentUserId();
        bool IsUserAuthenticated();
    }
}
