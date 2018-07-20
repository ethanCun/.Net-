using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cls.Models;
using PetaPoco;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace cls.Controllers
{
    public class ClassController : ApiController
    {
        private Database db = new Database("cls");

        public List<Class> clases = new List<Class>();
        
        /// <summary>
        /// 获取所有班级
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IList<Class> GetAllClass()
        {
            var querySql = Sql.Builder.Select("*").From("t_class");

            var classes = db.Query<Class>(querySql).ToList();

            return classes;
        }

        /// <summary>
        /// 获取所有的学生
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IList<Student> GetAllStudent()
        {
            var querySql = Sql.Builder.Select("*").From("t_student");

            var students = db.Query<Student>(querySql).ToList();

            return students;
        }

        /// <summary>
        /// 增加一条学生信息
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IHttpActionResult AddStudent(string StudentName, string StudentHeight, string StudentWeight)
        {
            var stu = new Student();

            stu.StudentName = StudentName;
            stu.StudentHeight = StudentHeight;
            stu.StudentWeight = StudentWeight;

            //参数对应： 表名称 主键名称  增加的实体
            object obj = db.Insert("t_student", "Id", stu);

            //返回结果
            Dictionary<string, object> result = new Dictionary<string, object>();

            if((int)obj > 0)
            {
                result.Add("code", 0);
                result.Add("message", "success");
            }
            else
            {
                result.Add("code", -1);
                result.Add("message", "failed");
            }

            return Content<object>(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// 删除一条学生信息
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IHttpActionResult RemoveStudent(int Id)
        {
            //首先需要获取到一条记录 这个方法只能取一条数据
            Student stu = db.SingleOrDefault<Student>("select * from t_student where Id=@0", Id);

            int obj = db.Delete("t_student", "Id", stu);

            Dictionary<string, object> result = new Dictionary<string, object>();

            if(obj > 0)
            {
                result.Add("code", 0);
                result.Add("message", "删除成功");
            }
            else
            {
                result.Add("code", -1);
                result.Add("message", "删除失败");
            }

            return Content<Dictionary<string, object>>(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// 删除所有名称一样的数据
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IHttpActionResult RemoveSameNameStudentInfo(string StudentName)
        {
            int res = db.Execute("delete from t_student where StudentName=@0", StudentName);

            Dictionary<string, object> result = new Dictionary<string, object>();

            if(res > 0)
            {
                result.Add("code", 0);
                result.Add("message", "success");
            }
            else
            {
                result.Add("code", -1);
                result.Add("message", "failed");
            }

            return Content<Dictionary<string, object>>(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IHttpActionResult UpdateStudentInfo(int Id, string StudentName)
        {
            //修改之前必须先获取到该数据
            Student stu = db.SingleOrDefault<Student>("select * from t_student where Id=@0", Id);

            Dictionary<string, object> res = new Dictionary<string, object>();

            if(stu == null)
            {
                res.Add("code", -1);
                res.Add("message", "failed");

                return Content<Dictionary<string, object>>(HttpStatusCode.OK, res);

            }


            stu.StudentName = StudentName;

            int obj = db.Update("t_student", "Id", stu);


            res.Clear();

            if (obj > 0)
            {
                res.Add("code", 0);
                res.Add("message", "success");
            }
            else
            {
                res.Add("code", -1);
                res.Add("message", "failed");
            }


            return Content<Dictionary<string, object>>(HttpStatusCode.OK, res);
        }

        /// <summary>
        /// sql连接数据库 返回数据
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public List<Class> GetAllStudentsByNormalSql()
        {
            string s = "Server=127.0.0.1;user=sa;pwd=sa;database=cls";

            SqlConnection sqlcon = new SqlConnection(s);

            sqlcon.Open();   

            SqlDataAdapter da = new SqlDataAdapter("select * from t_class", sqlcon);

            DataSet ds = new DataSet();

            da.Fill(ds);

            this.clases.Clear();

            foreach(DataTable dt in ds.Tables)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    Class clas = new Class();
                    clas.Id = (int)dr[0];
                    clas.ClassName = dr[1].ToString();
                    clas.StudentCount = (int)dr[2];

                    this.clases.Add(clas);
                }
            }

            return clases;
        }

        /// <summary>
        /// 更新或者新增学生信息
        /// </summary>
        /// <param name="Id">学生id</param>
        /// <param name="StudentName">学生名称</param>
        /// <param name="StudentHeight">学生身高</param>
        /// <param name="StudentWeight">学生体重</param>
        /// <returns></returns>
        public IHttpActionResult UpdateOrInsertStudent(int Id, string StudentName, string StudentHeight, string StudentWeight)
        {
            Sql sql = Sql.Builder.Select("*").From("t_student").Where("Id=@0", Id);

            List<Student> students = db.Query<Student>(sql).ToList();

            //如果存在就更新
            //找到存在的数据
            if(students.Count > 0)
            {
                Student stu = db.SingleOrDefault<Student>(sql);

                stu.StudentName = StudentName;
                stu.StudentHeight = StudentHeight;
                stu.StudentWeight = StudentWeight;

                int res =  db.Update("t_student", "Id", stu);

                if(res > 0)
                {
                    return Content<Dictionary<string, object>>(HttpStatusCode.OK, new Dictionary<string, object> { { "code", 0 }, { "message", "success" } });
                }
                else
                {
                    return Content<Dictionary<string, object>>(HttpStatusCode.OK, new Dictionary<string, object> { { "code", -1 }, { "message", "failed" } });

                }
            }
            else
            {
                //不存在就插入数据
                Student stu = new Student();
                stu.StudentName = StudentName;
                stu.StudentHeight = StudentHeight;
                stu.StudentWeight = StudentWeight;

                Object res = db.Insert("t_student", stu);

                if((int)res > 0)
                {
                    return Content<Dictionary<string, object>>(HttpStatusCode.OK, new Dictionary<string, object> { { "code", 0 }, { "message", "success" } });
                }
                else
                {
                    return Content<Dictionary<string, object>>(HttpStatusCode.OK, new Dictionary<string, object> { { "code", -1 }, { "message", "failed" } });
                }
            }
        }

        /// <summary>
        /// 更新或者新增学生信息
        /// </summary>
        /// <param name="student">学生模型</param>
        /// <returns></returns>
        public IHttpActionResult UpdateOrInsertStudent2(Student student)
        {
            Sql sql = Sql.Builder.Select("*").From("t_student").Where("Id=@0", student.Id);

            List<Student> students = db.Query<Student>(sql).ToList();

            //如果存在就更新
            //找到存在的数据
            if (students.Count > 0)
            {
                Student stu = db.SingleOrDefault<Student>(sql);

                stu.StudentName = student.StudentName;
                stu.StudentHeight = student.StudentHeight;
                stu.StudentWeight = student.StudentWeight;

                int res = db.Update("t_student", "Id", stu);

                if (res > 0)
                {
                    return Content<Dictionary<string, object>>(HttpStatusCode.OK, new Dictionary<string, object> { { "code", 0 }, { "message", "success" } });
                }
                else
                {
                    return Content<Dictionary<string, object>>(HttpStatusCode.OK, new Dictionary<string, object> { { "code", -1 }, { "message", "failed" } });

                }
            }
            else
            {
                //不存在就插入数据
                Student stu = new Student();
                stu.StudentName = student.StudentName;
                stu.StudentHeight = student.StudentHeight;
                stu.StudentWeight = student.StudentWeight;

                Object res = db.Insert("t_student", stu);

                if ((int)res > 0)
                {
                    return Content<Dictionary<string, object>>(HttpStatusCode.OK, new Dictionary<string, object> { { "code", 0 }, { "message", "success" } });
                }
                else
                {
                    return Content<Dictionary<string, object>>(HttpStatusCode.OK, new Dictionary<string, object> { { "code", -1 }, { "message", "failed" } });
                }
            }
        }

    }
}
