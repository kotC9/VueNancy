using System;
using System.Collections.Generic;
using System.Text;
using Nancy;

namespace VueNancy.Backend.Modules
{
    public abstract class BaseModule : NancyModule
    {
        protected BaseModule(string path = null)
        {
            ModulePath = string.IsNullOrEmpty(path)
                ? "api"
                : "api/" + path;
        }
    }

}
