//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestExam.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meetings
    {
        public int Id { get; set; }
        public Nullable<int> doctor_id { get; set; }
        public Nullable<int> patients_id { get; set; }
        public Nullable<System.DateTime> Meeting_Date { get; set; }
    
        public virtual Doctors Doctors { get; set; }
        public virtual Patients Patients { get; set; }
    }
}