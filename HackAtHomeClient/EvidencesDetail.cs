
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Webkit;
using Android.Graphics;
using static HackAtHome.Entities.Modelos;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace HackAtHomeClient
{
    [Activity(Label = "EvidencesDetail")]
    public class EvidencesDetail : Activity
    {

		string name;
		string pass;
		int EvidenceId;
		string TitleEvidence;
		string Status;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.EvidencesDetail);

			if (Intent != null)
			{
				name = Intent.GetStringExtra("Email");
				pass = Intent.GetStringExtra("Pass");
				EvidenceId = Intent.GetIntExtra("EvidenceID", 0);
				TitleEvidence = Intent.GetStringExtra("Title");
				Status = Intent.GetStringExtra("Status");
			}

			FindViewById<TextView>(Resource.Id.textViewName).Text = pass;
			FindViewById<TextView>(Resource.Id.textViewTitle).Text = TitleEvidence;
			FindViewById<TextView>(Resource.Id.textViewStatus).Text = Status;

			var ServiceClient = new HackAtHome.SAL.ServiceClient();

			EvidenceDetail EvidenceDetailByID = await ServiceClient.GetEvidenceByIDAsync(name, EvidenceId);

			var WebViewDescription = FindViewById<WebView>(Resource.Id.webViewDescription);


			WebViewDescription.LoadDataWithBaseURL(
				null, EvidenceDetailByID.Description,
				"text/html", "utf-8", null);
			WebViewDescription.SetBackgroundColor(Color.Transparent);

			var ImageEvidence = FindViewById<ImageView>(Resource.Id.imageViewEvidence);

			Koush.UrlImageViewHelper.SetUrlDrawable(ImageEvidence, EvidenceDetailByID.Url);
		}


		int Counter = 0;

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