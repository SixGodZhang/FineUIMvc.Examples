using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FineUIMvc.Examples.Areas.DataModel.Models
{
    public class StudentHelper
    {
        public static IEnumerable<Student> GetSimpleStudentList()
        {
            var students = new List<Student> { 
                new Student {
                    Id= 101,
                    Name= "张萍萍",
                    Gender= 0,
                    EntranceYear= 2000,
                    AtSchool= true,
                    Major= "材料科学与工程系",
                    Group = 1,
                    EntranceDate= DateTime.Parse("2000-09-01")
                },
                new Student {
                    Id= 102,
                    Name= "陈飞",
                    Gender= 1,
                    EntranceYear= 2000,
                    AtSchool= false,
                    Major= "化学系",
                    Group = 1,
                    EntranceDate= DateTime.Parse("2001-09-01")
                },
                new Student {
                    Id= 103,
                    Name= "董婷婷",
                    Gender= 0,
                    EntranceYear= 2000,
                    AtSchool= true,
                    Major= "化学系",
                    Group = 1,
                    EntranceDate= DateTime.Parse("2008-09-01")
                },
                new Student {
                    Id= 104,
                    Name= "刘国",
                    Gender= 1,
                    EntranceYear= 2002,
                    AtSchool= false,
                    Major= "化学系",
                    Group = 2,
                    EntranceDate= DateTime.Parse("2002-09-01")
                },
                new Student {
                    Id= 105,
                    Name= "康颖颖",
                    Gender= 0,
                    EntranceYear= 2008,
                    AtSchool= true,
                    Major= "数学系",
                    Group = 2,
                    EntranceDate= DateTime.Parse("2008-09-01")
                },
                new Student {
                    Id= 106,
                    Name= "彭博",
                    Gender= 1,
                    EntranceYear= 2008,
                    AtSchool= true,
                    Major= "数学系",
                    Group = 3,
                    EntranceDate= DateTime.Parse("2003-09-01")
                },
                new Student {
                    Id= 107,
                    Name= "黄婷婷",
                    Gender= 0,
                    EntranceYear= 2008,
                    AtSchool= true,
                    Major= "数学系",
                    Group = 3,
                    EntranceDate= DateTime.Parse("2000-09-01")
                },
                new Student {
                    Id= 108,
                    Name= "唐超",
                    Gender= 1,
                    EntranceYear= 2004,
                    AtSchool= false,
                    Major= "物理系",
                    Group = 4,
                    EntranceDate= DateTime.Parse("2004-09-01")
                },
                new Student {
                    Id= 109,
                    Name= "杨婷婷",
                    Gender= 0,
                    EntranceYear= 2004,
                    AtSchool= true,
                    Major= "物理系",
                    Group = 4,
                    EntranceDate= DateTime.Parse("2003-09-01")
                },
                new Student {
                    Id= 110,
                    Name= "徐鹏",
                    Gender= 1,
                    EntranceYear= 2002,
                    AtSchool= false,
                    Major= "物理系",
                    Group = 4,
                    EntranceDate= DateTime.Parse("2002-09-01")
                },
                new Student {
                    Id= 111,
                    Name= "董国",
                    Gender= 1,
                    EntranceYear= 2012,
                    AtSchool= true,
                    Major= "自动化系",
                    Group = 5,
                    EntranceDate= DateTime.Parse("2006-09-01")
                },
                new Student {
                    Id= 112,
                    Name= "张三石",
                    Gender= 1,
                    EntranceYear= 2012,
                    AtSchool= true,
                    Major= "材料科学与工程系",
                    Group = 5,
                    EntranceDate= DateTime.Parse("2000-09-01")
                }
            };

            return students;
        }
    }
}