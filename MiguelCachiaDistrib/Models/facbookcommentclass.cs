using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiguelCachiaDistrib.Models
{
    public class facbookcommentclass
    {

        
        public List<Ddatum> data { get; set; }

     
        public Ppaging paging { get; set; }
    }

    public partial class Ddatum
    {
        
        public string created_time { get; set; }

        
        public From from { get; set; }

        
        public string message { get; set; }

      
        public string id { get; set; }
    }

    public partial class From
    {
 
        public string name { get; set; }

        public string id { get; set; }
    }

    public partial class Ppaging
    {
       
        public Ccursors cursors { get; set; }
    }

    public partial class Ccursors
    {
       
        public string before { get; set; }

       
        public string after { get; set; }
    }
}
