using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
	internal class User
	{
		public string FullName { get; set; } = "";
		public DateTime BirthDate { get; set; }

		public int Age { get => DateTime.Now.Year - BirthDate.Year; }

		public User(string fullName, DateTime birthDate)
		{
			this.FullName = fullName;
			this.BirthDate = birthDate;
		}

		public override string ToString()
		{
			return FullName;
		}
	}
}
