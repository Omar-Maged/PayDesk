SELECT TOP 10
	m.MerchantCode,
	m.[Name] ,
	t.TerminalCode,
	tr.Amount
FROM PayDeskDb.dbo.Transactions tr
 JOIN PayDeskDb.dbo.Merchants m
	ON tr.MerchantId = m.MerchantId
JOIN PayDeskDb.dbo.Terminals t
	ON tr.TerminalId = t.TerminalId
WHERE tr.Status = 'Approved'
ORDER BY tr.Amount DESC