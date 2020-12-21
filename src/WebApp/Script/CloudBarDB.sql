CREATE TABLE [dbo].[Users]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Username] NVARCHAR(50) NOT NULL UNIQUE,
    [Name] NVARCHAR(100) NOT NULL,
    [Role] NVARCHAR(50),
    [Email] NVARCHAR(50) NOT NULL,
    [Password] NVARCHAR(512),
	[Salt] NVARCHAR(256),
	[Status] INT NOT NULL DEFAULT 0,
    [Created] DATETIME NOT NULL DEFAULT GETDATE(), 
    [Modified] DATETIME NULL
)

GO

CREATE TRIGGER [dbo].[Trigger_Users]
    ON [dbo].[Users]
    FOR UPDATE
    AS
    BEGIN
        UPDATE Users SET Modified = GETDATE()
		where Id in 
		(select distinct Id from Inserted)
    END
GO


CREATE TABLE [dbo].[Spirits]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(100) NOT NULL UNIQUE,
    [Price] DECIMAL(10,2) NOT NULL, -- Price per 100ml
	[Stock] INT NOT NULL DEFAULT 0,
    [Created] DATETIME NOT NULL DEFAULT GETDATE(),
    [Modified] DATETIME NULL
)

GO

CREATE TRIGGER [dbo].[Trigger_Spirits]
    ON [dbo].[Spirits]
    FOR UPDATE
    AS
    BEGIN
        UPDATE Spirits SET Modified = GETDATE()
		where Id in 
		(select distinct Id from Inserted)
    END
GO


CREATE TABLE [dbo].[Drinks]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(100) NOT NULL UNIQUE,
    [Quntity] INT NOT NULL DEFAULT 30,
    [Description] NVARCHAR(256) NULL,
    [OverheadCost] DECIMAL(10, 2) NOT NULL DEFAULT 0,
    [Created] DATETIME NOT NULL DEFAULT GETDATE(),
    [Modified] DATETIME NULL
)

GO

CREATE TRIGGER [dbo].[Trigger_Drinks]
    ON [dbo].[Drinks]
    FOR UPDATE
    AS
    BEGIN
        UPDATE Drinks SET Modified = GETDATE()
		where Id in 
		(select distinct Id from Inserted)
    END
GO


CREATE TABLE [dbo].[Ingredients]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [DrinkId] BIGINT NOT NULL,
    [SpiritId] BIGINT NOT NULL,
    [Percentage] INT NOT NULL DEFAULT 0,
    [Created] DATETIME NOT NULL DEFAULT GETDATE(),
    [Modified] DATETIME NULL,

    CONSTRAINT [FK_Ingredients_Spirits] FOREIGN KEY ([SpiritId]) REFERENCES [Spirits]([Id]),
    CONSTRAINT [FK_Ingredients_Drinks] FOREIGN KEY ([DrinkId]) REFERENCES [Drinks]([Id])
)

GO

CREATE TRIGGER [dbo].[Trigger_Ingredients]
    ON [dbo].[Ingredients]
    FOR UPDATE
    AS
    BEGIN
        UPDATE Ingredients SET Modified = GETDATE()
		where Id in 
		(select distinct Id from Inserted)
    END
GO

CREATE TABLE [dbo].[Orders]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Price] DECIMAL(10, 2) NOT NULL,

    [Created] DATETIME NOT NULL DEFAULT GETDATE(),
)

GO

CREATE TABLE [dbo].[OrderItems]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Type] NVARCHAR(50),
    [DrinkId] BIGINT NOT NULL,
    [Quantity] INT NOT NULL DEFAULT 0,
    [Price] DECIMAL(10, 2) NOT NULL,

    [Created] DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT [FK_OrderItems_Drinks] FOREIGN KEY ([DrinkId]) REFERENCES [Drinks]([Id])
)

GO

CREATE TABLE [dbo].[UserOrders]
(
    [Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [UserId] BIGINT NOT NULL,
    [OrderId] BIGINT NOT NULL,

    [Create] DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT [FK_UserOrders_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
    CONSTRAINT [FK_UserOrders_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id])
)

GO

-- -- Drop tables
-- DROP TABLE UserOrders
-- DROP TABLE Users
-- DROP TABLE OrderItems
-- DROP TABLE Orders
-- DROP TABLE Ingredients
-- DROP TABLE Drinks
-- DROP TABLE Spirits

-- Seed data
INSERT INTO Spirits (Name, Price, Stock)
VALUES
('Old Monk Extra Special Xxx Rum',60,100000),
('M-2 Magic Moments Remix Green Apple Flavoured Superior Vodka',94.4444444444444,100000),
('Mc Dowells Green Label The Rich Blend Whisky',61.3333333333333,100000),
('Mcdowells No.1 Deluxe Whisky',88.8888888888889,100000),
('Old Monk Rum Very Old Vatted',79.3333333333333,100000),
('Royal Challenge Classic Premium Whisky',105.555555555556,100000),
('Royal Stag Delux Whisky',100,100000),
('Teachers Highland Cream Blended Scotch Whisky',259.333333333333,100000),
('Vat 69 Blended Scotch Whisky',272.666666666667,100000),
('Blenders Pride Reserve Collection Whisky',178,100000)


INSERT INTO Drinks (Name, Quntity, OverheadCost)
VALUES
('Vodka(30ml) - Magic Moments Green Apple', 30, 20),
('Vodka(60ml) - Magic Moments Green Apple', 60, 32),
('Vodka(90ml) - Magic Moments Green Apple', 90, 40),

('Whisky(30ml) - Teachers Highland Cream Blended Scotch', 30, 40),
('Whisky(60ml) - Teachers Highland Cream Blended Scotch', 60, 64),
('Whisky(90ml) - Teachers Highland Cream Blended Scotch', 90, 80),

('Whisky(30ml) - Vat 69 Blended Scotch', 30, 50),
('Whisky(60ml) - Vat 69 Blended Scotch', 60, 80),
('Whisky(90ml) - Vat 69 Blended Scotch', 90, 100),

('Whisky(30ml) - Royal Stag Delux', 30, 20),
('Whisky(60ml) - Royal Stag Delux', 60, 32),
('Whisky(90ml) - Royal Stag Delux', 90, 40),

('Whisky(30ml) - Blenders Pride Reserve Collection', 30, 25),
('Whisky(60ml) - Blenders Pride Reserve Collection', 60, 40),
('Whisky(90ml) - Blenders Pride Reserve Collection', 90, 50)


INSERT INTO Ingredients ([DrinkId], [SpiritId], [Percentage])
VALUES
(1,2,100),
(2,2,100),
(3,2,100),
(4,8,100),
(5,8,100),
(6,8,100),
(7,9,100),
(8,9,100),
(9,9,100),
(10,7,100),
(11,7,100),
(12,7,100),
(13,10,100),
(14,10,100),
(15,10,100)


-- SELECT * from Spirits

-- select * from Drinks

-- select d.Name, s.Name, d.Quntity from Drinks d 
-- inner join Ingredients r on r.DrinkId = d.Id
-- inner join Spirits s on s.id = r.SpiritId