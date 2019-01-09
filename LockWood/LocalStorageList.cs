using System;
using System.Collections.Generic;
using CoreLocation;
using LockWood.Models;

namespace LockWood
{
    public class LocalStorageList
    {
        public static List<CoalAnnotation> annotations = new List<CoalAnnotation>();
        public LocalStorageList()
        {
        }

        public void AddAnnotation(CoalAnnotation annotation){
            lock(annotations)
            {
                annotations.Add(annotation);
            }
        }

        public List<CoalAnnotation> GetAllAnnotations()
        {
            return annotations;
        }

        public void RemoveAnnotation(CLLocationCoordinate2D coord)
        {
           
            lock(annotations)
            {
                foreach (var annot in annotations)
                {
                    if(annot.Coordinate.Equals(coord))
                    {
                        annotations.Remove(annot);
                    }

                }
            }
        }
    }
}
