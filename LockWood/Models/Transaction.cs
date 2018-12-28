using System;
namespace LockWood.Models
{
    public class Transaction
    {
        private string source;
        private string destination;
        private string customer;
      

        public Transaction()
        {
        }
        public Transaction(string source,string destination,string customer)
        {
            this.source = source;
            this.destination = destination;
            this.customer = customer;
        }

        public void SetSource(string source)
        {
            this.source = source;
        }

        public void SetDestination(string destination)
        {
            this.destination = destination;
        }
        public void SetCustomer(string customer)
        {
            this.customer = customer;
        }

        public string GetSource()
        {
            return source;
        }
        public string GetDestination()
        {
            return destination;
        }
        public string GetCustomer()
        {
            return customer;
        }
    }
}
