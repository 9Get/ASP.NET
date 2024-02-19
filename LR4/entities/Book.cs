namespace LR4.entities
{
	public class Book
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public string Genre { get; set; }
		public int YearPublished { get; set; }

		public Book()
		{
			Title = string.Empty;
			Author = string.Empty;
			Genre = string.Empty;
			YearPublished = 0;
		}

		public override string ToString()
		{
			return $"Title: {Title}, Author: {Author}, Genre: {Genre}, Year published: {YearPublished}.";
		}
	}
}
