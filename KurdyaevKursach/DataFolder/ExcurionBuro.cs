//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KurdyaevKursach.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExcurionBuro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExcurionBuro()
        {
            this.Excursion = new HashSet<Excursion>();
        }
    
        public int ExcurionBuroId { get; set; }
        public string ExcurionBuroName { get; set; }
        public string ExcurionBuroCountry { get; set; }
        public string ExcurionBuroExcursions { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Excursion> Excursion { get; set; }
    }
}
