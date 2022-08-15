using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        public DateTime _time;
        public Page1()
        {
            InitializeComponent();
            this.BindingContext = new[] { "Türkiye", "Almanya", "Polonya" };
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimeTick);

        }

        bool OnTimeTick()
        {
            if (_switch.IsToggled && DateTime.Now >= _time)
            {
                _switch.IsToggled = false;
                DisplayAlert("Uyarı" ,"Notunuz:" + _entry.Text + " Eklenmiştir.", "Tamam");
            }
            return true;
        }
        public void TimePickerPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Time")
            {
                SetTriggerTime();
            }
        }

         void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            SetTriggerTime();
        }

       void SetTriggerTime()
        {
            _time = DateTime.Today + _timePicker.Time;


            if (_time < DateTime.Now)
            {
                _time += TimeSpan.FromDays(1);
            }


        }
    }
}