use library
GO
-- Sample data for Members
DECLARE @i INT = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO Member (FirstName, LastName, Address, PhoneNumber, Email, RegistrationDate)
    VALUES ('User' + CAST(@i AS NVARCHAR), 'Lastname','Address', 'PhoneNumber', 'Member' + CAST(@i AS NVARCHAR) + '@example.com', DATEADD(DAY, @i * 3, GETDATE()));
    SET @i = @i + 1;
END
GO

-- Sample data for Book
DECLARE @j INT = 1;
WHILE @j <= 10
BEGIN
    INSERT INTO Book (Title, ISBN, PublicationYear, AvailableCopies)
    VALUES ('Title', '1234567890123', 2000, CAST(@j AS NVARCHAR));
    SET @j = @j + 1;
END
GO