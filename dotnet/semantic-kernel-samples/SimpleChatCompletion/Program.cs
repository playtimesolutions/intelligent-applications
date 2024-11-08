using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.Extensions.Configuration;

using SimpleChatCompletion;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{Environment.UserName}.json", optional: true)
    .Build();
var appConfiguration = configuration.Get<ApplicationConfiguration>()!;

IKernelBuilder kernelBuilder = Kernel
    .CreateBuilder()
    .AddAzureOpenAIChatCompletion(appConfiguration.DeploymentName, appConfiguration.Endpoint, appConfiguration.ApiKey);
Kernel kernel = kernelBuilder.Build();
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

var chatHistory = new ChatHistory();
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

    ChatMessageContent chatResponse = await chatCompletionService.GetChatMessageContentAsync(chatHistory, kernel: kernel);

    Console.WriteLine("Assistant > " + chatResponse);

    chatHistory.AddMessage(chatResponse.Role, chatResponse.Content ?? string.Empty);

} while (!string.IsNullOrEmpty(userInput));
