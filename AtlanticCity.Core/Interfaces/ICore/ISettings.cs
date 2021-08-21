using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.Interfaces.ICore
{
    public interface ISettings
    {
        string ApplicationName { get; set; }
        string EndpointDescription { get; set; }
        string EndpointUrl { get; set; }
        string ContactName { get; set; }
        string ContactUrl { get; set; }
        string DocNameV1 { get; set; }
        string DocInfoTitle { get; set; }
        string DocInfoVersion { get; set; }
        string DocInfoDescription { get; set; }

    }
}
