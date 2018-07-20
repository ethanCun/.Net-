using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cls.Models
{
    public class Class
    {
        /// <summary>
        /// 班级id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 班级人数
        /// </summary>
        public int StudentCount { get; set; }

        /// <summary>
        /// 所有学生模型
        /// </summary>
        public List<Student> students { get; set; } = new List<Student>();
    }

    public class Student
    {
        /// <summary>
        /// 学生Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 学生名称
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// 学生身高
        /// </summary>
        public string StudentHeight { get; set; }

        /// <summary>
        /// 学生体重
        /// </summary>
        public string StudentWeight { get; set; }
    }
}