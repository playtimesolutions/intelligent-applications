targetScope = 'subscription'

@description('Azure region the resource group will be created in.')
param location string

@description('Name of the resource group to create.')
param name string

resource resourceGroup 'Microsoft.Resources/resourceGroups@2024-03-01' = {
  name: name
  location: location
}
