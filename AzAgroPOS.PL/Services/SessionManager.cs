using System;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.PL.Services
{
    public static class SessionManager
    {
        private static Istifadeci _currentUser;
        private static DateTime _loginTime;

        public static Istifadeci CurrentUser 
        { 
            get => _currentUser; 
            private set => _currentUser = value; 
        }

        public static DateTime LoginTime 
        { 
            get => _loginTime; 
            private set => _loginTime = value; 
        }

        public static bool IsLoggedIn => _currentUser != null;

        public static void SetCurrentUser(Istifadeci user)
        {
            _currentUser = user;
            _loginTime = DateTime.Now;
        }

        public static void ClearSession()
        {
            _currentUser = null;
            _loginTime = default;
        }

        public static TimeSpan SessionDuration => 
            IsLoggedIn ? DateTime.Now - _loginTime : TimeSpan.Zero;

        public static bool HasRole(string roleName)
        {
            return IsLoggedIn && _currentUser.Rol?.Ad == roleName;
        }

        public static bool IsAdmin()
        {
            return HasRole("Administrator");
        }

        public static bool IsManager()
        {
            return HasRole("Manager");
        }

        public static bool IsCashier()
        {
            return HasRole("Cashier");
        }
    }
}