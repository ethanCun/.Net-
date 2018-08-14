using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//引入正则表达式
using System.Text.RegularExpressions;


namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "zhangsan11,, 95111,lisi,wangwu1@@@@@";

            //自定正则表达式规则 以 0-9 , 空格 a-z A-Z 开头  结尾出现>=1次@
            Regex reg = new Regex("^[0-9, a-zA-Z]+@{1,}$");

            //匹配 返回一个结果集
            MatchCollection result = reg.Matches(s1);

            foreach(Match m in result)
            {
                //输出结果
                Console.WriteLine(m.ToString());
            }

            //使用正则表达式替换
            string s2 = "zhangsan   lisi    wangwu";
            string s3 = Regex.Replace(s2, @"\s+|z|n|l|i|w|u", "-");
            Console.WriteLine("s3 = {0}", s3);

            //匹配边界
            string s4 = "I is czy";
            string s5 = Regex.Replace(s4, @"\bis\b", "am");
            Console.WriteLine(@"s5 = {0}", s5);

            string s6 = Regex.Replace(s4, @"\bis.*\bcz", "* ");
            Console.WriteLine(@"s6 = {0}", s6);

            //分离字符串
            string s7 = "zhangsan-lisi0-wangwi5";
            string[] s8s = Regex.Split(s7, @"-|0|5| ");
            Console.WriteLine("字符串分离");
            foreach(string s in s8s)
            {
                Console.WriteLine(s);
            }

            //验证数字是否是11位 并且以1开头
            string phone = "";
            string pattern = @"^1\d{10}";
            bool boolResult = false;
            do
            {
                phone = Console.ReadLine();
                boolResult = Regex.IsMatch(phone, pattern);

                if (!boolResult)
                {
                    Console.WriteLine("格式不对,请重新输入");
                }

            } while (!boolResult);

            Console.WriteLine("格式正确");


            Console.ReadKey();
        }
    }
}
