using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FineUIMvc.Examples.Areas.DataModel.Models
{
    public class User
    {
        [Required]
        [Display(Name = "用户名")]
        [StringLength(20)]
        public string UserName { get; set; }
        

        [Required(ErrorMessage = "用户密码不能为空！", AllowEmptyStrings = true)]
        [Display(Name = "密码")]
        [MaxLength(9, ErrorMessage = "密码最大为 9 个字符！")]
        [MinLength(3, ErrorMessage = "密码最小为 3 个字符！")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?:[0-9]+[a-zA-Z]|[a-zA-Z]+[0-9])[a-zA-Z0-9]*$", ErrorMessage = "密码至少包含一个字母和数字！")]
        public string Password { get; set; }

    }
}