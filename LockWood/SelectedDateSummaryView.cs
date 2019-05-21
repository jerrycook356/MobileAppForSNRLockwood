using Foundation;
using System;
using UIKit;
using LockWood.Models;
using System.Collections.Generic;

namespace LockWood
{
    public partial class SelectedDateSummaryView : UIViewController
    {
       
        List<Transaction> transactions = new List<Transaction>();
        
        public SelectedDateSummaryView (IntPtr handle) : base (handle)
        {

        }
        public SelectedDateSummaryView()
        {

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //get transanctions from the database
            WebService.WebService ws = new WebService.WebService();
            DateHolder ds = new DateHolder();
            DateTime startDate = ds.GetStartDate();
            DateTime endDate = ds.GetEndDate();
            Console.Out.WriteLine("getStartDate = " + startDate);
           transactions = ws.getSummary(startDate, endDate);
            ComputeSummary cs = new ComputeSummary();
            cs.getSummary(transactions, SelectedDateTextView);

        }


partial void BackButton_TouchUpInside(UIButton sender)
        {
            ViewChanger viewChanger = new ViewChanger(this, "SummaryViewController");
        }
    }
}