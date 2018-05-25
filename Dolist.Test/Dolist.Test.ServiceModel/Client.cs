using ServiceStack;
using ServiceStack.DataAnnotations;
using System;

namespace Dolist.Test.ServiceModel
{
    public sealed class Client
    {
        [AutoIncrement]

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreationDate { get; set; }

        public Client()
        {
            System.Console.WriteLine("ID: "+ID);
            System.Console.WriteLine("FirstName: " + FirstName);
            System.Console.WriteLine("LastName: " + LastName);
            System.Console.WriteLine("CreationDate: " + CreationDate);
        }

        public Client(PostClient request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
        }
       
    }
}
