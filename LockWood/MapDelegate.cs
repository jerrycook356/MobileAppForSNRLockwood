using System;
using System.Diagnostics.Contracts;
using CoreLocation;
using LockWood.Models;
using LockWood.WebService;
using MapKit;
using UIKit;

namespace LockWood
{
    public class MapDelegate:MKMapViewDelegate
    {
        private static readonly string identifier = "id";
        MapWebService mw = new MapWebService();

        public MapDelegate()
        {
        }

        public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            Contract.Ensures(Contract.Result<MKAnnotationView>() != null);
            MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(identifier);

            //set current location of user and annotation
            //  CLLocationCoordinate2D currentLocation = mapView.UserLocation.Coordinate;
            CLLocationCoordinate2D annotationLocation = annotation.Coordinate;

            //no special annotation for user (if using user location on map)
            //  if (currentLocation.Latitude == annotationLocation.Latitude &&
            //   currentLocation.Longitude == annotationLocation.Longitude)
            //   return null;



            if (annotationView == null)
            {
                annotationView = new MKPinAnnotationView(annotation, identifier);
            }
            else
            {
                annotationView.Annotation = annotation;
            }


            annotationView.CanShowCallout = true;
            (annotationView as MKPinAnnotationView).AnimatesDrop = true;
            (annotationView as MKPinAnnotationView).PinTintColor = MKPinAnnotationView.RedPinColor;
            annotationView.SetSelected(true, false);

            UIButton annotationDetailButton = UIButton.FromType(UIButtonType.InfoDark);
            annotationDetailButton.TouchUpInside += (sender, e) =>
            {

                var coord = annotationLocation;
                CoalAnnotation annot = new CoalAnnotation();
                annot.coord = annotation.Coordinate;
                mw.DeleteAnnotation(annot);
                mapView.RemoveAnnotation(annotation);

            };

            annotationView.RightCalloutAccessoryView = annotationDetailButton;
            //if want to change icon on the left, maybe another button later
            //use left callout accessory view


            return annotationView;
        }
    }
}
