using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo2
{
    /// <summary>
    /// 泛型类继承自普通类
    /// </summary>
    public abstract class BaseClass
    {
        //字段
        protected int user_id;

        //属性
        public virtual int User_Id
        {
            get
            {
                return user_id;
            }
            set
            {
                user_id = value;
            }
        }

        //构造函数
        public BaseClass(int User_Id)
        {
            user_id = User_Id;
        }

        public abstract void Method1(int t);
    }

    public class TGenericClass<T>:BaseClass
    {
        //影藏基类中的成员:new实例化一个新的
        protected new T user_id;
        public new T Uer_Id
        {
            get
            {
                return user_id;
            }
        }

        //重写泛型类的构造方法
        public TGenericClass(int id) : base(1001)
        {

        }

        public TGenericClass(T t) : base(100)
        {
            user_id = t;
        }

        public override void Method1(int t)
        {
            Console.WriteLine(base.User_Id);
            Console.WriteLine("调用父类抽象方法");
        }

        public void Method(T t)
        {

        }
    }

    //普通类继承自泛型类
    public abstract class TGenericClass2<T>
    {
        protected T user_name;

        public virtual T User_Name
        {
            get
            {
                return user_name;
            }
            set
            {
                user_name = value;
            }
        }

        public TGenericClass2(string name)
        {

        }

        public TGenericClass2(T t)
        {
            user_name = t;
        }

        public abstract void Method(T t);
    }

    public class NormalClass2 : TGenericClass2<string>
    {
        //重写属性
        public override string User_Name
        {
            get
            {
                return base.User_Name;
            }
        }

        //重写构造方法
        public NormalClass2(string name) : base(name)
        {
            Console.WriteLine(name);
        }

        //重写抽象方法
        public override void Method(string name)
        {
            Console.WriteLine("name = {0}", name);
        }
    }

    //泛型类继承自泛型类
    public abstract class TGenericClass3<T>
    {
        //字段
        protected T height;

        //属性
        public T Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        //构造函数
        public TGenericClass3(T t)
        {
            Console.WriteLine("父类:{0}", t);
            height = t;
        }

        //抽象方法
        public abstract void Method(T t);
    }

    public class TGenericClass4<T> : TGenericClass3<T>
    {
        //new 影藏字段
        protected new T height;

        //重写属性
        public T Height
        {
            get
            {
                return height;
            }
            set
            {
                height = Height;
            }
        }

        //构造方法
        public TGenericClass4(T t) : base(t)
        {
            Console.WriteLine("子类:{0}", t);
        }

        //重写抽象方法
        public override void Method(T t)
        {
            Console.WriteLine("泛型类继承自泛型类:{0}", t.ToString());

        }
    }

    //泛型继承自泛型 多个参数
    public abstract class TGenericClass4<T1, T2>
    {
        //声明两个数组字段  分别装T1 T2
        public T1[] arr;
        public T2[] ind;

        //声明一个索引属性
        public T1 this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }

        //声明一个长度的属性 只读获取数组的长度
        public int length
        {
            get
            {
                return arr.Length;
            }
        }

        //自定义构造方法 传入一个数组长度
        public TGenericClass4(int length)
        {
            arr = new T1[length];
            ind = new T2[length];
        }
    }

    //第一个参数T表示数组里面存的值可以是任意泛型 第二个值是index 为int
    class TGenericClass5<T> : TGenericClass4<T, int>
    {
        //自定义构造方法给ind赋值t
        public TGenericClass5(int length) : base(length)
        {
            for (int i = 0; i < length; i++)
            {
                ind[i] = i;
            }
        }

        //输出
        public void output()
        {
            for(int i=0; i<length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //普通类继承自泛型类
            TGenericClass<int> ge = new TGenericClass<int>(100);
            ge.Method1(1);

            //泛型类继承自普通类
            NormalClass2 n2 = new NormalClass2("zhangsan");
            n2.Method("lisi");

            //泛型类继承自泛型类
            TGenericClass4<string> tg2 = new TGenericClass4<string>("100.1");
            TGenericClass4<int> tg3 = new TGenericClass4<int>(12);
            tg3.Method(100);

            //泛型类继承自泛型类 多个参数
            TGenericClass5<string> tg5 = new TGenericClass5<string>(5);
            tg5[0] = "arr1";
            tg5[1] = "arr2";
            tg5[2] = "arr3";
            tg5[3] = "arr4";
            tg5[4] = "arr5";

            tg5.output();

            Console.ReadKey();
        }
    }
}
