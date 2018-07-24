using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderDetail.Models
{
    /// <summary>
    /// 返回结果编码
    /// </summary>
    public enum ResultCodeMsg
    {
        Exception = -1,
        Success,
        Fail,
        ReLogin,
        NoAuth
    }

    public class OrderDetails
    {
        public ResultCodeMsg code { get; set; }

        public string message { get; set; }

        public GetOrderInfoItem data { get; set; } = new GetOrderInfoItem();
    }

    public class GetOrderInfoItem
    {
        /// <summary>
        /// 主订单信息
        /// </summary>
        [PetaPoco.Ignore]
        public OrderMaster orderMaster { get; set; }

        /// <summary>
        /// 订单产品列表
        /// </summary>
        public List<OrderDetailInfo> orderDetailList = new List<OrderDetailInfo>();

        /// <summary>
        /// 宣传册 促销品
        /// </summary>
        public List<OrderBonus> orderBonusList = new List<OrderBonus>();

        /// <summary>
        /// 订单付款记录
        /// </summary>
        public List<OrderPayment> orderPaymentList = new List<OrderPayment>();

        /// <summary>
        /// 订单退款记录
        /// </summary>
        public List<RefundPayment> refundPaymentList = new List<RefundPayment>();

        /// <summary>
        /// 开票信息
        /// </summary>
        [PetaPoco.Ignore]
        public Ticket ticket { get; set; }

        /// <summary>
        /// 子订单列表
        /// </summary>
        public List<ChildOrder> childOrderList = new List<ChildOrder>();
    }

    public class OrderMaster
    {
        public string order_code { get; set; }
        public string gs_code { get; set; }
        public string receiver { get; set; }
        public string receiver_phone { get; set; }
        public string receiver_address { get; set; }
        public string pay_amount { get; set; }
        public string payed_amount { get; set; }
        public string create_time { get; set; }
        public string mark { get; set; }
        public int order_status { get; set; }
        public string invoice_type { get; set; }
        public int receipt_status { get; set; }
        public int receipt_on { get; set; }
        public string coupon_payed_amount { get; set; }
    }

    public class OrderDetailInfo
    {
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string price { get; set; }
        public string count { get; set; }
        public string buy_amount { get; set; }
        public string gift_amount { get; set; }
        public string gift_count { get; set; }
        public string order_type { get; set; }
        public string model { get; set; }
        public string photo { get; set; }

    }

    public class OrderBonus
    {
        public string type { get; set; }
        public string bonus_code { get; set; }
        public string product_name { get; set; }
        public string count { get; set; }
        public string model { get; set; }
        public string remark { get; set; }
        public string photo { get; set; }

    }

    public class OrderPayment
    {
        public string payment_type { get; set; }
        public string amount { get; set; }
        public string create_time { get; set; }

    }

    public class RefundPayment
    {
        public string account_type { get; set; }
        public string amount { get; set; }
        public string create_time { get; set; }

    }

    public class Ticket
    {
        public int id { get; set; }
        public string amount { get; set; }
        public string invoice_type { get; set; }
        public string ticket_name { get; set; }
        public string tax_id { get; set; }
        public string invoice_address { get; set; }
        public string invoice_phone { get; set; }
        public string opening_bank { get; set; }
        public string opening_account { get; set; }
        public string creator { get; set; }
        public string create_time { get; set; }

    }

    public class ChildOrder
    {
        public string child_code { get; set; }
        public int deliver_status { get; set; }
        public string logistic_code { get; set; }
        public string logistic_company { get; set; }
        public string estimated_time { get; set; }

        public List<ChildOrderDetail> childOrderDetailList = new List<ChildOrderDetail>();

        public List<Logistic> logisticList = new List<Logistic>();
    }

    public class ChildOrderDetail
    {
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string count { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public string photo { get; set; }

    }

    public class Logistic
    {
        public string track_time { get; set; }
        public string track_content { get; set; }

    }

}