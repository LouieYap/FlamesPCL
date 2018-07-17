using FlamesNew.model;
using FlamesNew.service;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlamesNew.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            flamesService = new FlamesService();
            ShouldDisplayContentView = false;
            DeveloperName = "Louie Hans Yap";
        }

        private FlamesService flamesService; //change to use dependency injection instead
        private string _name;
        private string _partnerName;
        private FlameResult _result;
        private Boolean _shouldDisplayContentView;

        public ICommand FlamesCommand => new Command(OnFlames);

        public string Name
        {
            get => _name; set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string PartnerName
        {
            get => _partnerName; set
            {
                _partnerName = value;
                OnPropertyChanged("PartnerName");
            }
        }

        public FlameResult Result
        {
            get => _result; set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        public Boolean ShouldDisplayContentView
        {
            get => _shouldDisplayContentView; set
            {
                _shouldDisplayContentView = value;
                OnPropertyChanged("ShouldDisplayContentView");
            }
        }

        public string DeveloperName { get; set; }

        

        public event PropertyChangedEventHandler PropertyChanged;


       protected virtual void OnPropertyChanged(string propertyName = null)
       {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }

        private void OnFlames()
        {
            Result = translateResult(Name, PartnerName);
            ShouldDisplayContentView = true;
        
        }



        private FlameResult translateResult(string Name, string PartnerName)
        {
            var result = flamesService.calculateFlames(Name, PartnerName);
            FlameResult fr = new FlameResult();
            switch (result)
            {
                case "F":
                    fr.relationship = "Friends";
                    fr.meaning = "You are Friends";
                    break;
                case "L":
                    fr.relationship = "Lovers";
                    fr.meaning = "You are Lovers";
                    break;
                case "A":
                    fr.relationship = "Attraction";
                    fr.meaning = "You are Attracted";
                    break;
                case "M":
                    fr.relationship = "Married";
                    fr.meaning = "You are Married";
                    break;
                case "E":
                    fr.relationship = "Enemies";
                    fr.meaning = "You are Enemies";
                    break;
                case "S":
                    fr.relationship = "Siblings";
                    fr.meaning = "You are Siblings";
                    break;
            }
            return fr;
        }
    }
}
