// See https://aka.ms/new-console-template for more information
using Clients;

Console.WriteLine("Hello, World!");

var c = new Clients.WeatherForecastClient("http://localhost:5118/", new HttpClient());

try
{
    await c.DeleteAsync("test");
}
catch (ApiException ex)
{
    Console.WriteLine(ex.Response.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

try
{
    await c.TestAsync();
}
catch (ApiException ex)
{
    Console.WriteLine(ex.Response.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}