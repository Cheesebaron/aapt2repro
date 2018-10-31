using MvvmCross.ViewModels;

namespace MyMvvmCrossApp.Core.ViewModels.Main
{
    public class AnimalViewModel : MvxNotifyPropertyChanged
    {
        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set => SetProperty(ref _imageUrl, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }

    public class DogViewModel : AnimalViewModel
    {

    }

    public class CatViewModel : AnimalViewModel
    {

    }
}
