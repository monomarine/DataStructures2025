using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
	internal class Student
	{
		public string FullName { get; set; }
		public float AverageScore { get; set; }

		public Student(string fullName, float averageScore)
		{
			FullName = fullName;
			AverageScore = averageScore;
		}
	}
}
