﻿


<a href="#VisualSVN serevr与tortoiseSVN client" rel="nofollow" target="_blank">1. windows下SVN版本控制VisualSVN serevr与tortoiseSVN client（类似mac上Cornerstone）的使用</a></p>
<a href="#泛型类与泛型参数" rel="nofollow" target="_blank">2. c#中的泛型类与泛型参数</a></p>
<a href="#泛型类继承自普通类、普通类继承自泛型类、泛型类继承自泛型类的情况" rel="nofollow" target="_blank">3. c#中泛型类继承自普通类、普通类继承自泛型类、泛型类继承自泛型类的情况
</a></p>
<a href="#为webapi添加接口注释和测试功能" rel="nofollow" target="_blank">4. 为webapi添加接口注释和测试功能</a></p>
<a href="#webapi接口返回值： IHttpActionResult HttpResponseMessage 与 自定义类型" rel="nofollow" target="_blank">5. webapi接口返回值： IHttpActionResult HttpResponseMessage 与 自定义类型</a></p>
<a href="#自定义的webApi接口返回值" rel="nofollow" target="_blank">6. 自定义的webApi接口返回值</a></p>
<a href="#PetaPoco（ORM操作）的简单实用" rel="nofollow" target="_blank">7. PetaPoco（ORM操作）的简单实用</a></p>
<a href="#PetaPoco分页获取信息Web.config" rel="nofollow" target="_blank">8. PetaPoco分页获取信息Web.config</a></p>
<a href="#多层数组结构的处理" rel="nofollow" target="_blank">9. 多层数组结构的处理</a></p>
<a href="#多层结构的api" rel="nofollow" target="_blank">10. 多层结构的api 详见OrderDetail</a></p>
<a href="#Newtonsoft ： json与对象的相互转换" rel="nofollow" target="_blank">11. Newtonsoft ： json与对象的相互转换</a></p>
<a href="#插入或者更新一条信息" rel="nofollow" target="_blank">12. 插入或者更新一条信息： 表中存在该信息 则更新（先删除原来存在的 再插入新的数据） 表中不存在该数据 则添加</a></p>
<a href="#常用复杂Sql语句" rel="nofollow" target="_blank">13. 常用复杂Sql语句</a></p>
<a href="#Nlog日志记录" rel="nofollow" target="_blank">14. Nlog日志记录</a></p>
<a href="#log4net日志记录" rel="nofollow" target="_blank">15. log4net日志记录</a></p>
<a href="#SuperSocket使用" rel="nofollow" target="_blank">16. SuperSocket使用</a></p>
<a href="#c# 泛型默认值、继承、基类约束、接口约束、引用类型与值类型" rel="nofollow" target="_blank">17. c# 泛型默认值、继承、基类约束、接口约束、引用类型与值类型</a></p>
<a href="#C#常用格式输出" rel="nofollow" target="_blank">18. C#常用格式输出</a></p>
<a href="#Lambda表达式的使用" rel="nofollow" target="_blank">19. Lambda表达式的使用</a></p>
<a href="#EF" rel="nofollow" target="_blank">20. EF的简单使用</a></p>
<a href="#HttpClient与HttpWebRequest" rel="nofollow" target="_blank">21. HttpClient与HttpWebRequest</a></p>
<a href="#Linq语句的使用" rel="nofollow" target="_blank">22. Linq语句的使用</a></p>
<a href="#Authentication接口安全-Basic认证" rel="nofollow" target="_blank">23. Authentication接口安全-Basic认证</a></p>
<a href="#正则表达式" rel="nofollow" target="_blank">24. c#正则表达式</a></p>
<a href="#图片与文件的上传" rel="nofollow" target="_blank">25. 图片与文件的上传</a></p>
<a href="#Base64与Image的互相转换" rel="nofollow" target="_blank">26. Base64与Image的互相转换, 生成头像路径 并保存到sqlserver</a></p>
<a href="#JPush" rel="nofollow" target="_blank">27. Jpush</a></p>
<a href="#Redis" rel="nofollow" target="_blank">28. Redis:一个开源的使用ANSI C语言编写、遵守BSD协议、支持网络、可基于内存亦可持久化的日志型、Key-Value数据库</a></p>

```
Tips:

1. windows10下打开sqlserver配置器的方法
   
    此电脑右键管理 - 》 展开服务于应用程序 -》 展开sqlserver配置器管理器 -》选择sqlserver网络配置 -》点击sqlexpress的协议 -》选择NamePipes、TCP
   /IP启动；

2.windows10下打开本地服务
   
   搜索程序services.msc点击打开

3. IIS（Internet Information Service）的位置：控制面板 -》 管理工具 -》Internet Information Services (IIS)管理器

   IIS发布web项目参考链接：https://jingyan.baidu.com/article/fedf073770f23335ac8977b1.html

4. IIS的配置：控制面板 -》  程序和功能 -》点击启用或关闭Windows功能 -》 勾选Internet Infomation Services下面的所有功能-》点击确定部署

5 webapi为接口添加注释， 右键项目属性 -》生成 -》勾选XML文档文件 -》设置为App_Data/XmlDocument.xml -》
   关闭 -》来到Aero -》HelpPage -》 App_Start -》 HelpPageConfig.cs -》 打开方法名为config.SetDocumentationProvider方法的注释 -》
   .xml文件的路径可以修改，只需要保证一致就行

    ### 发布环境下为接口添加注释功能， 一定不能少了在App_Data下添加XmlDocument.xml文件， 不然会报错，这个文件找不到

6.webAPi与mvc路由机制的区别：可以看看这篇文章：https://www.cnblogs.com/landeanfen/p/5501490.html

7. sql去重查找单个字段所有信息：SELECT DISTINCT 字段名 FROM Orders 

8 项目的部署：生成（重新生成解决方案） -》生成（发布...） -》或者右键项目 1：配置文件 自定义配置文件名称 2：连接publish method选择file system
   	设置一个target location（这个路径与IIS的物理地址一致） 3.设置  4.预览点击发布  -》在IIS中添加一个网站 设置网站名称  应用程序池 物理路径
	绑定ip地址和端口号， 点击确定

9 webapi添加接口注释和测试功能 ： https://blog.csdn.net/a123_z/article/details/71078062
	测试功能：需在 Areas\HelpPage\Views\Help\Api.cshtml文件最后面添加：
	
@Html.DisplayForModel("TestClientDialogs")
@section Scripts {
    <linktype ="text/css" href="~/Areas/HelpPage/HelpPage.css" rel="stylesheet" />
    @Html.DisplayForModel("TestClientReferences")
}

10 关于webapi的返回类型，看这个网址就能了解一大半了：https://www.cnblogs.com/landeanfen/p/5501487.html#_label0

11. MVC3中 ViewBag、ViewData和TempData的使用和区别： http://www.cnblogs.com/bianlan/archive/2013/01/11/2857105.html

12. PetaPoco的使用：
	先在Web.config <connectionStrings></connectionStrings>中连接数据库
               <add name="books" providerName="System.Data.SqlClient" connectionString="server=127.0.0.1;database=books;uid=sa;pwd=sa" />
	
	定义DataBase: private Database db = new Database("books");

	var sql = Sql.Builder.Select("*").From("mybook").Where("id>@0", 10).OrderBy("name asc");

 	var books = db.Query<book>(sql).ToList();

13. NLog的使用：https://blog.csdn.net/dsnq2011/article/details/51920265

14. SocketToll的使用 ： https://jingyan.baidu.com/article/c910274bfe8703cd361d2d9e.html

15. 配置SQLServer，允许远程连接：https://www.cnblogs.com/weizhengLoveMayDay/p/3267756.html

```

<h4 id='VisualSVN serevr与tortoiseSVN client'>1. windows下SVN版本控制VisualSVN serevr与tortoiseSVN client（类似mac上Cornerstone）的使用</h4>

####1. TortoiseSVN 使用： [https://blog.csdn.net/maplejaw_/article/details/52874348](https://blog.csdn.net/maplejaw_/article/details/52874348)

####2. VisualSVN 使用：[https://blog.csdn.net/fy_hanxu/article/details/52757745](https://blog.csdn.net/fy_hanxu/article/details/52757745)
   
```
   · 添加User / Group：1. VisualSVN右键点击Users / Groups 文件夹添加一个User/Group之后，右键仓库Properties添加User或者Group; 2.直接在Properties创建并添加；
   · VisualSVN配置仓库连接URL(形如http://192.168.11.10:8080/svn/testRepo)：右击VisualSVN Server(Local) -> Network 
   · CheckOut: VisualSVN右键点击需要CheckOut的仓库 -> CopyUrlToClipBoard -> 桌面右键SVN CheckOut
   · Commit与Update: 桌面右键 SVN Commit / SVN Update
   
```

### <h4 id='泛型类与泛型参数'>2. c#泛型类与泛型参数</h4>


```
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

```
```
     /// <summary>
    /// 自定义泛型类 以T开头 结尾带上泛型参数<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TGenericOne<T>
    {
        //字段
        public T info;

        //属性
        public T Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }

        /// <summary>
        /// 重写类的构造函数
        /// </summary>
        /// <param name="info"></param>
        public TGenericOne(T info)
        {
            this.info = info;

            Console.WriteLine(this.Info); 
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
```


### <h4 id="泛型类继承自普通类、普通类继承自泛型类、泛型类继承自泛型类的情况">3. c#中泛型类继承自普通类、普通类继承自泛型类、泛型类继承自泛型类的情况</h4>


```
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
```
```
            //泛型类继承自普通类
            TGenericClass<int> ge = new TGenericClass<int>(100);
            ge.Method1(1);
```
```
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
```
```
            //普通类继承自泛型类
            NormalClass2 n2 = new NormalClass2("zhangsan");
            n2.Method("lisi");
```
```
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
```
```
            //泛型类继承自泛型类
            TGenericClass4<string> tg2 = new TGenericClass4<string>("100.1");
            TGenericClass4<int> tg3 = new TGenericClass4<int>(12);
            tg3.Method(100);
```
```
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
```
```
            //泛型类继承自泛型类 多个参数
            TGenericClass5<string> tg5 = new TGenericClass5<string>(5);
            tg5[0] = "arr1";
            tg5[1] = "arr2";
            tg5[2] = "arr3";
            tg5[3] = "arr4";
            tg5[4] = "arr5";

            tg5.output();
```


### <h4 id="为webapi添加接口注释和测试功能">4. 为webapi添加接口注释和测试功能</h4>


```
接口注释参考链接： https://blog.csdn.net/a123_z/article/details/71078062
测试功能：NuGet添加WebApiTestClient，需在 Areas\HelpPage\Views\Help\Api.cshtml文件最后面添加：
	
@Html.DisplayForModel("TestClientDialogs")
@section Scripts {
    <linktype ="text/css" href="~/Areas/HelpPage/HelpPage.css" rel="stylesheet" />
    @Html.DisplayForModel("TestClientReferences")
}
```


### <h4 id="webapi接口返回值： IHttpActionResult HttpResponseMessage 与 自定义类型">5.  webapi接口返回值： IHttpActionResult HttpResponseMessage 与 自定义类型</h4>


```
        /// <summary>
        /// 测试返回类型的接口  返回类型为 ： Json<T>(T content)
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult SayWithIHttpActionResult()
        {
            string haha = "haha";

            return Json<string>(haha);
        }
```

```
        /// <summary>
        /// 返回值为void的接口 
        /// </summary>
        public void sayWithVoid()
        {
            
        }
```

```
        /// <summary>
        /// 返回值传递匿名类型
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult sayWithAnonymousType()
        {
            return Json<dynamic>(new { name="zhangsan", age=100, gender="男"} );
        }
```

```
        /// <summary>
        /// 返回值为Ok() 只告诉客户端返回成功 不返回任何数据
        /// </summary>
        /// <param name="haha"></param>
        /// <returns></returns>
        public IHttpActionResult sayWithOk2Result(string haha)
        {
            //直接返回Ok()表示告诉客户端返回成功 但是不返回任何类型
            return Ok();
        }
```

