using System;
using System.ComponentModel.DataAnnotations;

namespace NotesApplicationApi.VievModel
{
    public class NotesVm
    {
        private DateTime? date;
        private string v;

        [Key]
        public int Id { get; set; }

        public string Notes { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        public string Temp { get; set; }

        public NotesVm(int id, DateTime date, string notes, string temp)
        {
            this.Id = id;
            this.Date = date;
            this.Notes = notes;
            this.Temp = temp;

        }

        public NotesVm(int id)
        {
            this.Id = id;

        }

        public NotesVm(int id, DateTime? date, string notes, string v) : this(id)
        {
            this.date = date;
            Notes = notes;
            this.v = v;
        }
    }
}