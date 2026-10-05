SELECT 
    t.TerminalId,
    COUNT(*) AS TransactionCount,
    Cast(COUNT (CASE WHEN tr.Status = 'Declined' THEN 1 END)*100/COUNT(*) as varchar)+ '%' AS DeclinedPercentage

FROM Transactions tr
JOIN Terminals t
	ON tr.TerminalId = t.TerminalId

GROUP BY 
    t.TerminalId
     
ORDER BY TransactionCount DESC;



select * from MerchantsCount