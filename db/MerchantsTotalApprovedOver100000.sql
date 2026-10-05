
create view MerchantsCount_ as
SELECT 
	m.MerchantId,
	m.[Name],
	format(SUM(t.Amount), 'N2') As TotalApprovedAmount,
	SUM(t.Amount) As TotalApprovedAmount2
FROM PayDeskDb.dbo.Transactions t
 JOIN PayDeskDb.dbo.Merchants m
	ON t.MerchantId = m.MerchantId
WHERE t.Status = 'Approved'
GROUP BY
    m.MerchantId,
    m.Name
HAVING SUM(t.Amount) > 100000
ORDER BY TotalApprovedAmount DESC


