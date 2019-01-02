using System;
namespace LockWood.Models
{
    public class Transaction
    {
        private string truckId;
        private string startDate;
        private string endDate;
        private string source;
        private string destination;
        private string customer;
        private string grossWeight;
        private string tareWeight;
        private string timeStamp;
      

        public Transaction()
        {
        }
        public Transaction(string startDate, string endDate,string source,string destination,string customer)
        {
            this.startDate = startDate;
            this.endDate = endDate;
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
        public void SetStartDate(string startDate)
        {
            this.startDate = startDate;
        }
        public void SetEndDate(string endDate)
        {
            this.endDate = endDate;
        }
        public string GetStartDate()
        {
            return startDate;
        }
        public string GetEndDate()
        {
            return endDate;
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
        public void SetTruckId(string truckId)
        {
            this.truckId = truckId;
        }
        public string getTruckId()
        {
            return truckId;
        }
        public void SetGrossWeight(string grossWeight)
        {
            this.grossWeight = grossWeight;
        }
        public string GetGrossWeight()
        {
            return grossWeight;
        }
        public void SetTareWeight(string tareWeight)
        {
            this.tareWeight = tareWeight;
        }
        public string GetTareWeight()
        {
            return tareWeight;
        }

        public void SetTimeStamp(string timeStamp)
        {
            this.timeStamp = timeStamp;
        }
    }
}
