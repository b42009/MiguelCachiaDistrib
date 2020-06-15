using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiguelCachiaDistrib.Models
{
    public class FacbookAcountModel
    {
      
        public List<Datuma> data { get; set; }

   
        public Paging paging { get; set; }
    }

    public partial class Datuma
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
       
        public long Id { get; set; }

     
        public string Name { get; set; }
    }

    public partial class Paging
    {
        public Cursors Cursors { get; set; }
    }

    public partial class Cursors
    {
      
        public string Before { get; set; }

   
        public string After { get; set; }
    }
}
