# Intelligent Applications - Azure AI Search

This folder contains details on how to create and update Azure AI Search services.

## Readme's

* [How to create Azure AI Search service in the Azure portal](./create-azureaisearch-service/README.md)
* [How to create an index on Azure Blob storage](./index-blob-storage/README.md)

## Data files

* [ArtisanBread.txt](ArtisanBread.txt)<br/>
This file was uploaded to an Azure Blob storage container and indexed within Azure AI Search in order to use with the RAG code sample.
Taken from a [bread making web site](https://sallysbakingaddiction.com/homemade-artisan-bread/).

## Deployment

Bicep files exist in order to deploy the services from the command line rather than the portal.

* `deploy\resource-group.bicep`<br/>
Deploys the a resource group to deploy other services into.
* `deploy\aisearch.bicep`<br/>
Deploys the Azure AI Search service.
* `deploy\storage-account.bicep`<br/>
Deploys a storage account for use with Azure AI Search and RAG calls.

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

#### Azure AI Search deployment

1. Start up a shell to run the `az` command and login to your Azure subscription
1. Change the working folder to this folder
1. Build the Bicep file to show what its going to deploy<br/>
   `az bicep build --file aisearch.bicep --stdout`
1. If everything looks ok, deploy the resources
   ```bat
   az deployment group create `
     --name <DEPLOYMENT_NAME> `
     --resource-group <RG_NAME> `
     --template-file aisearch.bicep
   ```
   You can also use the `--parameters` parameter to adjust the deployment details with these named values:
   * `aisearchServiceName` name of the Azure OpenAI service to deploy, defaults to `aiblogs-aisearch`

#### Storage account deployment

You can use this for RAG calls used with Azure AI Search indexed data.

1. Start up a shell to run the `az` command and login to your Azure subscription
1. Change the working folder to this folder
1. Build the Bicep file to show what its going to deploy<br/>
   `az bicep build --file storage-account.bicep --stdout`
1. If everything looks ok, deploy the resources
   ```bat
   az deployment group create `
     --name <DEPLOYMENT_NAME> `
     --resource-group <RG_NAME> `
     --template-file storage-account.bicep
   ```
   You can also use the `--parameters` parameter to adjust the deployment details with these named values:
   * `storageAccountName` name of the storage account to deploy, defaults to `aiblogsstorage`
