# Intelligent Applications - Simple RAG

This sample project demonstrates a simple chat bot combined with retrieval augmented generation from a knowledge store.

## Building the application

You must first setup Azure OpenAI and Azure AI Search services and add authentication details to configuration.
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

`User > `What ingredients are used to make artisan bread?<br/>
`Assistant > `To make artisan bread, you will need the following ingredients: bread flour, instant yeast, salt, and water [doc4]. Additionally, you can optionally use cornmeal for dusting the pan and add various herbs, seasonings, and other flavorings such as garlic, rosemary, cheese, nuts, or dried fruits [doc2].

`User > `What type of salt?<br/>
`Assistant > `The recipe for artisan bread recommends using coarse salt, such as coarse sea salt, for the best flavor [doc1].

`User > `Are there any recommended dishes to serve with?<br/>
`Assistant > `The artisan bread can be served with various dishes such as homemade honey butter, crab dip, beer cheese dip, garlic & bacon spinach dip, slow cooker chicken chili, pumpkin chili, minestrone soup, creamy chicken noodle soup, crab soup, mac & cheese, goat cheese & honey crostini, and breakfast casserole [doc1][doc2].