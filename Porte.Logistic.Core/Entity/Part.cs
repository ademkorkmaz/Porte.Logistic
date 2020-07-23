using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Porte.Logistic.Core.Entity
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }
        public int PartWeight { get; set; }
        public int PartCost { get; set; }

        public int BoxId { get; set; }
    }
}
