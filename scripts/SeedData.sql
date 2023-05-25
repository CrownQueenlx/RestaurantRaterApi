USE RestaurantDb
GO

-- Reset the tables TRUNCATE
DELETE FROM Ratings
DELETE FROM Restaurants
GO

-- Reset the Identity Counter
DBCC CHECKIDENT (Restaurants, RESEED, 0)
DBCC CHECKIDENT (Ratings, RESEED, 0)
GO


-- Add Restaurants
INSERT INTO Restaurants
    (Name, [Location])
VALUES
    ('The Bistro', '12175 Visionary Way'),
    ('India Garden', '207 N Delaware St'),
    ('McDonald''s', '8907 E 116th Street') -- '' give us an apostrophe in the string
GO

-- Add Ratings
INSERT INTO Ratings
    ([RestaurantId], [Score])
VALUES
    (1,5), (1,3), (1,4), (1,1),
    (2,5), (2,4), (2,1), (2,4),
    (3,5), (3,3), (3,4), (3,5);
    GO
