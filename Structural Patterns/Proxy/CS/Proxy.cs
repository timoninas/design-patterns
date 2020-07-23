using System;
using System.Collections.Generic;
using System.Linq;

namespace ProxyPattern
{
    // Example for Entity Framework
    // Table User
    public class User
    {
        public int id { get; private set; }
        public string username { get; private set; }
        public string password { get; private set; }

        public User(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }
    }

    // Fake converted  UserContext: DbContext
    public class dbUser
    {
        public  List<User> Users { get; private set; }

        public dbUser()
        {
            this.Users = new List<User>();

            this.Users.Add(new User(0, "123", "321"));
            this.Users.Add(new User(1, "login", "password"));
            this.Users.Add(new User(2, "It is login", "My password"));
            this.Users.Add(new User(3, "antontimonin", "urloowl;"));
            this.Users.Add(new User(4, "tele", "kek"));
        }

        public User GetConcreteUser(int number)
        {
            int index = this.Users.FindIndex(u => u.id == number);
            if (index == -1)
            {
                return null;
            }

            return this.Users[index];
         }

        public void Clear()
        {
            this.Users.Clear();
        }
    }

    // Class for request to db
    public class UserStorage
    {
        public dbUser db { get; set; }

        public UserStorage()
        {
            this.db = new dbUser();
        }

        public User GetConcreteUser(int number)
        {
            return this.db.GetConcreteUser(number);
        }

        public void ClearDB()
        {
            this.db.Clear();
        }
    }

    // PROXY
    public class UserStorageProxy
    {
        public List<User> ReceivedUsers { get; private set; }
        public UserStorage userstorage { get; private set; }

        public UserStorageProxy()
        {
            this.ReceivedUsers = new List<User>();
        }

        public User GetConcreteUser(int number) 
        {
            User user = this.ReceivedUsers.FirstOrDefault(p => p.id == number);

            if (user == null)
            {
                if (this.userstorage == null)
                {
                    this.userstorage = new UserStorage();
                }

                Console.WriteLine("Accessing the UserContext");
                user = this.userstorage.GetConcreteUser(number);
                this.ReceivedUsers.Add(user);
            } else
            {
                Console.WriteLine("Accessing the ReceivedUsers");
            }

            return user;
        }

        public void ClreadDB()
        {
            if (this.userstorage != null)
            {
                this.userstorage.ClearDB();
            }
        }
    }
}
