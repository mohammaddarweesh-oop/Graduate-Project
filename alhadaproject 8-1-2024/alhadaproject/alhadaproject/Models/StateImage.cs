using System.ComponentModel.DataAnnotations.Schema;

namespace alhadaProject.Models
{
    public class StateImage
    {
        public int Id { get; set; }

        public string estateImage { get; set; }
        
        public int StateId { get; set; }
        

    }
}
