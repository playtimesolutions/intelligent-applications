using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SimplePlugin;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{Environment.UserName}.json", optional: true)
    .Build();
var appConfiguration = configuration.Get<ApplicationConfiguration>()!;

IKernelBuilder kernelBuilder = Kernel
    .CreateBuilder()
    .AddAzureOpenAIChatCompletion(appConfiguration.DeploymentName, appConfiguration.Endpoint, appConfiguration.ApiKey);
kernelBuilder.Plugins.AddFromType<DronePlugin>();
Kernel kernel = kernelBuilder.Build();

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
AzureOpenAIPromptExecutionSettings promptExecutionSettings = new()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};

ChatHistory chatHistory = new();
string? userInput;
do
{
    Console.Write("User > ");
    userInput = Console.ReadLine();

    if (string.IsNullOrEmpty(userInput))
    {
        continue;
    }

    chatHistory.AddUserMessage(userInput);

    ChatMessageContent chatResponse = await chatCompletionService.GetChatMessageContentAsync(
        chatHistory,
        executionSettings: promptExecutionSettings,
        kernel: kernel);

    Console.WriteLine("Assistant > " + chatResponse);

    chatHistory.AddMessage(chatResponse.Role, chatResponse.Content ?? string.Empty);
} while (!string.IsNullOrEmpty(userInput));