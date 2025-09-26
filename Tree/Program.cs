namespace Tree
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			Tree tree = new Tree();

			User first = new User("Валиков Антон Андреевич", new DateTime(1980, 12, 12));
			User second = new User("Сергеев Владимир Викторович", new DateTime(1999, 10, 10));
			User third = new User("Иванов Иван Иванович", new DateTime(1967, 8, 8));

			tree.AddNode(first);
			tree.AddNode(second);
			tree.AddNode(third);

			List<User> result = tree.TreeTraversal();
			
			foreach(var item in result)
			{
				Console.WriteLine($"ФИО: {item} Дата рождения: {item.BirthDate.ToShortDateString()} Возраст: {item.Age}");
			}

			Console.WriteLine($"Средний возраст => {tree.AverageAge()}");

			Console.ReadKey();
		}
	}
}
