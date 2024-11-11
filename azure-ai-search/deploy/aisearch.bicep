@description('Name of the Azure OpenAI service')
param aisearchServiceName string = 'aiblogs-aisearch'

param location string = resourceGroup().location

@description('Azure AI Search service')
resource aisearch 'Microsoft.Search/searchServices@2024-03-01-preview' = {
  name: aisearchServiceName
  location: location
  tags: {
    project: 'ai-blogs'
  }
  sku: {
    name: 'free'
  }
  properties: {
    networkRuleSet: {
      bypass: 'None'
    }
    partitionCount: 1
    publicNetworkAccess: 'enabled'
    replicaCount: 1
  }
}
