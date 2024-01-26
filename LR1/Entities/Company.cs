using System;

namespace LR1.Entities
{
	public class Company
	{
		public string Name { get; set; }
		public string Address{ get; set; }
		public uint BranchesNumber { get; set; }

		public Company()
		{
			Name = string.Empty;
			Address = string.Empty;
			BranchesNumber = 0;
		}
		public Company(string name, string address, uint brachesNumber)
		{
			Name = name;
			Address = address;
			BranchesNumber = brachesNumber;
		}

		public override string ToString()
		{
			return $"Name: {Name};\nAddress: {Address};\nNumber of branches: {BranchesNumber}.\n";
		}
	}
}