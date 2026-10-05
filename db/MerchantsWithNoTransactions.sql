SELECT
    MerchantId,
    Name
FROM Merchants 
where MerchantId not in (select distinct MerchantId from [Transactions] 
    WHERE CAST(CreatedAtUtc AS DATE)  = DATEADD(DAY, -2, CURRENT_DATE));



    
