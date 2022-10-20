CREATE TABLE [User] (
    [IdUser] INT IDENTITY (1, 1) NOT NULL,
    [Lastname]	NVARCHAR(20) 	NOT NULL,
    [Firstname] NVARCHAR (20) 	NOT NULL,
    [Login] 	NVARCHAR (20) 	NOT NULL,
    [Password] 	NVARCHAR (MAX) 	NOT NULL,
	[Salt] 	NVARCHAR (MAX) 	NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUser] ASC),
);

CREATE TABLE [Ticket] (
    [IdTicket]	INT	IDENTITY (1, 1) 	NOT NULL,
    [Name]  	NVARCHAR(20) 			NOT NULL,
    [IdUser]	INT				NULL,
    PRIMARY KEY CLUSTERED ([IdTicket] ASC),
    FOREIGN KEY ([IdUser]) REFERENCES [User] ([IdUser])
);

INSERT User(Lastname,Firstname,Login,Password, Salt)
	VALUES('Vialard','Celine','celvia','a1a6deda0b8d7ed3a72c07305987071ab205e964eddd8271a24411c9c98e0b04','bcgw!78'),
	('Betrisey','Julienne','julbet','1019fc40a7983ecf8a1687697a37f3fedcd5deb7ad1492cf02285d5d3ab7762c','jfdL$3nskj'),
	('Clerc','Theo','thecle','44cdf4a0998a7fb6e898b05d8377fc93baeeea0db83852d2cc04134f990ffa4c','Jbus453-');

INSERT Ticket(Name,IdUser)
	VALUE('ticket1',1);

INSERT Ticket(Name,IdUser)
	VALUE('ticket2',2);

INSERT Ticket(Name,IdUser)
	VALUE('ticket3',3);




