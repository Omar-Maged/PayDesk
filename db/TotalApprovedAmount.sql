SELECT 
	m.MerchantId,
	m.[Name],
	SUM(t.Amount) As TotalApprovedAmount
FROM PayDeskDb.dbo.Transactions t
 JOIN PayDeskDb.dbo.Merchants m
	ON t.MerchantId = m.MerchantId
WHERE t.Status = 'Approved'
GROUP BY
    m.MerchantId,
    m.Name
ORDER BY TotalApprovedAmount DESC;

