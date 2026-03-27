# Weather API Wrapper 🌤️

A lightweight and fast RESTful API built with **C# & ASP.NET Core (Minimal APIs)** that acts as a wrapper for a 3rd-party weather service. 

This project is a solution to the [Weather API Wrapper challenge from roadmap.sh](https://roadmap.sh/projects/weather-api-wrapper-service).

## 🚀 Features
* **Data Fetching:** Seamlessly connects to the Visual Crossing Weather API using `HttpClient` to fetch real-time weather data.
* **Smart Caching ⚡:** Implements `IMemoryCache` to store weather data for 12 hours. This drastically reduces external API calls, bypasses rate limits, and returns responses in milliseconds.
* **Security First 🔐:** API keys are safely managed using `appsettings.json` and User Secrets, ensuring sensitive credentials are never exposed in version control.

## 🛠️ Tech Stack
* C# / .NET 8 (or latest)
* ASP.NET Core (Minimal APIs)
* IMemoryCache
* Visual Crossing Weather API

## 🚦 Getting Started

### Prerequisites
* .NET SDK installed on your machine.
* A free API key from [Visual Crossing](https://www.visualcrossing.com/).

### Installation
1. Clone this repository.
2. Open `appsettings.json` and replace the placeholder with your actual API key:
   ```json
   {
     "WeatherAPI": {
       "ApiKey": "YOUR_API_KEY_HERE"
     }
   }

## Project URL
https://roadmap.sh/projects/weather-api-wrapper-service
