using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    public partial class User
    {
        [Key]
        public int UId		 { get; set; }

        [Display(Name ="用户名")]
       //[Required(ErrorMessage = "{0} 必须填写")]
        public string UserName { get; set; }//用户名

        [Display(Name = "性别")]
        public bool UserSex  { get; set; }

        [Display(Name = "年龄")]
        //[Range(1, 100, ErrorMessage = "超出范围")]
        public int Age		 { get; set; }

        [Display(Name = "时间")]
        public DateTime Time1 { get; set; }

        [Display(Name = "手机号")]
        //[StringLength(11, MinimumLength = 11, ErrorMessage = "{0}输入长度不正确")]
        public string Phone	 { get; set; }//手机号

        [Display(Name = "电子邮件")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "邮件格式不正确")]
        public string Emile { get; set; }//电子邮件

        [Display(Name = "备注")]
        public string Note { get; set; }//备注

        [Display(Name = "账号")]
        public string Number   { get; set; }//账号

        [Display(Name = "密码")]
        public string Password { get; set; }//密码
    }
} 
