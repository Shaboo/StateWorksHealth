using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using StatWorks.Models;
using StatWorks.Services;
using StatWorks.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace StatWorks.ViewModels
{
    [Preserve(AllMembers = true)]
    public class BMIViewModel : BaseViewModel
    {
        public ObservableCollection<string> GenderItems { get; }

        double _height;
        public double Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        double _weight;
        public double Weight
        {
            get
            {
                return _weight;
            }

            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        int _age;
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        double _waist;
        public double Waist
        {
            get
            {
                return _waist;
            }

            set
            {
                _waist = value;
                OnPropertyChanged(nameof(Waist));
            }
        }

        double _hip;
        public double Hip
        {
            get
            {
                return _hip;
            }

            set
            {
                _hip = value;
                OnPropertyChanged(nameof(Hip));
            }
        }

        string _selectedGenderItem;
        public string SelectedGenderItem
        {
            get
            {
                return _selectedGenderItem;
            }

            set
            {
                _selectedGenderItem = value;
                OnPropertyChanged(nameof(SelectedGenderItem));
            }
        }

        public IAsyncCommand SubmitCommand
        {
            get;
            private set;
        }

        public BMIViewModel()
        {
            SubmitCommand = new AsyncCommand(Submit, CanSubmit);
            GenderItems = new ObservableCollection<string>
            {
                "Male",
                "Female"
            };
        }

        private bool CanSubmit(object arg)
        {
            return this.IsNotBusy;
        }

        private async Task Submit()
        {
            try
            {
                this.IsBusy = true;

                if (this.Height <= 0)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Please insert Height valid value", "OK");
                    return;
                }


                if (this.Weight <= 0)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Please insert Weight valid value", "OK");
                    return;
                }

                if (this.Age <= 0)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Please insert Age valid value", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.SelectedGenderItem))
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Please Select Gender Value", "OK");
                    return;
                }

                BodyMetrics bodyMetrics = new BodyMetrics
                {
                    weight = new Weight
                    {
                        value = this.Weight,
                        unit = "kg"
                    },
                    height = new Height
                    {
                        value = this.Height,
                        unit = "cm"
                    },
                    sex = SelectedGenderItem == "Male" ? "m" : "f",
                    age = this.Age,
                    hip = this.Hip,
                    waist = this.Waist
                };

                BMIApiResponse res =  await BMIApiClient.Instance.PostBMI(bodyMetrics);
                await App.Current.MainPage.Navigation.PushAsync(new BMIResult(res), true);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}
