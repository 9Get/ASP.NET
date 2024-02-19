namespace LR4.entities
{
	public class User
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public override string ToString()
		{
			return $"ID: {ID};\nName: {Name};\nEmail: {Email};\nPassword: {Password}.\n";
		}
	}
}
