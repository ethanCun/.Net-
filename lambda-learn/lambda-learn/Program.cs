using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Lambda 表达式是一种可用于创建委托或表达式目录树的匿名函数
/// 形如 (参数，可以0,1,2...等多个) => (具体操作：表达式或者语法句子)
/// </summary>
namespace lambda_learn
{
    class Program
    {
        //定义三个委托 分别为不带参数 带1个参数 带2个参数
        private delegate string DelLambdaOne();
        private delegate void DeleLambdaTwo(string s);
        private delegate int DelLambdaThree(int i, int j);

        static void Main(string[] args)
        {
            //不带参数的Lambda表达式
            DelLambdaOne one = () =>
            {
                return "one";
            };

            Console.WriteLine(one());

            //带一个参数的Lambda表达式
            DeleLambdaTwo two = p =>
            {
                Console.WriteLine(p);
            };

            two("带一个参数的Lambda表达式");

            //带两个参数的Lambda表达式
            DelLambdaThree three = (p1, p2) =>
            {
                return p1 + p2;
            };

            Console.WriteLine(three(10,20));

            //Func与Lambda表达式
            LambdaFunc();

            //where筛选和查找的用法
            //获取所有的用户ID
            //List<string> gidList = Users.Select(p => p.Gid).ToList();
            //aaList = retList.Where(p => p > 6).ToList();

            Console.WriteLine("===所有大于3的数字集合===");

            //获取大于3的所有数字
            List<int> List1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> NewList1 = List1.Where(p => p > 3).ToList<int>() ;

            foreach(int i in NewList1)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("===名字的长度集合===");

            //获取名字的长度集合
            List<string> User = new List<string> { "zhangsan", "lisi", "wangwu", "zhaoliu" };
            List<int> NewUser = User.Select(user => user.Length).ToList<int>();

            foreach(int nameLen in NewUser)
            {
                Console.WriteLine(nameLen);
            }

            Console.WriteLine("===linq(语言集成查询（Language Integrated Query）)和lambda一起的用法（部分）===");

            Console.WriteLine(LambdaAndEach()); 

            Console.ReadKey();
        }

        /// <summary>
        /// linq(语言集成查询（Language Integrated Query）)和lambda一起的用法（部分）
        /// </summary>
        /// <returns></returns>
        public static string LambdaAndEach()
        {
            List<int> retList = new List<int> { 1,2,3,4,5,6,7};
            StringBuilder sbBuilder = new StringBuilder();
            retList.ForEach(p =>
            {
                if (p == retList[retList.Count - 1])
                {
                    sbBuilder.Append("'" + p);
                }
                else
                {
                    sbBuilder.Append("'" + p + "',");
                }
            });
            return sbBuilder.ToString();
        }

        /// <summary>
        /// Func和Lambda表达式一起用
        /// </summary>
        public static void LambdaFunc()
        {
            //Func和Lambda表达式一起用
            Func<string, string, string> addStr = (p1, p2) =>
            {
                return p1 + " - " + p2;
            };

            Console.WriteLine(addStr("lambda表达式1", "lambda表达式2"));
        }
    }
}
