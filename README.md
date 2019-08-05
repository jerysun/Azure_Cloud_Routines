# Azure Cloud Routines

This is a series that will cover Azure CosmosDB, Azure Service Bus, Azure Storage Account, Azure SQL Database, Azure Blob Containers, Azure Function App, Azure API App, Azure Mobile Apps, Azure App Service, Azure Authentication, etc.

## I. Project CosmosdbLite

### Azure CosmosDB

Azure Cosmos DB is truly schema-agnostic - it automatically indexes all the data without requiring you to deal with schema and index management. Azure Cosmos DB is multi-model - it natively supports document, key-value, graph and columnar data models. With Azure Cosmos DB, you can access your data using NoSQL APIs of your choice. All your data is fully and transparently encrypted and secure by default.

Features:
1. Azure Cosmos DB is ISO, FedRAMP, EU, HIPAA, and PCI compliant as well.
2. Session consistency is most widely used consistency level both for single region as well as, globally distributed applications.
3. One major advantage that Cosmos DB offers over a Storage Account table storage is that Sub 10ms latency is guaranteed.

### Project Description

To run this app you must create your Azure CosmosDB from https://portal.azure.com , however if you just want to read the source codes and learn something, then you don't have to create your CosmosDB resource on Microsoft Azure cloud.

Note:
- If you create your own CosmosDB on Azure cloud platform, then please replace the placeholders with your own endpoint and key in App.config file.
- This project assumes you have created an empty Cosmos DB named "maindb" and an empty container named "employee" (Again, it's unnecessary if you don't plan to really run this app).

Points:
- It shows how to connect to the CosmosDB, insert Non structured data, query them with filters, etc.
- It also displays how to adopt the best practice of software engineering to do the architecture of a project, and how to use the design patterns such as Singleton, DI(Dependency Injection), etc.

Please feel free to ask me if you have any questions.

Have fun,

Jerry Sun

Email:    jerysun007@hotmail.com

Website:  https://sites.google.com/site/geekssmallworld