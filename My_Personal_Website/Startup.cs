﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(My_Personal_Website.Startup))]
namespace My_Personal_Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
