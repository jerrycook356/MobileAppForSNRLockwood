using System;
using CoreLocation;
using MapKit;
namespace LockWood.Models
{
    public class StockPileInfo
    {

        static string stockpileNumber;
        static string company;
        static string source;
        static CLLocationCoordinate2D coord;

        public StockPileInfo()
        {
        }

        public void SetStockPileNumber(string stockPileNumberIn)
        {
            stockpileNumber = stockPileNumberIn;
        }

        public string GetStockPileNumber(){
            return stockpileNumber;
        }
        public void SetCompany(string companyIn)
        {
            company = companyIn;
        }
        public string GetCompany()
        {
            return company;
        }

        public void SetCoord(CLLocationCoordinate2D coordinate2D)
        {
            coord = coordinate2D;
        }
        public CLLocationCoordinate2D GetCoord()
        {
            return coord;
        }

        public void SetSource(string sourceIn)
        {
            source = sourceIn;
        }
        public string GetSource()
        {
            return source;
        }

        public void clear()
        {
            stockpileNumber = null;
            company = null;
        }

    }
}
