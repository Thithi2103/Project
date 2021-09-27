using System;
using System.Collections.Generic;

namespace Persistence
{
    public class User
    {
        public User()
        {
            ListBill = new List<Bill>();
            ListAppBought = new List<Application>();
            ListPayment = new List<Payment>();
        }
        public int User_ID{get;set;}
        public string Name{get;set;}
        public string PhoneNumber{get;set;}
        public string UserName{get;set;}
        public string Password{get;set;}
        
        public List<Bill> ListBill{get;set;}
        public List<Application> ListAppBought{get;set;}
        public List<Payment> ListPayment{get;set;}

        public override bool Equals(object obj)
        {
            User u = (User)obj;
            return this.GetHashCode() == u.GetHashCode();
        }
        public override int GetHashCode()
        {
            return (User_ID + Name + PhoneNumber + UserName +
             Password + ListBill + ListAppBought + ListPayment).GetHashCode();
        }
    }
}