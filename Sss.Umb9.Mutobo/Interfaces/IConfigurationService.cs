using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface IConfigurationService
    {
        string GetAppSettingValue(string key, bool essential = true);
        int? GetAppSettingIntValue(string key, bool essential = true);
        bool? GetAppSettingBoolValue(string key, bool essential = true);
    }
}
