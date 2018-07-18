using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bill.Interface;
using Bill.Models;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace Bill.Interface
{
    public class CkeckBillOperator : ICkeckBill
    {
        //所有对账单信息的List
        CheckBill bills = new CheckBill();

        /// <summary>
        /// 连接数据库  获取数据库中所有的对账单信息
        /// </summary>
        public void connectDb()
        {
            string conStr = "Server=127.0.0.1; user=sa; pwd=sa; database=checkbill";

            SqlConnection sqlcon = new SqlConnection(conStr);

            sqlcon.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter("select * from bill", sqlcon);

            DataSet ds = new DataSet();

            sqlda.Fill(ds);

            //清空
            this.bills.data.Clear();

            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    bill bl = new bill();
                    bl.year = dr[1].ToString();
                    bl.month = dr[2].ToString();
                    bl.begin_arrears = dr[3].ToString();
                    bl.delivery_amount = dr[4].ToString();
                    bl.payed_amount = dr[5].ToString();
                    bl.bedding_quota = dr[6].ToString();
                    bl.min_pay_amount = dr[7].ToString();
                    bl.current_arrears = dr[8].ToString();
                    bl.flag = (int)dr[9];
                    bl.sign_status = (int)dr[10];
                    bl.sign_date = dr[11].ToString();
                    bl.sign_photo = dr[12].ToString();

                    //重新添加
                    bills.data.Add(bl);
                }
            }
        }

        /// <summary>
        /// 获取所有月份的对账单
        /// </summary>
        /// <returns></returns>
        /// 
        public CheckBill GetBills(string gscode, string year, string month)
        {
            connectDb();

            if (this.bills.data.Count == 0)
            {
                this.bills.message = "暂无对账单信息";
            }
            else
            {
                this.bills.message = "查找成功";
            }

            this.bills.code = 0;

            return this.bills;
        }
    }
}