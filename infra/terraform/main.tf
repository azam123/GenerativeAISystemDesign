terraform { required_version = ">= 1.6.0" }
variable "location" { default = "eastus" }
output "deployment_model" { value = "Azure Container Apps + PostgreSQL + Redis + Qdrant + Azure OpenAI" }
