using LibraryManagementSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.DAL.Models
{
    public class Reader : IEntity, IUser
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public byte[] Salt { get; set; }

        public int Iterations { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
        public virtual Role Role { get; set; }

        public Reader(string login, string password, string firstName, string lastName, string phoneNumber, byte[] salt, int iterations, Role role)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Salt = salt;
            Iterations = iterations;
            Role = role;

            Rents = new List<Rent>();
        }
        public Reader()
        {
            Rents = new List<Rent>();
        }

    }
}
