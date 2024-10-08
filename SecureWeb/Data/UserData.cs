using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using BCrypt.Net;
using SecureWeb.Models;

namespace SecureWeb.Data
{
    public class UserData : IUser
    {
        private readonly ApplicationDbContext _db;
        private readonly EmailService _emailService;

        public UserData(ApplicationDbContext db, EmailService emailService)
        {
            _db = db;
            _emailService = emailService;
        }

        public User Login(User user)
        {
            var _user = _db.Users.FirstOrDefault(u => u.Email == user.Email);
            if (_user == null)
            {
                throw new Exception("User Not Found");
            }
            if (!BCrypt.Net.BCrypt.Verify(user.Password, _user.Password))
            {
                throw new Exception("Password is Incorect");
            }
            return _user;
        }

        public User Registration(User user)
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                _db.Users.Add(user);
                _db.SaveChanges();

                // string subject = "Konfirmasi Email";
                // string body = $"Silakan konfirmasi email Anda dengan mengklik tautan ini: http://localhost:5083/confirm-email?email={user.Email}";
                // _emailService.SendEmail(user.Email, subject, body);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public User GetUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email);
        }

        public void UpdateUser(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public User ChangePassword(string email, string newPassword, string oldPassword)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(u => u.Email == email);

                if (user != null)
                {
                    if (BCrypt.Net.BCrypt.Verify( oldPassword,user.Password))
                    {
                        user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                        _db.Update(user);
                        _db.SaveChanges();

                        return user;
                    }
                    else
                    {
                        throw new Exception("Password Lama Tidak Sesuai");
                    }
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error changing password: " + ex.Message);
            }
        }
    }
}