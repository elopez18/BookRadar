using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRadarFrontEnd.Utils.Config
{
    public interface IGetConfig
    {
        IConfigurationRoot GetConfiguration();
    }
}
