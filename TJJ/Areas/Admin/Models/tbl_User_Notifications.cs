//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TJJ.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_User_Notifications
    {
        public int ticket_id { get; set; }
        public string Id { get; set; }
        public System.DateTime not_creation_date_time { get; set; }
        public string not_subject { get; set; }
        public string not_comment { get; set; }
        public string not_text { get; set; }
        public bool read_user_not { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}