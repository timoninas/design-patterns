using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CompanyJukebox company1 = new CompanyJukebox();
            CompanyRegedit company2 = new CompanyRegedit();

            List<Application> apps = new List<Application>();

            apps.Add(company1.CreateMobileApp());
            apps.Add(company1.CreateWebApp());
            apps.Add(company2.CreateMobileApp());
            apps.Add(company2.CreateWebApp());
            apps.Add(company1.CreateWebApp());

            foreach (var app in apps)
            {
                app.OpenApp();
            }
        }

        // OUTPUT
        // Jukebox create web app: Jukebox Web App with type: simple
        // Regedit create app: Regedit App with os: iOS
        // Regedit create web app: Regedit Web App with type: adapted
        // Jukebox create web app: Jukebox Web App with type: simple
    }
}
