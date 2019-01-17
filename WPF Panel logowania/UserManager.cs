using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Panel_logowania
{
	public static class UserManager
	{
		private static User _loggedInUser;

		public static void SignIn(User user)
		{
			_loggedInUser = user;
		}

		public static User GetUser()
		{
			if (_loggedInUser != null)
			{
				return _loggedInUser;
			}
			return null;
		}

		public static void LogOut()
		{
			_loggedInUser = null;
		}

	}
}
