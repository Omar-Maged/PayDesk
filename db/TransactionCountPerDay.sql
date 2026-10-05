SELECT TOP (1000)
    CAST(CreatedAtUtc AS DATE)  AS  TransactionDate,
    COUNT(*) AS TransactionCount
FROM Transactions

WHERE CAST(CreatedAtUtc AS DATE) >= DATEADD(DAY, -7, CURRENT_DATE)
GROUP BY 
    CAST(CreatedAtUtc AS DATE)
     
ORDER BY TransactionDate DESC;