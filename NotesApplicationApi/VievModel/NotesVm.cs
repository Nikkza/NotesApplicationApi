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

        public NotesVm(int id, DateTime? date, string notes, string temp)
        {
            this.Id = id;
            this.Date = (DateTime)date;
            this.Notes = notes;
            this.Temp = temp;

        }
    }
}