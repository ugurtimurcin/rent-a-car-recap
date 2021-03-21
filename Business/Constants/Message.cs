using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Message
    {
        public static string AuthorizationDenied = "You do not have permisson to access";
        public static string TokenCreated = "Token created";
        public static string UserNotExists = "User not exists";
        public static string PasswordError = "Password is not correct";
        public static string UserRegistered = "User succesfully registered";
        public static string UserExists = "User already exists";
        public static string CarImageCountOverLimit = "Car image count must be less than or equals five";
        public static string CarAlreadyRented = "Car already rented";
    }
}
