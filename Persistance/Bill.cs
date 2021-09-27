using System;

namespace Persistence
{
    public class Bill
    {
        public int Bill_ID{get;set;}
        public Application App{get;set;}
        public User User{get;set;}
        public double UnitPrice{get;set;}
        public DateTime DateCreate{get;set;}
        public Payment Payment;

        public override bool Equals(object obj)
        {
            Bill b = (Bill)obj;
            return this.GetHashCode() == b.GetHashCode();
        }
        public override int GetHashCode()
        {
            return (Bill_ID + App.GetHashCode() + User.GetHashCode() + UnitPrice + DateCreate.GetHashCode() + Payment.GetHashCode()).GetHashCode();
        }
    }
}