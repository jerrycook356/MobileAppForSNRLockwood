// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace LockWood
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CustomerTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DestinationTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EndDateTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField SourceTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField StartDateTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CustomerTextField != null) {
                CustomerTextField.Dispose ();
                CustomerTextField = null;
            }

            if (DestinationTextField != null) {
                DestinationTextField.Dispose ();
                DestinationTextField = null;
            }

            if (EndDateTextField != null) {
                EndDateTextField.Dispose ();
                EndDateTextField = null;
            }

            if (SourceTextField != null) {
                SourceTextField.Dispose ();
                SourceTextField = null;
            }

            if (StartDateTextField != null) {
                StartDateTextField.Dispose ();
                StartDateTextField = null;
            }
        }
    }
}