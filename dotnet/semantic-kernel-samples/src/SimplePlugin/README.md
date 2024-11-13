# Intelligent Applications - Simple Plugin

This sample project demonstrates a simple chat bot combined with plugin function calling.
Prompts, history and function definitions are sent to Azure OpenAI where Semantic Kernel can then call the functions.
Responses are output and added to the chat history.

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

`User > `What is the drones current location?<br/>
`Assistant > `The drone's current location is:
- X-axis (east-west) location: 0
- Y-axis (north-south) location: 0
- Z-axis (height) location: 0

`User > `Move the drone north 2 clicks<br/>
`Assistant > `The drone has been moved north 2 clicks. Its current location is:
- X-axis (east-west) location: 0
- Y-axis (north-south) location: 2
- Z-axis (height) location: 0

`User > `Move the drone west 3 clicks<br/>
`Assistant > `The drone has been moved west 3 clicks. Its current location is:
- X-axis (east-west) location: -3
- Y-axis (north-south) location: 2
- Z-axis (height) location: 0

`User > `Make the drone gain height<br/>
`Assistant > `The drone has gained height. Its current location is:<br/>
- X-axis (east-west) location: -3
- Y-axis (north-south) location: 2
- Z-axis (height) location: 1

`User > `What is the distance of the drone from its original location?<br/>
`Assistant > `The current position of the drone is:<br/>
- X-axis (east-west) location: -3
- Y-axis (north-south) location: 2
- Z-axis (height) location: 1

The distance of the drone from its original location can be calculated using the distance formula. The drone has moved 3 units west (in the negative X-axis direction), 2 units north, and 1 unit up from its original position. This results in a total distance of sqrt((-3)^2 + 2^2 + 1^2) = sqrt(9 + 4 + 1) = sqrt(14) ~ 3.74 units.
