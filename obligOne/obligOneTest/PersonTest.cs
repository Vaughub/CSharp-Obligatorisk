using NUnit.Framework;
using obligOne;

namespace obligOneTest
{
	public class PersonTest
	{
		[Test]
		public void TestAllFields()
		{
			var p = new Person
			{
				Id = 17,
				FirstName = "Ola",
				LastName = "Nordmann",
				BirthYear = 2000,
				DeathYear = 3000,
				Father = new Person() { Id = 23, FirstName = "Per" },
				Mother = new Person() { Id = 29, FirstName = "Lise" },
			};

			var actualDescription = p.GetDescription();
			var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

			Assert.AreEqual(expectedDescription, actualDescription);
		}

		[Test]
		public void TestNoFields()
		{
			var p = new Person
			{
				Id = 1,
			};

			var actualDescription = p.GetDescription();
			var expectedDescription = "(Id=1)";

			Assert.AreEqual(expectedDescription, actualDescription);
		}

		[Test]
		public void TestSomeFields()
		{
			var p = new Person
			{
				Id = 22,
				FirstName = "Ola",
				DeathYear = 1798,
				Mother = new Person() {Id = 6}
			};

			var actualDescription = p.GetDescription();
			var expectedDescription = "Ola (Id=22) Død: 1798 Mor: (Id=6)";

			Assert.AreEqual(expectedDescription, actualDescription);
		}

		[Test]
		public void TestSomeFields2()
		{
			var p = new Person
			{
				Id = 22,
				BirthYear = 1704,
				Father = new Person() {FirstName = "Per"},
				Mother = new Person() {FirstName = "Eva", Id = 6}
			};

			var actualDescription = p.GetDescription();
			var expectedDescription = "(Id=22) Født: 1704 Far: Per Mor: Eva (Id=6)";

			Assert.AreEqual(expectedDescription, actualDescription);
		}
	}
}