```
        /// <summary>
        /// 返回值类型传递 Ok<T>(T content)
        /// </summary>
        /// <param name="haha"></param>
        /// <returns></returns>
        public IHttpActionResult sayWithOK1Result(string haha)
        {
            //返回给客户端一个数据
            return Ok<String>(haha);
        }
```

```
        /// <summary>
        /// NotFound会返回一个404给客户端
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult NotFoundTest()
        {
            return NotFound();
        }
```

```
        /// <summary>
        /// 向客户端返回值和http状态码 Content<T>(HttpStatusCode statusCode, T value) 204 NO Content
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult NoThing()
        {
            return Content<string>(HttpStatusCode.NoContent, "没有找到相关内容");
        }
```

```
        /// <summary>
        /// 404
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult ErrorFound()
        {
            return Content<string>(HttpStatusCode.NotFound, "错误");
        }
```

```
        /// <summary>
        /// 400
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult BadRequest()
        {
            return Content<string>(HttpStatusCode.BadRequest, "无效请求：400");
        }
```

```
        /// <summary>
        /// 没有内容时 虽然设置了NoContent 但是啥也不返回
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult NoContent()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("code", 0);
            result.Add("message", "没有相关内容");

            return Content<Dictionary<string, object>>(HttpStatusCode.NoContent, result);
        }
```

```
        /// <summary>
        /// 正常返回内容 字典里面包含数组
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult ReturnContent()
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            res.Add("code", 0);
            res.Add("message", "查询成功");

            List<string> sts = new List<string>();
            for(int i=0; i < 10; i++)
            {
                sts.Add("zhangsan");
            }

            res.Add("data", sts);

            return Content<Dictionary<string, object>>(HttpStatusCode.OK, res);
        }
```

```
        /// <summary>
        /// 没有数据的时候返回编码以及结果提示文字
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult ReturnMessageWhenNoContent()
        {
            Dictionary<string, object> res = new Dictionary<string, object>();

            List<string> data = new List<string>();

            if(data.Count == 0)
            {
                res.Add("code", 1);
                res.Add("message", "没有相关数据");
            }
            else
            {
                res.Add("code", 0);
                res.Add("message", "数据获取成功");
            }

            res.Add("data", data);

            return Content<Dictionary<string, object>>(HttpStatusCode.OK, res);
        }
```

```
        /// <summary>
        /// 自定义的返回类型
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult CustomContent()
        {
            var lstRes = new List<object>();

            //实际项目中，通过后台取到集合赋值给lstRes变量。这里只是测试。
            lstRes.Add("string1");
            lstRes.Add("string2");

            Dictionary<string, object> res = new Dictionary<string, object>();
            res.Add("code", 0);
            res.Add("message", "success");
            res.Add("data", lstRes);

            return new RequestResult(res, Request);
        }
```


### <h4 id="自定义的webApi接口返回值">6. 自定义的webApi接口返回值</h4>


```
    public class RequestResult : IHttpActionResult
    {
        object _value;
        HttpRequestMessage _request;

        public RequestResult(object value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage() {

                Content = new ObjectContent(typeof(object), _value, new JsonMediaTypeFormatter()),
                RequestMessage = _request
            };

            return Task.FromResult(response);
        }
    }
```

```
        /// <summary>
        /// HttpResponseMessaage返回类型
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult ReturnHttpResponseMessage()
        {
            return Content<string>(HttpStatusCode.OK, "HttpResponseMessage 一般用来返回 HttpResponse 对象， 例如到处excel文件流");
        }

```

```
        /// <summary>
        /// 完全自定义的返回类型 这种方式返回的结果和IHttpActionResult一致，直接返回200；
        /// </summary>
        public object customReturnData()
        {
            return new Dictionary<string, object>{ { "code",0 }, { "message", "success" }, { "data", new List<string> { "s1", "s2" } } };
        }

        /// <summary>
        /// 返回模型  会在后台前端显示数据层次
        /// </summary>
        /// <param name="gscode"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpPost]
        public CheckBill GetBills2(string gscode, string year, string month)
        {
            return blo.GetBills(gscode, year, month);
        }
```


### <h4 id="PetaPoco（ORM操作）的简单实用">7. PetaPoco（ORM操作）的简单实用</h4>


```
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
```

```
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
```

```
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
```

```
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
```

```
        /// <summary>
        /// 获取班级以及对应学生的所有数据
        /// </summary>
        /// 
        [HttpPost]
        public IList<Class> GetAllClasses()
        {
            Sql classSql = Sql.Builder.Select("*").From("t_class");

            IList<Class> classes = db.Query<Class>(classSql).ToList();

            Sql studentSql = Sql.Builder.Select("*").From("t_student");

            IList<Student> students = db.Query<Student>(studentSql).ToList();

            foreach(Student stu in students)
            {
                foreach(Class cls in classes)
                {
                    if(cls.ClassName == stu.Class)
                    {
                        cls.students.Add(stu);
                    }
                }
            }

            return classes;
        }
```


### <h4 id="PetaPoco分页获取信息Web.config">8. PetaPoco分页获取信息Web.config</h4>


```
    <add name="cls" providerName="System.Data.SqlClient" connectionString="Server=127.0.0.1;database=cls;uid=sa;pwd=sa" />
```
```
Models:
    public class Students
    {
        public long CurrentPage { get; set; }
        public long TotalPages { get; set; }
        public long TotalItems { get; set; }
        public List<Student> students = new List<Student>();
    }

    [PetaPoco.TableName("t_student")]
    [PetaPoco.PrimaryKey("Id")]
    public class Student
    {
        [PetaPoco.Ignore]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentHeight { get; set; }
        public string StudentWeight { get; set; }
    }
```

```
ApiControllerr:
        private Database db = new Database("cls");

        /// <summary>
        /// 分页获取学生信息
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="numsPerPage"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public Students GetInfoByPage(int currentPage, int numsPerPage)
        {
            Page<Student> result = db.Page<Student>(currentPage, numsPerPage, "select * from t_student order by StudentName asc");

            Students students = new Students();

            foreach(Student stu in result.Items)
            {
                students.students.Add(stu);
            }

            students.CurrentPage = result.CurrentPage;
            students.TotalPages = result.TotalPages;
            students.TotalItems = result.TotalItems;

            return students;
        }
```
```
        /// <summary>
        /// 获取header中的值
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public string GetHeaders1(HttpRequestMessage request, string key)
        {
            IEnumerable<string> keys = null;
            if (!request.Headers.TryGetValues(key, out keys))
                return null;

            return keys.First();
        }
```
```
        /// <summary>
        /// 获取请求方式
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// 
        //[HttpPost]
        public string GetMethod11()
        {
            return Request.Method.ToString();
        }
```


### <h4 id="多层数组结构的处理">9. 多层数组结构的处理</h4>


```
       public Biology  GetBiology(string BiologyName)
        {
            if(BiologyName == null || BiologyName == "" || BiologyName == "{BiologyName}")
            {
                return null;
            }

            //获取该种生物的信息
            Biology biology = db.SingleOrDefault<Biology>(Sql.Builder.Select("*").From("t_biology").Where("BiologyName=@0", BiologyName));

            //获取所有的动物或植物
            List<Animal> animals = db.Fetch<Animal>(Sql.Builder.Select("*").From("t_animal"));


            foreach (Animal animal in animals)
            {
                //获取所有的生物信息
                List<AnimalInfo> animalInfos = db.Fetch<AnimalInfo>(Sql.Builder.Select("*").From("t_animalInfo").Where("Animal=@0", animal.AnimalName));

                animal.AnimalInfos = animalInfos;

                //先根据animal的名称 将不同的animal信息放入animalInfo's中
                //foreach (AnimalInfo animalInfo in animalInfos)
                //{

                //    if (animalInfo.Animal == animal.AnimalName)
                //    {
                //        //将同样类型的添加进去
                //        animal.AnimalInfos.Add(animalInfo);
                //    }
                //}

                if (animal.Biology == biology.BiologyName)
                {
                    biology.Animals.Add(animal);
                }
            }
```


### <h4 id="多层结构的api">10. 多层结构的api  详见OrderDetail</h4>


```
        private Database db = new Database("OrderDetail");

        [HttpPost]
        public OrderDetails GetOrderDetail()
        {
            OrderDetails orderDetail = new OrderDetails();

            //主订单信息
            OrderMaster ordermaster = db.SingleOrDefault<OrderMaster>(Sql.Builder.Append("select * from t_OrderMaster"));
            orderDetail.data.orderMaster = ordermaster;

            //订单产品列表
            List<OrderDetailInfo> orderDetailList = db.Fetch<OrderDetailInfo>(Sql.Builder.Append("select * from t_OrderDetailInfo"));
            orderDetail.data.orderDetailList = orderDetailList;

            //宣传册 促销品
            List<OrderBonus> orderBonusList = db.Fetch<OrderBonus>(Sql.Builder.Append("select * from t_OrderBonus"));
            orderDetail.data.orderBonusList = orderBonusList;

            //订单付款记录
            List<OrderPayment> orderPaymentList = db.Fetch<OrderPayment>(Sql.Builder.Append("select * from t_OrderPayment"));
            orderDetail.data.orderPaymentList = orderPaymentList;

            //订单退款记录
            List<RefundPayment> refundPaymentList = db.Fetch<RefundPayment>(Sql.Builder.Append("select * from t_RefundPayment"));
            orderDetail.data.refundPaymentList = refundPaymentList;

            //开票信息
            Ticket ticket = db.SingleOrDefault<Ticket>(Sql.Builder.Append("select * from t_Ticket"));
            orderDetail.data.ticket = ticket;

            //子订单列表
            List<ChildOrder> childOrderList = db.Fetch<ChildOrder>(Sql.Builder.Append("select * from t_ChildOrder"));

            foreach(ChildOrder childOrder in childOrderList)
            {
                //子订单产品列表
                List<ChildOrderDetail> childOrderDetailList = db.Fetch<ChildOrderDetail>(Sql.Builder.Append("select * from t_ChildOrderDetail"));
                childOrder.childOrderDetailList = childOrderDetailList;

                //物流信息
                List<Logistic> logisticList = db.Fetch<Logistic>(Sql.Builder.Append("select * from t_Logistic"));
                childOrder.logisticList = logisticList;
            }

            orderDetail.data.childOrderList = childOrderList;

            //返回状态码
            orderDetail.code = ResultCodeMsg.Success;

            //返回说明
            orderDetail.message = "success";

            return orderDetail;
        }
```


### <h4 id="Newtonsoft ： json与对象的相互转换">11. Newtonsoft ： json与对象的相互转换</h4>


```
//JsonConvert需导入
using Newtonsoft.Json;

//stringReader
using System.IO;

//JObject JArray需导入
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
```
```
        #region
        /// <summary>
        /// 序列化:对象转字符串
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public string stringWithPerson()
        {
            Person p = new Person();

            p.Name = "zhangsan";
            p.Weight = "100";
            p.Height = "100";

            //序列化
            return JsonConvert.SerializeObject(p);
        }
        #endregion
```

```        #region
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object personWithJsonString()
        {
            string jsonString = "{\"Name\": \"zhangsan\", \"Weight\": \"100\", \"Heigth\": \"100\"}";

            object obj = JsonConvert.DeserializeObject(jsonString);

            return obj;
        }
        #endregion
```
```
        /// <summary>
        /// Newtonsoft 创建json对象
        /// </summary>
        /// <returns></returns>
        public object jsonObjectWithNewtonsoft()
        {
            //创建json对象
            JObject jobj = new JObject();
            jobj.Add(new JProperty("Name", "Jack"));
            jobj.Add(new JProperty("Weight", "100"));
            jobj.Add(new JProperty("Leader", new JObject(new JProperty("Name", "lisi"), new JProperty("Height", "110"))));

            return jobj;
        }
```
```
        /// <summary>
        /// Newtonsoft创建json数组
        /// </summary>
        /// <returns></returns>
        public object jsonArrayWithNewtonsoft()
        {
            //创建json数组
            JArray jarr = new JArray();
            jarr.Add(new JValue(1));
            jarr.Add(new JValue(2));
            jarr.Add(new JValue(3));

            return jarr;
        }
```

