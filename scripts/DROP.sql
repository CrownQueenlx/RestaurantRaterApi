USE master;
GO

ALTER DATABASE RestaurantDb SET single_user with ROLLBACK IMMEDIATE;
GO

DROP DATABASE RestaurantDb;
GO