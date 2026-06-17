using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/md_parves2002_gmail_com", ([FromQuery] string x, [FromQuery] string y) =>
{
    // Validate natural numbers (integers > 0)
    if (!long.TryParse(x, out long firstNumber) || firstNumber <= 0 ||
        !long.TryParse(y, out long secondNumber) || secondNumber <= 0)
    {
        return Results.Content("NaN", "text/plain");
    }

    try
    {
        long lcm = FindLcm(firstNumber, secondNumber);
        return Results.Content(lcm.ToString(), "text/plain");
    }
    catch (OverflowException)
    {
        return Results.Content("NaN", "text/plain");
    }
});

app.Run();

static long FindGcd(long a, long b)
{
    while (b != 0)
    {
        long remainder = a % b;
        a = b;
        b = remainder;
    }

    return a;
}

static long FindLcm(long a, long b)
{
    checked
    {
        return (a / FindGcd(a, b)) * b;
    }
}