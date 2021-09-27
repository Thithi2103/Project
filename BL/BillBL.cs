using System;
using System.Collections.Generic;
using Persistence;
using DAL;

namespace BL
{
    public class BillBL
    {
        public bool CreateBill(Bill bill)
        {
            return BillDAL.CreateBill(bill);
        }
        public List<Bill> GetListBillByUserID(int UserId)
        {
            return BillDAL.GetListBillByUserId(UserId);
        }
    }
}
