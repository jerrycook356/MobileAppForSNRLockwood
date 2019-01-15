using System;
using CoreLocation;
using MapKit;

namespace LockWood.Models
{
    public class CoalAnnotation:MKAnnotation
    {
        //have to be public to convert to and from json 

        //parts of CLLocationCoordinate2d
        public double latitude;
        public double longitude;

        public string stockpile;
        public  string company;
        public string source;
        public CLLocationCoordinate2D coord;
        public static double id = 0;

        public CoalAnnotation()
        {
        }
        public CoalAnnotation(string stockPileNumberIn, string companyIn,string sourceIn, CLLocationCoordinate2D coordinate2D){
            if((stockpile != "")&&(company != "")&&(source != ""))
            {
                this.stockpile = stockPileNumberIn;
                this.company = companyIn;
                this.source = sourceIn;
                this.coord = coordinate2D;
            }
        }
        public CoalAnnotation(double id,string stockPileNumberIn, string companyIn, string sourceIn, double latitude,double longitude)
        {
            if ((stockpile != "") && (company != "") && (source != ""))
            {
                SetId(id);
                this.stockpile = stockPileNumberIn;
                this.company = companyIn;
                this.source = sourceIn;
                this.longitude = longitude;
                this.latitude = latitude;
                CLLocationCoordinate2D location;
                location.Latitude = latitude;
                location.Longitude = longitude;
                this.coord = location;
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
        public void SetId(double idIn)
        {
            id = idIn;
        }
        public override string Title{
            get{
                return stockpile;
            }
        }

        public override string Subtitle => company + " | " + source;
        public double GetId()
        {
            return id;
        }
    }
}
