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
    
    public partial class Patients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patients()
        {
            this.Meetings = new HashSet<Meetings>();
        }
    
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Second_Name { get; set; }
        public string Middle_Name { get; set; }

        public string FULL { get => $"{Second_Name} {First_Name} {Middle_Name}"; }
        public Nullable<System.DateTime> Birth_day { get; set; }
        public string Address { get; set; }
        public string Illness { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meetings> Meetings { get; set; }
    }
}
