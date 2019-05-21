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
    [Register ("SummaryViewController")]
    partial class SummaryViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BackButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EndDateTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SearchButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField StartDateTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TodayButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton YesterdaySummaryButton { get; set; }

        [Action ("BackButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("SearchButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SearchButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("TouchedButtonToday:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchedButtonToday (UIKit.UIButton sender);

        [Action ("YesterdaySummaryButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void YesterdaySummaryButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BackButton != null) {
                BackButton.Dispose ();
                BackButton = null;
            }

            if (EndDateTextField != null) {
                EndDateTextField.Dispose ();
                EndDateTextField = null;
            }

            if (SearchButton != null) {
                SearchButton.Dispose ();
                SearchButton = null;
            }

            if (StartDateTextField != null) {
                StartDateTextField.Dispose ();
                StartDateTextField = null;
            }

            if (TodayButton != null) {
                TodayButton.Dispose ();
                TodayButton = null;
            }

            if (YesterdaySummaryButton != null) {
                YesterdaySummaryButton.Dispose ();
                YesterdaySummaryButton = null;
            }
        }
    }
}