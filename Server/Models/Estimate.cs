using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp2017.Server.Models
{
    public class Estimate
    {
        [Key]
        public int ID { get; set; }
        public string ProjectName { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EntryTime { get; set; }

        //Setting Default value
        public Estimate() => this.EntryTime = DateTime.Now;
    }
}
