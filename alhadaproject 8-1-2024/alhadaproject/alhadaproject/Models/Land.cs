using System.ComponentModel.DataAnnotations.Schema;

namespace alhadaProject.Models
{
    public class Land
    {
        public int Id { get; set; }
        public int Ref { get; set; }   //  رقم المرجع
        public string? Source { get; set; }  //   
        public string? City { get; set; }  // المحاقظة
         public string? LandDir { get; set; }  // المديرية
        public string? Region { get; set; }  // القرية
        public int BasinNo { get; set; }  //   رقم الحوض
        public string? BasinName { get; set; } // اسم الحوض
        public string? Owner { get; set; } //  اسم المالك
        public string? Mobile { get; set; }  //  الهاتف 
        public int LandNo { get; set; }  // رقم القطعة
        public double TotalArea { get; set; } = 0;  //  المساحة
        public double Price { get; set; }  //  السعر
        public string? Location { get; set; } //  الموقع
        public int StreetNo { get; set; } = 0;  //   عدد الشوارع

        public bool Sold { get; set; } = false;   //  بيعت
       
        public string? Notes { get; set; }  //   ملاحظات



        //Relationship

      
        public int EmpNo { get; set; }
      
        

    }
}
