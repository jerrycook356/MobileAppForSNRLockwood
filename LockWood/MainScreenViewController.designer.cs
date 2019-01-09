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
        UIKit.UIButton MapViewButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StockPIleInfoButton { get; set; }

        [Action ("ChangToStockpileView:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ChangToStockpileView (UIKit.UIButton sender);

        [Action ("MapViewButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void MapViewButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (MapViewButton != null) {
                MapViewButton.Dispose ();
                MapViewButton = null;
            }

            if (StockPIleInfoButton != null) {
                StockPIleInfoButton.Dispose ();
                StockPIleInfoButton = null;
            }
        }
    }
}