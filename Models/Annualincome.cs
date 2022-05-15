
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MatrimonyAPI.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Annualincome
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Annualincome()
    {

        this.PhysicalProfileInfoes = new HashSet<PhysicalProfileInfo>();

        this.PartnerPreferances = new HashSet<PartnerPreferance>();

    }


    public int Id { get; set; }

    public string AnnualIncomeName { get; set; }

    public Nullable<System.DateTime> DateCreated { get; set; }

    public Nullable<System.DateTime> DateModified { get; set; }

    public Nullable<int> CreatedBy { get; set; }

    public Nullable<int> ModifiedBy { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<PhysicalProfileInfo> PhysicalProfileInfoes { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<PartnerPreferance> PartnerPreferances { get; set; }

}

}
