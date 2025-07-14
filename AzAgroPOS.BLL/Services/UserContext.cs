using AzAgroPOS.BLL.Interfaces;
using System;

namespace AzAgroPOS.BLL.Services
{
    public class UserContext : IUserContext
    {
        public int? UserId { get; private set; }
        public string UserName { get; private set; }
        public string Username => UserName; // Alias for UserName
        public string Role { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public bool IsAdmin => Role == "Administrator" || Role == "Admin";
        public DateTime? LastActivity { get; private set; }

        public void SetUser(int userId, string userName, string role)
        {
            UserId = userId;
            UserName = userName;
            Role = role;
            IsAuthenticated = true;
            LastActivity = DateTime.Now;
        }

        public void ClearUser()
        {
            UserId = null;
            UserName = null;
            Role = null;
            IsAuthenticated = false;
            LastActivity = null;
        }

        public void UpdateActivity()
        {
            if (IsAuthenticated)
            {
                LastActivity = DateTime.Now;
            }
        }
    }
}