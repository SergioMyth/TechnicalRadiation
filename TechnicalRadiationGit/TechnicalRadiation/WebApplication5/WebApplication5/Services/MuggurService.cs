using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.TechnicalRadiation.Models;

namespace WebApplication5.Services
{
    public class MuggurService : IMuggurService
    {
        public MuggurService(IConfiguration config)
        {
            Config = config;
        }

        public IConfiguration Config { get; }

        public List<HyperMediaModel> GetStuff()
        {
            var x = new HyperMediaModel();
            var y = new HyperMediaModel();
            var ret = new List<HyperMediaModel>() { x, y };
            return ret;

        }
    }
}
