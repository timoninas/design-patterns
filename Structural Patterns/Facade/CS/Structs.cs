using System;
namespace Facade
{
    public struct BlogPost
    {
        public string title { get; private set; }
        public string content { get; private set; }

        public BlogPost(string title, string content)
        {
            this.title = title;
            this.content = content;
        }
    }

    public struct User
    {
        public string username { get; private set; }
        public string password { get; private set; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
