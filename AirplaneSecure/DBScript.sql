CREATE TABLE [User] (
    [IdUser] INT IDENTITY (1, 1) NOT NULL,
    [Lastname]	NVARCHAR(MAX) 	NOT NULL,
    [Firstname] NVARCHAR (MAX) 	NOT NULL,
    [Login] 	NVARCHAR (MAX) 	NOT NULL,
    [Password] 	NVARCHAR (MAX) 	NOT NULL,
	[Salt] 	NVARCHAR (MAX) 	NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUser] ASC),
);

CREATE TABLE [Ticket] (
    [IdTicket]	INT	IDENTITY (1, 1) 	NOT NULL,
    [Name]  	NVARCHAR(MAX) 			NOT NULL,
    [IdUser]	INT				NULL,
    PRIMARY KEY CLUSTERED ([IdTicket] ASC),
    FOREIGN KEY ([IdUser]) REFERENCES [User] ([IdUser])
);

INSERT User(Lastname,Firstname,Login,Password, Salt)
	VALUES('Vialard','Celine','celvia','oabe2guNftOnLAcwWYcHGrIF6WTt3YJxokQRycmOCwQ=','bcgw!78'),
	('Betrisey','Julienne','julbet','EBn8QKeYPs+KFodpejfz/tzV3retFJLPAihdXTq3diw=','jfdL$3nskj'),
	('Clerc','Theo','thecle','RM30oJmKf7bomLBdg3f8k7ru6g24OFLSzAQTT5kP+kw=','Jbus453-');

INSERT Ticket(Name,IdUser)
	VALUE('ticket1',1);

INSERT Ticket(Name,IdUser)
	VALUE('ticket2',2);

INSERT Ticket(Name,IdUser)
	VALUE('ticket3',3);




