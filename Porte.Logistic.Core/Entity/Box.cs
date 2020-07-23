using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Porte.Logistic.Core.Entity
{
    public  class Box
    {
        [Key]
        public int BoxId { get; set; }
        public int Weight { get; set; }
        public int PartCount { get; set; }

        public List<Part> PartList { get; set; }
    }
}