```
        /// <summary>
        /// Newtonsoft获取Value
        /// </summary>
        /// <returns></returns>
        public string jsonValueWithNewtonsoft()
        {
            string jsonStr = "{\"Name\" : \"zhangsan\", \"Weight\" : \"120\"}";

            //json字符串转换为json对象
            JObject obj = JObject.Parse(jsonStr);

            return obj["Name"].ToString();
        }
```
```
        /// <summary>
        /// Newtonsoft修改value
        /// </summary>
        /// <returns></returns>
        public JObject ModifyJsonValueWithNewtonsoft(string weight)
        {
            string jsonStr = "{\"Name\":\"zhangsan\", \"Weight\":\"111\"}";

            JObject jobj = JObject.Parse(jsonStr);

            //修改
            jobj["Weight"] = weight;

            return jobj;
            //return Content<Dictionary<string, string>>(HttpStatusCode.OK, new Dictionary<string, string> { { "message", "success" } });
        }
```
```
        /// <summary>
        /// Newtonsoft 修改复杂json value
        /// </summary>
        /// <returns></returns>
        public JObject ModifyMultiJsonValue(string Age)
        {
            string jsonStr = "{\"Name\" : \"wangwu\", \"Friends\" : [{\"Name\":\"zhangsan\", \"Age\":\"20\"},{\"Name\":\"lisi\",\"Age\":\"30\"}]}";

            JObject jobj = JObject.Parse(jsonStr);

            jobj["Friends"][0]["Age"] = Age;

            return jobj;
        }
```
```

        /// <summary>
        /// Newtonsoft删除json value
        /// </summary>
        public JObject RomoveJsonValuesWithNewtonsoft()
        {
            string jsonStr = "{\"Name\" : \"wangwu\", \"Friends\" : [{\"Name\":\"zhangsan\", \"Age\":\"20\"},{\"Name\":\"lisi\",\"Age\":\"30\"}]}";

            JObject jobj = JObject.Parse(jsonStr);

            jobj["Friends"][0].Remove();

            return jobj;
        }
```
```
        /// <summary>
        /// Newtonsoft清空某一项的values
        /// </summary>
        /// <returns></returns>
        public object RomoveAllJsonValuesWithNewtonsoft()
        {
            string jsonStr = "{\"Name\" : \"wangwu\", \"Friends\" : [{\"Name\":\"zhangsan\", \"Age\":\"20\"},{\"Name\":\"lisi\",\"Age\":\"30\"}]}";

            JObject jobj = JObject.Parse(jsonStr);

            jobj.Remove("Friends");

            return jobj;
        }
```
```
        /// <summary>
        /// Newtonsoft 清空
        /// </summary>
        /// <returns></returns>
        public object RemoveAllKeysAndValuesWithNewtonsoft()
        {
            string jsonStr = "{\"Name\" : \"wangwu\", \"Friends\" : [{\"Name\":\"zhangsan\", \"Age\":\"20\"},{\"Name\":\"lisi\",\"Age\":\"30\"}]}";

            JObject jobj = JObject.Parse(jsonStr);

            jobj.RemoveAll();

            return jobj;
        }
```
```
        /// <summary>
        /// Newtonsoft在指定键值对后面加上新的键值对
        /// </summary>
        /// <returns></returns>
        public JObject AddWeightAfterNameWithNewtonsoft(string weight)
        {
            string jsonStr = "{\"Name\" : \"wangwu\", \"Friends\" : [{\"Name\":\"zhangsan\", \"Age\":\"20\"},{\"Name\":\"lisi\",\"Age\":\"30\"}]}";

            JObject jobj = JObject.Parse(jsonStr);

            //在之后添加：AddAfterSelf 在之前添加：AddBeforeSelf 在最前面添加：AddFirst
            //jobj["Name"].Parent.AddAfterSelf(new JProperty("Weight", weight));
            jobj["Name"].Parent.AddBeforeSelf(new JProperty("Weight", weight));

            return jobj;
        }
```
```
        /// <summary>
        /// Newtonsoft json数组中添加新数组
        /// </summary>
        /// <returns></returns>
        public JObject AddFriendsWithNewtonsoft()
        {
            string jsonStr = "{\"Name\" : \"wangwu\", \"Friends\" : [{\"Name\":\"zhangsan\", \"Age\":\"20\"},{\"Name\":\"lisi\",\"Age\":\"30\"}]}";

            JObject obj = new JObject(new JProperty("Name","liqi"), new JProperty("Age", "40"));

            JObject jobj = JObject.Parse(jsonStr);

            jobj["Friends"].Last.AddAfterSelf(obj);

            return jobj;
        }
```
```
        /// <summary>
        /// Newtonsoft 简化查询
        /// </summary>
        /// <returns></returns>
        public string EasySearchWithNewtonsoft()
        {
            string jsonStr = "{\"Name\" : \"wangwu\", \"Friends\" : [{\"Name\":\"zhangsan\", \"Age\":\"20\"},{\"Name\":\"lisi\",\"Age\":\"30\"}]}";

            JObject jobj = JObject.Parse(jsonStr);

            JToken jtoken = jobj.SelectToken("Name");

            return jtoken.ToString();
        }
```
```
        /// <summary>
        /// Newtonsoft 简化查询所有好友的名字
        /// </summary>
        public List<string> EasySearchAllNamesWithNewtonsoft()
        {
            string jsonStr = "{\"Name\" : \"wangwu\", \"Friends\" : [{\"Name\":\"zhangsan\", \"Age\":\"20\"},{\"Name\":\"lisi\",\"Age\":\"30\"}]}";

            JObject jobj = JObject.Parse(jsonStr);

            var result = jobj.SelectToken("Friends").Select(f => f["Name"]).ToList();

            List<string> Names = new List<string>();

            foreach(string name in result)
            {
                Names.Add(name);
            }

            return Names;
        }
```
```
        /// <summary>
        /// Newtonsoft 简化查询最后一个好友的名字
        /// </summary>
        /// <returns></returns>
        public string EasySearchLastNameWithNewtonsoft()
        {
            string jsonStr = "{\"Name\" : \"wangwu\", \"Friends\" : [{\"Name\":\"zhangsan\", \"Age\":\"20\"},{\"Name\":\"lisi\",\"Age\":\"30\"}]}";

            JObject jobj = JObject.Parse(jsonStr);

            string Name = jobj.SelectToken("Friends[1].Name").ToString() ;

            return Name;
        }
```
```
      /// <summary>
        /// Newtonsoft删除 键值对为a=aa的项
        /// </summary>
        /// <returns></returns>
        public JArray RemoveSameValueWithNewtonsoft()
        {
            string jsonStr = "[{'a':'aaa','b':'bbb','c':'ccc'},{'a':'aa','b':'bb','c':'cc'}]";

            JArray jarr = JArray.Parse(jsonStr);

            //所有key=value为a=aa的项存储数组
            List<JToken> projects = new List<JToken>();

            foreach(var obj in jarr)
            {
                if(obj["a"].ToString() == "aa")
                {
                    projects.Add(obj);
                }
            }

            //遍历projects 同时在jrr中删除
            foreach(JObject jobj in projects)
            {
                jarr.Remove(jobj);
            }

            return jarr;
        }
```
```
        /// <summary>
        /// Newtonsoft 复杂json获取数据
        /// </summary>
        /// <returns></returns>
        public IList<string> GetAllLanguages()
        {
            string jsonStr = @"
                [{'Languages':['C#','Java'],'Name':'李志伟','Sex':true},
                {'Languages':['C#','C++'],'Name':'Coder2','Sex':false},
                {'Languages':['C#','C++','C','Java'],'Name':'Coder3','Sex':true}]";

            JArray jarr = JArray.Parse(jsonStr);

            //所有语言的数组
            List<string> Languages = new List<string>();

            foreach (JObject jobj in jarr)
            {
                JArray arr = JArray.Parse(jobj["Languages"].ToString());

                foreach(string lng in arr)
                {
                    Languages.Add(lng);
                }
            }

            //去重
            List<string> newLangs = new List<string>();
            foreach(string lans in Languages)
            {
                if (!newLangs.Contains(lans))
                {
                    newLangs.Add(lans);
                }
            }

            return newLangs;
        }


     /// <summary>
        /// 复杂json转换实例
        /// </summary>
        /// <returns></returns>
        public Languages duplicateJsonToObject()
        {
            string jsonStr = @"
                [{'Languages':['C#','Java'],'Name':'李志伟','Sex':true},
                {'Languages':['C#','C++'],'Name':'Coder2','Sex':false},
                {'Languages':['C#','C++','C','Java'],'Name':'Coder3','Sex':true}]";

            Languages lans = new Languages();

            JArray jarr = JArray.Parse(jsonStr);

            foreach (JObject langDetail in jarr)
            {
                Language lan = new Language();
                lan.Name = langDetail["Name"].ToString();
                lan.Sex = langDetail["Sex"].ToString();

                foreach(string langName in langDetail["Languages"])
                {
                    lan.languageKinds.Add(langName);
                }

                lans.myLanguages.Add(lan);
            }


            return lans;
        }
```
```
        /// <summary>
        /// Newtonsoft 处理时间字符串
        /// </summary>
        /// <returns></returns>
        public string stringWithTimeNow()
        {
            DateTime time = DateTime.Now;

            IsoDateTimeConverter dateTimeConvter = new IsoDateTimeConverter();
            dateTimeConvter.DateTimeFormat = "北京时间: yyyy-MM-dd HH:mm:ss";

            //序列化时间
            string now = JsonConvert.SerializeObject(time, dateTimeConvter);

            return now;
        }

     /// <summary>
        /// 时间反序列化
        /// </summary>
        /// <returns></returns>
        public DateTime Now()
        {
            DateTime dateTime = DateTime.Now;

            //时间转换为字符串
            IsoDateTimeConverter dateTimeConverter = new IsoDateTimeConverter();
            dateTimeConverter.DateTimeFormat = "北京时间: yyyy-MM-dd HH:mm:ss";

            string now = JsonConvert.SerializeObject(dateTime, dateTimeConverter);

            //字符串转换回时间
            DateTime nnow = JsonConvert.DeserializeObject<DateTime>(now, dateTimeConverter);

            return nnow;
        }
```


<h4 id="插入或者更新一条信息">12. 插入或者更新一条信息： 表中存在该信息 则更新（先删除原来存在的  再插入新的数据） 表中不存在该数据 则添加</h4>


```
        private Database db = new Database("Names");

        /// <summary>
        /// 插入或者更新表
        /// Name存在则更新Age的信息 Name不存在则添加一条person的信息
        /// </summary>
        /// <returns></returns>
        public List<Person> InsertOrUpdateTable(Person person)
        {
            //如果存在该名字的person信息 则删除然后重新添加新的Age信息
            //如果不存在 则直接添加一条新的信息
            /*
            if exists(select * from t_Names where Name='sss')
             begin 
             delete from t_Names where Name='sss'
             end 
             insert into t_Names (Name, Age) values('sss','111')
            */
            string sql = @"if exists(select * from t_Names where Name="
                        + "'" 
                        + person.Name
                        + "'" 
                        + ") begin delete from t_Names where Name=" 
                        + "'"
                        + person.Name + 
                        "'" 
                        + " end insert into t_Names (Name, Age) values(" 
                        + "'" 
                        + person.Name + "'," + "'" + person.Age + "'" + ")";

             int res = db.Execute(Sql.Builder.Append(sql));

            List<Person> names = db.Fetch<Person>(Sql.Builder.Append("select * from t_Names"));

            return names;
        }
```


<h4 id="常用复杂Sql语句">13. 常用复杂Sql语句</h4>


