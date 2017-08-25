
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
using static HackAtHome.Entities.Modelos;
using static HackAtHome.CustomAdapters.ServicioWEBAPI;

namespace HackAtHomeClient
{
	public class EvidencesFragment : Fragment
	{
		public List<Evidence> Evidences { get; set; }
		public BaseAdapter EvidencesAdapter { get; set; }

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			RetainInstance = true;
		}


	}
}
