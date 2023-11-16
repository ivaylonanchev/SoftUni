
namespace _03.Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> list = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] a = Console.ReadLine().Split(", ");
                string title = a[0];
                string content = a[1];
                string author = a[2];

                Article article = new Article()
                {
                    Author = author,
                    Title = title,
                    Content = content
                };
                list.Add(article);

            }
            foreach (Article article in list)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");

            }

        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Article()
        {

        }
    }
}