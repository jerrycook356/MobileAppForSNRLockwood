using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using LockWood.Models;
using LockWood.WebService;

namespace LockWood
{
    public partial class YesterdaySummaryViewController : UIViewController
    {
        public YesterdaySummaryViewController (IntPtr handle) : base (handle)
        {
           
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            try
            {
                DateTime dt = DateTime.Today.AddDays(-1);
                List<Transaction> transactions = new List<Transaction>();
                WebService.WebService ws = new WebService.WebService();
                transactions = ws.getSummary(dt, dt);
                ComputeSummary cs = new ComputeSummary();
                cs.getSummary(transactions, yesterdaySummaryTextView);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
            }
        }

        partial void BackButton_TouchUpInside(UIButton sender)
        {
            ViewChanger viewChanger = new ViewChanger(this, "MainScreenViewController");
        }
    }
}