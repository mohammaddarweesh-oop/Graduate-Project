using System.ComponentModel.DataAnnotations.Schema;

namespace alhadaProject.Models
{
    public class Client
    {
        public int Id { get; set; }

        public int Ref { get; set; }  //    رقم المعرف
        public string? ClientName { get; set; }  //   اسم العميل
        public int Mobile { get; set; }  //   رقم الموبايل
       
        public string? Interest { get; set; }  //   درجة الأهمية
        public bool Archeive { get; set; } = false; //   ارشيف 
        public bool Buy { get; set; } = false; //  قام بالشراء
        public string? details { get; set; }  //  تفاصيل الزبون
       
        public string? AddedDate { get; set; }   // تاريخ الاضافة

        public int EmpNo { get; set; }  // رقم الموظف
      

    }
}
