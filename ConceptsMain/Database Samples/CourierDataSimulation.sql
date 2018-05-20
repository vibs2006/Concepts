--https://blog.sqlauthority.com/2007/04/29/sql-server-random-number-generator-script-sql-query/
USE relio4dw_ws1

TRUNCATE TABLE Vaibhav_M_Customer;

TRUNCATE TABLE garima.Vaibhav_T_Shipment;

GO

DECLARE @Random INT;
DECLARE @Upper INT;
DECLARE @Lower INT

---- This will create a random number between 1 and 999
SET @Lower =-36 ---- The lowest random number
SET @Upper = 0 ---- The highest random number

--SELECT @Random
--select * from garima.Vaibhav_M_Customer
DECLARE @count INT = 1;

--Not Deleted Customer
WHILE ( @count <= 100 )
  BEGIN
      INSERT INTO garima.Vaibhav_M_Customer
                  (Cust_CoName,
                   Deleted)
      SELECT 'Customer ' + CONVERT(NVARCHAR(50), @count)
             + ' Act',
             0;

      DECLARE @CustomerIdentity INT = Scope_identity();
      DECLARE @ShipmentCount INT = 1;

      WHILE ( @ShipmentCount < = 5 )
        BEGIN
            SET @Random = Round(( ( @Upper - @Lower - 1 ) * Rand() + @Lower ), 0)

            DECLARE @ShipmentCodeIdentity INT;

            --DECLARE @RandomInt int = (CONVERT(int, RAND() * 10)+1)  - CONVERT(int, RAND() * 10);
            IF ( @ShipmentCount = 3 )
              BEGIN
                  INSERT INTO garima.Vaibhav_T_Shipment
                              (Shipment_Date,
                               Account_Number,
                               Charges,
                               Discount,
                               Shipment_Status,
                               CarrierNetCost,
                               CarrierVAT)
                  SELECT Dateadd(MONTH, @Random, Getdate()),
                         @CustomerIdentity,
                         Abs(@Random * 100),
                         @Random,
                         1,
                         Abs(@Random * 10),
                         Abs(@Random * 5);

                  SET @ShipmentCodeIdentity = Scope_identity();

                  DECLARE @ShipmentChargesCount INT = 1;

                  WHILE ( @ShipmentChargesCount <= 5 )
                    BEGIN
                        IF ( @ShipmentChargesCount <> 2 )
                          BEGIN
                              INSERT INTO garima.Vaibhav_T_Shipment_Charges
                              SELECT @ShipmentCodeIdentity,
                                     10,
                                     1
                          END

                        SET @ShipmentChargesCount = @ShipmentChargesCount + 1;
                    END
              END
            ELSE
              BEGIN
                  INSERT INTO garima.Vaibhav_T_Shipment
                              (Shipment_Date,
                               Account_Number,
                               Charges,
                               Discount,
                               Shipment_Status,
                               CarrierNetCost,
                               CarrierVAT)
                  SELECT Dateadd(MONTH, @Random, Getdate()),
                         @CustomerIdentity,
                         Abs(@Random * 100),
                         @Random,
                         2,
                         Abs(@Random * 10),
                         Abs(@Random * 5);
              END

            SET @ShipmentCount = @ShipmentCount + 1;
        END

      SET @count = @count + 1
  END

SELECT *
FROM   garima.Vaibhav_M_Customer

SELECT *
FROM   garima.Vaibhav_T_Shipment

SELECT *
FROM   garima.Vaibhav_T_Shipment_Charges

SELECT TS.Shipment_Code,
       TS.Account_Number,
       TS.Charges,
       Isnull(Sum(TSC.AdjustmentValue), 0)   [AdjustmentValue],
       TS.Charges
       + Isnull(Sum(TSC.AdjustmentValue), 0) [TotalValue]
FROM   garima.Vaibhav_T_Shipment TS
       LEFT JOIN garima.Vaibhav_T_Shipment_Charges TSC
              ON TS.Shipment_Code = TSC.Shipment_Code
GROUP  BY TS.Shipment_Code,
          TS.Account_Number,
          TS.Charges
--DECLARE @count1 INT = 2000;
--Deleted Customers 100
--WHILE ( @count1 <= 2100 )
--  BEGIN
--      INSERT INTO garima.Vaibhav_M_Customer
--                  (Cust_CoName,
--                   Deleted)
--      SELECT 'Customer ' + CONVERT(NVARCHAR(50), @count1)
--             + ' NonAct',
--             1;
--      SET @count1 = @count1 + 1;
--  END
--SELECT *
--FROM   garima.Vaibhav_M_Customer 
