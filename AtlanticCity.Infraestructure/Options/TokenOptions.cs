using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Infraestructure.Options
{
    public class TokenOptions
    {
        public string secretKey { get; set; }
        public string encryptSecretKey { get; set; }
        public int timeExp { get; set; }
    }
}
