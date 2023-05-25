-- Create the database itself
CREATE DATABASE RestaurantDb;
GO


-- Creating the Restaurant Table
CREATE TABLE RestaurantDb.dbo.Restaurants --DB.Schema.Table
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
    [Location] NVARCHAR(100) NOT NULL
)
GO

-- Change the targeted database
USE RestaurantDb
CREATE TABLE Ratings
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Score] FLOAT NOT NULL CHECK (Score >= 0.0 AND Score <= 5.0),
    [RestaurantId] INT NOT NULL
)
GO

-- Set the foreign key relationship
ALTER TABLE Ratings             -- The table to alter
ADD FOREIGN KEY (RestaurantId)  -- The field on the altered table
REFERENCES Restaurants(Id);      -- The table(field) that are being referenced
GO
