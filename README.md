# Simple C# Weather App

## Description
A lightweight console application built in C# that fetches and displays current weather information for any city in the world. This project demonstrates fundamental C# programming concepts including:

- Making HTTP requests to external APIs
- Asynchronous programming using async/await
- JSON parsing with Newtonsoft.Json
- Error handling with try/catch blocks
- User input processing
- Formatted console output
![page_0](https://github.com/user-attachments/assets/c104982c-06d2-4e9c-9da5-6196aeb1675e)
![page_1](https://github.com/user-attachments/assets/5479d1e6-5438-4cfd-b6d3-8be825236ea7)

## Features
- Get real-time weather data for any city
- Display comprehensive weather information including:
  - Current temperature and "feels like" temperature
  - Weather conditions and detailed description
  - Humidity and wind speed
  - Sunrise and sunset times
  - Country code and timezone information
- Simple console interface with continuous query capability
- Error handling for invalid city names or API issues

## Requirements
- .NET Core 3.1 or higher
- Newtonsoft.Json package
- Internet connection
- OpenWeatherMap API key

## Setup and Installation
1. Clone this repository or download the source code
2. Register for a free API key at [OpenWeatherMap](https://openweathermap.org/)
3. Replace the placeholder API key in the code with your own key:
   ```csharp
   private static readonly string API_KEY = "your-api-key-here";
