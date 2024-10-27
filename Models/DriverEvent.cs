﻿using System.ComponentModel.DataAnnotations;
namespace Information_system_i_ASP.Net.Models
{
    public class DriverEvent
    {
        public int DriverEventID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NoteDate { get; set; }
        public string NoteDescription { get; set; }
        public decimal BeloppIn { get; set; }
        public decimal BeloppUt { get; set; }

        // Relation till Driver
        public int DriverID { get; set; }
        public Driver? Driver { get; set; }
    }
}
