using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FineUIMvc.Examples.Areas.DataModel.Models
{
    public class UICompareModel
    {
        [Required]
        [Display(Name = "开始日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? StartDate { get; set; }


        [Required]
        [Display(Name = "结束日期（大于开始日期）")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [UICompare("StartDate", Operator.GreaterThan, ErrorMessage = "结束日期应该大于开始日期！")]
        public DateTime? EndDate { get; set; }


        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "两次输入的密码要相同！")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Display(Name = "数字 1")]
        public int? Number1 { get; set; }

        [Required]
        [Display(Name = "数字 2（大于等于数字 1）")]
        [UICompare("Number1", Operator.GreaterThanEqual, ErrorMessage = "数字 2 应该大于等于数字 1 的值！")]
        public int? Number2 { get; set; }


    }
}