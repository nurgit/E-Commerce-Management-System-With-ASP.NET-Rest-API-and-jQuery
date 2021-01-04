//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Backend_Rest__API.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    public partial class UserRegistration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserRegistration()
        {
            this.Feedbacks = new HashSet<Feedback>();
        }
        List<Link> links = new List<Link>();

        public int UId { get; set; }
        [Required]
        public string UEmail { get; set; }
        [Required]
        public string Uname { get; set; }
        [Required]
        public string Upassword { get; set; }
        public List<Link> Links
        {
            get { return links; }

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore, XmlIgnore]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
