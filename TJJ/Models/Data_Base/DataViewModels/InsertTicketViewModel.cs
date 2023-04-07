using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TJJ.Data_Base.DataViewModels
{
    public class InsertTicketViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "موضوع درخواست")]
        [MaxLength(130)]
        public string ticket_subject { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "متن درخواست")]
        [DataType(DataType.MultilineText)]
        [MaxLength(5000)]
        public string ticket_desc { get; set; }
    }
}