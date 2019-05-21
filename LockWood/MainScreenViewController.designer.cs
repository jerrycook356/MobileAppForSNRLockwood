// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace LockWood
{
    [Register ("MainScreenViewController")]
    partial class MainScreenViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AboutButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StockPIleInfoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SummaryButton { get; set; }

        [Action ("AboutButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AboutButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("StockPIleInfoButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void StockPIleInfoButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("SummaryButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SummaryButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AboutButton != null) {
                AboutButton.Dispose ();
                AboutButton = null;
            }

            if (StockPIleInfoButton != null) {
                StockPIleInfoButton.Dispose ();
                StockPIleInfoButton = null;
            }

            if (SummaryButton != null) {
                SummaryButton.Dispose ();
                SummaryButton = null;
            }
        }
    }
}