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

## II. Project MyAzureSQLDatabase

### Azure SQLDatabase

Azure SQL Database is the intelligent, scalable, cloud database service that provides the broadest SQL Server engine compatibility.

Features:
- Built-in machine learning for peak database performance and durability that optimises performance and security for you
- Unmatched scale and high availability for compute and storage without sacrificing performance
- Advanced data security including data discovery and classification, vulnerability assessment and advanced threat detection all in a single pane of glass

### Project Description

To run this app you must create your Azure SQL Database from https://portal.azure.com , however if you just want to read the source codes and learn something, then you don't have to create your SQL Database resource on Microsoft Azure cloud.

Note:
- If you create your own SQL Database on Azure cloud platform, then please replace the placeholder with your own connection string in App.config file.
- This project assumes you have created a database and a talbe named "employee" inside it either directly on Azure or via your local MSSMS (Again, it's unnecessary if you don't plan to really run this app).

Points:
- It shows how to connect to the Azure SQL Database, insert data, asynchronous operation, etc.
- It also displays how to adopt the best practice of software engineering to do the architecture of a project, and how to use the design patterns such as Bridge, DI(Dependency Injection), etc.
- It revealss you Azure SQL Database's power of automatic scaling, high availability as well as the data security by creating the firewall whitelist.

Please feel free to ask me if you have any questions.

Have fun,

Jerry Sun

Email:    jerysun007@hotmail.com

Website:  https://sites.google.com/site/geekssmallworld