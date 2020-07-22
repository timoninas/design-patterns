using System;
namespace AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract Application CreateMobileApp();

        public abstract Application CreateWebApp();
    }

    public class CompanyRegedit : AbstractFactory
    {
        public override Application CreateMobileApp()
        {
            return new MobileApplicationForRegedit("Regedit App", MobileOS.iOS);
        }

        public override Application CreateWebApp()
        {
            return new WebApplicationForRegedit("Regedit Web App", TypeWebSite.adapted);
        }
    }

    public class CompanyJukebox: AbstractFactory
    {
        public override Application CreateMobileApp()
        {
            return new MobileApplicationForJukebox("Jukebox App", MobileOS.Android);
        }

        public override Application CreateWebApp()
        {
            return new WebApplicationForJukebox("Jukebox Web App", TypeWebSite.simple);
        }
    }

    public abstract class Application
    {
        public string name { get; private set; }

        public Application(string name)
        {
            this.name = name;
        }

        public abstract void OpenApp();
    }

    public enum MobileOS
    {
        iOS, Android
    }

    public class MobileApplicationForRegedit: Application
    {
        public MobileOS typeOS { get; private set; }

        public MobileApplicationForRegedit(string name, MobileOS os): base(name)
        {
            this.typeOS = os;
        }

        public override void OpenApp()
        {
            Console.WriteLine($"Regedit create app: {this.name} with os: {this.typeOS}");
        }
    }

    public class MobileApplicationForJukebox : Application
    {
        public MobileOS TypeOS { get; private set; }

        public MobileApplicationForJukebox(string name, MobileOS os) : base(name)
        {
            this.TypeOS = os;
        }

        public override void OpenApp()
        {
            Console.WriteLine($"Jukebox create app: {this.name} with os: {this.TypeOS}");
        }
    }

    public enum TypeWebSite
    {
        simple, adapted
    }

    public class WebApplicationForRegedit : Application
    {
        public TypeWebSite TypeSite { get; private set; }

        public WebApplicationForRegedit(string name, TypeWebSite browser) : base(name)
        {
            this.TypeSite = browser;
        }

        public override void OpenApp()
        {
            Console.WriteLine($"Regedit create web app: {this.name} with type: {this.TypeSite}");
        }
    }

    public class WebApplicationForJukebox : Application
    {
        public TypeWebSite TypeSite { get; private set; }

        public WebApplicationForJukebox(string name, TypeWebSite browser) : base(name)
        {
            this.TypeSite = browser;
        }

        public override void OpenApp()
        {
            Console.WriteLine($"Jukebox create web app: {this.name} with type: {this.TypeSite}");
        }
    }
}
