using Microsoft.SemanticKernel;
using Microsoft.Extensions.Configuration;

using SimplePromptTemplate;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{Environment.UserName}.json", optional: true)
    .Build();
var appConfiguration = configuration.Get<ApplicationConfiguration>()!;

IKernelBuilder kernelBuilder = Kernel
    .CreateBuilder()
    .AddAzureOpenAIChatCompletion(appConfiguration.DeploymentName, appConfiguration.Endpoint, appConfiguration.ApiKey);
Kernel kernel = kernelBuilder.Build();

const string prompt = "What is the timezone at {{$location}}?";

string? userInput;
Console.Write("User enter a location > ");
userInput = Console.ReadLine();

if (string.IsNullOrEmpty(userInput))
{
    return;
}

KernelFunction kernelFunction = kernel.CreateFunctionFromPrompt(prompt);
FunctionResult result = await kernelFunction.InvokeAsync(kernel, new() { ["location"] = userInput });

Console.WriteLine("Assistant > " + result);
