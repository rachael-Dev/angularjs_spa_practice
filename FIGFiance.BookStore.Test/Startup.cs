using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FIGFiance.BookStore.Test.Startup))]

namespace FIGFiance.BookStore.Test
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
