using System;
using System.Collections.Generic;
namespace LockWood.PickerFillers
{
    public class PickerFiller
    {

        WebService.WebService ws = new WebService.WebService();
        public List<string> FillSourcePicker()
        {

            List<string> sources = ws.getSourcesFromDatabase();
            return sources;

        }

        public List<string>FillCustomerPicker()
        {
            List<string> customers = ws.GetCustomersFromDatabase();
            return customers;
        }

        public List<string> FillDestinationPicker()
        {
            List<string> destinations = ws.GetDestinationsFromDatabase();
            return destinations;
        }

    }
}
