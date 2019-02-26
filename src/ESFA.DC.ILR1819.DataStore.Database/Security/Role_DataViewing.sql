
CREATE ROLE [DataViewing] AUTHORIZATION [dbo]
GO

-- Grant access rights to a specific schema in the database
GRANT 
	REFERENCES, 
	SELECT, 
	VIEW DEFINITION 
ON SCHEMA::dbo
	TO DataViewing
GO

-- Grant access rights to a specific schema in the database
GRANT 
REFERENCES, 
	SELECT, 
	VIEW DEFINITION 
ON SCHEMA::Invalid
	TO DataViewing
GO

-- Grant access rights to a specific schema in the database
GRANT 
	REFERENCES, 
	SELECT, 
	VIEW DEFINITION 
ON SCHEMA::Valid
	TO DataViewing
GO

-- Grant access rights to a specific schema in the database
GRANT 
	REFERENCES, 
	SELECT, 
	VIEW DEFINITION 
ON SCHEMA::Rulebase
	TO DataViewing
GO

-- Grant access rights to a specific schema in the database
GRANT 
	REFERENCES, 
	SELECT, 
	VIEW DEFINITION 
ON SCHEMA::DataLock
	TO DataViewing
GO
