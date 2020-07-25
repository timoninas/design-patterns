using System;
using System.Collections.Generic;

namespace Facade
{
    public class Blog
    {
        public Dictionary<User, BlogPost> posts { get; private set; }

        public Blog()
        {
            this.posts = new Dictionary<User, BlogPost>();
        }

        protected void AddPost(BlogPost post, User user)
        {
            this.posts.Add(user, post);
        }
    }


    // FACADE
    public class BlogFacade: Blog
    {
        private ISpellChecker _CheckerMistake;
        private IAutharizateCheck _CheckerAuthorizate;

        public BlogFacade(ISpellChecker mistaker, IAutharizateCheck authorizater) : base()
        {
            this._CheckerMistake = mistaker;
            this._CheckerAuthorizate = authorizater;
        }

        public bool PublishPost(BlogPost post, User user)
        {
            if (_CheckerAuthorizate.IsAuthorized(user) == false
                || _CheckerMistake.CheckSpell(post) == false)
            {
                return false;
            }

            this.AddPost(post, user);

            return true;
        }

        private bool IsAuthorized(User user)
        {
            return _CheckerAuthorizate.IsAuthorized(user);
        }

        private bool CheckMistakeInPost(BlogPost post)
        {
            return _CheckerMistake.CheckSpell(post);
        }


    }

    // SUBSYSTEM 1
    public interface ISpellChecker
    {
        bool CheckSpell(BlogPost post);
    }

    public class SpellChecker: ISpellChecker
    {
        public bool CheckSpell(BlogPost post)
        {
            // FAKE CHECK :)
            if (post.title != post.content)
            {
                return true;
            }

            return false;
        }
    }

    // SUBSYSTEM 2
    public interface IAutharizateCheck
    {
        bool IsAuthorized(User user);
    }

    public class Authorizator : IAutharizateCheck
    {
        public bool IsAuthorized(User user)
        {
            // FAKE CHECK :)
            if (user.username != user.password)
            {
                return true;
            }

            return false;
        }
    }
}
