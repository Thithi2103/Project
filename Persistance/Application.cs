using System;

namespace Persistence
{
    public class Application
    {
        public int App_ID{get;set;}
        public string Name{get;set;}
        public string Kind{get;set;}
        public double Price{get;set;}
        public string Description{get;set;}
        public string Publisher{get;set;}
        public string Rating{get;set;}
        public DateTime DatePublisher{get;set;}
        public double Size{get;set;}

        public override bool Equals(object obj)
        {
            Application o = (Application)obj;

            return this.GetHashCode() == o.GetHashCode();
        }
        public override int GetHashCode()
        {
            return (App_ID + Name + Kind + Price + Description + Publisher + DatePublisher + Size + Rating).GetHashCode();
        }
    }
}