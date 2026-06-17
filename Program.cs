using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/md_parves2002_gmail_com", HandleLcmRequest);
app.MapGet("/md_parves2002_gmail_com/", HandleLcmRequest);

app.Run();

static IResult HandleLcmRequest([FromQuery] string? x, [FromQuery] string? y)
{
    if (string.IsNullOrWhiteSpace(x) || string.IsNullOrWhiteSpace(y) ||
        !long.TryParse(x, out long numX) || numX <= 0 ||
        !long.TryParse(y, out long numY) || numY <= 0)
    {
        return Results.Text("NaN", "text/plain");
    }

    long lcm = CalculateLCM(numX, numY);
    return Results.Text(lcm.ToString(), "text/plain");
}

static long CalculateGCD(long a, long b)
{
    while (b != 0)
    {
        long temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

static long CalculateLCM(long a, long b)
{
    return (a / CalculateGCD(a, b)) * b;
}