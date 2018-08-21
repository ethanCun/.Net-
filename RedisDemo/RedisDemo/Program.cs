using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisDemo
{
    class Program
    {
        public static string IP = "127.0.0.1";
        public static int PORT = 6379;
        public static string PWD = "czy1212";

        static void Main(string[] args)
        {
            //初始化RedisClient:IP地址 端口 密码 数据库下标
            RedisClient client = new RedisClient(IP, PORT);

            //删除所有数据库
            //client.FlushAll();
            //删除当前数据库
            //client.FlushDb();
            //选择数据库
            //client.ChangeDb(1);

            #region String 

            Console.WriteLine("=====value为普通字符串的存储=======");
            //AddMilliseconds:返回一个新的 System.DateTime，它将指定的毫秒数加到此实例的值上  时间：
            //过期时间
            //添加key-value
            client.Add<string>("timeout", "30秒之后消失", DateTime.Now.AddMilliseconds(30000));
            Console.WriteLine("消失时间：{0}",client.Get<string>("timeout"));
            Console.WriteLine("是否存在:{0}", client.ContainsKey("timeout"));
            //移除key
            client.Remove("timeout");
            //是否包含key
            Console.WriteLine("是否存在:{0}", client.ContainsKey("timeout"));

            Console.WriteLine("======value为自定义对象的储存=====");
            Student stu = new Student() { Name = "zhangsan", Class = "class1" };
            client.Add<Student>("stu", stu, DateTime.MaxValue);
            Student s = client.Get<Student>("stu");
            Console.WriteLine("是否存在学生对象:{0}", client.ContainsKey("stu"));
            Console.WriteLine("Name={0}, Class={1}", s.Name,s.Class);
            #endregion

            client.FlushDb();

            #region Hash

            Console.WriteLine("=====value为哈希值的储存=====");
            //保存一条信息
            client.SetEntryInHash("czy", "Name", "ethan");
            client.SetEntryInHash("czy", "Location", "ChangSha");
            //获取所有keys
            List<string> keys = client.GetHashKeys("czy");
            foreach(string key in keys)
            {
                //Name Location
                Console.WriteLine("key = {0}", key);
            }
            List<string> allKeys = client.GetAllKeys();
            foreach(string kk in allKeys)
            {
                //czy
                Console.WriteLine("kk = {0}", kk);
            }
            //获取所有values
            List<string> values = client.GetHashValues("czy");
            foreach(string value in values)
            {
                Console.WriteLine("values = {0}", value);
            }
            #endregion

            client.FlushDb();

            #region List

            //入栈
            client.EnqueueItemOnList("czy", "ethan");
            client.EnqueueItemOnList("czy", "changsha");
            client.EnqueueItemOnList("czy", "iOS");
            client.EnqueueItemOnList("czy", "c#");

            long count = client.GetListCount("czy");
            long count1 = client.LLen("czy");
            Console.WriteLine("数量:{0}{1}", count, count1);

            //根据下标取值
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("list根据下标取值:{0}", client.GetItemFromList("czy", i));
            }

            //插入新数据
            byte[] ii = System.Text.Encoding.Default.GetBytes("iOS");
            byte[] nn = System.Text.Encoding.Default.GetBytes("web");

            //true：在前面插入 false:在后面插入
            client.LInsert("czy", true, ii, nn);

            //获取所有value
            List<string> listValues = client.GetAllItemsFromList("czy");
            foreach(string ss in listValues)
            {
                Console.WriteLine("ss = {0}", ss);
            }

            //挨个出栈 先进后出
            for(int i =0; i<count; i++)
            {
                //string dequeueString = client.DequeueItemFromList("czy");
                string dequeueString = client.PopItemFromList("czy");
                Console.WriteLine("当前出栈:{0}", dequeueString);
            }
            #endregion

            //清空数据库
            client.FlushDb();

            #region Set

            Console.WriteLine("=====set=====");
            client.AddItemToSet("czy1", "ethan");
            client.AddItemToSet("czy1", "iOS");
            client.AddItemToSet("czy1", "c#");

            //数量
            Console.WriteLine("set数量:{0}", client.GetSetCount("czy1"));

            //所有值
            HashSet<string> sset1 = client.GetAllItemsFromSet("czy1");

            Console.WriteLine();
            Console.WriteLine("====sset1====");
            foreach(string sss1 in sset1)
            {
                Console.WriteLine("sss1 = {0}", sss1);
            }

            client.AddItemToSet("czy2", "ethan");
            client.AddItemToSet("czy2", "changsha");
            client.AddItemToSet("czy2", "pingpong");

            HashSet<string> sset2 = client.GetAllItemsFromSet("czy2");

            Console.WriteLine();
            Console.WriteLine("====sset2====");
            foreach (string sss2 in sset2)
            {
                Console.WriteLine("sss2 = {0}", sss2);
            }

            //并集
            HashSet<string> unionSets = client.GetUnionFromSets(new string[]{"czy1", "czy2"});
            Console.WriteLine("集合并集:");
            foreach(string unions in unionSets)
            {
                Console.WriteLine(unions);
            }

            //交集
            HashSet<string> intersectSets = client.GetIntersectFromSets(new string[] { "czy1", "czy2" });
            Console.WriteLine("集合交集:");
            foreach(string intersects in intersectSets)
            {
                Console.WriteLine(intersects);
            }

            //差集://[返回存在于第一个集合，但是不存在于其他集合的数据。差集]
            HashSet<string> differenceSets = client.GetDifferencesFromSet("czy1", new string[] {"czy2" });
            Console.WriteLine("集合差集:");
            foreach(string difference in differenceSets)
            {
                Console.WriteLine(difference);
            }

            Console.WriteLine();
            HashSet<string> differenceSets2 = client.GetDifferencesFromSet("czy2", new string[] { "czy1" });
            foreach(string diff in differenceSets2)
            {
                Console.WriteLine(diff);
            }

            #endregion

            client.FlushDb();

            #region Sorted Set

            client.AddItemToSortedSet("czy", "ethan");
            client.AddItemToSortedSet("czy", "changsha");
            client.AddItemToSortedSet("czy", "iOS");
            client.AddItemToSortedSet("czy", "c#");

            List<string> hset = client.GetAllItemsFromSortedSet("czy");
            foreach(string ssss in hset)
            {
                Console.WriteLine("Sorted Set = {0}", ssss);
            }

            #endregion

            Console.ReadKey();
        }
    }
}