```
-- 数据存在则根据名称更新年龄  不存在则增加一条信息
if exists(select * from t_Names where Name='sss')
 begin 
 delete from t_Names where Name='sss'
 end 
 insert into t_Names (Name, Age) values('sss','111')
```
```
 -- case...end （范围） 显示级别 
 select * ,
	case 
		when Age <= 10 then '等级1'
		when Age <= 50 then '等级2'
		when Age <= 100 then '等级3'
		when Age <= 1000  then '等级4'
		when Age <= 10000 then '等级5'
		when Age > 10000 then '等级6'
	end 
from t_Names
```
```
--子查询 : 将一个查询语句做为一个结果集供其他SQL语句使用，就像使用普通的表一样，
--被当作结果集的查询语句被称为子查询。所有可以使用表的地方几乎都可以使用子查询来代替。

-- 标记最大年龄、最小年龄、平均年龄、总年龄、行数
select (select max(Age) from t_Names) as '最大年龄',
		(select min(Age) from t_Names) as '最小年龄',
		(select avg(Age) from t_Names) as '平均年龄',
		(select sum(Age) from t_Names) as '总年龄',
		(select count(Age) from t_Names) as '总行数'

-- 找出所有年龄大于10的 并且名字首字母大于l的所有人员 按照升序显示
select * from (select * from t_Names where Age > 10 ) as person
		 where person.Name > 'l' order by Name Asc
```
```
--全局变量:
--最后一个T-SQL错误的错误号
select @@ERROR

--获取创建的同时连接的最大数目
select @@MAX_CONNECTIONS

--返回最近一次插入的编号
select @@IDENTITY
```


<h4 id="Nlog日志记录">14. Nlog日志记录</h4>


##### 在项目NuGet程序包中搜索NLog并安装
#### App.config/Web.config配置
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  
  <!--
  在<nlog />节点中，有五个子节点可让我们配置，前两个节点是配置必须的，而后面的几个是可选，
  可用于更高级的场景:
  
  <targets /> –定义日志记录输出的目标位置，可以配置为输出到控制台，文件，数据库，事件日志等等
  <rules /> –定义日志输出路径规则
  <extensions /> –定义从某个*.dll获取Nlog扩展
  <include />– 包含外部的配置文件
  <variable /> – 设置配置变量的值
  -->
  <!--
  1.autoReload="true"表示在不重新启动应用程序的情况下，修改配置文件，NLog会自动加载应用
  
  2.internalLogLevel="Trace"internalLogFile="logs/internalLog.txt"这个设置可以将NLog内部的
  日志消息写到应用程序目录下的logs文件夹里的internalLog.txt文件中；（这个配置常用于调试Nlog
  的配置是否正确，调试完成后，最好关闭以提高性能）
  
  3. <target>的配置：type="File|Console" 属性是设置日志输出目标是"File"(文件)或者"Console"（控制台）；
  type="File"的时候要指定fileName属性， fileName="${basedir}/logs/${shortdate}.log" 设置日记
  记录文件的路径和名称，即应用程序下的log目录里格式为yyyy-MM-DD.log；
  layout="${date:format=yyyyMMddHHmmss} ${callsite} ${level} ${message}" 
  设置日志输出格式(可查阅官网说明).
  
  4.name="NLogConsoleExample"表示配置的规则适用于Logger名称为“NLogConsoleExample”，
  如果填*，则表示所有的Logger都运用这个规则。
  
  5.minlevel="Debug"maxlevel="Error"用来配置记录的级别为最小是"Debug"最大为"Error"
  (备注：此处也可以用levels="Debug,Error"来设置，说明只输出Debug级别以及Error级别的日志
  
  6. writeTo="t1,t2"其中t1,t2分别代表上面设置的targets名称为t1以及t2的目标输出，
  此处表示将分别将日志信息输出到文件和控制台。
  -->
  
  <configSections>
    <section name="nlog" type="NLog.Config.ConfigSectionHandler, NLog"/>
  </configSections>
  
  <nlog autoReload="true" internalLogLevel="Trace" internalLogFile="logs/internalLog.txt">
    <targets>
      <target name="t1" type="File" fileName="${basedir}/logs/${shortdate}.log"
      layout="${longdate} ${callsite} ${level}:
      ${message} ${event-context:item=exception} ${stacktrace} ${event-context:item=stacktrace}"/>
      <target name="t2" type="Console" layout="${date:format=yyyyMMddHHmmss} ${callsite} ${level} ${message}"/>
    </targets>
    <rules>
      <logger name="NLogConsoleExample" minlevel="Trace" maxlevel="Fatal" writeTo="t1,t2" />
    </rules>
  </nlog>
  
  
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
    </startup>
</configuration>
```
```
使用：
        private static readonly Logger logger = LogManager.GetLogger("NLogConsoleExample");
        static void Main(string[] args)
        {
            logger.Trace("trace");
            logger.Debug("debug");
            logger.Info("info");
            logger.Error("error");
            logger.Fatal("fatal");

            Console.Read();
        }
```

### <h4 id="log4net日志记录">15. log4net日志记录的使用</h4>
```
App.config 配置

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  
  <!--log4net的使用-->
  <configSections>
    <section name="log4net" type="System.Configuration.IgnoreSectionHandler"/>
  </configSections>

  <appSettings>
  </appSettings>

  <log4net>
    
    <!--定义输出到文件中-->
    <appender name="LogFileAppender" type="log4net.Appender.FileAppender">
      <!--定义文件存放位置-->
      <file value="E:\Log4NetDemo\Log4NetDemo\log.txt" />
      <appendToFile value="true" />
      <rollingStyle value="Date" />
      <datePattern value="yyyyMMdd-HH:mm:ss" />
      <layout type="log4net.Layout.PatternLayout">
        <!--每条日志末尾的文字说明-->
        <footer value="by czy" />
        <!--输出格式-->
        <!--样例：2008-03-26 13:42:32,111 [10] INFO  Log4NetDemo.MainClass [(null)] - info-->
        <conversionPattern value="记录时间：%date 线程ID:[%thread] 日志级别：%-5level 出错类：%logger property:[%property{NDC}] - 错误描述：%message%newline" />
      </layout>
    </appender>
    
    <!--定义输出到控制台命令行中-->
    <appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] - %message%newline" />
      </layout>
    </appender>
    
    <!--定义输出到windows事件中-->
    <appender name="EventLogAppender" type="log4net.Appender.EventLogAppender">
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] - %message%newline" />
      </layout>
    </appender>
    
    <!--定义输出到数据库中，这里举例输出到Access数据库中，数据库为C盘的log4net.mdb-->
    <appender name="AdoNetAppender_Access" type="log4net.Appender.AdoNetAppender">
      <connectionString value="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:log4net.mdb" />
      <commandText value="INSERT INTO LogDetails ([LogDate],[Thread],[Level],[Logger],[Message]) VALUES (@logDate, @thread, @logLevel, @logger,@message)" />
      <!--定义各个参数-->
      <parameter>
        <parameterName value="@logDate" />
        <dbType value="String" />
        <size value="240" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%date" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@thread" />
        <dbType value="String" />
        <size value="240" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%thread" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@logLevel" />
        <dbType value="String" />
        <size value="240" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%level" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@logger" />
        <dbType value="String" />
        <size value="240" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%logger" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@message" />
        <dbType value="String" />
        <size value="240" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%message" />
        </layout>
      </parameter>
    </appender>
    
    <!--定义日志的输出媒介，下面定义日志以四种方式输出。也可以下面的按照一种类型或其他类型输出。-->
    <root>
      <!--文件形式记录日志-->
      <appender-ref ref="LogFileAppender" />
      <!--控制台控制显示日志-->
      <appender-ref ref="ConsoleAppender" />
      <!--Windows事件日志-->
      <appender-ref ref="EventLogAppender" />
      <!-- 如果不启用相应的日志记录，可以通过这种方式注释掉
      <appender-ref ref="AdoNetAppender_Access" />
      -->
    </root>

  </log4net>
  
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
    </startup>
</configuration>
```
```
log4net的使用：

using log4net;
using System.Reflection;

//注意下面的语句一定要加上，指定log4net使用.config文件来读取配置信息
//如果是WinForm（假定程序为MyDemo.exe，则需要一个MyDemo.exe.config文件）
//如果是WebForm，则从web.config中读取相关信息
//表示直接从 app.config中读取配置即可
//如果你只是一个简单的项目，那么在这个项目的 AssemblyInfo.cs文件上加上
//[assembly: log4net.Config.XmlConfigurator(Watch=true)]即可。
//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Log4NetDemo
{
    /// 说明：本程序演示如何利用log4net记录程序日志信息。log4net是一个功能著名的开源日志记录组件。
    /// 利用log4net可以方便地将日志信息记录到文件、控制台、Windows事件日志和数据库中
    /// （包括MS SQL Server, Access, Oracle9i,Oracle8i,DB2,SQLite）。
    /// 下面的例子展示了如何利用log4net记录日志
    class Program
    {
        static void Main(string[] args)
        {
            //Log4net框架定义了一个叫做LogManager的类，用来管理所有的logger对象。它有一个GetLogger()静态方法，用我们提供的名字参数来检索已经存在的Logger对象。如果框架里不存在该Logger对象，它也会为我们创建一个Logger对象。代码如下所示：
            //log4net.ILog log = log4net.LogManager.GetLogger("logger-name");
            //通常来说，我们会以类（class）的类型（type）为参数来调用GetLogger()
           ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            log.Debug("调试");

            log.Info("信息");

            log.Warn("警告");

            log.Error("错误");

            log.Fatal("致命错误");

            Console.WriteLine("命令执行完毕");
            Console.Read();
        }
    }
}

```

### <h4 id="SuperSocket使用">16.  SuperSocket使用：文档：[http://docs.supersocket.net/v1-6/zh-CN](http://docs.supersocket.net/v1-6/zh-CN)</h4>
```
    /*
        注意事项：
        
        a) MyServer、自定义命令和MySession的访问权限必须设置为public

        b) MyServer父类为AppServer<MySession>

        c) MySession父类为AppSession<MySession>

        d) HELLO父类为CommandBase<MySession,StringRequestInfo>，
        ExecueteCommand方法传入值类型分别为MySession和StringRequestInfo

        e) 多服务器中需注意AppSession、AppServer、自定义命令中的AppSession不要搞错

        AppSession 代表一个和客户端的逻辑连接，基于连接的操作应该定于在该类之中。
        你可以用该类的实例发送数据到客户端，接收客户端发送的数据或者关闭连接。

        AppServer 代表了监听客户端连接，承载TCP连接的服务器实例。
        理想情况下，我们可以通过AppServer实例获取任何你想要的客户端连接，
        服务器级别的操作和逻辑应该定义在此类之中。

        命令行协议是一种被广泛应用的协议。一些成熟的协议如 Telnet, SMTP, POP3 和 FTP 都是基于命令行协议的。
        在SuperSocket 中， 如果你没有定义自己的协议，SuperSocket 将会使用命令行协议, 这会使这样的协议的开发变得很简单。
        命令行协议定义了每个请求必须以回车换行结尾 "\r\n"。

        如果你在 SuperSocket 中使用命令行协议，所有接收到的数据将会翻译成 StringRequestInfo 实例.

        SuperSocket 中内置的命令行协议用空格来分割请求的Key和参:
        因此当客户端发送如下数据到服务器端时: "LOGIN kerry 123456" + NewLine
        SuperSocket 服务器将会收到一个 StringRequestInfo 实例，这个实例的属性为:

        Key: "LOGIN"
        Body: "kerry 123456";
        Parameters: ["kerry", "123456"]

        如果你定义了名为 "LOGIN" 的命令, 这个命令的 ExecuteCommand 方法将会被执行，
        服务器所接收到的StringRequestInfo实例也将作为参数传给这个方法:

        public class LOGIN : CommandBase<AppSession, StringRequestInfo>
        {
            public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
            {
                //Implement your business logic
            }
        }
        */

```
```
       //Commad处理自定义指令过程
        //发起命令 > SuperSocket处理解析 > 触发Session内部事件 > 触发ExecuteCommand事件 
        //> 自定义命令解析处理 > 触发Send事件返回服务器处理数据
         // 注意设置为public权限
    public class ADD : CommandBase<TestSession, StringRequestInfo>
    {
        public override void ExecuteCommand(TestSession session, StringRequestInfo requestInfo)
        {
            session.Send(requestInfo.Parameters.Select(p => Convert.ToDouble(p)).Sum().ToString());
        }
    }
