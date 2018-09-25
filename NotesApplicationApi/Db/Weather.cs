using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApplicationApi.Db
{
    [Table("Weather")]
    public partial class Weather
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Note...")]
        public string Notes { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Date { get; set; }

       

    }
}
