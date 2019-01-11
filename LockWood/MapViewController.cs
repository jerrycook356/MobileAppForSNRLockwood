using Foundation;
using System;
using UIKit;
using CoreLocation;
using MapKit;
using System.Collections.Generic;
using LockWood.Models;
using LockWood.WebService;

namespace LockWood
{
    public partial class MapViewController : UIViewController
    {
        public static List<CoalAnnotation> annots = new List<CoalAnnotation>();
        MKMapViewDelegate mapDelegate;
        MapWebService mw = new MapWebService();
        LocalStorageList storage = new LocalStorageList();
        public MapViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //map centered on lockwood dock
            CLLocationCoordinate2D coords = new CLLocationCoordinate2D(
                38.32515865003414, -82.57881700040785);
            MKCoordinateSpan span = new MKCoordinateSpan(
                MilesToLattitudeDegrees(.15), MilesToLongitudeDegrees(.15, coords.Latitude));
            mapView.Region = new MKCoordinateRegion(coords, span);
            mapDelegate = new MapDelegate();
            mapView.Delegate = mapDelegate;
            UITapGestureRecognizer tap = new UITapGestureRecognizer(Tapper);
            View.AddGestureRecognizer(tap);
            //fill map with stored annotations
            FillMap();
        }

        public double MilesToLattitudeDegrees(double miles)
        {
            double earthRadius = 3960.0; //in miles
            double radianDegree = 180 / Math.PI;
            return (miles / earthRadius) * radianDegree;
        }

        public double MilesToLongitudeDegrees(double miles, double atLattitude)
        {
            double earthRadius = 3960.0;//in miles
            double radianToDegree = 180 / Math.PI;
            double degreeToRadian = Math.PI / 180;
            //derive the earth raduis at the point of lattitude
            double radiusAtLattitude = earthRadius * Math.Cos(atLattitude * degreeToRadian);
            return (miles / radiusAtLattitude) * radianToDegree;

        }

        //changes view back to start up screen
        partial void BackButton_TouchUpInside(UIButton sender)
        {
            ViewChanger viewChanger = new ViewChanger(this, "MainScreenViewController");
        }

        public void Tapper(UITapGestureRecognizer press)
        {
            StockPileInfo info = new StockPileInfo();
            var pixelLocation = press.LocationInView(mapView);
            var gelocation = mapView.ConvertPoint(pixelLocation, mapView);
            var stockPile = info.GetStockPileNumber();
            var source = info.GetSource();
            var company = info.GetCompany();
            if ((!string.IsNullOrEmpty(stockPile)) && (!string.IsNullOrEmpty(company))&&(
                !string.IsNullOrEmpty(source)))
            {
                CoalAnnotation annotation = new CoalAnnotation(stockPile, company,source, gelocation);
                annotation.IncrementId();
                // storage.AddAnnotation(annotation);
                mw.SaveAnnotation(annotation);
                mapView.AddAnnotation(annotation);
                info.clear();
            }
        }

        //fill map from saved annotations
        public void FillMap()
        {
            //  annots = storage.GetAllAnnotations();
            // foreach (var annotation in annots)
            // {
            //     mapView.AddAnnotation(annotation);
            //  }
            annots = mw.getAnnotationsFromDatabase();
            Console.Out.WriteLine("number of annot from database = " + annots.Count);
            foreach(var annotation in annots){
                mapView.AddAnnotation(annotation);
            }
        }

        partial void CenteryButton_TouchUpInside(UIButton sender)
        {
            ViewDidLoad();

        }

partial void StockPileInfoButton_TouchUpInside(UIButton sender)
        {
            ViewChanger viewChanger = new ViewChanger(this, "SetInfoViewController");
        }
    }
}