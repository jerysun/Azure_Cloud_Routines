# Azure Cloud Routines

This is a series that will cover Azure CosmosDB, Azure Service Bus, Azure Storage Account, Azure SQL Database, Azure Blob Containers, Azure Function App, Azure API App, Azure Mobile Apps, Azure App Service, Azure Authentication, etc.

### Catalogue
1. Azure CosmosDB
2. Azure SQLDatabase
3. Azure Blob Storage
4. Azure Service Bus
5. HangfireDemo

## I. Project CosmosdbLite

### Azure CosmosDB

Azure Cosmos DB is truly schema-agnostic - it automatically indexes all the data without requiring you to deal with schema and index management. Azure Cosmos DB is multi-model - it natively supports document, key-value, graph and columnar data models. With Azure Cosmos DB, you can access your data using NoSQL APIs of your choice. All your data is fully and transparently encrypted and secure by default.

Features:
1. Azure Cosmos DB is ISO, FedRAMP, EU, HIPAA, and PCI compliant as well.
2. Session consistency is most widely used consistency level both for single region as well as, globally distributed applications.
3. One major advantage that Cosmos DB offers over a Storage Account table storage is that Sub 10ms latency is guaranteed.

### Project Description

To run this app you must create your Azure CosmosDB on https://portal.azure.com , however if you just want to read the source codes and learn something, then you don't have to create your CosmosDB resource on Microsoft Azure cloud.

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

To run this app you must create your Azure SQL Database on https://portal.azure.com , however if you just want to read the source codes and learn something, then you don't have to create your SQL Database resource on Microsoft Azure cloud.

Note:
- If you create your own SQL Database on Azure cloud platform, then please replace the placeholder with your own connection string in App.config file.
- This project assumes you have created a database and a talbe named "employee" inside it either directly on Azure or via your local MSSMS (Again, it's unnecessary if you don't plan to really run this app).

Points:
- It shows how to connect to the Azure SQL Database, insert data, asynchronous operation, etc.
- It also displays how to adopt the best practice of software engineering to do the architecture of a project, and how to use the design patterns such as Bridge, DI(Dependency Injection), etc.
- It reveals you Azure SQL Database's power of automatic scaling, high availability as well as the data security by creating the firewall whitelist.

## III. Project ABlobStorage

### Azure Blob Storage

Azure Blob Storage helps you create data lakes for your analytics needs, and provides storage to build powerful cloud-native and mobile apps. Optimize costs with tiered storage for your long-term data, and flexibly scale up for high-performance computing and machine learning workloads.

### Project Description

To run this app you must create your Azure Storage Account on https://portal.azure.com , however if you just want to read the source codes and learn something, then you don't have to create your storage resource on Microsoft Azure cloud.

Note:
- If you create your own Azure Storage Account, then please replace the placeholder with your own connection string in appsettings.json file.
- This project assumes you have created a blob container "aexample"

Points:
- It's a full-fledged Web Api project targeted at Azure Blob Storage based on ASP.NET Core 3.1
- It shows how to access the containers of Azure Blob Storage as well as how to manipulate the files stored there.
- It also displays how to adopt the best practice of software engineering to do the architecture of a project, and how to use the design patterns such as Service-Repository, DI(Dependency Injection), etc.

## IV. WebApp AzureServiceBus

Azure Service Bus is a cloud-based messaging service providing queues and topics with publish/subscribe semantics and rich features. Use Service Bus to:
- Build reliable and elastic cloud apps with messaging.
- Protect your application from temporary peaks.
- Distribute messages to multiple independent backend systems.
- Decouple your applications from each other.

### App Description

It consists of three projects: ASBPublisher, ASBShared, ASBSubscriber.

To run this app you must create your Service Bus resource on https://portal.azure.com , however if you just want to read the source codes and learn something, then you don't have to do it.

Note:
- If you create your own Service Bus resource, then please replace the placeholder with your own connection string in appsettings.json file of ASBPublisher, and Program.cs of ASBSubscriber.
- This App assumes you have created a service bus queue "personqueue".

## V. HangfireDemo

An easy way to perform background processing in .NET and .NET Core applications. No Windows Service or separate process required. Backed by persistent storage. Open and free for commercial use.

Although it doesn't belong to Microsoft Azure cloud, however it's used widely in huge amounts of Azure related projects.

### Project Description

It is a WebAPI scaffold project consisting of four "modules":
- Fire and Forget Jobs
- Delayed Jobs
- Recurring Jobs
- Continuous Jobs

which can be easily expanded, so that they can be smoothly adapted to the product environment.

Tips:
- Use POSTMAN to do the tests
- Use Hangfire dashboard to monitor and manage the background jobs

Please feel free to ask me if you have any questions.

Have fun,

Jerry Sun

Email:    jerysun007@hotmail.com

Website:  https://sites.google.com/site/geekssmallworld