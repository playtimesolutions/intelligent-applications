# Intelligent Applications - Simple Chat Completion

This sample project demonstrates a simple chat bot where prompts and history are sent to Azure OpenAI where the response is then output and added to the chat history.

## Pre-requisites

You must first setup an Azure OpenAI service and create a deployment model such as GPT-3 for LLM usage.

## Building the application

Add Azure OpenAI authentication details to configuration.
1. Copy the `appsettings.json` file to your own user name e.g. `appsettings.AlanTuring.json`
1. Edit your users settings file adding the configuration required<br/>
The `ApiKey` must be set - **NEVER ADD THIS TO SOURCE CONTROL!**
1. Build the application as normal
 
## Running the application

The program runs in a loop presenting you with a `User > ` prompt.
Enter a question or statement you wish to pass to the AI model and press return.<br/>
The response will be output to the console after `Assistant > `.

This continues until you press return with no question to exit the application.

**NOTE:** as the history continues to be appended to, eventually there will be too much information in the history that the model will fail to process the request due to token exhaustion.

### Example running

`User > `What is C#?<br/>
`Assistant > `C# is a general-purpose, object-oriented programming language developed by Microsoft. It is designed for building a variety of applications, including web applications, desktop applications, mobile apps, games, and more. C# is part of the .NET framework and is widely used for developing software for the Windows platform. It is known for its simplicity, scalability, and versatility.<br/>
`User > `What is the current version?<br/>
`Assistant > `The current stable version of C# is C# 9.0, which was released in November 2020 as part of the .NET 5.0 release.<br/>
`User > `When is the next version going to be released?<br/>
`Assistant > `As of my last knowledge update, there is no confirmed release date for the next version of C#. Microsoft typically releases new versions of C# alongside updates to the .NET framework, and they typically provide details about upcoming releases on their official .NET development blog. I recommend checking the official Microsoft developer resources for the latest information on upcoming releases.
