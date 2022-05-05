using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ErrorContext = Newtonsoft.Json.Serialization.ErrorContext;
using JsonExtensionDataAttribute = Newtonsoft.Json.JsonExtensionDataAttribute;

namespace SectraDataApp.Models
{

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Statusdata
    {
        private List<SiteInfo> _siteinfo { get; set; }
        public List<SiteInfo> siteinfo
        {
            get
            {
                if (_siteinfo == null)
                {
                    throw new Exception("siteinfo not loaded!");
                }
                return _siteinfo;
            }
            set
            { _siteinfo = value; }
        }
        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            errorContext.Handled = true;
        }

    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    
    public class SiteInfo
    {
        [Key]
        public int Id { get; set; } 

        public string? cmpid { get; set; }
        public string? nameofsoftware { get; set; }
        public string? versionpatch { get; set; }
        public string? hostgroup { get; set; }
        public string? root { get; set; }
        [JsonExtensionData]
        private IDictionary<string, string> _additionalData;
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            string _status_info = (string)_additionalData["status_info"];
            nameofsoftware = _status_info.Split(",")[0];
            versionpatch = _status_info.Split(".")[1];
        }
        public SiteInfo()
        {
            _additionalData = new Dictionary<string, string>();
        }
    }
}
