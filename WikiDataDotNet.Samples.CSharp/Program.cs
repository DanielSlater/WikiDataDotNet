using System;

namespace WikiDataDotNet.Samples.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var italy = Request.request_entity("Q38");
            Console.WriteLine(italy.title);

            var searchResult = Request.search_english("Headquarters of the U.N");
            Console.WriteLine(searchResult.search);
        }
    }
}
