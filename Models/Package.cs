
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
    
public partial class Package
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Package()
    {

        this.UserPackages = new HashSet<UserPackage>();

    }


    public int Id { get; set; }

    public string PackageName { get; set; }

    public Nullable<decimal> Cost { get; set; }

    public Nullable<int> ValidityInMonths { get; set; }

    public Nullable<int> NoOfProfileView { get; set; }

    public Nullable<System.DateTime> DateCreated { get; set; }

    public Nullable<int> CreatedBy { get; set; }

    public Nullable<System.DateTime> DateModified { get; set; }

    public Nullable<int> ModifiedBy { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<UserPackage> UserPackages { get; set; }

}

}
