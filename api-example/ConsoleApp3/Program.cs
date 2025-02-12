using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

RestClient jokeClient = new RestClient("https://v2.jokeapi.dev/");
RestRequest jokeRequest = new RestRequest("joke/Programming?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&type=twopart");
RestResponse jokeResponse = await jokeClient.GetAsync(jokeRequest);

JObject jokeResponseObj = JsonConvert.DeserializeObject<JObject>(jokeResponse.Content);

RestClient newsClient = new RestClient("https://saurav.tech/NewsAPI/");
RestRequest newsRequest = new RestRequest("top-headlines/category/technology/us.json");
RestResponse newsResponse = await newsClient.GetAsync(newsRequest);

JObject newsResponseObj = JsonConvert.DeserializeObject<JObject>(newsResponse.Content);

while (true)
{
    Console.WriteLine("Ask me for one of the following: \n1. Joke\n2. News\n\nOr Exit to exit");
    string input = Console.ReadLine();

    if (input.ToLower() == "joke")
    {
        Console.WriteLine($"{jokeResponseObj["setup"]}\n{jokeResponseObj["delivery"]}");
    }
    else if (input.ToLower() == "news")
    {
        Console.WriteLine(newsResponseObj["articles"][0]["title"]);
    }
    else if (input.ToLower() == "exit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Sorry, I don't offer that");
    }

}
