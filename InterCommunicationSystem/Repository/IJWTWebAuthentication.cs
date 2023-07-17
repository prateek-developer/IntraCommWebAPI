using InterCommunicationSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Repository
{
    public interface IJWTWebAuthentication
    {

        TokenViewModel authenticate(LoginViewModel Login);
    }
}
