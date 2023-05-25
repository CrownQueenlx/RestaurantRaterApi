USe RestaurantDb

-- SELECT * FROM RestaurantDb.dbo.Restaurants

SELECT [Id], [Name], [Location]
FROM Restaurants
-- WHERE [NAME] = 'The Bistro'

SELECT [RestaurantId], [Score]
FROM Ratings
GO


-- SELECT [RestaurantId], [Score] FROM Ratings

SELECT *
FROM Ratings
WHERE [RestaurantId] = 2;
GO

        --COLUMN        --Relabel
SELECT AVG(Score) AS Average_Rating
FROM Ratings --TABLE
-- WHERE RestaurantId = 2 --Filters for certain value
-- WHERE Score > 3 ;
GO

SELECT r.Id, r.Name, AVG(rt.Score) AS Average_Rating--reference to different tables
From Restaurants r
    LEFT OUTER JOIN Ratings rt --access and connect information from separate tables
    ON rt.RestaurantId = r.Id
GROUP BY r.Id, r.Name
ORDER BY Average_Rating DESC
