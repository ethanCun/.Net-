﻿### 为webapi添加接口注释和测试功能
```
接口注释参考链接： https://blog.csdn.net/a123_z/article/details/71078062
测试功能：NuGet添加WebApiTestClient，需在 Areas\HelpPage\Views\Help\Api.cshtml文件最后面添加：
	
@Html.DisplayForModel("TestClientDialogs")
@section Scripts {
    <linktype ="text/css" href="~/Areas/HelpPage/HelpPage.css" rel="stylesheet" />
    @Html.DisplayForModel("TestClientReferences")
}
```

### webapi接口返回值： IHttpActionResult HttpResponseMessage 与 自定义类型 
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

#### 自定义的webApi接口返回值：
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

### PetaPoco（ORM操作）的简单实用
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

### PetaPoco分页获取信息Web.config
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

### 多层数组结构的处理
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
### 多层结构的api  详见OrderDetail
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
### Newtonsoft ： json与对象的相互转换
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
### 插入或者更新一条信息： 表中存在该信息 则更新（先删除原来存在的  再插入新的数据） 表中不存在该数据 则添加
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
### 常用复杂Sql语句
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
### Nlog日志记录 
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