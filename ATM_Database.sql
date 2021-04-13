CREATE DATABASE ATM;
GO

USE ATM;
GO

CREATE TABLE Bill
(
	MonetaryValue INT PRIMARY KEY,
	CONSTRAINT CHK_BILL CHECK (MonetaryValue >= 0)
);

CREATE TABLE WadOfBills
(
	BillValue INT PRIMARY KEY,
	Quantity INT DEFAULT 0 NOT NULL,
	FOREIGN KEY (BillValue) REFERENCES Bill(MonetaryValue),
	CONSTRAINT CHK_WAD CHECK (Quantity >= 0)
);

GO

/*Creates a new wad of bills for every new bill*/
CREATE TRIGGER TRG_NEW_BILL
ON Bill
AFTER INSERT
AS
BEGIN
	INSERT INTO WadOfBills (BillValue)
	SELECT MonetaryValue
	FROM INSERTED
END

GO

CREATE TRIGGER TRG_DELETE_BILL
ON Bill
INSTEAD OF DELETE 
AS 
BEGIN
	DECLARE @DELETEDBILLVALUE INT
	SELECT @DELETEDBILLVALUE = d.MonetaryValue FROM DELETED as d

	DELETE FROM WadOfBills
	WHERE BillValue = @DELETEDBILLVALUE

	DELETE FROM Bill
	WHERE MonetaryValue = @DELETEDBILLVALUE
END

GO

INSERT INTO Bill
  (MonetaryValue)
VALUES
  (2),(5),(10),(20),(50),(100),(200)

SELECT b.MonetaryValue FROM Bill as b
SELECT wb.BillValue, wb.Quantity FROM WadOfBills as wb