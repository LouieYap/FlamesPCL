using FlamesNew.ViewModel;
using System;
using Xamarin.Forms;

namespace FlamesNew
{
	public partial class MainPage : ContentPage
	{
        MainPageViewModel vm;
        public MainPage()
		{
            vm = new MainPageViewModel();
            BindingContext = vm;
            InitializeComponent();
		}

        async void OnFlamesClicked(object sender, EventArgs e) //Needs to be in view model using task instead
        {

            if (vm.PartnerName.Trim().Length == 0 || vm.Name.Trim().Length == 0)
            {
                var answer = await DisplayAlert("Alert", "Your Name and Partner Name should not be blank", "OK", "Cancel");

                if (answer)
                {
                    vm.ShouldDisplayContentView = false;
                }
            }
        }
    }
}
