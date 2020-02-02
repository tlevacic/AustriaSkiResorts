using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AustriaSkiResorts.Models
{
    public class resort
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public float length { get; set; }
        public float height { get; set; }
        public int price { get; set; }
        public string snowRange { get; set; }
        public string shortInfo { get; set; }
        public string longInfo { get; set; }
        public string urlPicture { get; set; }
        public int availableNumberOfTermins { get; set; }
    }
}
