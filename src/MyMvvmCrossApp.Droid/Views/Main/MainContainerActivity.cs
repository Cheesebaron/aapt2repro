using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyMvvmCrossApp.Core.ViewModels.Main;

namespace MyMvvmCrossApp.Droid.Views.Main
{
    [Activity(
        Theme = "@style/AppTheme", Label = "Woofers and kitters",
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class MainContainerActivity : BaseActivity<MainContainerViewModel>
    {
        protected override int ActivityLayoutId => Resource.Layout.activity_main_container;
    }
}
