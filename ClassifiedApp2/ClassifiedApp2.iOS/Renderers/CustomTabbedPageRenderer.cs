using System;
using ClassifiedApp2.Views;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using ClassifiedApp2.iOS.Renderers;

//[assembly: ExportRenderer(typeof(RootTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace ClassifiedApp2.iOS.Renderers
{
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            SetSearchToolbar();
        }

        public override void WillMoveToParentViewController(UIKit.UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);

            if (parent != null)
            {
                parent.NavigationItem.RightBarButtonItem = NavigationItem.RightBarButtonItem;
                parent.NavigationItem.TitleView = NavigationItem.TitleView;
            }
        }

        private void SetSearchToolbar()
        {
            var element = Element as RootTabbedPage;
            if (element == null)
            {
                return;
            }

            var width = NavigationController.NavigationBar.Frame.Width;
            var height = NavigationController.NavigationBar.Frame.Height;
            var searchBar = new UIStackView(new CGRect(0, 0, width * 0.85, height));

            searchBar.Alignment = UIStackViewAlignment.Center;
            searchBar.Axis = UILayoutConstraintAxis.Horizontal;
            searchBar.Spacing = 3;

            var searchTextField = new UITextField();
            searchTextField.BackgroundColor = UIColor.FromRGB(239, 239, 239);
            NSAttributedString strAttr = new NSAttributedString("Search", foregroundColor: UIColor.FromRGB(146, 146, 146));
            searchTextField.AttributedPlaceholder = strAttr;
            searchTextField.SizeToFit();

            // Delete button
            UIButton textDeleteButton = new UIButton(new CGRect(0, 0, searchTextField.Frame.Size.Height + 5, searchTextField.Frame.Height));
            textDeleteButton.Font = UIFont.FromName("FontAwesome", 18f);
            textDeleteButton.BackgroundColor = UIColor.Clear;
            textDeleteButton.SetTitleColor(UIColor.FromRGB(146, 146, 146), UIControlState.Normal);
            textDeleteButton.SetTitle("\uf057", UIControlState.Normal);
            textDeleteButton.TouchUpInside += (sender, e) =>
            {
                searchTextField.Text = string.Empty;
            };

            searchTextField.RightView = textDeleteButton;
            searchTextField.RightViewMode = UITextFieldViewMode.Always;

            // Border
            searchTextField.BorderStyle = UITextBorderStyle.RoundedRect;
            searchTextField.Layer.BorderColor = UIColor.FromRGB(239, 239, 239).CGColor;
            searchTextField.Layer.BorderWidth = 1;
            searchTextField.Layer.CornerRadius = 5;
            searchTextField.EditingChanged += (sender, e) =>
            {
                element.SetValue(RootTabbedPage.SearchTextProperty, searchTextField.Text);
            };

            searchBar.AddArrangedSubview(searchTextField);

            var searchbarButtonItem = new UIBarButtonItem(searchBar);
            NavigationItem.SetRightBarButtonItem(searchbarButtonItem, true);

            NavigationItem.TitleView = new UIView();

            if (ParentViewController != null)
            {
                ParentViewController.NavigationItem.RightBarButtonItem = NavigationItem.RightBarButtonItem;
                ParentViewController.NavigationItem.TitleView = NavigationItem.TitleView;
            }
        }
    }
}
