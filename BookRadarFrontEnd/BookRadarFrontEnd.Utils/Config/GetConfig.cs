using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace BookRadarFrontEnd.Utils.Config
{
    public class GetConfig : IGetConfig
    {

        private readonly IConfiguration _configuration;

        public GetConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfigurationRoot GetConfiguration()
        {
            return (IConfigurationRoot)_configuration;
        }
    }
}
