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
    }
    public struct RequestItem
    {
        public Article anArticle;
        public int count;
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
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            //TODO
        }
    }
}