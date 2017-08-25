using System;
namespace HackAtHome.Entities
{
    public class Modelos
    {
		public class Evidence
		{
			public int EvidenceID { get; set; }
			public string Title { get; set; }
			public string Status { get; set; }
		}


		public class EvidenceDetail
		{
			public string Description { get; set; }
			public string Url { get; set; }
		}


		public class LabItem
		{
			public string Id { get; set; }
			public string Email { get; set; }
			public string Lab { get; set; }
			public string DeviceId { get; set; }

		}



		public enum Status
		{
			Error = 0,
			Success = 1,
			InvalidUserOrNotInEvent = 2,
			OutOfDate = 3,
			AllSuccess = 999
		}

		public class ResultInfo
		{
			public Status Status { get; set; }
			// El valor del Token expira después de 10 minutos del último acceso al servicio REST
			public string Token { get; set; }

			public string FullName { get; set; }
		}



		public class UserInfo
		{
			public string Email { get; set; }
			public string Password { get; set; }
			public string EventID { get; set; }
		}


    }
}
