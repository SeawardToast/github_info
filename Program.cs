using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace WebAPIClient
{
    class Program
    {

	private static readonly HttpClient client = new HttpClient();    

	private static async Task<List<Repository>> ProcessRepositories()
	{
	    var serializer = new DataContractJsonSerializer(typeof(List<Repository>));
	    client.DefaultRequestHeaders.Accept.Clear();
	    client.DefaultRequestHeaders.Accept.Add(
		new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
	    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
	    var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
	    var repositories = serializer.ReadObject(await streamTask) as List<Repository>;
	    return repositories;
	}

        static void Main(string[] args)
        {
            Console.WriteLine("This shit is starting up now");
	    var repositories = ProcessRepositories().Result;

	    foreach (var repo in repositories) {
	        Console.Write("Name: ");
		Console.WriteLine(repo.Name);
		Console.Write("Description: ");
		Console.WriteLine(repo.Description);
		Console.Write("Git Home URL: ");
		Console.WriteLine(repo.GitHubHomeUrl);
		Console.Write("Homepage: ");
		Console.WriteLine(repo.Homepage);
		Console.Write("# watchers: ");
		Console.WriteLine(repo.Watchers);
		Console.Write("Last Push: ");
		Console.WriteLine(repo.LastPush);
		Console.WriteLine();
	    }
        }
    }
}