```

### <h4 id="c# 泛型默认值、继承、基类约束、接口约束、引用类型与值类型">17. c# 泛型默认值、继承、基类约束、接口约束、引用类型与值类型</h4>
```
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
```
```
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
```
```
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
```
```
基类约束调用：
            //基类约束
            A1 a1 = new A1();
            A2 a2 = new A2();
            A3<A1, A2> a3 = new A3<A1, A2>(a1, a2);
```
```
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
```
```
接口约束调用：
            //接口约束
            UU u = new UU();
            VV v = new VV();
            BB<UU, VV> bb = new BB<UU, VV>(u, v);
```
```
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
```
```
构造器约束调用：
            //构造器约束 两种情况都是走不带参数的构造器

            Console.WriteLine("===构造器约束不带参数的情况====");
            C3<C1> c311 = new C3<C1>();
            C3<C2> c321 = new C3<C2>();

            Console.WriteLine("====构造器约束带参数的情况====");
            C3<C1> c31 = new C3<C1>("c1");
            C3<C2> c32 = new C3<C2>("c2");
```
```
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
```
```
调用：
            //泛型约束的值约束与引用约束
            D3<int> d1 = new D3<int>();

            //报错：u不是值类型
            //D3<u> d2 = new D3<u>();

            D4<C2> d4 = new D4<C2>();
```
### <h4 id="C#常用格式输出">C#常用格式输出</h4>
```
static void Main()
        {
            Console.WriteLine("-------部分数值格式输出方式的示例--------");
            Console.WriteLine("在宽度空间里靠左对齐：{0,-10}",99);
            Console.WriteLine("在宽度空间里靠右对齐：{0,10}", 99);
            Console.WriteLine("在宽度空间里靠左对齐：{0,-10}", "LLL");
            Console.WriteLine("在宽度空间里靠右对齐：{0,10}", "RRR");
            Console.WriteLine("货币-{0:C}{1:C4}",88.8,-888.8);
            Console.WriteLine("10进制整数-{0:D5}",88);
            Console.WriteLine("科学计数-{0:E}",888.8);
            Console.WriteLine("固定小数点-{0:F3}",888.8888);
            Console.WriteLine("浮点数-{0:G}",888.8888);
            Console.WriteLine("数字格式-{0:N}",8888888.8);
            Console.WriteLine("16进制格式-{0:X4}",88);

            Console.WriteLine("--------常用日期格式----------");
            DateTime datetime = DateTime.Now;
            Console.WriteLine(datetime);
            Console.WriteLine(datetime.ToString("yyyy-MM-dd hh:mm:ss"));
            Console.WriteLine(datetime.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine(datetime.ToString("yyyy-MM-dd"));
            Console.WriteLine(datetime.ToString("yyyy-MM"));
            Console.WriteLine(datetime.ToString("yyyy"));
            Console.WriteLine(datetime.ToString("yyyy/MM/dd"));
            Console.WriteLine(datetime.ToString("yyyy年MM月dd日"));
            Console.WriteLine(datetime.ToString("yyyy年MM月"));
            Console.WriteLine(datetime.ToString("yyyy年"));
        }
    }
```
```
输出结果：
-------部分数值格式输出方式的示例--------
在宽度空间里靠左对齐：99
在宽度空间里靠右对齐：        99
在宽度空间里靠左对齐：LLL
在宽度空间里靠右对齐：       RRR
货币 -￥88.80￥-888.8000
10进制整数 - 00088
科学计数 - 8.888000E+002
固定小数点 - 888.889
浮点数 - 888.8888
数字格式 - 8,888,888.80
16进制格式 - 0058
--------常用日期格式----------
2018 / 8 / 15 10:55:38
2018 - 08 - 15 10:55:38
2018 - 08 - 15 10:55:38
2018 - 08 - 15
2018 - 08
2018
2018 / 08 / 15
2018年08月15日
2018年08月
2018年
```

### <h4 id="Lambda表达式的使用">19. Lambda表达式的使用</h4>
```
        //定义三个委托 分别为不带参数 带1个参数 带2个参数
        private delegate string DelLambdaOne();
        private delegate void DeleLambdaTwo(string s);
        private delegate int DelLambdaThree(int i, int j);
```
```
 	//不带参数的Lambda表达式
            DelLambdaOne one = () =>
            {
                return "one";
            };

            Console.WriteLine(one());
```
```
            //带一个参数的Lambda表达式
            DeleLambdaTwo two = p =>
            {
                Console.WriteLine(p);
            };

            two("带一个参数的Lambda表达式");
```
```
            //带两个参数的Lambda表达式
            DelLambdaThree three = (p1, p2) =>
            {
                return p1 + p2;
            };

            Console.WriteLine(three(10,20));
```
```
            //Func与Lambda表达式

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

           LambdaFunc();
```
```

            //where筛选
            Console.WriteLine("===所有大于3的数字集合===");

            //获取大于3的所有数字
            List<int> List1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> NewList1 = List1.Where(p => p > 3).ToList<int>() ;

            foreach(int i in NewList1)
            {
                Console.WriteLine(i);
            }
```
```
            //select查找
            Console.WriteLine("===名字的长度集合===");

            //获取名字的长度集合
            List<string> User = new List<string> { "zhangsan", "lisi", "wangwu", "zhaoliu" };
            List<int> NewUser = User.Select(user => user.Length).ToList<int>();

            foreach(int nameLen in NewUser)
            {
                Console.WriteLine(nameLen);
            }
```
```
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
```
### <h4 id="EF">20.  EF的简单使用</h4>
#### <a href="https://blog.csdn.net/u010028869/article/details/47108205">DatabaseFirst: https://blog.csdn.net/u010028869/article/details/47108205</a>
#### <a href="https://blog.csdn.net/u010028869/article/details/47134343">ModelFirst: https://blog.csdn.net/u010028869/article/details/47134343</a>

```
        数据库优先：
        
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
```
```

        模型优先：


            //注意：当我们的实体需要改变时，只需要在模型设计视图修改保存模型，
            //此时实体类就会相应改变，
            //然后选择“从模型生成到数据库”重新执行生成的脚本即可将变化同步到数据库。

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
```
### <h4 id="HttpClient与HttpWebRequest">21. HttpClient与HttpWebRequest</h4>
```
        /// <summary>
        /// 带参数的HttpClient get请求
        /// </summary>
        /// <param name="param"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpPost]
        public object SendRequestWithHttpClientSignalParam2(Dictionary<string, string> param, string url)
        {
            HttpClient httpClient = new HttpClient();

            var urlString = url + "?" + Tool.BuildParam(param, Encoding.UTF8);

            var responseJson = httpClient.GetAsync(urlString).Result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject(responseJson);
        }
```
```
      /// <summary>
        /// 数组包含字典情况：将参数按照1=1&2=2&3=3的方式拼接起来
        /// </summary>
        /// <param name="paramArray"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string BuildParam(List<KeyValuePair<string, string>> paramArray, Encoding encoding)
        {
            string url = "";

            //不过没有编码则用UTF8编码
            if(encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            if(paramArray == null || paramArray.Count == 0)
            {
                return "";
            }
            else
            {
                string paramStr = "";

                foreach(var item in paramArray)
                {
                    paramStr += String.Format("{0}={1}&", Encode(item.Key, encoding), Encode(item.Value, encoding));
                }

                if (paramStr != "")
                {
                    paramStr = paramStr.TrimEnd('&');
                }

                url += paramStr;
            }

            return url;
        }

        /// <summary>
        /// 字典 将键值对以&符号拼接起来
        /// </summary>
        /// <param name="param"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string BuildParam(Dictionary<string, string> param, Encoding encoding)
        {
            if(encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            string paramStr = "";

            foreach(KeyValuePair<string, string> kv in param)
            {
                paramStr = String.Format("{0}={1}&", Encode(kv.Key, encoding), Encode(kv.Value, encoding));
            }

            paramStr = paramStr.TrimEnd('&');

            return paramStr;
        }
```
```
     /// <summary>
        /// 将字符串转成UTF8编码
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static string Encode(string content, Encoding encoding)
        {
            if(encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            return System.Web.HttpUtility.UrlEncode(content, encoding);
        }
```
```
        /// <summary>
        /// 封装的HttpClient Post请求 发送一个键值对
        /// </summary>
        /// <param name="url"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object SendRe2(string url, Dictionary<string, string> para)
        {
            return HttpBase.NetWorkManager.PostParam<object>(url, para);
        }
```
```
       /// <summary>
        /// HttpClient 封装的Post请求 带对象参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T PostParam<T>(string url, Dictionary<string, string> param) where T:class, new()
        {
            //https
            if (url.StartsWith("https"))
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls;
            }

            //内容
            HttpContent httpContent = new ObjectContent(typeof(Dictionary<string, string>), param, new JsonMediaTypeFormatter());

            //headers
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpClient httpClient = new HttpClient();

            //post请求
            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            T result = default(T);

            if (response.IsSuccessStatusCode)
            {
                string s = response.Content.ReadAsStringAsync().Result;

                result = JsonConvert.DeserializeObject<T>(s);
            }

            return result;
        }

        /// <summary>
        /// 封装的 HttpClient Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T StartPostWithParam<T>(string requestUrl, object param) where T:class, new()
        {
            T result = default(T);

            if (requestUrl == "" 
                || requestUrl == null
                || requestUrl == "{url}")
            {
                CommonHttpResult<string> res = new CommonHttpResult<string> { code = CommonResult.Exception, Message = "请求url为null", Data = "" };

                return res as T;
            }
```
```
        /// <returns></returns>
        [HttpPost]
        public object SendPostRequestWithHttpWebRequest (string requestUrl, Dictionary<string, string> param)
        {
            //创建httpWebRequest对象 
            //HttpWebRequest不能直接通过new来创建，只能通过WebRequest.Create(url)的方式来获得。 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);

            //请求类型 默认GET
            request.Method = "post";

            //现将字典转换成json字符串
            string paramStr = JsonConvert.SerializeObject(param);

            //转换输入参数的编码类型，获取bytep[] 数组
            byte[] bytes = Encoding.UTF8.GetBytes(paramStr);

            //内容长度
            request.ContentLength = bytes.Length;

            //
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                //输出流写入数据
                requestStream.Write(bytes, 0, bytes.Count());
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();

            if(httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new ApplicationException(string.Format("fail:{0}", httpResponse.StatusCode));
            }

            var responseJson = "";

            using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8))
            {
                responseJson = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject(responseJson);
        }
```
### <h4 id="Linq语句的使用">22. Linq语句的使用</h4>
```
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

            foreach(var p in pp)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("================");

            //Linq语句与Lambda语句的结合使用
            var ss = nums.Where(p => p > 4 && p % 2 == 0);

            foreach(var s in ss)
            {
                Console.WriteLine(s);
            }

            //求出第一个数
            var dd = nums.First(p => p > 2 || p % 2 == 0);

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

            Console.WriteLine(dd);
            Console.ReadKey();
```
### <h4 id="Authentication接口安全-Basic认证">23. Authentication接口安全-Basic认证 </h4>
```
    public class AuthenticationDemoController : ApiController
    {
        [HttpGet]
        public object AuthenticationTestApi(string UserName, string Password)
        {
            if (!HttpTool.IsValidate(UserName)
                || !HttpTool.IsValidate(Password))
            {
                return "账号或密码格式错误";
            }

            //
            // 摘要:
            //     使用 cookie 名、版本、目录路径、发布日期、过期日期、持久性以及用户定义的数据初始化 System.Web.Security.FormsAuthenticationTicket
            //     类的新实例。
            //
            // 参数:
            //   version:
            //     票证的版本号。
            //
            //   name:
            //     与票证关联的用户名。
            //
            //   issueDate:
            //     票证发出时的本地日期和时间。
            //
            //   expiration:
            //     票证过期时的本地日期和时间。
            //
            //   isPersistent:
            //     如果票证将存储在持久性 Cookie 中（跨浏览器会话保存），则为 true；否则为 false。如果该票证存储在 URL 中，将忽略此值。
            //
            //   userData:
            //     存储在票证中的用户特定的数据。
            //
            //   cookiePath:
            //     票证存储在 Cookie 中时的路径。
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, UserName, DateTime.Now,
                DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", UserName, Password),
                FormsAuthentication.FormsCookiePath);

            //返回用户登录结果 用户信息 用户验证票据信息
            //创建一个字符串，其中包含适用于 HTTP Cookie 的加密的 Forms 身份验证票证。
            //
            // 参数:
            //   ticket:
            //     用于创建加密的 Forms 身份验证票证的 System.Web.Security.FormsAuthenticationTicket 对象。
            //
            // 返回结果:
            //     一个字符串，其中包含加密的 Forms 身份验证票证。
            var UserInfo = new UserInfo { bRes = true, UserName = UserName, Password = Password, Ticket = FormsAuthentication.Encrypt(ticket) };

            //将身份信息保存到session  验证当前请求是否有效
            //WebApi默认是没有开启Session的: 需要在注册api路由需将RouteHandler 改写，才能使用
            HttpContext.Current.Session[UserName] = UserInfo;

            return UserInfo;
        }

        //[RequestAuthorize]
        [HttpPost]
        public string TestAfterLogin()
        {
            return "登录之后的带验证请求示例";
        }
    }
```
```
            //将身份信息保存到session  验证当前请求是否有效
            //WebApi默认是没有开启Session的: 需要在注册api路由需将RouteHandler 改写，才能使用
#if false
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
#endif

        //session为null： 需要在注册api路由需将RouteHandler 改写，才能使用
        //建立HttpControllerHandler和HttpControllerRouteHandler 并覆写它
        public static void Register(HttpConfiguration config)
        {
            RouteTable.Routes.MapHttpRoute(

            name: "DefaultApi",

            routeTemplate: "api/{controller}/{action}/{id}",

            defaults: new { id = RouteParameter.Optional }

            ).RouteHandler = new SessionControllerRouteHandler();
        }
    }
