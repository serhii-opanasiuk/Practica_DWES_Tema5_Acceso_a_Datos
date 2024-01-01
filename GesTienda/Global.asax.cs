using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace GesTienda
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Asignar el perfil de caché a nivel de aplicación
            OutputCacheSettingsSection outputCacheSettings = ConfigurationManager.GetSection("system.web/caching/outputCacheSettings") as OutputCacheSettingsSection;
            OutputCacheProfile noCacheProfile = outputCacheSettings.OutputCacheProfiles["NoCache"];
            OutputCacheParameters cacheSettings = new OutputCacheParameters { Duration = noCacheProfile.Duration, Location = noCacheProfile.Location, NoStore = noCacheProfile.NoStore };

            HttpRuntime.Cache.Insert("NoCacheProfile", cacheSettings);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Código que se ejecuta al producirse un error no controlado
            Server.Transfer("~/ControlError.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}