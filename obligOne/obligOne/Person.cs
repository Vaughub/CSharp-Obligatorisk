using System.Collections.Generic;

namespace obligOne
{
	public class Person
	{
		public int Id;
		public string FirstName;
		public string LastName;
		public int BirthYear;
		public int DeathYear;
		public Person Mother;
		public Person Father;

		public string GetDescription()
		{
			List<string> list = new List<string>();

			if(FirstName != null) list.Add(FirstName);
			if(LastName != null) list.Add(LastName);
			if(Id != 0) list.Add($"(Id={Id})");
			if(BirthYear != 0) list.Add($"Født: {BirthYear}");
			if(DeathYear != 0) list.Add($"Død: {DeathYear}");
			list.Add(GetParents());

			return string.Join(" ", list).Trim();
		}

		private string GetParents()
		{
			List<string> list = new List<string>();

			if (Father != null && (Father.FirstName != null || Father.Id != 0))
			{
				list.Add("Far:");
				if (Father.FirstName != null) list.Add(Father.FirstName);
				if (Father.Id != 0) list.Add($"(Id={Father.Id})");
			}

			if (Mother != null && (Mother.FirstName != null || Mother.Id != 0))
			{
				list.Add("Mor:");
				if (Mother.FirstName != null) list.Add(Mother.FirstName);
				if (Mother.Id != 0) list.Add($"(Id={Mother.Id})");
			}

			return string.Join(" ", list);
		}

		public string GetChildren()
		{
			List<string> list = new List<string>();

			if (FirstName != null) list.Add(FirstName);
			if (Id != 0) list.Add($"(Id={Id})");
			if (BirthYear != 0) list.Add($"Født: {BirthYear}");

			return "    " + string.Join(" ", list);
		}

		/*public string GetDescription()
		{
			var temp = new StringBuilder();

			temp.Append(FirstName == null ? "" : $"{FirstName} ");
			temp.Append(LastName == null ? "" : $"{LastName} ");
			temp.Append(Id == 0 ? "" : $"(Id={ Id}) ");
			temp.Append(BirthYear == 0 ? "" : $"Født: {BirthYear} ");
			temp.Append(DeathYear == 0 ? "" : $"Død: {DeathYear} ");
			temp.Append((Father == null ? "" : Father.FirstName == null ? "Far: " : $"Far: {Father.FirstName} ") + (Father == null || Father.Id == 0 ? "" : $"(Id={Father.Id}) "));
			temp.Append((Mother == null ? "" : Mother.FirstName == null ? "Mor: " : $"Mor: {Mother.FirstName} ") + (Mother == null || Mother.Id == 0 ? "" : $"(Id={Mother.Id})"));

			return temp.ToString().Trim();
		}*/
	}
}
