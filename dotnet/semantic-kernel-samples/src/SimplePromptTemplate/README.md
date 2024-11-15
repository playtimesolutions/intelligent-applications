# Intelligent Applications - Simple Prompt Template

This sample project demonstrates how to create a simple prompt template and send it to Azure OpenAI where the response is then output.

The template is predefined, `"What is the timezone at {{$location}}?"` where location is user input.

## Pre-requisites

You must first setup an Azure OpenAI service and create a deployment model such as GPT-3 for LLM usage.

## Building the application

Add Azure OpenAI authentication details to configuration.
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

* `User enter a location > `Melbourne<br/>
`Assistant > `Melbourne is in the Australian Eastern Standard Time zone (AEST), which is UTC+10 during standard time and UTC+11 during daylight saving time.
* `User enter a location > `London<br/>
`Assistant > `The timezone at London is Greenwich Mean Time (GMT) during standard time and British Summer Time (BST) during daylight saving time.
