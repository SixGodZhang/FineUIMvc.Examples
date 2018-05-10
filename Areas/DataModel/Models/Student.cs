using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FineUIMvc.Examples.Areas.DataModel.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "姓名")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "性别")]
        public int Gender { get; set; }

        [Required]
        [Display(Name = "入学年份")]
        public int EntranceYear { get; set; }

        [Required]
        [Display(Name = "是否在校")]
        public bool AtSchool { get; set; }

        [Required]
        [Display(Name = "所学专业")]
        [StringLength(200)]
        public string Major { get; set; }

        [Required]
        [Display(Name = "分组")]
        public int Group { get; set; }


        [Display(Name = "注册日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EntranceDate { get; set; }

    }
}