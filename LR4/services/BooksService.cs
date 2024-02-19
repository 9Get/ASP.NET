using LR4.entities;
using LR4.interfaces;
using System.Text;
using System.Text.Json;

namespace LR4.services
{
	public class BooksResponse
	{
		public List<Book> Books { get; set; }
	}

	public class BooksService : IBooksService
	{
		private readonly BooksResponse _response;
		public BooksService() 
		{
			string jsonString = File.ReadAllText("books.json");
			
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			_response = JsonSerializer.Deserialize<BooksResponse>(jsonString, options);
		}
		public string GetBooks()
		{
			if (_response is null)
			{
				throw new InvalidOperationException("Failed to read json file.");
			}

			StringBuilder booksString = new StringBuilder();

			foreach (var book in _response.Books)
			{
				booksString.AppendLine(book.ToString());
			}

			return booksString.ToString();
		}

	}
}
