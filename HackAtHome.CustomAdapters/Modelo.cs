using System;
namespace HackAtHome.CustomAdapters
{
    public class Modelo
    {
		public class ResultInfo
		{
			public Status Status { get; set; }
			// El Token expira después de 10 minutos del último acceso al servicio REST
			public string Token { get; set; }
			public string FullName { get; set; }
		}

		public enum Status
		{
			Error = 0,
			Success = 1,
			InvalidUserOrNotInEvent = 2,
			OutOfDate = 3,
			AllSuccess = 999
		}


		public class UserInfo
		{
			public string Email { get; set; }
			public string Password { get; set; }
			public string EventID { get; set; }
		}

	}
}
