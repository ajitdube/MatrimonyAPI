
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
    
public partial class PhysicalProfileInfo
{

    public int Id { get; set; }

    public Nullable<int> UserId { get; set; }

    public Nullable<int> BodyTypeId { get; set; }

    public Nullable<int> ComplexionId { get; set; }

    public Nullable<int> PhysicalStatusId { get; set; }

    public Nullable<int> HeightId { get; set; }

    public Nullable<decimal> Weight { get; set; }

    public Nullable<int> EducationId { get; set; }

    public Nullable<int> EmploymentTypeId { get; set; }

    public Nullable<int> OccupationId { get; set; }

    public Nullable<int> AnnualIncomeId { get; set; }

    public Nullable<System.DateTime> DateCreated { get; set; }

    public Nullable<int> CreatedBy { get; set; }

    public Nullable<System.DateTime> DateModified { get; set; }

    public Nullable<int> ModofiedBy { get; set; }



    public virtual Annualincome Annualincome { get; set; }

    public virtual BodyType BodyType { get; set; }

    public virtual Complexion Complexion { get; set; }

    public virtual Education Education { get; set; }

    public virtual EmploymentType EmploymentType { get; set; }

    public virtual Height Height { get; set; }

    public virtual Occupation Occupation { get; set; }

    public virtual PhysicalStatu PhysicalStatu { get; set; }

    public virtual User User { get; set; }

}

}
