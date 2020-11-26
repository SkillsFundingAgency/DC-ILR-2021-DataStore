# DC-ILR-2021-DataStore

This code will create the fifth/sixth part of the ILR pipeline. 
After validation and funding has completed the data needs to be persisted to a database.
This service will delete old data from the database, update any apprenticeship history and then finally update the ILR/Validation/Funding output.
Online this creates a service fabric application (stateless service) and for desktop creates a nuget package.

