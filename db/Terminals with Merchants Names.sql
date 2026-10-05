SELECT TOP (1000)
    t.TerminalId,
    t.TerminalCode,
    t.Channel,
    m.MerchantId,
    m.Name AS MerchantName
FROM PayDeskDb.dbo.Terminals t
INNER JOIN PayDeskDb.dbo.Merchants m
    ON t.MerchantId = m.MerchantId;