namespace LR4.interfaces
{
	public interface IUsersService
	{
		public string GetUserByID(int id);
		public string GetCurrentUser();
	}
}
