using System;
using System.ComponentModel.DataAnnotations;

namespace NotesApplicationApi.VievModel
{
    public class NotesVm
    {
        [Key]
        public int Id { get; set; }

        public string Notes { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        public string Temp { get; set; }

        
    }
}