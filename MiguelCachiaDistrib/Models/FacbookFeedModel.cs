using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace MiguelCachiaDistrib.Models
{
    public partial class FacbookFeedModel
    {
    
        public List<Datum> data { get; set; }

      
        public Paging paging { get; set; }
    }

    public partial class Datum
    {
       
        public string message { get; set; }

       
        public string created_time { get; set; }

      
        public string id { get; set; }
    }

    public partial class Paging
    {
      
        public Uri previous { get; set; }

        public Uri next { get; set; }
    }
}