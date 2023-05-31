provider "azurerm" {
    features {}
    subscription_id = "c21c45aa-a934-4c98-9c2f-2be868a9a957"
    client_id = var.spn-client-id
    client_secret = var.spn-client-secret
    tenant_id = var.spn-tenant-id
}
