
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
    
public partial class PartnerPreferance
{

    public int Id { get; set; }

    public Nullable<int> StarId { get; set; }

    public Nullable<int> EducationId { get; set; }

    public Nullable<int> EmployeetypeId { get; set; }

    public Nullable<int> OccupationId { get; set; }

    public Nullable<int> AnnualIncomeId { get; set; }

    public Nullable<int> CountryId { get; set; }

    public Nullable<int> StateId { get; set; }

    public Nullable<int> DistrictId { get; set; }

    public Nullable<int> CityId { get; set; }

    public Nullable<int> UserId { get; set; }

    public Nullable<System.DateTime> DateCreated { get; set; }

    public Nullable<int> CreatedBy { get; set; }

    public Nullable<System.DateTime> DateModified { get; set; }

    public Nullable<int> ModifiedBy { get; set; }



    public virtual Annualincome Annualincome { get; set; }

    public virtual City City { get; set; }

    public virtual Country Country { get; set; }

    public virtual District District { get; set; }

    public virtual Education Education { get; set; }

    public virtual EmploymentType EmploymentType { get; set; }

    public virtual Occupation Occupation { get; set; }

    public virtual Star Star { get; set; }

    public virtual State State { get; set; }

    public virtual User User { get; set; }

}

}
