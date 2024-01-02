using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WPFDeskManager.Utilities
{
    public class DefaultDataView : Control
    {
        static DefaultDataView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DefaultDataView), new FrameworkPropertyMetadata(typeof(DefaultDataView)));
        }

        public static readonly DependencyProperty ViewTitleProperty =
            DependencyProperty.Register("ViewTitle", typeof(string), typeof(DefaultDataView), new PropertyMetadata(""));

        public string ViewTitle
        {
            get { return (string)GetValue(ViewTitleProperty); }
            set { SetValue(ViewTitleProperty, value); }
        }

        public static readonly DependencyProperty AddButtonTextProperty =
            DependencyProperty.Register("AddButtonText", typeof(string), typeof(DefaultDataView), new PropertyMetadata(""));

        public string AddButtonText
        {
            get { return (string)GetValue(AddButtonTextProperty); }
            set { SetValue(AddButtonTextProperty, value); }
        }

        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(DefaultDataView), new PropertyMetadata(false));

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register("Content", typeof(object), typeof(DefaultDataView), new PropertyMetadata(null));

        public object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
    }
}
