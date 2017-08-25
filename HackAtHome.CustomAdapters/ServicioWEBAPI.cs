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

namespace HackAtHome.CustomAdapters
{
	public class ServicioWEBAPI : BaseAdapter<Evidence>
	{
		List<Evidence> Items; // Datos de cada evidencia de laboratorio.
		Activity Context; // Activity donde se utilizará este adapter.
		int ItemLayoutTemplate; // Layout a utilizar para mostrar los datos de un elemento.
		int EvidenceTitleViewID; // ID del TextView donde se mostrar el nombre de la evidencia.
		int EvidenceStatusViewID; // ID del TextView donde se mostrar el estatus de la evidencia.

		//Constructor
		public ServicioWEBAPI(Activity context, List<Evidence> evidences, int
			itemLayoutTemplate, int evidenceTitleViewID, int evidenceStatusViewID)
		{
			this.Context = context;
			this.Items = evidences;
			this.ItemLayoutTemplate = itemLayoutTemplate;
			this.EvidenceTitleViewID = evidenceTitleViewID;
			this.EvidenceStatusViewID = evidenceStatusViewID;
		}

		public override Evidence this[int position]
		{
			get
			{
				return Items[position];
			}
		}

		public override int Count
		{
			get
			{
				return Items.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return Items[position].EvidenceID;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			// Obtenemos el elemento del cual se requiere la vista
			var Item = Items[position];
			View ItemView; // Vista que vamos a devolver
			if (convertView == null)
			{
				// No hay vista reutilizable, crear una nueva
				ItemView = Context.LayoutInflater.Inflate(ItemLayoutTemplate, null
					/*No hay View padre*/);
			}
			else
			{
				// Reutilizamos un View existente para ahorrar recursos
				ItemView = convertView;
			}

			// Establecemos los datos del elemento dentro del View
			ItemView.FindViewById<TextView>(EvidenceTitleViewID).Text = Item.Title;
			ItemView.FindViewById<TextView>(EvidenceStatusViewID).Text = Item.Status;

			return ItemView;
		}

	}
}
