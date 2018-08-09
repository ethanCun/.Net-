using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst
{
    class Program
    {
        //https://blog.csdn.net/u010028869/article/details/47134343
        static void Main(string[] args)
        {
            //注意：当我们的实体需要改变时，只需要在模型设计视图修改保存模型，
            //此时实体类就会相应改变，
            //然后选择“从模型生成到数据库”重新执行生成的脚本即可将变化同步到数据库。
            ModelFisrt();

            Console.ReadKey();
        }

        /// <summary>
        /// 模型优先
        /// </summary>
        public static void ModelFisrt()
        {
            //实例化数据库上下文
            ModelTestContainer dbContext = new ModelTestContainer();

            //找出数据库下UserSet表中所有名字长度不为0的用户
            var users = dbContext.UserSet.Where(p => p.Name.Length > 4).ToList();

            if (users.Any())
            {
                foreach (var obj in users)
                {
                    Console.WriteLine("Id:{0}, Name:{1}, Sex:{2}, Password:{3}",
                        obj.Id, obj.Name, obj.Sex, obj.Password);
                }
            }
        }
    }
}
