using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length < 2)
                throw new ArgumentNullException();


            var url = "https://www.pja.edu.pl";
            var httpCLient = new HttpClient();

            var response = await httpCLient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                var matches = regex.Matches(htmlContent);
                int bylo = 0;

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                    bylo++;
                }

                if (bylo == 0)
                    throw new Exception("Nie znaleziono adresow e-mail");


            }
            else
                throw new Exception("blad w czasie pobierania strony");

            httpCLient.Dispose();

        }
    }
}
