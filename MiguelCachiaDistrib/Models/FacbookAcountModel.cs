using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiguelCachiaDistrib.Models
{
    public class FacbookAcountModel
    {

      
        public List<DDatum> data { get; set; }

      
        public Paging paging { get; set; }
    }

    public partial class DDatum
    {
      
        public string access_token { get; set; }

        
        public string category { get; set; }

      
        public List<CategoryList> category_list { get; set; }

       
        public string name { get; set; }

        
        public string id { get; set; }

       
        public List<string> tasks { get; set; }
    }

    public partial class CategoryList
    {
        public long id { get; set; }

       
        public string name { get; set; }
    }

  
}
