using Android.App;
using Android.Widget;
using Android.OS;
using HackAtHome.SAL;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using static HackAtHome.Entities.Modelos;
using Android.Views;

namespace HackAtHomeClient
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true)]
    public class MainActivity : Activity
    {

        //FloatingActionButton fab;

        int Counter = 0;
        Toolbar toolbar;
        EditText etCorreo, etPass;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);



            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            etCorreo = FindViewById<EditText>(Resource.Id.etCorreo);
            etPass = FindViewById<EditText>(Resource.Id.etPass);



            FindViewById<Button>(Resource.Id.btnValidar).Click += async (sender, e) =>
            {
                var ServiceClient = new HackAtHome.SAL.ServiceClient();

                var Result =
                    await ServiceClient.AutenticateAsync(
                        etCorreo.Text.ToString(), etPass.Text.ToString());

                if (Result.Status == Status.Success)
                {

                    SendEvidence();


                    Toast.MakeText(this,
                                   "Status Success",
                                   ToastLength.Short).Show();
                    
                    
                    var ActivityIntent =
                        new Android.Content.Intent(this, typeof(EvidenciaActivity));
                    ActivityIntent.PutExtra("email", Result.Token);
                    ActivityIntent.PutExtra("pass", Result.FullName);
                    StartActivity(ActivityIntent);
                }
                else
                {
                    Toast.MakeText(this,
                                   $"{Result.Status}\n{Result.FullName}\n{Result.Token}",
                                   ToastLength.Long).Show();
                }



            };


        }

		


		public async void SendEvidence()
		{
			var MicrosoftEvidence = new LabItem
			{
				Email = etCorreo.Text.ToString(),
				Lab = "Hack@Home",
				DeviceId = Android.Provider.Settings.Secure.GetString(
					ContentResolver, Android.Provider.Settings.Secure.AndroidId)
			};

			var MicrosoftClient = new HackAtHome.SAL.MicrosoftServiceClient();
			await MicrosoftClient.SendEvidence(MicrosoftEvidence);
		}


		protected override void OnSaveInstanceState(Bundle outState)
		{
			outState.PutInt("CounterValue", Counter);

			base.OnSaveInstanceState(outState);
		}

		protected override void OnStart()
		{
			base.OnStart();
		}

		protected override void OnResume()
		{
			base.OnResume();
		}

		protected override void OnPause()
		{
			base.OnPause();
		}

		protected override void OnStop()
		{
			base.OnStop();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
		}

		protected override void OnRestart()
		{
			base.OnRestart();
		}

    }
}