using System;
//泛型命名空间
using System.Collections.Generic;
using System.Linq;

namespace Generic
{
    /// <summary>
    /// 自定义泛型类 以T开头 结尾带上泛型参数<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TGenericOne<T>
    {
        public T Info;

        /// <summary>
        /// 重写类的构造函数
        /// </summary>
        /// <param name="info"></param>
        public TGenericOne(T info)
        {
            this.Info = info;

            Console.WriteLine(Info); 
        }
    }

    /// <summary>
    /// 普通类 返回值为泛型 带泛型参数
    /// </summary>
    public static class NormalClass
    {
        //非泛型方法 泛型参数不属于方法本身
        public static T Say<T>(T t)
        {
            if (t is string)
            {
                Console.WriteLine(t);
            }

            return t;
        }
    }

    /// <summary>
    /// 泛型类 
    /// </summary>
    public static class TGenericClassTwo<T>
    {
        //泛型方法 泛型参数属于方法本身
        public static T Say(T t)
        {
            if (t is Array)
            {
                Console.WriteLine("是数组");
            }
            else
            {
                Console.WriteLine("不是数组");
            }

            if (t is String)
            {
                Console.WriteLine("字符串:" + t);
            }

            if(t is int)
            {
                Console.WriteLine("整型:" + t.ToString());
            }

            if(t is char)
            {
                Console.WriteLine("字符型:" + t.ToString());
            }

            //如果是自定义类型
            if(t is CustomClass)
            {
                Console.WriteLine("自定义类型:" + t);
            }

            return t;
        }
    }

    public class CustomClass
    {
        public int Id;

        public CustomClass(int Id)
        {
            this.Id = Id;
        }
    }

    class Program
    {
        /// <summary>
        /// 自定义泛型类
        /// </summary>
        public static void CustomGenericClass()
        {
            //泛型类重写构造方法
            TGenericOne<string> tg = new TGenericOne<string>("this is a generic class");

            //非泛型类
            NormalClass.Say("Normal, Hello world！");

            //泛型
            TGenericClassTwo<string>.Say("Generic, Hello world");
            TGenericClassTwo<int>.Say(111);
            TGenericClassTwo<char>.Say('i');
            //泛型参数为自定义的类型
            CustomClass customClass = new CustomClass(1);
            TGenericClassTwo<CustomClass>.Say(customClass);
        }

        static void Main(string[] args)
        {
            //集合与数组区别：1.长度可变 2.元素类型可不一致
            //List<T>  T:type 用来定义泛型类时的占位符 T出现的位置在实例化时可以使用任意的类型来替代
            // 泛型类只有在实例化的时候才分配栈内存
            // 泛型在实例化的时候才由开放类型变成封闭类型 List<t> -> List<string>
            List<int> list1 = new List<int>();
            list1.Add(1);
            list1.AddRange(new int[] { 1,2,3});
            //list1.AddRange(list1);
            list1.Remove(1);
            list1.Reverse();
            list1.Sort();

            //转换为数组
            int[] arr1 = list1.ToArray();

            //转换为List<>
            List<int> llist1 = arr1.ToList();

            foreach (int i in llist1) ;

            //泛型集合类：
            //List<T> 增加 删除 逆序 排序
            //Dictionary<TKey, TValue> 键值对
            //SortedDictionary<TKey, TValue>  键值对 可以按照键来排序
            //LinkedList<T> 双向链表
            //Queue<T> 队列 先进先出 如打印 Enqueue Dequeue Peek
            //Stack<T> 栈 先进后出

            //Queue<T> queue1 = new Queue<T>();
            //queue1.Enqueue() 相当于栈的push
            //queue1.Dequeue() 相当于栈的pop
            //queue1.Peek 返回位于 System.Collections.Generic.Queue`1 开始处的对象但不将其移除。

            //Stack<T> stack = new Stack<T>();
            //stack.Push()
            //stack.Pop();
            //stack.Peek();

            //自定义泛型类
            Program.CustomGenericClass();


            Console.ReadKey();
        }
    }
}
