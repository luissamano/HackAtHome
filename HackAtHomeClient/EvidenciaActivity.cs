
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
using HackAtHome.SAL;
using System.Security.Policy;
using HackAtHome.CustomAdapters;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using HackAtHome.Entities;
using System.Dynamic;

namespace HackAtHomeClient
{
    [Activity(Label = "EvidenciaActivity")]
    public class EvidenciaActivity : Activity
    {
        string Email;
        string Pass;
        EvidencesFragment evidencias;
        ListView lvEvidencia;
        ProgressDialog progress;

        protected  override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Datos);

			if (Intent != null)
			{
				Email = Intent.GetStringExtra("email");
				Pass = Intent.GetStringExtra("pass");
			}

            lvEvidencia = FindViewById<ListView>(Resource.Id.lvEvidencia);
            var txName = FindViewById<TextView>(Resource.Id.txName);
            txName.Text = Pass;

			lvEvidencia.ItemClick += (sender, e) =>
			{
				var ActivityIntent =
					new Intent(this, typeof(EvidencesDetail));
				ActivityIntent.PutExtra("Email", Email);
				ActivityIntent.PutExtra("Pass", Pass);
				ActivityIntent.PutExtra("EvidenceID", evidencias.Evidences[e.Position].EvidenceID);
				ActivityIntent.PutExtra("Title", evidencias.Evidences[e.Position].Title);
				ActivityIntent.PutExtra("Status", evidencias.Evidences[e.Position].Status);
				StartActivity(ActivityIntent);
			};

            evidencias = new EvidencesFragment();
            if (evidencias.Evidences == null)
            {
                progress = new Android.App.ProgressDialog(this);
                progress.Indeterminate = true;
                progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
                progress.SetMessage("Please...");
                progress.SetCancelable(false);
                progress.Show();

                var fragmentTransaction = this.FragmentManager.BeginTransaction();
                fragmentTransaction.Add(evidencias, "Evidences");
                fragmentTransaction.Commit();

                GetEvidences();
                progress.Cancel();
            }
            else
            {
                lvEvidencia.Adapter = evidencias.EvidencesAdapter;
            }

        }

        private async void GetEvidences()
        {

            var ServiceClient = new HackAtHome.SAL.ServiceClient();
            evidencias.Evidences = await ServiceClient.GetEvidencesAsync(Email);

            evidencias.EvidencesAdapter =
                new ServicioWEBAPI(
                        this,
                        evidencias.Evidences,
                        Resource.Layout.ListItem,
                        Resource.Id.title,
                        Resource.Id.sub);

            lvEvidencia.Adapter = evidencias.EvidencesAdapter;

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
