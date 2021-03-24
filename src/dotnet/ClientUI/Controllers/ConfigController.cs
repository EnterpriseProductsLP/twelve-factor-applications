using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ClientUI.Controllers
{
    public class ConfigController : Controller
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult FromAppSettings()
        {
            var model = new ConfigViewModel
            {
                Value = _configuration["ClientUI:FromAppSettingsValue"]
            };

            return View(model);
        }

        public ViewResult FromAppSettingsEnvironment()
        {
            var model = new ConfigViewModel
            {
                Value = _configuration["ClientUI:FromAppSettingsEnvironmentValue"]
            };

            return View(model);
        }

        public ViewResult FromUserSecrets()
        {
            var model = new ConfigViewModel
            {
                Value = _configuration["ClientUI:FromUserSecrets"]
            };

            return View(model);
        }
    }
}