```
```
        //session为null： 需要在注册api路由需将RouteHandler 改写，才能使用
        //建立HttpControllerHandler和HttpControllerRouteHandler 并覆写它
        public class SessionRouteHandler : HttpControllerHandler, IRequiresSessionState
        {
            public SessionRouteHandler(RouteData routeData) : base(routeData)
            {

            }
        }

        public class SessionControllerRouteHandler : HttpControllerRouteHandler
        {
            protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
            {

                return new SessionRouteHandler(requestContext.RouteData);

            }
        }
```
```
Login前端代码：
<script src="~/Scripts/jquery-1.10.2.min.js"></script>
@{
    ViewBag.Title = "Login";
}

<h2>Login</h2>

<div>
    <div>账号：<input id="account" type="text" /></div>
    <div>密码:<input id="password" type="text"/></div>

    <input type="button" value="登录" id="login"/>
</div>

<script>

    $(document).ready(function () {

        $("#login").click(function () {

            //点击登录的时候去获取值
            var account = $("#account").val().toString();
            var password = $("#password").val().toString();

            $.ajax({

                type: "get",
                url: "http://localhost:49204/api/AuthenticationDemo/AuthenticationTestApi",
                data:{UserName:account, Password:password},
                success: function (data,status) {

                    console.log("data = " + data);

                    if (data.UserName != null) {

                        //登录成功之后将账号和Ticket带到主页
                        window.location.href = '/Home/Index?UserName=' + data.UserName + "&Ticket=" + data.Ticket;
                    } else {

                        alert(data);
                    }
                },
                error: function (error) {

                    console.log("error = " + error);
                }
            });
        });
    });

</script>

```
```
Home前端代码：
<script src="~/Scripts/jquery-1.10.2.min.js">
    var UserName = '@ViewBag.UserName';
    var Ticket = '@ViewBag.Ticket';
</script>

<div>
    <p>当前登录用户:'@ViewBag.UserName'</p>
    <div>登录之后带验证的测试:<input type="button" value="点击测试" id="test"/></div>
    <p id="content"></p>
    <div>获取string1:<input value="获取字符串1" id="string1" type="button"/></div>
    <p id="s1"></p>
    <div>获取string2:<input value="获取字符串2" id="string2" type="button"/></div>
    <p id="s2"></p>
</div>

<script>

    $(document).ready(function () {

        $("#test").click(function () {

            //注意单引号 不然会报异常错误
            var token = '@ViewBag.Ticket';

            $.ajax({

                type:"post",
                url: "http://localhost:49204/api/AuthenticationDemo/TestAfterLogin",
                beforeSend:function(xhr){

                    //发送ajax请求之前向http的head里面加入验证信息
                    xhr.setRequestHeader('Authorization', 'BasicAuth ' + token);
                },
                success: function (data, status) {

                    console.log(JSON.stringify(data));

                    if (status == "success") {

                        $("#content").html(data);
                    }
                },
                error: function (error) {

                    console.log(error);
                }
            });
        });


        $("#string1").click(function () {

            //注意单引号 不然会报异常错误
            var token = '@ViewBag.Ticket';

            $.ajax({

                type: "get",
                url: "http://localhost:49204/api/Info/string1",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'BasicAuth ' + token);
                },
                success: function (data) {

                    $("#s1").html(data);
                },
                error: function (error) {

                }
            });
        });


        $("#string2").click(function () {

            //注意单引号 不然会报异常错误
            var token = '@ViewBag.Ticket';

            $.ajax({

                type: "post",
                url: "http://localhost:49204/api/Info/string2",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'BasicAuth ' + token);
                },
                success: function (data) {

                    $("#s2").html(data);
                },
                error: function (error) {

                }
            });
        });
    });
</script>
```
```
    //在具体的Api接口增加我们上面自定义类的特性
    //增加了特性标注之后，每次请求这个API里面的接口之前，
    //程序会先进入到我们override过的 OnAuthorization() 方法里面，
    //验证通过之后，才会进到相应的方法里面去执行，否则返回401。
    [RequestAuthorize]
    public class InfoController : ApiController
    {
        [HttpGet]
        public string string1()
        {
            return "这个接口需要header里进行授权";
        }

        /// <summary>
        /// AllowAnonymous:允许匿名，允许某一个方法不需要header验证
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public string string2()
        {
            return "加上AllowAnonymous允许某个接口不需要header验证";
        }
    }
```
```
身份验证：
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//AuthorizeAttribute
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace AuthenticationDemo.Authentication
{
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {
        //然后重写OnAuthorization方法，在这个方法里面取到请求头的Ticket信息，
        //然后校验用户名密码是否合理。
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = actionContext.Request.Headers.Authorization;

            if((authorization != null) && ( authorization.Parameter != null))
            {
                //解密用户ticket,并校验用户名密码是否匹配
                var encryptTicket = authorization.Parameter;

                if (ValidateTicket(encryptTicket))
                {
                    //base.OnAuthorization(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            else
            {
                // 如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }

            //在具体的Api接口增加我们上面自定义类的特性
            //增加了特性标注之后，每次请求这个API里面的接口之前，程序会先进入到我们override过的 OnAuthorization() 方法里面，
            //验证通过之后，才会进到相应的方法里面去执行，否则返回401。
        }

        /// <summary>
        /// 解密Ticket 并验证 
        /// 登录api创建Ticket时，存储在票证中的用户特定的数据为：string.Format("{0}&{1}", UserName, Password)
        /// </summary>
        /// <param name="encryptTicket"></param>
        /// <returns></returns>
        public bool ValidateTicket(string encryptTicket)
        {
            //解密Ticket
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;

            var index = strTicket.IndexOf("&");
            string strUser = strTicket.Substring(0, index);
            string strPas = strTicket.Substring(index + 1);

            if(strUser == "17673647340" && strPas == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);

            var authentication = actionContext.Request.Headers.Authorization;

        }
    }
}
```
###  <h4 id="正则表达式">24. 正则表达式</h4>

```
元字符	描述
\	将下一个字符标记为一个特殊字符、或一个原义字符、或一个向后引用、或一个八进制转义符。例如，“\n”匹配一个换行符。“\\n”匹配字符"n"。序列“\\”匹配“\”而“\(”则匹配“(”。
^	匹配输入字符串的开始位置。如果设置了RegExp对象的Multiline属性，^也匹配“\n”或“\r”之后的位置。
$	匹配输入字符串的结束位置。如果设置了RegExp对象的Multiline属性，$也匹配“\n”或“\r”之前的位置。
*	匹配前面的子表达式零次或多次。例如，zo*能匹配“z”以及“zoo”。*等价于{0,}。
+	匹配前面的子表达式一次或多次。例如，“zo+”能匹配“zo”以及“zoo”，但不能匹配“z”。+等价于{1,}。
?	匹配前面的子表达式零次或一次。例如，“do(es)?”可以匹配“does”或“does”中的“do”。?等价于{0,1}。
{n}	n是一个非负整数。匹配确定的n次。例如，“o{2}”不能匹配“Bob”中的“o”，但是能匹配“food”中的两个o。
{n,}	n是一个非负整数。至少匹配n次。例如，“o{2,}”不能匹配“Bob”中的“o”，但能匹配“foooood”中的所有o。“o{1,}”等价于“o+”。“o{0,}”则等价于“o*”。
{n,m}	m和n均为非负整数，其中n<=m。最少匹配n次且最多匹配m次。例如，“o{1,3}”将匹配“fooooood”中的前三个o。“o{0,1}”等价于“o?”。请注意在逗号和两个数之间不能有空格。
?	当该字符紧跟在任何一个其他限制符（*,+,?，{n}，{n,}，{n,m}）后面时，匹配模式是非贪婪的。非贪婪模式尽可能少的匹配所搜索的字符串，而默认的贪婪模式则尽可能多的匹配所搜索的字符串。例如，对于字符串“oooo”，“o?”将匹配单个“o”，而“o+”将匹配所有“o”。
.点	匹配除“\n”之外的任何单个字符。要匹配包括“\n”在内的任何字符，请使用像“[\s\S]”的模式。
(pattern)	匹配pattern并获取这一匹配。所获取的匹配可以从产生的Matches集合得到，在VBScript中使用SubMatches集合，在JScript中则使用$0…$9属性。要匹配圆括号字符，请使用“\(”或“\)”。
(?:pattern)	匹配pattern但不获取匹配结果，也就是说这是一个非获取匹配，不进行存储供以后使用。这在使用或字符“(|)”来组合一个模式的各个部分是很有用。例如“industr(?:y|ies)”就是一个比“industry|industries”更简略的表达式。
(?=pattern)	正向肯定预查，在任何匹配pattern的字符串开始处匹配查找字符串。这是一个非获取匹配，也就是说，该匹配不需要获取供以后使用。例如，“Windows(?=95|98|NT|2000)”能匹配“Windows2000”中的“Windows”，但不能匹配“Windows3.1”中的“Windows”。预查不消耗字符，也就是说，在一个匹配发生后，在最后一次匹配之后立即开始下一次匹配的搜索，而不是从包含预查的字符之后开始。
(?!pattern)	正向否定预查，在任何不匹配pattern的字符串开始处匹配查找字符串。这是一个非获取匹配，也就是说，该匹配不需要获取供以后使用。例如“Windows(?!95|98|NT|2000)”能匹配“Windows3.1”中的“Windows”，但不能匹配“Windows2000”中的“Windows”。
(?<=pattern)	反向肯定预查，与正向肯定预查类似，只是方向相反。例如，“(?<=95|98|NT|2000)Windows”能匹配“2000Windows”中的“Windows”，但不能匹配“3.1Windows”中的“Windows”。
(?<!pattern)	反向否定预查，与正向否定预查类似，只是方向相反。例如“(?<!95|98|NT|2000)Windows”能匹配“3.1Windows”中的“Windows”，但不能匹配“2000Windows”中的“Windows”。
x|y	匹配x或y。例如，“z|food”能匹配“z”或“food”。“(z|f)ood”则匹配“zood”或“food”。
[xyz]	字符集合。匹配所包含的任意一个字符。例如，“[abc]”可以匹配“plain”中的“a”。
[^xyz]	负值字符集合。匹配未包含的任意字符。例如，“[^abc]”可以匹配“plain”中的“plin”。
[a-z]	字符范围。匹配指定范围内的任意字符。例如，“[a-z]”可以匹配“a”到“z”范围内的任意小写字母字符。注意:只有连字符在字符组内部时,并且出两个字符之间时,才能表示字符的范围; 如果出字符组的开头,则只能表示连字符本身.
[^a-z]	负值字符范围。匹配任何不在指定范围内的任意字符。例如，“[^a-z]”可以匹配任何不在“a”到“z”范围内的任意字符。
\b	匹配一个单词边界，也就是指单词和空格间的位置。例如，“er\b”可以匹配“never”中的“er”，但不能匹配“verb”中的“er”。
\B	匹配非单词边界。“er\B”能匹配“verb”中的“er”，但不能匹配“never”中的“er”。
\cx	匹配由x指明的控制字符。例如，\cM匹配一个Control-M或回车符。x的值必须为A-Z或a-z之一。否则，将c视为一个原义的“c”字符。
\d	匹配一个数字字符。等价于[0-9]。
\D	匹配一个非数字字符。等价于[^0-9]。
\f	匹配一个换页符。等价于\x0c和\cL。
\n	匹配一个换行符。等价于\x0a和\cJ。
\r	匹配一个回车符。等价于\x0d和\cM。
\s	匹配任何空白字符，包括空格、制表符、换页符等等。等价于[ \f\n\r\t\v]。
\S	匹配任何非空白字符。等价于[^ \f\n\r\t\v]。
\t	匹配一个制表符。等价于\x09和\cI。
\v	匹配一个垂直制表符。等价于\x0b和\cK。
\w	匹配包括下划线的任何单词字符。等价于“[A-Za-z0-9_]”。
\W	匹配任何非单词字符。等价于“[^A-Za-z0-9_]”。
\xn	匹配n，其中n为十六进制转义值。十六进制转义值必须为确定的两个数字长。例如，“\x41”匹配“A”。“\x041”则等价于“\x04&1”。正则表达式中可以使用ASCII编码。
\num	匹配num，其中num是一个正整数。对所获取的匹配的引用。例如，“(.)\1”匹配两个连续的相同字符。
\n	标识一个八进制转义值或一个向后引用。如果\n之前至少n个获取的子表达式，则n为向后引用。否则，如果n为八进制数字（0-7），则n为一个八进制转义值。
\nm	标识一个八进制转义值或一个向后引用。如果\nm之前至少有nm个获得子表达式，则nm为向后引用。如果\nm之前至少有n个获取，则n为一个后跟文字m的向后引用。如果前面的条件都不满足，若n和m均为八进制数字（0-7），则\nm将匹配八进制转义值nm。
\nml	如果n为八进制数字（0-7），且m和l均为八进制数字（0-7），则匹配八进制转义值nml。
\un	匹配n，其中n是一个用四个十六进制数字表示的Unicode字符。例如，\u00A9匹配版权符号（©）。
```
```
正则表达式的使用：
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
```
```
常用正则表达式：
//验证电话号码
public bool IsTelephone(string str_telephone)
{
return System.Text.RegularExpressions. 
Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
}

//验证密码
public bool IsPassword(string str_password)
{
return System.Text.RegularExpressions. 
Regex.IsMatch(str_password, @"[A-Za-z]+[0-9]");
}

//验证邮政编码
public bool IsPostalcode(string str_postalcode)
{
return System.Text.RegularExpressions.
Regex.IsMatch(str_postalcode, @"^\d{6}$");
}

//验证手机号码
public bool IsHandset(string str_handset)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_handset, @"^[1][3-5]\d{9}$");
}

//验证身份证
public bool IsIDcard(string str_idcard)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_idcard, @"(^\d{18}$)|(^\d{15}$)");
}

