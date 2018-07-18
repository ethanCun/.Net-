using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Bill.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckBill
    {
        /// <summary>
        /// 返回成功状态
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 返回说明
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 对账单所有信息模型
        /// </summary>
        public List<bill> data { get; set; } = new List<bill>();
    }

    /// <summary>
    /// 
    /// </summary>
    public class bill
    {
        /// <summary>
        /// 对账单id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public string year { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        public string month { get; set; }

        /// <summary>
        /// 期初欠款
        /// </summary>
        public string begin_arrears { get; set; }

        /// <summary>
        /// 发货数量
        /// </summary>
        public string delivery_amount { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public string payed_amount { get; set; }

        /// <summary>
        /// 欠款金额
        /// </summary>
        public string bedding_quota { get; set; }

        /// <summary>
        /// 最少应付
        /// </summary>
        public string min_pay_amount { get; set; }

        /// <summary>
        /// 当前欠款
        /// </summary>
        public string current_arrears { get; set; }

        /// <summary>
        /// 标记是否过期
        /// </summary>
        public int flag { get; set; }

        /// <summary>
        /// 是否签名
        /// </summary>
        public int sign_status { get; set; }

        /// <summary>
        /// 签名日期
        /// </summary>
        public string sign_date { get; set; }

        /// <summary>
        /// 签名照片
        /// </summary>
        public string sign_photo { get; set; }
    }
}