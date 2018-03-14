using System;
using System.Configuration;

namespace SfQuery
{
    public class Program
    {
        private static SalesforceClient CreateClient()
        {
            return new SalesforceClient
            {
                Username = ConfigurationManager.AppSettings["quyma.viana@hotmail.com"],
                Password = ConfigurationManager.AppSettings["maskarab8@"],
                Token = ConfigurationManager.AppSettings["nkkp9j5QAwFEUh7fNPRQGZUaB"],
                ClientId = ConfigurationManager.AppSettings["3MVG9mclR62wycM2v4K1sb_UZ0ZzvI417x79MJFeAsLZi2H0bbcMoyPvTZfsj9H4v3TZDR83Ol5gktbSl3vt7"],
                ClientSecret = ConfigurationManager.AppSettings["1913044141285210362"]
            };
        }

        static void Main(string[] args)
        {
            var client = CreateClient();
            //foi
            if (args.Length > 0)
            {
                client.Login();
                Console.WriteLine(client.Query(args[0]));
            }
            else
            {
                client.Login();
               // Console.WriteLine(client.Describe("Account"));
              //  Console.WriteLine(client.Describe("Contact"));
              //  Console.WriteLine(client.QueryEndpoints());
              //  Console.WriteLine(client.Query("SELECT Name from Contact"));
            }
            Console.ReadLine();
        }
    }
}
