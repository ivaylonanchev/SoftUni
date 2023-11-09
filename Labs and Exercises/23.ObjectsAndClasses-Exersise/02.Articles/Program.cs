using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(", ").ToList();
            Article article = new Article()
            {
                Title = list[0],
                Content = list[1],
                Author = list[2]
            };
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] a = Console.ReadLine().Split(": ");
                string comand = a[1];
                if (a[0] == "Edit")
                {
                    article.Edit(comand);
                }
                else if (a[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(comand);
                }
                else if (a[0] == "Rename")
                {
                    article.Rename(comand);
                }
            }
            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");

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
        public void Edit(string content)
        {
            Content = content;
        }
        public void ChangeAuthor(string author)
        {
            Author = author;
        }
        public void Rename(string name)
        {
            Title = name;
        }
    }
}