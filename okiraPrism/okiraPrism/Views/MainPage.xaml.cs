using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace okiraPrism.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            label.Text = slider.Value.ToString();
        }

        private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            label.Text = e.NewValue.ToString();
        }
    }
}