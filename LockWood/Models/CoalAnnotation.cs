using System;
using CoreLocation;
using MapKit;

namespace LockWood.Models
{
    public class CoalAnnotation:MKAnnotation
    {
        //have to be public to convert to and from json 
       public string stockPileNumber;
       public  string company;
        public string source;
       public CLLocationCoordinate2D coord;
        public static double id = 0;

        public CoalAnnotation()
        {
        }
        public CoalAnnotation(string stockPileNumberIn, string companyIn,string sourceIn, CLLocationCoordinate2D coordinate2D){
            if((stockPileNumber != "")&&(company != "")&&(source != ""))
            {
                this.stockPileNumber = stockPileNumberIn;
                this.company = companyIn;
                this.source = sourceIn;
                this.coord = coordinate2D;
            }
        }

        public override CLLocationCoordinate2D Coordinate => coord;

        public  CLLocationCoordinate2D GetCoord()
        {
            return coord;
        }

        public void IncrementId()
        {
            id++;
        }
        public override string Title{
            get{
                return stockPileNumber;
            }
        }

        public override string Subtitle => company + " | "+source;
        public double GetId()
        {
            return id;
        }
    }
}
