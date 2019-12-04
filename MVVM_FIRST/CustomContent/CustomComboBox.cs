using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_FIRST.CustomContent
{

    [TemplatePart(Name ="DataGrid" , Type = typeof(DataGrid))]
    [TemplatePart(Name = "Col" , Type = typeof(DataGridTextColumn))]
    public class CustomComboBox : Control
    {
        static CustomComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomComboBox), new FrameworkPropertyMetadata(typeof(CustomComboBox)));
        }
        #region Private Memebers
        private DataGrid dataGrid;
        private DataGridTextColumn col;
        #endregion
 

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // Code to get the Template parts as instance member
            dataGrid = GetTemplateChild("DataGrid") as DataGrid;
            col = GetTemplateChild("Col") as DataGridTextColumn;

            if (dataGrid == null )
            {
                throw new NullReferenceException("Template parts not available");
            }
        }

        public static readonly DependencyProperty ListBinding =
            DependencyProperty.Register("ListBinding", typeof(string), typeof(CustomComboBox), new
               PropertyMetadata("", new PropertyChangedCallback(OnListBindingChanged)));

        public List<Object> listElement
        {
            get { return (List<Object>)GetValue(ListBinding); }
            set { SetValue(ListBinding, value); }
        }



        private static void OnListBindingChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            CustomComboBox UserControl1Control = d as CustomComboBox;
            UserControl1Control.OnListBindingChanged(e);
        }

        private void OnListBindingChanged(DependencyPropertyChangedEventArgs e)
        {
            dataGrid.ItemsSource = e.NewValue.ToString();
        }
    }
}
