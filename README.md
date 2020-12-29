# CloudBar

This is a simple ASP.NET Core application created to test out different libraries.

Integrated libraries:
  1. EF Core
  2. Dapper
  3. Swashbuckle
  4. Serilog
  5. FontAwesome
  
To be integrated:
  1. BenchmarkDotnet
  2. Polly
  3. Automapper
  4. AspNetCore.Diagnostics.HealthChecks
  5. Hotjar
  6. Bootstrap



# Instructions to run:

1. Install Docker.
2. Open terminal.
3. Navigate to root folder of this repository.
4. Run command: docker-compose up



# Running docker-compose will spin up services:

1. es01: Elasticsearch image running on port 9200.
2. kib01: Kibana image running on port 5601.
3. ms-sql-server: MSSQL server image on port 1433.
4. web-app: WebApp instance, a .NET 5 mvc project on ports 2000 and 2001.


  
Developed with ♥
<br/>
Happy to receive feedback.
