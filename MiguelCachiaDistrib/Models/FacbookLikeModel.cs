using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiguelCachiaDistrib.Models
{
    public class FacbookLikeModel
    {
        public List<Datumm> data { get; set; }

        public Paging paging { get; set; }
    }

    public partial class Datumm
    {
        public string name { get; set; }

        public string id { get; set; }

        public string created_time { get; set; }
    }

   
}

