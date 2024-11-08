# Intelligent Applications - Simple Prompt

This sample project demonstrates how to create a simple prompt and send it to Azure OpenAI where the response is then output.

## Building the application

You must first setup an Azure OpenAI service and add authentication details to configuration.
1. Copy the `appsettings.json` file to your own user name e.g. `appsettings.AlanTuring.json`
1. Edit your users settings file adding the configuration required<br/>
The `ApiKey` must be set - **NEVER ADD THIS TO SOURCE CONTROL!**
1. Build the application as normal
 
## Running the application

On startup you will be presented with a `User > ` prompt.
Enter a question or statement you wish to pass to the AI model and press return.<br/>
The response will be output to the console after `Assistant > `.

Press return with no question to exit the application.

### Example running

* `User > `What is C#?<br/>
`Assistant > `C# (pronounced "C sharp") is a programming language developed by Microsoft for building a wide range of applications on the .NET framework. It is known for its object-oriented and component-oriented programming features, and is commonly used for developing software applications, web applications, and games.
* `User > `What is the latest version of C#?<br/>
`Assistant > `The latest version of C# as of October 2021 is C# 9.0.
