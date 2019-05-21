using Foundation;
using System;
using UIKit;

namespace LockWood
{
    public partial class AboutViewController : UIViewController
    {
        public AboutViewController (IntPtr handle) : base (handle)
        {

        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            aboutTextView.Text = "Programmed/Desinged:\nJerry Cook\n"
                + "February 2019\nVersion 1.0";
        }

        partial void BackButton_TouchUpInside(UIButton sender)
        {
            ViewChanger viewChanger = new ViewChanger(this, "MainScreenViewController");
        }
    }
}