using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Configure
{
    public enum EnvironmentType
    {
        Development,
        Staging,
        Production
    }

    public class EnumExtension
    {
        public EnumExtension() { }
        public string GetBaseUrl(EnvironmentType environment)
        {
            switch (environment)
            {
                case EnvironmentType.Development:
                    return "https://localhost:7240";
                case EnvironmentType.Staging:
                    return "http://staging.guyou.com";
                case EnvironmentType.Production:
                    return "http://guyou.com";
                default:
                    throw new ArgumentOutOfRangeException(nameof(environment), environment, null);
            }
        }
    }
}
