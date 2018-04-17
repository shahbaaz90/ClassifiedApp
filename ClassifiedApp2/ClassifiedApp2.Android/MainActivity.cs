using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using ClassifiedApp2.Droid.Services;
using ClassifiedApp2.Services;
using DryIoc;
using Prism;
using Prism.Ioc;
using Xamarin.Facebook;
using Xamarin.Forms;

namespace ClassifiedApp2.Droid
{
    [Activity(Label = "ClassifiedApp2", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        App appInstance;
        public static Toolbar ToolBar { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            FacebookSdk.SdkInitialize(this);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            appInstance = new App(new AndroidInitializer());

            LoadApplication(appInstance);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
           // var dependencyService = new DependencyService();

            base.OnActivityResult(requestCode, resultCode, data);

            var manager = appInstance?.Container?.Resolve<IFacebookManager>();
            if (manager != null)
            {
                (manager as FacebookManager).callbackManager.OnActivityResult(requestCode, (int)resultCode, data);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            ToolBar = FindViewById<Toolbar>(Resource.Id.toolbar);
            return base.OnCreateOptionsMenu(menu);
        }
	}

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
            container.RegisterSingleton<IFacebookManager, FacebookManager>();
        }
    }
}

