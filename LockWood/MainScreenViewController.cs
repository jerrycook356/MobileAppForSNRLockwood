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
            //get Reference to storyBoard
            UIStoryboard storyboard = this.Storyboard;
            //create instance of view controller
            UIViewController viewController = 
                (UIViewController)storyboard.InstantiateViewController("StockPileView");
            viewController.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
            this.PresentViewController(viewController, true, null);

        }
    }
}