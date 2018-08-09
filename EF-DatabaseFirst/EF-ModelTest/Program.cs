using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelTest
{
    class Program
    {
        //参考链接：https://blog.csdn.net/u010028869/article/details/47108205
        static void Main(string[] args)
        {
            DatabaseFirst();

            Console.ReadKey();
        }

        public static void DatabaseFirst()
        {
            //注意：如果咱们的数据库表结构发生改变后，只需在模型设计视图空白处右键，
            //选择“从数据库更新模型”接着按照向导操作即可将模型更新或者新增表。
            //删除：数据库删除表之后，需要在模型设计视图里选择相应的模型右击选择："从模型删除"。

            Console.WriteLine("使用Lanmbda表达式查询");

            //实例化数据库上下文
            EFTestEntities dbContext = new EFTestEntities();

            //使用Lambda表达式查询数据
            var users = dbContext.t_User.Where(p => p.Name.Length > 4).ToList();

            if (users.Any())
            {
                foreach (var obj in users)
                {
                    Console.WriteLine("Name:{0}, Sex:{1}, Department:{2}", obj.Name, obj.Sex, obj.Department);
                }
            }

            Console.WriteLine("使用Linq语句查询");

            //linq语句查询
            var users2 = from o in dbContext.t_User
                         where o.Name == "lisi"
                         select o;

            if (users2.Any())
            {
                foreach (var obj in users2)
                {
                    Console.WriteLine("Name:{0}, Sex:{1}, Department:{2}", obj.Name, obj.Sex, obj.Department);
                }
            }
        }
    }
}
