using System;
using ClassifiedApp2.Models;

namespace ClassifiedApp2.Services
{
    public interface IFacebookManager
    {
        void Login(Action<FacebookUser, string> onLoginComplete);

        void Logout();
    }
}
