using System;

namespace Graphs
{
	internal class Student
	{
		public string Name { get; set; }
		public List<double> Grades { get; set; }

		public Student(string name, params double[] grades)
		{
			Name = name;
			Grades = new List<double>(grades ?? Array.Empty<double>());
		}

		public double Average()
		{
			if(Grades == null || Grades.Count == 0) return 0.0;
			double sum = 0.0;
			foreach(double g in Grades) sum += g;
			return sum / Grades.Count;
		}

		public override string ToString() => Name;
	}
}


