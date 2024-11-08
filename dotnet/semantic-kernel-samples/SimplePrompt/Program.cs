using Microsoft.SemanticKernel;
using Microsoft.Extensions.Configuration;

using SimplePrompt;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{Environment.UserName}.json", optional: true)
    .Build();
var appConfiguration = configuration.Get<ApplicationConfiguration>()!;

IKernelBuilder kernelBuilder = Kernel
    .CreateBuilder()
    .AddAzureOpenAIChatCompletion(appConfiguration.DeploymentName, appConfiguration.Endpoint, appConfiguration.ApiKey);
Kernel kernel = kernelBuilder.Build();

string? userInput;
Console.Write("User > ");
userInput = Console.ReadLine();

if (string.IsNullOrEmpty(userInput))
{
    return;
}

FunctionResult result = await kernel.InvokePromptAsync(userInput);

Console.WriteLine("Assistant > " + result);
