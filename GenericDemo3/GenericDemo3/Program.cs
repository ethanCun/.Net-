using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GenericDemo3
{
    class TGenericClass<T1, T2, T3>
    {
    #region c# 设置泛型默认值
        //不能实例化 例如：_object = new T1();     
        //因为此刻不知道T1是什么，也就不能使用它的构造函数，可能T1就没有构造函数，
        //或者没有可公共访问的构造函数。因此要对泛型进行实际的操作需要更多了解其使用的类型。
        //要确定用于创建泛型类型的实例，需要了解一个最基本的情况，它是引用类型还是值类型，
        //若不了解这个情况就不能直接对变量赋予null值。此时default关键字就派上了用场：
        //如果_object是引用类型就给引用类型赋为null值，如果为值类型就给它赋为默认值。
        //对于数字类型默认值为0，对于结构，按照相同的规则对它们进行赋值。
        //default关键字允许对必须使用的类型进行更多的操作，为了进行更多的操作，必须对使用的类型进行更多的约束。
        private T1 _object = default(T1);

        //构造方法
        public TGenericClass(T1 obj)
        {
            _object = obj;
        }

        //只读属性
        public T1 Innerobj
        {
            get
            {
                return _object;
            }
        }
    }

    #endregion

    #region C#泛型继承：
    class A<U, V>
    {

    }

    class B:A<string, int>
    {

    }

    class C<U, V> : A<U, V>
    {

    }

    class D<U, V> : A<string, int>
    {

    }

    //报错 E类型为非法的，因为E类型不是泛型，A是泛型，E无法给A提供泛型的实例化
    //class E : A<U, V>
    //{

    //}

    //报错
    //class F<string, int> : A<U, V>
    //{

    //}

    #endregion

    #region c#基类约束
     class A1
    {
        public void log()
        {
            Console.WriteLine("A1");
        }
    }

    class A2
    {
        public void log()
        {
            Console.WriteLine("A2");
        }
    }

    class A3<U, V> 
        where U : A1
        where V : A2
    {
        public A3(U u, V v)
        {
            A1 a1 = new A1();
            A2 a2 = new A2();

            a1.log();
            a2.log();
        }
    }

    #endregion

    #region c#接口约束
    interface B1<T>
    {
        T fun1();
    }

    interface B2
    {
        void fun2();
    }

    interface B3<T>
    {
        T fun3();
    }

#warning 注意继承的接口参数
    class BB<U, V>
         where U : B1<string>
         where V : B2, B3<string>
    {
        public BB(U u, V v)
        {
            //u可以调用B1接口的方法
            u.fun1();

            //v可以调用B2和B3接口的方法
            v.fun2();
            v.fun3();
        }
    }

    //实现接口的两个类
    class UU : B1<string>
    {
        string B1<string>.fun1()
        {
            Console.WriteLine("fun1");

            return MethodBase.GetCurrentMethod().DeclaringType.ToString();
        }
    }

    class VV : B2, B3<string>
    {
        void B2.fun2()
        {
            Console.WriteLine("fun2");
        }

        string B3<string>.fun3()
        {
            Console.WriteLine("fun3");

            return MethodBase.GetCurrentMethod().DeclaringType.ToString();
        }
    }

    #endregion

    #region c#构造器约束 C#现在只支持无参的构造器约束

    class C1
    {
        //不带参数的构造函数
        public C1()
        {
            Console.WriteLine("c1");
        }
    }

    class C2
    {
        //构造器约束 不管传参或者不传参 走的都是无参的构造器方法
        public C2(string s)
        {
            Console.WriteLine("c2 带参数的构造函数");
        }

        public C2()
        {
            Console.WriteLine("c2 不带参数的构造函数");
        }
    }

    class C3<T>
        where T : new()
    {
        T t;
        public C3()
        {
            t = new T();
        }

        public C3(string s)
        {
            t = new T();
        }
    }

    #endregion

    #region c3泛型约束值引用类型与值类型

    //值类型 结构体
    public struct D1
    {
        
    }

    public class D2
    {

    }

    public class D3<T> where T : struct
    {

    }

    public class D4<T> where T : class
    {

    }


    #endregion

    class Program 
    {
        static void Main(string[] args)
        {
            //c#中的可空类型
            int a = 0;
            int? b = null;

            Console.WriteLine("a = {0}, b = {1}", a, b);

            //泛型demo1
            var num = new NumberCollection();
            Console.WriteLine("====输出所有元素=======");
            num.Print();

            //自定义排序
            num.Sort(NumberCollectionDelegate.CompareDelegate);
            Console.WriteLine("=========自定义排序=========");
            num.Print();

            //自定义谓词 查找
            var num1 = new NumberCollection(num.FindAll(NumberCollectionDelegate.Predicate));
            Console.WriteLine("========自定义谓词查找=========");
            num1.Print();

            Dictionary<int, string> paras = new Dictionary<int, string>();
            paras.Add(0, "0000");
            paras.Add(1, "1111");
            paras.Add(2, "2222");

            Console.WriteLine("输出key value");
            foreach(KeyValuePair<int, string> kv in paras)
            {
                Console.WriteLine("key = {0}, value = {1}", kv.Key, kv.Value);
            }

            //基类约束
            A1 a1 = new A1();
            A2 a2 = new A2();
            A3<A1, A2> a3 = new A3<A1, A2>(a1, a2);

            //接口约束
            UU u = new UU();
            VV v = new VV();
            BB<UU, VV> bb = new BB<UU, VV>(u, v);

            //构造器约束 两种情况都是走不带参数的构造器

            Console.WriteLine("===构造器约束不带参数的情况====");
            C3<C1> c311 = new C3<C1>();
            C3<C2> c321 = new C3<C2>();

            Console.WriteLine("====构造器约束带参数的情况====");
            C3<C1> c31 = new C3<C1>("c1");
            C3<C2> c32 = new C3<C2>("c2");


            //泛型约束的值约束与引用约束
            D3<int> d1 = new D3<int>();

            //报错：u不是值类型
            //D3<u> d2 = new D3<u>();

            D4<C2> d4 = new D4<C2>();

            Console.Read();
        }
    }
}
