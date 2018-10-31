using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MyMvvmCrossApp.Core.ViewModels.Main;

namespace MyMvvmCrossApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
