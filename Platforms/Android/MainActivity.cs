using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Widget;

namespace Interactive_Event_Maps
{
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
	[IntentFilter(
		new[] { Microsoft.Maui.ApplicationModel.Platform.Intent.ActionAppAction },
		Categories = new[] { Intent.CategoryDefault })]
	public class MainActivity : MauiAppCompatActivity
	{
		protected override async void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Platform.Init(this, bundle);
			await Platform.WaitForActivityAsync();
		}

		protected override void OnResume()
		{
			base.OnResume();

			Platform.OnResume(this);
		}

		protected override void OnNewIntent(Intent intent)
		{
			base.OnNewIntent(intent);

			Platform.OnNewIntent(intent);
		}


		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

	}
}

[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(new[] { Intent.ActionView },
			  Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
			  DataScheme = CALLBACK_SCHEME,
			  DataHost = CALLBACK_HOST)]
public class WebAuthenticationCallbackActivity : Microsoft.Maui.Authentication.WebAuthenticatorCallbackActivity
{
	const string CALLBACK_SCHEME = "myapp";
	const string CALLBACK_HOST = "callback";
}
