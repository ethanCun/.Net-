using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrderDetail.Models;
using PetaPoco;

namespace OrderDetail.Controllers
{
    public class OrderDetailController : ApiController
    {

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
    }
}
