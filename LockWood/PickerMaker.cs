using System;
using System.Collections.Generic;
using LockWood.PickerFillers;
using UIKit;
namespace LockWood
{
    public class PickerMaker
    {
        public PickerMaker(List<string> data, UITextField textField)
        {
            List<string> data2 = data;
            var pickerView = new UIPickerView();
            var viewModel = new NameModel(data);
            pickerView.Model = viewModel;
            pickerView.ShowSelectionIndicator = true;
            textField.InputView = pickerView;
            viewModel.textChanged += (sender, e) =>
            {
                textField.Text = viewModel.textNow;
                textField.ResignFirstResponder();
            };
        }
    }
}
