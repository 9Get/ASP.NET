namespace LR2.Entities
{
	public class User
	{
		public string Name { get; set; } = "";
		public int Age { get; set; } = 0;

		public override string ToString()
		{
			return $"Name: {Name};\nAge: {Age}.";
		}
	}
}
