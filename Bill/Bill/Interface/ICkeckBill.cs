using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bill.Models;

namespace Bill.Interface
{
    interface ICkeckBill
    {
        /// <summary>
        /// 获取所有的对账单信息
        /// </summary>
        /// <returns></returns>
       CheckBill  GetBills(string gscode, string year, string month);
    }
}
