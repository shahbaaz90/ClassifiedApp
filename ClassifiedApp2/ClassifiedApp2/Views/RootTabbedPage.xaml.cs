using System;
using System.Collections.Generic;
using System.Windows.Input;
using BottomBar.XamarinForms;
using ClassifiedApp2.Controls;
using Xamarin.Forms;

namespace ClassifiedApp2.Views
{
    public partial class RootTabbedPage : BottomBarPage
    {
        public RootTabbedPage()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty SearchPlaceHolderTextProperty = BindableProperty.Create(
            nameof(SearchPlaceHolderText), 
            typeof(string), 
            typeof(RootTabbedPage), 
            string.Empty);
        public static readonly BindableProperty SearchTextProperty = BindableProperty.Create(
            nameof(SearchText), 
            typeof(string), 
            typeof(RootTabbedPage), 
            string.Empty);
        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(
            nameof(SearchCommand), 
            typeof(ICommand), 
            typeof(RootTabbedPage));

        public string SearchPlaceHolderText
        {
            get
            {
                return (string)GetValue(SearchPlaceHolderTextProperty);
            }
            set
            {
                SetValue(SearchPlaceHolderTextProperty, value);
            }
        }

        public string SearchText
        {
            get
            {
                return (string)GetValue(SearchTextProperty);
            }
            set
            {
                SetValue(SearchTextProperty, value);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return (ICommand)GetValue(SearchCommandProperty);
            }
            set
            {
                SetValue(SearchCommandProperty, value);
            }
        }
    }
}
