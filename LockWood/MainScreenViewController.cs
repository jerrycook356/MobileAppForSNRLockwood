using Foundation;
using System;
using UIKit;

namespace LockWood
{
    public partial class MainScreenViewController : UIViewController
    {
        public MainScreenViewController(IntPtr handle) : base(handle)
        {
        }

       

partial void StockPIleInfoButton_TouchUpInside(UIButton sender)
        {
            ViewChanger viewChanger = new ViewChanger(this, "StockPileView");
        }


partial void SummaryButton_TouchUpInside(UIButton sender)
        {
            ViewChanger viewChanger = new ViewChanger(this, "SummaryViewController");
        }


partial void AboutButton_TouchUpInside(UIButton sender)
        {
            ViewChanger viewChanger = new ViewChanger(this, "AboutViewController");
        }


}