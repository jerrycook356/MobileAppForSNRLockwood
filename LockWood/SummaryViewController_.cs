using Foundation;
using System;
using UIKit;

namespace LockWood
{
    public partial class SummaryViewController : UIViewController
    {
       ViewChanger viewChanger ;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var tapOutside = new UITapGestureRecognizer(() => View.EndEditing(true));
            tapOutside.CancelsTouchesInView = false;
            View.AddGestureRecognizer(tapOutside);
            StartDateTextField.AttributedPlaceholder = new NSAttributedString("Start Date:", null, UIColor.Red);
            EndDateTextField.AttributedPlaceholder = new NSAttributedString("End Date:", null, UIColor.Red);
            Picker(StartDateTextField);
            Picker(EndDateTextField);
        }

        public SummaryViewController (IntPtr handle) : base (handle)
        {
        }

       
partial void touchedButtonToday(UIButton sender)
        {
            Console.Out.WriteLine("todaySummaryButton touch up inside");
            viewChanger = new ViewChanger(this, "TodaySummaryViewController");
        }

        partial void YesterdaySummaryButton_TouchUpInside(UIButton sender)
        {
            viewChanger = new ViewChanger(this, "YesterdaySummaryViewController");
        }


partial void BackButton_TouchUpInside(UIButton sender)
        {
            viewChanger = new ViewChanger(this, "MainScreenViewController");
        }

partial void SearchButton_TouchUpInside(UIButton sender)
        {

            DateTime startDate = DateTime.ParseExact(StartDateTextField.Text, "MM/dd/yyyy", null);
            DateTime endDate = DateTime.ParseExact(EndDateTextField.Text, "MM/dd/yyyy", null);
            SelectedDateSummaryView sv = new SelectedDateSummaryView();
            DateHolder dt = new DateHolder(startDate, endDate);
            viewChanger = new ViewChanger(this, "SelectedDateSummaryView");

        }

        public void Picker(UITextField textField){
            var datePicker = new UIDatePicker();
            datePicker.Mode = UIDatePickerMode.Date;
            textField.InputView = datePicker;
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
    }
}