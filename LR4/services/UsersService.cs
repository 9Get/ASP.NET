using LR4.entities;
using LR4.interfaces;
using System.Text;
using System.Text.Json;

namespace LR4.services
{
	public class UsersResponse
	{
		public List<User> Users { get; set; }
	}

	public class UsersService : IUsersService
	{
		public string GetCurrentUser()
		{
			string jsonString = File.ReadAllText("currentUser.json");

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			var user = JsonSerializer.Deserialize<User>(jsonString, options);

			return user.ToString();
		}

		public string GetUserByID(int id)
		{
			if (id < 0)
			{
				throw new ArgumentException("ID should be greater or equal 0", nameof(id));
			}

			string jsonString = File.ReadAllText("users.json");

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			var usersResponse = JsonSerializer.Deserialize<UsersResponse>(jsonString, options);

			foreach (var user in usersResponse.Users)
			{
				if (user.ID == id)
				{
					return user.ToString();
				}
			}

			return GetCurrentUser();
		}
	}
}
