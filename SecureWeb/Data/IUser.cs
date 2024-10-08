using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecureWeb.Models;

namespace SecureWeb.Data
{
    public interface IUser
    {
        User Registration(User user);
        User Login(User user);

        User GetUserByEmail(string email);
        User ChangePassword(string email, string newPassword, string oldPassword);
        void UpdateUser(User user);
    }
}