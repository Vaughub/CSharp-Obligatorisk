using System.Text;
using System.Text.RegularExpressions;

namespace obligOne
{
	public class FamilyApp
	{
		public Person[] Family { get; }
		public readonly string WelcomeMessage = "Slektstre-Program";
		public readonly string CommandPrompt = "Kommando: ";

		public FamilyApp(params Person[] family)
		{
			Family = family;
		}

		public string HandleCommand(string line)
		{
			if (!Regex.IsMatch(line, "(^(hjelp|liste)$|^(vis \\d+)$)")) 
				return "Ugyldig kommando ('hjelp' for å se alle kommandoene)";

			string[] arr = line.Split(" ");
			string command = arr[0];
			if (command == "hjelp") return WriteHelpText();
			if (command == "liste") return ShowEveryoneOnList();
			return command == "vis" ? ShowPersonWithId(arr[1]) : "This shouldn't have happened";
		}

		private string ShowPersonWithId(string idNr)
		{
			int number = int.Parse(idNr);
			var main = new StringBuilder();
			var children = new StringBuilder();
			foreach (var person in Family)
			{
				if (person.Id == number) main.Append(person.GetDescription() + "\n");
				if (person.Mother != null && person.Mother.Id == number || person.Father != null && person.Father.Id == number)
					children.Append(person.GetChildren() + "\n");
			}
			if (main.Length == 0) return "Person ikke funnet";
			string childTag = children.Length > 0 ? "  Barn:\n" : "";

			return main + childTag + children;
		}

		private string ShowEveryoneOnList()
		{
			var tempFamily = new StringBuilder();
			foreach (var person in Family)
			{
				tempFamily.AppendLine(person.GetDescription());
			}

			return tempFamily.ToString();
		}

		private string WriteHelpText()
		{
			return   "hjelp     Viser en hjelpetekst som forklarer alle kommandoene\n"
			       + "liste     Lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert\n"
			       + "vis <id>  Viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem)\n";
		}
	}
}
