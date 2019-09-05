using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Services
{
    public class LameService : ILameService
    {
        public IConfiguration Config { get; }
        public LameService(IConfiguration config)
        {
            Config = config;
        }
        public bool Authenticate(string secret)
        {
            var secretKey = Config.GetValue<string>("secret_key");
            if (secretKey == secret)
            {
                return true;
            }

            return false;
        }
    }
}
