SELECT TOP (1000) [MerchantId]
      ,[Name]
      ,[City]
      ,[ContactEmail]
      ,[MerchantCode]
      ,[Status]
  FROM [PayDeskDb].[dbo].[Merchants] ORDER BY [Name] desc
