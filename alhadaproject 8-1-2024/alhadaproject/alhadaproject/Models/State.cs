using System.ComponentModel.DataAnnotations.Schema;

namespace alhadaProject.Models
{
    public class State
    {
        public int Id { get; set; }
        public int Ref { get; set; }   // 1 المرجع
        
        public string? Source { get; set; }     // المصدر  1
        public string? Category { get; set; }  //   تصنيف العقار
        public string? Owner { get; set; }    //  1 المالك
        public string? Mobile { get; set; }   // 1  الموبايل
        public string? City { get; set; }   // 1 المحافظة
        public string? Region { get; set; }  // 1 الحي
        public string? Location { get; set; }   // 1 الموقع الجغرافي
        public string? Address { get; set; }   //  1العنوان بالتفصيل
        public double LandArea { get; set; }  // 1 مساحة الأرض
        public int BuildYear { get; set; }   //   1سنة البناء
        public int ApartNo { get; set; }  //   1عدد شقق العقار 
        public string? stateType { get; set; }  // نوع العقار
        public double StateArea { get; set; }  // مساحة البناء
        public string? StateStatus { get; set; }  // جالة العقار
        public double Price { get; set; }  // سعر العقار
        public string? Floor { get; set; }   // الطابق
        public int RoomNo { get; set; }    // عدد الغرف
        public int MasterNo { get; set; }  //  عدد غرف الماستر
        public int BalconyNo { get; set; }  //  عدد البلاكونات
        public int PathNo { get; set; }   //   عدد الجمامات
        public int KitchNo { get; set; }  // عدد المطابخ
        public int LiveRoomNo { get; set; }   //  عدد غرف المعيشة
        public int SaloonNo { get; set; }   //  عدد الصالونات



        public bool LaundryRoom { get; set; } = false; // غرفة غسيل
        public bool Guard { get; set; } = false; // حارس
        public bool Furnished { get; set; } = false;  // مفروشة
        public bool SolarHeater { get; set; } = false;  // سخان شمسي
        public bool ElectricBlind { get; set; } = false;  // اباجورات كهرباء
        public bool MaidRoom { get; set; } = false;  // غرفة خادمة
        public bool PrivateGarage { get; set; } = false;  // كراج خاص
        public bool Haunted { get; set; } = false; // شقة مسكونة
        public bool Jacozzi { get; set; } = false;  // جاكوزي
        public bool Parquet { get; set; } = false;  // باركيه
        public bool Heating { get; set; } = false;  // تدفئة
        public bool Garage { get; set; } = false;  // كراج
        public bool NeverLive { get; set; } = false;      // جديدة لم تسكن
        public bool ShowerBox { get; set; } = false;  // شوربوكس
        public bool Viewed { get; set; } = false;  // اطلالة
        public bool EstablishHeat { get; set; } = false;  // تأسيس تدفئة
        public bool Garden { get; set; } = false;  // حديقة
        public bool Geezer { get; set; } = false;  // جيزر
        public bool DoubleGlass { get; set; } = false;  // دبل جلاس
        public bool Installment { get; set; } = false;  // أقساط
        public bool Conditioning { get; set; } = false;  // تكييف
        public bool Taras { get; set; } = false;  // ترس
        public bool FirePlace { get; set; } = false;  // فيربليس
        public bool Ceramic { get; set; } = false;  // سيرامك
        public bool Elevator { get; set; } = false;  // مصعد
        public bool Entrance { get; set; } = false;     // مدخل خاص
        public bool SwimmingPool { get; set; } = false;  // مفروشة
        public bool Marble { get; set; } = false;  // رخام
        public bool StateView { get; set; } = false;  // الاعلان شوهد
        public bool trading { get; set; } = false;  // تجاري
        public bool NeedDate { get; set; } = false; // تحتاج لموعد للمشاهدة
        public string? GuardName { get; set; }  // اسم الحارس
        public string? GradMobile { get; set; }  // رقم موبايل الحارس

        public double LandTarasArea { get; set; }   // مساحة الارض و الترس
        public double TarasArea { get; set; }   // مساحة الترس
        public double GardenArea { get; set; }   // مساحة الجديقة

        public string? Commision { get; set; }  // العمولة
       
        public bool Sold { get; set; }    //  بيعت
        public bool HomePage { get; set; }    //  الصفحة الرئيسة

        public string? Photo { get; set; }  //  صور الاعلان
        public string? Notes { get; set; }  //  الملاحظات
        public string? PromoNotes { get; set; }  // اعلانات للعقار تظهر على الصفحة الرئيسية

        //relationship


        public int EmpNo { get; set; }


       
  


    }
}
