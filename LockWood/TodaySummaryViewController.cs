using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using LockWood.Models;
using LockWood.WebService;

namespace LockWood
{
    public partial class TodaySummaryViewController : UIViewController
    {
        List<Transaction> transactions = new List<Transaction>();

        public TodaySummaryViewController(IntPtr handle) : base(handle)
        {

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //get list from database
            WebService.WebService ws = new WebService.WebService();
            DateTime today = DateTime.Now;
            transactions = ws.getSummary(today, today);
            ComputeSummary cs = new ComputeSummary();
             cs.getSummary(transactions,TodayTextView);

        }
        partial void BackButton_TouchUpInside(UIButton sender)
        {
            ViewChanger viewChanger = new ViewChanger(this, "SummaryViewController");
        }

       
    }
   
}