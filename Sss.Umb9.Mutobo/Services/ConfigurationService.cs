using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sss.Umb9.Mutobo.Common.Exceptions;
using Sss.Umb9.Mutobo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Web;

namespace Sss.Umb9.Mutobo.Services
{
    public class ConfigurationService : BaseService, IConfigurationService
    {
        private readonly IConfiguration _configuration;
        

        public ConfigurationService(
            IConfiguration configuration,
            ILogger<ConfigurationService> logger,
            IUmbracoContextAccessor contextAccessor) 
            : base(logger, contextAccessor)
        {
            _configuration = configuration;   
        }

        public bool? GetAppSettingBoolValue(string key, bool essential = true)
        {
            var result = _configuration.GetValue<bool?>(key);
            
            if (result == null)
            {
                if (essential)
                    throw new AppSettingsException($"Missing config/AppSettings.config or config entry: {key}");
                else
                    Logger.LogWarning($"Missing config/AppSettings.config or config entry: {key}");
            }

            return result;
        }

        public int? GetAppSettingIntValue(string key, bool essential = true)
        {
            var result = _configuration.GetValue<int?>(key);

            if (result == null)
            {
                if (essential)
                    throw new AppSettingsException($"Missing config/AppSettings.config or config entry: {key}");
                else
                    Logger.LogWarning($"Missing config/AppSettings.config or config entry: {key}");
            }

            return result;
        }

        public string GetAppSettingValue(string key, bool essential = true)
        {
            var result = _configuration.GetValue<string>(key);

            if (result == null)
            {
                if (essential)
                    throw new AppSettingsException($"Missing config/AppSettings.config or config entry: {key}");
                else
                    Logger.LogWarning($"Missing config/AppSettings.config or config entry: {key}");
            }

            return result;
        }
    }
}
