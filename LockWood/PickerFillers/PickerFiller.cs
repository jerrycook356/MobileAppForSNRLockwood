using System;
using System.Collections.Generic;
using LockWood.WebService;
namespace LockWood.PickerFillers
{
    public class PickerFiller
    {


        public List<string> FillSourcePicker()
        {
            WebService.WebService ws = new WebService.WebService();
            List<string> sources = ws.getSourcesFromDatabase();
            return sources;

        }


    }
}
