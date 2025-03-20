//system namespace, console for input output operations
using System;
//sending http and receving http responses from webservers
using System.Net.Http;
//asynchronous programming with task pattern
using System.Threading.Tasks;
//using Newtonsoft.Json for json parsing
using Newtonsoft.Json.Linq;

class Program
{
  private static readonly string API_KEY = "7c2a9cc3361f4011fcebea7e6eca1f87";
  private static readonly HttpClient client = new HttpClient();

  static async Task Main(string[] args)
  {
    //main entry point of the program async means the method can use await and task is the return type for the async methods
    Console.WriteLine("Simple weather app in C#");
    Console.WriteLine("--------------------------");
    while (true)
    {
      Console.Write("\nEnter city name (or 'exit' to quit): ");
      //user types and store it in variable called city
      string city = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(city) || city.ToLower() == "exit")
      {
        break;
      }
      try
      {
        //calling the getweather method and passing the city as a parameter
        await GetWeather(city);
      }
      catch(Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }
  }

  //async method to get the weather
  static async Task GetWeather(string city)
  {
    //creating a url to get the weather data
    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}&units=metric";
    //sending a get request to the url
    HttpResponseMessage response = await client.GetAsync(url);
    //checking if the response is successful
    if (response.IsSuccessStatusCode)
    {
      //parsing the response as json
      string json = await response.Content.ReadAsStringAsync();
      //converting the json to a jobject
      JObject data = JObject.Parse(json);
      //getting the temperature from the json
      string weatherMain = data["weather"][0]["main"].ToString();
      //getting the description
      string weatherDescription = data["weather"][0]["description"].ToString();
      //getting the temperature
      double temperature = (double)data["main"]["temp"];
      //getting the humidity
      double humidity = (double)data["main"]["humidity"];
      //getting the wind speed
      double windSpeed = (double)data["wind"]["speed"];
      //getting the feels like temperature
      double feelsLike = (double)data["main"]["feels_like"];
      //getting the country
      string country = data["sys"]["country"].ToString();
      //getting the sunrise time
      DateTime sunrise = DateTimeOffset.FromUnixTimeSeconds((long)data["sys"]["sunrise"]).DateTime;
      //getting the sunset time
      DateTime sunset = DateTimeOffset.FromUnixTimeSeconds((long)data["sys"]["sunset"]).DateTime;
      //getting the timezone
      int timezone = (int)data["timezone"];
      //getting the city name
      string cityName = data["name"].ToString();
      //printing the weather data
      Console.WriteLine($"\nWeather in {cityName}, {country}:");
      Console.WriteLine($"Main: {weatherMain}");
      Console.WriteLine($"Description: {weatherDescription}");
      Console.WriteLine($"Temperature: {temperature}°C");
      Console.WriteLine($"Humidity: {humidity}%");
      Console.WriteLine($"Wind Speed: {windSpeed} m/s");
      Console.WriteLine($"Feels Like: {feelsLike}°C");
      Console.WriteLine($"Sunrise: {sunrise.ToString("HH:mm")}");
      Console.WriteLine($"Sunset: {sunset.ToString("HH:mm")}");
      Console.WriteLine($"Timezone: {timezone} minutes");
      Console.WriteLine("--------------------------");
    }
    else
    {
        string errorContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error: Unable to retrieve weather data for {city}");
        Console.WriteLine($"Error details: Status code: {(int)response.StatusCode} - {errorContent}");
    }
  }
}