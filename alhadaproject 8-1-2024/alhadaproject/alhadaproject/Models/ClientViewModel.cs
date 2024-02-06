namespace alhadaproject.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        public int Ref { get; set; } 
        public string? ClientName { get; set; }  
        public int Mobile { get; set; }  

        public string? Interest { get; set; }  
        public bool Archeive { get; set; } = false; 
        public bool Buy { get; set; } = false; 
         

        public string? AddedDate { get; set; }   

        public string? EmpName { get; set; }  
    }
}
