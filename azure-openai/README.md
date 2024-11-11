# Intelligent Applications - Azure OpenAI

This folder contains details on how to create and update Azure OpenAI services.

## Useful links

* [Azure OpenAI Portal](https://oai.azure.com)
* [Main Azure OpenAI documentation web site](https://learn.microsoft.com/en-us/azure/ai-services/openai)
* [Create and deploy an Azure OpenAI Service resource](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource)
* [Deploy an Azure OpenAI model](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource#deploy-a-model)
* [Deploy AI services with Bicep](https://learn.microsoft.com/en-us/azure/ai-services/create-account-bicep)

## Readme's

* [How to create Azure OpenAI service in the Azure portal](./create-azureopenai-service/README.md)
* [How to create an LLM model deployment for Azure OpenAI in the Azure portal](./create-openai-deployment/README.md)

## Deployment

Bicep files exist in order to deploy the services from the command line rather than the portal.

* `deploy\resource-group.bicep`<br/>
Deploys the a resource group to deploy other services into.
* `deploy\openai.bicep`<br/>
Deploys the Azure OpenAI service.

### Deployment instructions

Using the Bicep scripts described here to deploy resources will require you to have a valid Azure subscription.

1. Start up a shell to run the `az` command
1. Login to your Azure subscription<br/>
`az login`

Where multiline commands are documented here, they are based on Powershell with the back-tick ` being a line extender. For Linux shells use backslash \ instead.

#### Prerequisites

1. Install the `az` CLI - see https://learn.microsoft.com/en-us/cli/azure/install-azure-cli
1. Install Bicep tools - see https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/install
1. Ensure a resource group has been created to deploy the resources into<br/>
   You can easily do this with a simple Azure CLI command:<br/>
   ```bat
   az group create --name <RG_NAME> --location <LOCATION>
   ```
   Or you can used a Bicep script `resource-group.bicep` created for you.
   On a shell enter the following command to deploy a resource group to your subscription:
   ```bat
   az deployment sub create `
     --name <DEPLOYMENT_NAME> `
     --location <LOCATION> `
     --template-file resource-group.bicep `
     --parameters name=<RG_NAME> location=<LOCATION>
   ```
   Where `<DEPLOYMENT_NAME>` is the name of the deployment, `<LOCATION>` is the Azure location to deploy the resource gruop and `<RG_NAME>` is the name you want to use for the resource group.

#### Run the deployment

1. Start up a shell to run the `az` command and login to your Azure subscription
1. Change the working folder to this folder
1. Build the Bicep file to show what its going to deploy<br/>
   `az bicep build --file openai.bicep --stdout`
1. If everything looks ok, deploy the resources
   ```bat
   az deployment group create `
     --name <DEPLOYMENT_NAME> `
     --resource-group <RG_NAME> `
     --template-file openai.bicep
   ```
   You can also use the `--parameters` parameter to adjust the deployment details with these named values:
   * `openaiServiceName` name of the Azure OpenAI service to deploy, defaults to `aiblogs-openai`
   * `llmModelDeploymentName` name of the LLM deployment model, defaults to `aiblogs-llm`
   * `llmModelCapacity` capacity tokens per minute in 1000's for the LLM model, defaults to `30`.
   * `textEmbeddingModelDeploymentName` name of the text embeddings deployment model, defaults to `aiblogs-text-embedding`
   * `textEmbeddingModelCapacity` capacity tokens per minute in 1000's for the text embeddings model, defaults to `120`.