//验证小数格式
public bool IsDecimal(string str_decimal)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_decimal, @"^[0-9]+\.[0-9]{2}$");
}

//验证月份
public bool IsMonth(string str_Month)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_Month, @"^(0?[[1-9]|1[0-2])$");
}

//验证天数
public bool IsDay(string str_day)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_day, @"^((0?[1-9])|((1|2)[0-9])|30|31)$");
}

//验证是否为数字
public bool IsNumber(string str_number)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_number, @"^[0-9]*$");
}

//验证密码长度
public bool IsPasswLength(string str_Length)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_Length, @"^\d{6,18}$");
}

//验证正整数
public bool IsIntNumber(string str_intNumber)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_intNumber, @"^\+?[1-9][0-9]*$");
}

//验证大小写
public bool IsUpChar(string str_UpChar)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_UpChar, @"^[A-Z]+$");
}

public bool IsLowerChar(string str_UpChar)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_UpChar, @"^[a-z]+$");
}

//验证是否为字母
public bool IsLetter(string str_Letter)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_Letter, @"^[A-Za-z]+$");
}

//验证是否为中文
public bool IsChinese(string str_chinese)
{
return System.Text.RegularExpressions.Regex. 
IsMatch(str_chinese, @"^[\u4e00-\u9fa5]{1,}$");
}

//验证邮箱
public bool IsEmail(string str_Email)
{
return System.Text.RegularExpressions.Regex.IsMatch(str_Email, 
@"^(([\w\.]+)@(([[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))|((\w+\.?)+)@([a-zA-Z]{2,4}|[0-9]{1,3})(\.[a-zA-Z]{2,4}))$");
}

//验证IP
public bool IPCheck(string IP)
{
string num = @"(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)"; 
return Regex.IsMatch(IP, 
("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
}

//验证Url
public bool IsUrl(string str_url)
{
return System.Text.RegularExpressions.Regex.IsMatch(str_url, 
@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
}
```
### <h4 id="图片与文件的上传">25. 图片与文件的上传</h4>
```
    public class UploadController : ApiController
    {
        [HttpPost]
        //[Route("api/Upload")]
        public async Task<string> Upload(string guid)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            
            string UploadFilePath = HostingEnvironment.MapPath("~/Upload");

            //如果路径不存在 创建路径
            if (Directory.Exists(UploadFilePath))
            {
                Directory.CreateDirectory(UploadFilePath);
            }

            List<string> files = new List<string>();

            var provider = new WithExtensionMultipartFormDataStreamProvider(UploadFilePath, guid);

            try
            {
                //读取data
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    files.Add(Path.GetFileName(file.LocalFileName));
                }
            }
            catch
            {
                throw;
            }

            return string.Join(",", files);
        }
    }
```
```
    public class WithExtensionMultipartFormDataStreamProvider: MultipartFormDataStreamProvider
    {
        public string guid { get; set; }

        public WithExtensionMultipartFormDataStreamProvider(string rootPath, string guidStr):base(rootPath)
        {
            guid = guidStr;
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            //IsNullOrWhiteSpace:指示指定的字符串是 null、空还是仅由空白字符组成
            //返回指定的路径字符串的扩展名: Path.GetExtension
            string extension = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ?
                Path.GetExtension(GetValidFileName(headers.ContentDisposition.FileName)) : "";

            return guid + extension;
        }

        private string GetValidFileName(string filePath)
        {
            //获取包含不允许在文件名中使用的字符的数组
            char[] invalids = Path.GetInvalidFileNameChars();
            //StringSplitOptions.RemoveEmptyEntries:返回值不包括含有空字符串的数组元素
            return string.Join("_", filePath.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
        }
    }
```
```
前端：
<script src="~/Scripts/jquery-1.10.2.min.js"></script>

<form id="UploadForm">

    <p>指定文件名 ：<input type="text" name="filename" value="" id="filename"/></p>
    <p>请选择需要上传的文件：<input type="file" name="file" /></p>

    <input type="button" value="上传" onclick="upload()" />
</form>

<script>

    function upload() {

        //序列化表单
        //$("form").serialize()和 new FormData($('#uploadForm')[0])都是序列化表单
        //序列化表单，$("form").serialize()只能序列化数据，不能序列化文件
        var formData = new FormData($("#UploadForm")[0]);
        //$("#UploadForm").serialize();

        console.log(formData);
        console.log($("#UploadForm").serialize());

        $.ajax({

            url: "http://localhost:62277/Api/Upload/Upload?guid="+$("#filename").val(),
            data: formData,
            type: "POST",
            async: false,
            cache: false,
            contentType: false,
            processData: false,
            success: function (data) {

                alert(data);
            },
            error: function (error) {

                alert(error);
            }
        })
    }


</script>
```
### <h4 id="Base64与Image的互相转换">26. Base64与Image的互相转换, 生成头像路径 并保存到sqlserver</h4>
```
       /// <summary>
        /// Base64转Image
        /// </summary>
        /// <param name="ImageName"></param>
        /// <param name="base64Str"></param>
        /// 
        [HttpPost]
        public CommonResult<string> Base64ToImage(ImageConvert Model)
        {
            CommonResult<string> res = ImageBase64Convert<string>.Base64StringToImage(Model.Name, Model.ImageBase64Str);

            if(res.Code == Code.Success)
            {
                //插入数据库
                Client client = new Client();
                client.Name = Model.Name;
                client.Avator = res.Message;

                object obj = db.Insert("client_info", "Id", client);

                if((int)obj > 0)
                {
                    Console.WriteLine("新增成功");
                }
                else
                {
                    Console.WriteLine("新增失败");
                }
            }

            return res;
        }

        /// <summary> 
        /// Image转Base64字符串 app
        /// </summary>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public CommonResult<string> ImageToBase64Str(string Name)
        {

            CommonResult<string> res = ImageBase64Convert<string>.ImageToBase64String<string>(Name);

            return res;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpPost]
        public Client GetClientInfo(string Name)
        {
            CommonResult<Client> clientInfo = new CommonResult<Client> { Code = Code.Success, Message = "", Result = default(Client) };

            Client client = db.SingleOrDefault<Client>("select * from client_info where Name=@0", Name);

            if(client == null)
            {
                clientInfo.Result = null;
                clientInfo.Code = Code.Failed;
                clientInfo.Message = "失败";
            }
            else
            {
                clientInfo.Result = client;
                clientInfo.Code = Code.Success;
                clientInfo.Message = "成功";
            }

            return clientInfo;
        }
```
```
#### Image与Base64的互相转换
    public class ImageBase64Convert<T>
    {
        /// <summary>
        /// base64转Image
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="base64Str"></param>
        public static CommonResult<T> Base64StringToImage(string Name, string base64Str)
        {
            CommonResult<T> result = new CommonResult<T> { Code = Code.Success, Message = "", Result = default(T) };

            try
            {
                string inputStr = base64Str;

                //将base64转成byte[]
                byte[] bytes = Convert.FromBase64String(inputStr);

                //bytes -> MemoryStream
                MemoryStream ms = new MemoryStream(bytes);

                //MemoryStream -> Bitmap
                Bitmap bmap = new Bitmap(ms);

                //保存图片到指定路径
                bmap.Save(HttpContext.Current.Server.MapPath(@"~/Images/" + Name + ".jpg"), 
                    System.Drawing.Imaging.ImageFormat.Jpeg);

                ms.Close();

                result.Message = WebBase.GetRootPath() + @"Images/" + Name + ".jpg";

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());

                result.Code = Code.Failed;
                result.Message = "失败";

                return result;
            }
        }


        /// <summary>
        /// 图片转base64
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ImageName"></param>
        /// <returns></returns>
        public static CommonResult<T> ImageToBase64String<T>(string ImageName) where T:class
        {
            CommonResult<T> result = new CommonResult<T> { Code = Code.Success, Message = "", Result = default(T)};

            string path1 = HttpContext.Current.Server.MapPath(@"~/Images/" + ImageName);

            try
            {
                //Image途径实例化位图
                Bitmap bmap = new Bitmap(path1);

                //内存流
                MemoryStream ms = new MemoryStream();

                //将图片以jpeg形式 保存到内存流中
                bmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                //实例化内存流长度的byte数组
                byte[] arr = new byte[ms.Length];

                //设置内存流读的起始位置
                ms.Position = 0;

                //读取
                ms.Read(arr, 0 , (int)ms.Length);

                ms.Close();

                string base64 = Convert.ToBase64String(arr);

                result.Result = base64 as T;
                result.Message = "成功";

                return result;

            }catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());

                result.Code = Code.Failed;
                result.Message = "失败";

                return result;
            }
        }

    }
