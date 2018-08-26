# fargalaxy

This project is about a tool for weather forecasting written for the civilizations Vulcanos, Ferengis and Betasoides. This project also includes a RESTful API for retrieving a desiered weather condition for a single day. 

## Tool Usage

This project generates the weather conditions for a given space in time using a job. The executable can be used from a command prompt in the following way:

![alt text](https://raw.githubusercontent.com/fourzans/fargalaxy/master/Job-Execution.png)

In the example above, a prediction for the weather conditions for the next ten years has been made, obtaining the following results:

1) Total drought days: 41 of 3650 days (10 years) - 1.12%
2) Total rainy days: 1187 of 3650 days (10 years) - 32.52%
  a) The maximum day of inestability is going to be the day 72.
3) Period of optimal pressure and temperature conditions: 81 of 3650 days (10 years) - 2.2%
 
### Tool Commands

| Command | Description |
| --- | --- |
| ci=VALUE | Create initial weather conditions for a given number of years |
| c=VALUE | Retrieves weather conditions for a given number of years |
| cm=VALUE | Creates the database model for a given number of years |

### API Call example

We can call an API URI to retrieve the weather conditions from a single day the following way:

| VERB | URI | RESULT |
| :---         | :---           | :---          |
| GET  | https://fargalaxy-api.azurewebsites.net/weather/566     | {"day":566,"weather":"RainyDay"}    |

## Built With

* [.NET 4.7](https://www.microsoft.com/net/download/dotnet-framework-runtimea) - The framework useda
* [AutoFac](https://autofac.org/) - IoC container
* [Redis](https://redis.io/) - NoSQL DB for storing weather conditions
* [Azure](https://azure.microsoft.com/en-us/) - Cloud platform services to store the API

