using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace MyMvvmCrossApp.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        private string _hello = "Select An Animal Above";
        public string Hello
        {
            get => _hello;
            set => SetProperty(ref _hello, value);
        }

        public MvxObservableCollection<AnimalViewModel> Animals { get; }
            = new MvxObservableCollection<AnimalViewModel>();

        private AnimalViewModel _selectedAnimal;
        public AnimalViewModel SelectedAnimal
        {
            get => _selectedAnimal;
            set => SetProperty(ref _selectedAnimal, value);
        }

        public MvxCommand<AnimalViewModel> ItemClickCommand { get; }
        public MvxCommand ButtonClickCommand { get; }

        public MainViewModel()
        {
            ItemClickCommand = new MvxCommand<AnimalViewModel>(OnAnimalClicked);
            ButtonClickCommand = new MvxCommand(OnButtonClicked);

            var dogImageUrls = new string[]
            {
                "https://pbs.twimg.com/profile_images/1046968391389589507/_0r5bQLl_400x400.jpg",
                "http://m.aercmn.com/files/aec/ckfinder/images/dog-633562.jpg",
                "https://cdn.psychologytoday.com/sites/default/files/styles/article-inline-half/public/field_blog_entry_images/2018-02/vicious_dog_0.png",
                "https://www.nationalgeographic.com/content/dam/animals/thumbs/rights-exempt/mammals/d/domestic-dog_thumb.ngsversion.1484159404151.adapt.1900.1.jpg"
            };

            var dogNames = new string[]
            {
                "Blitz",
                "Bones",
                "Chevy",
                "Ewok",
                "Jethro",
                "Snookie",
                "Puddin",
                "Biscuit",
                "Cha-Cha"
            };

            var catImageUrls = new string[]
            {
                "https://www.petmd.com/sites/default/files/petmd-kitten-development.jpg",
                "https://www.petmd.com/sites/default/files/small-kitten-walking-towards_127900829_0.jpg",
                "https://static1.squarespace.com/static/54e8ba93e4b07c3f655b452e/t/56c2a04520c64707756f4267/1493764650017/",
                "https://animalcenter.org/wp-content/uploads/2018/06/Oreo-Belly.jpg"
            };

            var catNames = new string[]
            {
                "Dusky",
                "Daisy",
                "Ms Liegewumps",
                "Tiger",
                "Stripes",
                "Olive",
                "Latte",
                "Panda",
                "Patch"
            };

            var random = new Random();

            IEnumerable<AnimalViewModel> dogs = Enumerable.Range(0, 20).Select(_ =>
                new DogViewModel
                {
                    Name = dogNames[random.Next(dogNames.Length - 1)],
                    ImageUrl = dogImageUrls[random.Next(dogImageUrls.Length - 1)]
                });

            IEnumerable<AnimalViewModel> cats = Enumerable.Range(0, 20).Select(_ =>
                new CatViewModel
                {
                    Name = catNames[random.Next(catNames.Length - 1)],
                    ImageUrl = catImageUrls[random.Next(catImageUrls.Length - 1)]
                });

            Animals.AddRange(dogs.Concat(cats).OrderBy(_ => Guid.NewGuid()));
        }

        private void OnButtonClicked()
        {
            if (SelectedAnimal == null)
                return;


        }

        private void OnAnimalClicked(AnimalViewModel obj)
        {
            SelectedAnimal = obj;

            if (obj is DogViewModel)
            {
                Hello = "Woof, Woof!";
            }
            else if (obj is CatViewModel)
            {
                Hello = "Meow, Meow!";
            }
        }
    }
}
