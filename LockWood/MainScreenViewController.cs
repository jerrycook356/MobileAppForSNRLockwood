using Foundation;
using System;
using UIKit;

namespace LockWood
{
    public partial class MainScreenViewController : UIViewController
    {
        public MainScreenViewController (IntPtr handle) : base (handle)
        {
        }

partial void ChangToStockpileView(UIButton sender)
        {

            ViewChanger viewChanger = new ViewChanger(this, "StockPileView");

        }

partial void MapViewButton_TouchUpInside(UIButton sender)
        {
            ViewChanger viewChanger = new ViewChanger(this, "MapViewController");
        }
    }
}