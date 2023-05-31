terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.0.0"
    }
  }
  backend "azurerm" {
    storage_account_name = "tfsorkdemostg001"
    container_name = "terraform-state"
    key = "tf-azdo-demo.tfstate"
  }
}