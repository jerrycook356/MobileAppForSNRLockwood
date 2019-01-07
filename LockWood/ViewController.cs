using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using LockWood.PickerFillers;
using LockWood.Models;


namespace LockWood
{
    public partial class ViewController : UIViewController
    {


        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            var tapOutside = new UITapGestureRecognizer(() => View.EndEditing(true));
            tapOutside.CancelsTouchesInView = false;
            View.AddGestureRecognizer(tapOutside);

            StartDateTextField.AttributedPlaceholder = new Foundation.NSAttributedString(
                "Start Date: ", null, UIColor.Red);
            EndDateTextField.AttributedPlaceholder = new Foundation.NSAttributedString(
                "End Date: ", null, UIColor.Red);

            SourceTextField.AttributedPlaceholder = new Foundation.NSAttributedString(
                "Source: ", null, UIColor.Red);

            DestinationTextField.AttributedPlaceholder = new Foundation.NSAttributedString(
                "Destination: ", null, UIColor.Red);

            CustomerTextField.AttributedPlaceholder = new Foundation.NSAttributedString(
                "Customer: ", null, UIColor.Red);


            Picker(StartDateTextField);
            Picker(EndDateTextField);
        }

        public override void ViewDidAppear(bool animated)
        {

            base.ViewDidAppear(animated);

            //code to make custom pickers

            PickerFiller pFill = new PickerFiller();
            //gets the sources from the database
            List<string> sources = pFill.FillSourcePicker();
            //makes a custom picker to hold the sources attached to the SourceTextField
            PickerMaker(sources, SourceTextField);
            //gets customers from the database
            List<string> customers = pFill.FillCustomerPicker();
            //makes a custom picker to hold the customers attached to the CustomerTextField
            PickerMaker(customers, CustomerTextField);
            //gets the destinations from the database
            List<string> destinations = pFill.FillDestinationPicker();
            //makes a custompicker totheld the destinations attached to the DestinationTextField
            PickerMaker(destinations, DestinationTextField);

            //end custom pickers
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        //creates the date pickers
        public void Picker(UITextField textField)
        {
            var datePicker = new UIDatePicker();
            datePicker.Mode = UIDatePickerMode.Date;
            textField.InputView= datePicker;
            datePicker.ValueChanged += (sender, e) =>
             {
                 NSDateFormatter dateFormat = new NSDateFormatter
                 {
                     DateFormat = "MM/dd/yyyy"
                 };
                 textField.Text = dateFormat.ToString(datePicker.Date);
                 ResignFirstResponder();
             };
        }

        //creats custom pickers attached to textfields
        public void PickerMaker(List<string> data, UITextField field)
        {
            List<string> data2 = data;
            var pickerView = new UIPickerView();
            var viewModel = new NameModel(data);
            pickerView.Model = viewModel;
            pickerView.ShowSelectionIndicator = true;
            field.InputView = pickerView;
            viewModel.textChanged += (sender, e) =>
              {
                  field.Text = viewModel.textNow;
                  field.ResignFirstResponder();
              };

        }


        //button that gets the information after the pickers are selected
        partial void SearchButton_TouchUpInside(UIButton sender)
        {
            List<Transaction> transactions = new List<Transaction>();
            if((StartDateTextField.Text != "")&&(EndDateTextField.Text != "")&&
              (SourceTextField.Text != "")&&(DestinationTextField.Text != "")&&
               (CustomerTextField.Text !=""))
            {
                Transaction transaction = new Transaction(StartDateTextField.Text,
                                                         EndDateTextField.Text, SourceTextField.Text,
                                                          DestinationTextField.Text, CustomerTextField.Text);
                // gets the transactions from the database based on selections 
                WebService.WebService ws = new WebService.WebService();
               transactions =  ws.GetSelectedTransactions(transaction);

                FillTextView(transactions);
            }
        }

        public void FillTextView(List<Transaction>transactions)
        {
            int numberOfLoads = transactions.Count;
            double totalGrossWeight = 0;
            double totalTareWeight = 0;
            double totalTons = 0;

            foreach(var truck in transactions)
            {
                totalGrossWeight += Convert.ToDouble(truck.grossWeight);
                totalTareWeight += Convert.ToDouble(truck.tareWeight);
                
            }
            totalTons = (totalGrossWeight - totalTareWeight) / 2000;
            ResultTextView.Text = "Number of loads: " + numberOfLoads + "\nTotal Gross Weight: " + totalGrossWeight +
                  "\nTotal Tare Weight: " + totalTareWeight + "\nTotal Tons: " + totalTons;
        }

        partial void ClearButton_TouchUpInside(UIButton sender)
        {
            StartDateTextField.Text = "";
            EndDateTextField.Text = "";
            SourceTextField.Text = "";
            DestinationTextField.Text = "";
            CustomerTextField.Text = "";
            ResultTextView.Text = "";
        }

        partial void BackToMainView(UIButton sender)
        {
            //get Reference to storyBoard
            UIStoryboard storyboard = this.Storyboard;
            //create instance of view controller
            UIViewController viewController =
                (UIViewController)storyboard.InstantiateViewController("MainScreenViewController");
            viewController.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
            this.PresentViewController(viewController, true, null);
        }
    }
}
