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
    
    public partial class tbl_Tickets
    {
        public int ticket_id { get; set; }
        public string Id { get; set; }
        public int ticket_answer_id { get; set; }
        public System.DateTime ticket_date_time { get; set; }
        public string ticket_subject { get; set; }
        public string ticket_desc { get; set; }
        public bool read_ticket { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
