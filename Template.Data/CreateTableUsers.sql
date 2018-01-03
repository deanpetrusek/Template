-- Create a new tabdomain'Users' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('domain.Users', 'U') IS NOT NULL
DROP TABLE domain.Users
GO

-- Create the table in the specified schema
CREATE TABLE domain.Users (UsersId INT NOT NULL PRIMARY KEY, -- primary key column
    FirstName [NVARCHAR](50) NOT NULL,
    LastName [NVARCHAR](50) NOT NULL
    -- specify more columns here
);
GO