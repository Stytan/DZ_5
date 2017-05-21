using System;

namespace DZ_5
{
    public enum ArticleType { Motherboard, VideoCard, CPU, RAM, Monitor }
    public struct Article
    {
        public int id;
        public string name;
        public double price;
        public ArticleType type;
        public static new bool Equals(object obj1, object obj2)
        {
            return obj1.Equals(obj2);
        }
        public override string ToString()
        {
            return string.Format("ID {0}; {1}; price: {2:0.00}; type: {3}",
                                    id, name, price, type.ToString());
        }
    }
    public enum ClientType { VIP, Gold, Standart }
    public struct Client
    {
        public int id;
        public string name;
        public string address;
        public string tel;
        public int zakazov;
        public double summ;
        public ClientType type;
        public static new bool Equals(object obj1, object obj2)
        {
            return obj1.Equals(obj2);
        }
    }
    public struct RequestItem
    {
        public Article anArticle;
        public int count;
        public static new bool Equals(object obj1, object obj2)
        {
            return obj1.Equals(obj2);
        }
    }
    public enum PayType { Card, Bitcoin, Cash }
    public struct Request
    {
        public int id;
        public Client aClient;
        public DateTime date;
        public RequestItem[] Items;
        public PayType payType;
        public double summ
        {
            get
            {
                double sum = 0;
                foreach (RequestItem item in Items)
                {
                    sum += item.anArticle.price * item.count;
                }
                return sum;
            }
        }
        public static new bool Equals(object obj1, object obj2)
        {
            return obj1.Equals(obj2);
        }
    }
    public class Program
    {
        /// <summary>
        /// Delegate for compare two object
        /// </summary>
        /// <returns></returns>
        public delegate bool Comparer(object obj1, object obj2);
        public static bool Contains(object[] args, object obj, Comparer comp)
        {
            foreach(object O in args)
                if (comp(obj, O)) return true;
            return false;
        }
        public static void Main(string[] args)
        {
            Article[] arts = new Article[5];
            for(int i=0;i<5;++i)
            {
                arts[i].id = i;
                arts[i].name = "Article #" + i;
                arts[i].price = 5.5 * i;
                arts[i].type = ArticleType.Motherboard + i;
            }
            object[] Oarts = { arts[0], arts[1], arts[2], arts[3], arts[4] };
            Article art;
            art.id = 3;
            art.name = "Article #" + 5;
            art.price = 5.5 * 3;
            art.type = ArticleType.RAM;
            Console.WriteLine("Array of Articles:");
            foreach (Article A in Oarts)
                Console.WriteLine(A);
            Console.WriteLine("The article {0} in Array = {1}",
                art, Contains(Oarts, art, new Comparer(Article.Equals)));
            art.name = "Article #" + 3;
            Console.WriteLine("The article {0} in Array = {1}",
                art, Contains(Oarts, art, new Comparer(Article.Equals)));
        }
    }
}
