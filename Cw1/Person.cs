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
            var url = "https://www.pja.edu.pl";
            var httpCLient =  new HttpClient();

            var response = await httpCLient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+" ,RegexOptions.IgnoreCase);
                var matches = regex.Matches(htmlContent);
                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }

        }
    }
}


