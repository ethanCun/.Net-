using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //简单Linq筛选语句
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var qq = from num in nums
                     where num > 5
                     select num;

            foreach (var q in qq)
            {
                Console.WriteLine(q);
            }

            Console.WriteLine("===============");

            //多个关系条件
            var pp = from num in nums
                     where (num > 2) && (num % 2 == 0)
                     select num;

            foreach (var p in pp)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("================");

            //Linq语句与Lambda语句的结合使用
            var ss = nums.Where(p => p > 4 && p % 2 == 0);

            foreach (var s in ss)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("==================");

            //求出第一个数
            var dd = nums.First(p => p > 2 || p % 2 == 0);
            Console.WriteLine(dd);

            Console.WriteLine("====================");

            Person p1 = new Person();
            p1.Name = "zhangsan";
            p1.Age = 20;
            Person p2 = new Person();
            p2.Name = "lisi";
            p2.Age = 23;

            List<Person> persons = new List<Person> { p1, p2 };

            //创建新对象
            var gg = from p in persons
                     select new { p1.Name, p2.Age };

            foreach(var g in gg)
            {
                Console.WriteLine("Name = {0}, Age = {1}", g.Name, g.Age);
            }

            Console.WriteLine("==============");

            //计算个数
            Console.WriteLine("count = {0}", persons.Count(p=>p.Age>22));

            Console.WriteLine("================");

            //求和
            var sum = 0;
            foreach(Person p in persons)
            {
                if(p.Age < 20)
                {
                    continue;
                }
                sum += p.Age;
            }

            Console.WriteLine("sum = {0}", sum);
        
            Console.WriteLine(persons.Select(p=>p.Age).Sum());

            Console.WriteLine("=====================");

            //最大值与最小值 平均值
            Console.WriteLine("max = {0}, min = {1}", persons.Select(p => p.Age).Max(),
                persons.Select(p => p.Age).Min());
            Console.WriteLine("max = {0}, min = {1}", persons.Max(p=>p.Name), persons.Min(p=>p.Name));
            Console.WriteLine("aver = {0}", persons.Select(p=>p.Age).Average());
            Console.WriteLine("aver = {0}", persons.Average(p=>p.Age));

            Console.WriteLine("=========================");

            //一对多关系:选出所有1..<10之间的数
            List<int> arr1 = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> arr2 = new List<int> { 11, 2, 3, 4, 55, 21, 12, 31 };
            List<int> arr3 = new List<int> { 31, 22, 12, 24, 33, 12 };
            List<List<int>> arr4 = new List<List<int>> { arr1, arr2, arr3 };

            var hh = from p in arr4
                     from q in p
                     where q > 0 && q < 10
                     select q;
            foreach(var p in hh)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("==========");

            //排序
            var jj = from p in arr2
                     orderby p descending
                     select p;

            foreach(var j in jj)
            {
                Console.WriteLine(j);
            }


            Person pp1 = new Person();
            pp1.Name = "zhangsan";
            pp1.Age = 12;
            Person pp2 = new Person();
            pp2.Name = "lisi";
            pp2.Age = 22;
            Person pp3 = new Person();
            pp3.Name = "wangwu";
            pp3.Age = 33;
            Person pp4 = new Person();
            pp4.Name = "wangwu";
            pp4.Age = 44;

            List<Person> ppps = new List<Person> { pp1, pp2, pp3, pp4};

            //综合排序
            var kk = from p in ppps
                     orderby p.Name ascending, p.Age descending
                     select p;
            foreach(var k in kk)
            {
                Console.WriteLine("Name:{0},Age:{1}", k.Name, k.Age);
            }

            Console.WriteLine("=============");

            var ll = ppps.OrderBy(p => p.Name)
            .ThenByDescending(p => p.Age);

            foreach(Person p in ll)
            {
                Console.WriteLine("Name = {0}, Age = {1}", p.Name, p.Age);
            }

            Console.ReadKey();
        }
    }
}
