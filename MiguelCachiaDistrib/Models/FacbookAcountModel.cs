using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiguelCachiaDistrib.Models
{
    public class FacbookAcountModel
    {

        [JsonProperty("data")]
        public List<inp> data { get; set; }

        [JsonProperty("paging")]
        public Paging paging { get; set; }
    }

    public partial class inp
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
       
      
        public string id { get; set; }

     
        public string name { get; set; }
    }

    public partial class Paging
    {
        [JsonProperty("cursors")]
        public Cursors cursors { get; set; }
    }

    public partial class Cursors
    {
       
        public string before { get; set; }

      
        public string after { get; set; }
    }
}
