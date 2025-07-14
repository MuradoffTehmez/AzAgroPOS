using System;

namespace AzAgroPOS.BLL.Interfaces
{
    public interface IUserContext
    {
        int? UserId { get; }
        string UserName { get; }
        string Username { get; }
        string Role { get; }
        bool IsAuthenticated { get; }
        bool IsAdmin { get; }
        DateTime? LastActivity { get; }
    }
}