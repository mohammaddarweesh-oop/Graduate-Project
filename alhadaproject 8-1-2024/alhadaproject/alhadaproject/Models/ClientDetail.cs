using System.ComponentModel.DataAnnotations.Schema;

namespace alhadaProject.Models
{
    public class ClientDetail
    {
        public int Id { get; set; }
       
        public string? Srl { get; set; }
        public DateTime VisitorDate { get; set; }
        public DateTime VisitorTime { get; set; }
        public string? Details { get; set; }
        public string? CommDetail { get; set; }
        public string? VisitType { get; set; }
        //relationship
       
       
        public int ClientNo { get; set; }
       
    }
}
