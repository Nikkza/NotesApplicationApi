using NotesApplicationApi.Models;

namespace NotesApplicationApi.ModesApi
{
    public class List
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }

    }
}
