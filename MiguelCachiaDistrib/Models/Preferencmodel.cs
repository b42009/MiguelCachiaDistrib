using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiguelCachiaDistrib.Models
{
    public class Preferencmodel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }
        public String praivecyuserid { get; set; }
        public virtual ApplicationUser praivecyuser { get; set; }

        public bool name { get; set; }
        public bool email { get; set; }

        public bool birthday { get; set; }


    }
}