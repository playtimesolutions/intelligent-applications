@description('Name of the Azure OpenAI service')
param openaiServiceName string = 'aiblogs-openai'

@description('Name of the LLM model to deploy')
param llmModelDeploymentName string = 'aiblogs-llm'

@description('LLM model capacity in 1000 tokens per minute')
param llmModelCapacity int = 30

@description('Name of the text embedding model to deploy')
param textEmbeddingModelDeploymentName string = 'aiblogs-text-embedding'

@description('Text embedding model capacity in 1000 tokens per minute')
param textEmbeddingModelCapacity int = 120

param location string = resourceGroup().location

@description('Main Azure OpenAI service')
resource openaiService 'Microsoft.CognitiveServices/accounts@2023-05-01' = {
  name: openaiServiceName
  location: location
  sku: {
    name: 'S0'
  }
  tags: {
    project: 'ai-blogs'
  }
  kind: 'OpenAI'
  identity: {
    type: 'None'
  }
  properties: {
    customSubDomainName: openaiServiceName
    networkAcls: {
      defaultAction: 'Allow'
    }
    publicNetworkAccess: 'Enabled'
  }
}

@description('LLM model for prompt calls')
resource llmModel 'Microsoft.CognitiveServices/accounts/deployments@2023-05-01' = {
  name: llmModelDeploymentName
  parent: openaiService
  properties: {
    model: {
      format: 'OpenAI'
      name: 'gpt-35-turbo'
      version: '1106'
    }
    raiPolicyName: 'Microsoft.DefaultV2'
    versionUpgradeOption: 'OnceNewDefaultVersionAvailable'
  }
  sku: {
    capacity: llmModelCapacity
    name: 'Standard'
  }
}

@description('Text embedding model for RAG calls')
resource textEmbeddingModel 'Microsoft.CognitiveServices/accounts/deployments@2023-05-01' = {
  name: textEmbeddingModelDeploymentName
  parent: openaiService
  properties: {
    model: {
      format: 'OpenAI'
      name: 'text-embedding-ada-002'
      version: '2'
    }
    raiPolicyName: 'Microsoft.DefaultV2'
    versionUpgradeOption: 'OnceNewDefaultVersionAvailable'
  }
  sku: {
    capacity: textEmbeddingModelCapacity
    name: 'Standard'
  }
}
