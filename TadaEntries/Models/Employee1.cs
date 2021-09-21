using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TadaEntries.Models
{
    public class Employee1
    {
        [Key]
        public int Id { get; set; }

            [Display(Name = "Date")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public NameList Name { get; set; }

        [Display(Name = "Total Cost")]
        public int Travel_Cost { get; set; }
        [Display(Name = "Lunch Cost")]
        public int Lunch_Cost { get; set; }
        [Display(Name = "Instrument Cost")]
        public int Instrument_Cost { get; set; }
        public PStatus Paid { get; set; }
        public enum PStatus
        {
            Paid,
            Unpaid
        }
        public enum NameList
        {
            Sumit,
            Sourov,
            Raihan,
            Faisal
        }

    }
}