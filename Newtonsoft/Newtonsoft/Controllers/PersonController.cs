using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Models;

//JsonConvert需导入
using Newtonsoft.Json;

//stringReader
using System.IO;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace Newtonsoft.Controllers
{
    public class PersonController : ApiController
    {
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


        #region
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
    }
}
