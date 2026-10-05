USE PayDeskDb;
GO

create table Merchants
(
	Id int Identity(1,1) Primary Key,
	Name VARCHAR(200) NOT NULL,
    City VARCHAR(100) NOT NULL,
	ContactEmail VARCHAR(200) NOT NULL,
	MerchantCode VARCHAR(6) NOT NULL UNIQUE,
	Status VARCHAR(20) NOT NULL,


	CONSTRAINT CK_Merchants_Status CHECK (Status IN ('Active', 'Suspended'))


);

alter table Terminals
(
	TerminalId int Identity(1,1) Primary Key,
	TerminalCode VARCHAR(8) NOT NULL UNIQUE,
	MerchantId int NOT NULL,
	Channel VARCHAR(20) NOT NULL,
	Status VARCHAR(20) NOT NULL,

	CONSTRAINT CK_Terminals_Status CHECK(Status IN ('Active', 'Inactive')),
	CONSTRAINT FK_Terminals_Merchants Foreign Key (MerchantId) references Merchants(MerchantId)

);

create table Transactions
(
	Id int Identity(1,1) Primary Key,
	Reference VARCHAR(50) NOT NULL UNIQUE,
	MerchantId int NOT NULL,
	TerminalId int NOT NULL,
	Amount Bigint NOT NULL,
	Currency VARCHAR(3) NOT NULL,
	CardLast4 VARCHAR(4) NOT NULL,
	CardScheme VARCHAR(20) NOT NULL,
	Status VARCHAR(20) NOT NULL,
	CreatedAtUtc DATETIME2 NOT NULL,

	CONSTRAINT CK_Transactions_Status CHECK(Status IN ('Pending', 'Approved', 'Declined', 'Refunded')),
	CONSTRAINT FK_Transactions_Merchants Foreign Key (MerchantId) references Merchants(Id),
	CONSTRAINT FK_Transactions_Terminals Foreign Key (TerminalId) references Terminals(Id)


);

create table DailySummaries
(
	Id int Identity(1,1) Primary Key
);