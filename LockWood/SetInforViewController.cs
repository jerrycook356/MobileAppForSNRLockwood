using Foundation;
using System;
using UIKit;
using LockWood.PickerFillers;
using System.Collections.Generic;
using LockWood.Models;
namespace LockWood
{
    public partial class SetInforViewController : UIViewController
    {
        PickerFiller pfill = new PickerFiller();
        PickerMaker maker;

        public SetInforViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //fill company picker 
            List<string> customers = pfill.FillCustomerPicker();
            maker = new PickerMaker(customers, SetCompanyTextField);
            //fill stockpiles
            List<string> stockpiles = pfill.FillDestinationPicker();
            maker = new PickerMaker(stockpiles, SetStockPileTextField);
            //fill sources
            List<string> sources = pfill.FillSourcePicker();
            maker = new PickerMaker(sources, SourceTextField);

        }
        partial void CancelButton_TouchUpInside(UIButton sender)
        {
            ViewChanger viewChanger = new ViewChanger(this, "MapViewController");
        }

partial void SaveButton_TouchUpInside(UIButton sender)
        {
            StockPileInfo stockpile = new StockPileInfo();
            stockpile.SetCompany(SetCompanyTextField.Text);
            stockpile.SetStockPileNumber(SetStockPileTextField.Text);
            stockpile.SetSource(SourceTextField.Text);
            SetStockPileTextField.Text = "";
            SetCompanyTextField.Text = "";
            SourceTextField.Text = "";
            ViewChanger view = new ViewChanger(this, "MapViewController");
        }
    }
}