```
```
           /// <summary>
          /// 得到当前网站的根地址
          /// </summary>
          /// <returns></returns>
          public static string GetRootPath()
          {
              // 是否为SSL认证站点
              string secure = HttpContext.Current.Request.ServerVariables["HTTPS"];
              string httpProtocol = (secure == "on" ? "https://" : "http://");

             // 服务器名称
             string serverName = HttpContext.Current.Request.ServerVariables["Server_Name"];
             string port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];

             // 应用服务名称
             string applicationName = HttpContext.Current.Request.ApplicationPath;
             return httpProtocol + serverName + (port.Length > 0 ? ":" + port : string.Empty) + applicationName;
         }
```
### <h4 id="JPush">27. JPush</h4>
```
### web.config配置
```
    <!-- 极光推送配置 -->
    <add key="JPushAppKey" value="354003058a25b14234XXXX" />
    <add key="JPushMasterSecret" value="2e469438a8d9e9XXXX" />
    <add key="JPushIOSProd" value="false" />
```
   public class Jpush
    {
        public static string AppKey = ConfigurationManager.AppSettings["JPushAppKey"];
        public static string Master_Secret = ConfigurationManager.AppSettings["JPushMasterSecret"];

        #region 广播
        /// <summary>
        /// 全员广播
        /// </summary>
        /// <param name="title">广播标题</param>
        /// <param name="content">广播内容</param>
        /// <param name="json">json数据</param>
        /// <returns></returns>
        public static string JPushAll(string title, string content, Dictionary<string, object> json)
        {
            JPushClient jpushClient = new JPushClient(AppKey, Master_Secret);

            PushPayload payload = new PushPayload();
            payload.Platform = "all";
            payload.Audience = "all";

            Notification noti = new Notification();
            noti.Alert = content;
            noti.Android = new Android() { Alert = content, Title = title, Extras = json };
            noti.IOS = new IOS() { Alert = content, Category = title, Extras = json };
            payload.Notification = noti;

            Jiguang.JPush.Model.HttpResponse response = jpushClient.SendPush(payload);

            return response.Content;
        }

        /// <summary>
        /// 指定别名广播
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="json">推送内容</param>
        /// <param name="aliases">别名集合</param>
        /// <returns></returns>
        public static string JPushAliases(string title, string content, Dictionary<string, object> json, ArrayList aliases)
        {
            JPushClient jpushClient = new JPushClient(AppKey, Master_Secret);

            PushPayload payload = new PushPayload();
            payload.Platform = "all";

            Dictionary<string, ArrayList> audis = new Dictionary<string, ArrayList>();
            audis.Add("alias", aliases);
            payload.Audience = audis;

            Notification noti = new Notification();
            noti.Alert = title;
            noti.Android = new Android() { Title = title, Alert = content, Extras = json };
            noti.IOS = new IOS() { Alert = content, Category = title, Extras = json };
            payload.Notification = noti;

            Jiguang.JPush.Model.HttpResponse response = jpushClient.SendPush(payload);

            return response.Content;
        }
        #endregion

        #region 消息
        /// <summary>
        /// 全员消息
        /// </summary>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="json">json数据</param>
        /// <returns></returns>
        public static string JPushMessageAll(string title, string content, Dictionary<string, object> json)
        {
            JPushClient jpushClient = new JPushClient(AppKey, Master_Secret);

            PushPayload payload = new PushPayload();
            payload.Platform = "all";
            payload.Audience = "all";

            Message msg = new Message();
            msg.Content = content;
            msg.Title = title;
            msg.Extras = json;
            msg.ContentType = "text";

            payload.Message = msg;

            Jiguang.JPush.Model.HttpResponse response = jpushClient.SendPush(payload);

            return response.Content;
        }

        /// <summary>
        /// 别名消息
        /// </summary>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="json">json数据</param>
        /// <param name="aliases">别名集合</param>
        /// <returns></returns>
        public static string JPushMessageAliases(string title, string content, Dictionary<string, object> json, ArrayList aliases)
        {
            JPushClient jpushClient = new JPushClient(AppKey, Master_Secret);

            PushPayload payload = new PushPayload();
            payload.Platform = "all";

            Dictionary<string, ArrayList> aliasSet = new Dictionary<string, ArrayList>();
            aliasSet.Add("alias", aliases);
            payload.Audience = aliasSet;

            Message msg = new Message();
            msg.ContentType = "text";
            msg.Title = title;
            msg.Content = content;
            msg.Extras = json;

            payload.Message = msg;

            Jiguang.JPush.Model.HttpResponse response = jpushClient.SendPush(payload);

            return response.Content;
        }

        #endregion

    }
```
### <h4 id="Redis">28. Redis:一个开源的使用ANSI C语言编写、遵守BSD协议、支持网络、可基于内存亦可持久化的日志型、Key-Value数据库</h4>
```
一个好用的Redis客户端工具：
<a href="https://pan.baidu.com/s/1i4TOJU9">redisclient-win32.x86.1.5</a>
```
```
简介：

REmote DIctionary Server(Redis) 是一个由Salvatore Sanfilippo写的key-value存储系统。

Redis是一个开源的使用ANSI C语言编写、遵守BSD协议、支持网络、可基于内存亦可持久化的日志型、Key-Value数据库，并提供多种语言的API。

它通常被称为数据结构服务器，因为值（value）可以是 字符串(String), 哈希(Map), 列表(list), 集合(sets) 和 有序集合(sorted sets)等类型。
```
```
特点与优势：

Redis支持数据的持久化，可以将内存中的数据保存在磁盘中，重启的时候可以再次加载进行使用。
Redis不仅仅支持简单的key-value类型的数据，同时还提供list，set，zset，hash等数据结构的存储。
Redis支持数据的备份，即master-slave模式的数据备份。

性能极高 – Redis能读的速度是110000次/s,写的速度是81000次/s 。
丰富的数据类型 – Redis支持二进制案例的 Strings, Lists, Hashes, Sets 及 Ordered Sets 数据类型操作。
原子 – Redis的所有操作都是原子性的，意思就是要么成功执行要么失败完全不执行。单个操作是原子性的。多个操作也支持事务，即原子性，通过MULTI和EXEC指令包起来。
丰富的特性 – Redis还支持 publish/subscribe, 通知, key 过期等等特性。
```
```
Windows下安装Redis: 
<a href="https://github.com/MSOpenTech/redis/releases">https://github.com/MSOpenTech/redis/releases</a>

运行Redis:
1. cd到Redis安装目录下：  运行 redis-server.exe redis.windows.conf
2. 另启一个cmd窗口，原来的不要关闭，不然就无法访问服务端了;  cd到Redis安装目录下： redis-cli.exe -h 127.0.0.1 -p 6379
```
```
Redis命令：

如果需要在远程 redis 服务上执行命令，同样我们使用的也是 redis-cli 命令： redis-cli -h host -p port -a password

1. 键（Key）：
    设值： set czy "ethan"
    取值： get czy
    删除： del czy
    是否存在：exists czy

2. 字符串(String):
    设值：set czy "a iOS developer"
    取值：get czy
    删除： del czy
    是否存在：exists czy
    返回指定子字符串：getrange czy 0 10
    末尾拼接字符串：append czy "and a c# developer"
    返回长度：strlen czy

3. 哈希(Hash):
    Redis hash 是一个string类型的field和value的映射表，hash特别适合用于存储对象。
    Redis 中每个 hash 可以存储 232 - 1 键值对（40多亿）。
    
    设值：hmset czy name "ethan" des "a iOS and c# developer" location "changsha"
    设值当字段： hset czy des iOS
    取值所有：hgetall czy
    取值单个字段：hget czy des
    是否存在：hexists czy des
    获取所有字段: hkeys czy
    获取所有字段数量：hlen czy
    删除某个字段：hdel czy name

4. 列表(List):
    设值： lpush czy ios c# changsha
    取值： lrange czy 0 10
    移除第一个元素：blpop czy 0 (0:超时时间)
    移除最后一个元素：btpop czy 0 (0:超时时间)
    获取指定index元素：lindex czy 0
    在指定元素前后插入新元素：linsert  czy before(after) ethan c# 表示在ethan前/后面插入c#
    设值指定index元素的值：lset czy 0 iOS
    获取List长度：llen czy
    删除列表元素： lrem czy 1 ethan  (1:移除的次数  ethan:列表内容)

5. 集合(Set):
    Redis 的 Set 是 String 类型的无序集合。集合成员是唯一的，这就意味着集合中不能出现重复的数据。

   设值：sadd czy ethan iOS c# changsha
   取值：smembers czy
   获取集合数量： scard czy
   移除最后一个元素： spop czy
   移除指定元素：srem czy c#

6. 有序集合(sorted set):
   Redis 有序集合和集合一样也是string类型元素的集合,且不允许重复的成员。
   不同的是每个元素都会关联一个double类型的分数。redis正是通过分数来为集合中的成员进行从小到大的排序。
   有序集合的成员是唯一的,但分数(score)却可以重复。
   集合是通过哈希表实现的，所以添加，删除，查找的复杂度都是O(1)。 集合中最大的成员数为 232 - 1 (4294967295, 每个集合可存储40多亿个成员)。
   
   设值：zadd czy 1 ethan  (1:score)
   取值：zrange czy 0 10
   获取集合数量：  zcard czy
   移除指定元素：zrem czy ethan
```
```
Redis 发布订阅(pub/sub)：
一种消息通信模式：发送者(pub)发送消息，订阅者(sub)接收消息。

发送消息： publish czy "this is a test message"
订阅：subscribe czy
退订：unsubscribe czy
```
```
Redis 事务可以一次执行多个命令， 并且带有以下两个重要的保证：

批量操作在发送 EXEC 命令前被放入队列缓存。
收到 EXEC 命令后进入事务执行，事务中任意命令执行失败，其余的命令依然被执行。
在事务执行过程，其他客户端提交的命令请求不会插入到事务执行命令序列中。

127.0.0.1:6379> multi //标记一个事务块的开始。
OK
127.0.0.1:6379> lpush czy ethan
QUEUED
127.0.0.1:6379> lpush czy iOS
QUEUED
127.0.0.1:6379> lpush czy c#
QUEUED
127.0.0.1:6379> exec //执行所有事务块内的命令。
1) (integer) 1
2) (integer) 2
3) (integer) 3
127.0.0.1:6379>

取消事务：discard

```
```
Redis 脚本：

127.0.0.1:6379> EVAL "return {KEYS[1],KEYS[2],ARGV[1],ARGV[2]}" 2 key1 key2 first second
1) "key1"
2) "key2"
3) "first"
4) "second"
127.0.0.1:6379>
```
```
Redis 连接命令:

1. 验证密码是否正确: auth password
2. 打印字符串：echo message
3. 查看服务是否运行：ping
4.关闭当前连接：quit
5.切换到指定的数据库：select index
6.服务器信息：info (<a href="http://www.runoob.com/redis/redis-server.html">http://www.runoob.com/redis/redis-server.html</a>)
```
```
Redis 数据备份与恢复:

1.save:如果需要恢复数据，只需将备份文件 (dump.rdb) 移动到 redis 安装目录并启动服务即可
2. 获取 redis 目录:config get dir
3. bgsave:创建 redis 备份文件也可以使用命令 BGSAVE，该命令在后台执行
```
```
Redis 安全

1.查看是否设置了密码验证: config set requirepass password
2.验证密码：auth ppassword
3. 获取密码信息：config get requirepass

```
### Redis在c#中的应用：在NuGet中引入Redis
```
 class Program
    {
        public static string IP = "127.0.0.1";
        public static int PORT = 6379;

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
            client.Add<string>("timeout", "3秒之后消失", DateTime.Now.AddMilliseconds(3000));
            //休眠4s之后已经消失 有效时间为3s
            Thread.Sleep(4000);
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
```