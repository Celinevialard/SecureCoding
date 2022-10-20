CREATE TABLE [User] (
    [IdUser] INT IDENTITY (1, 1) NOT NULL,
    [Lastname]	NVARCHAR(MAX) 	NOT NULL,
    [Firstname] NVARCHAR (MAX) 	NOT NULL,
    [Login] 	NVARCHAR (MAX) 	NOT NULL,
    [Password] 	NVARCHAR (MAX) 	NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUser] ASC),
);

CREATE TABLE [Ticket] (
    [IdTicket]	INT	IDENTITY (1, 1) 	NOT NULL,
    [Name]  	NVARCHAR(MAX) 			NOT NULL,
    [IdUser]	INT				NULL,
    PRIMARY KEY CLUSTERED ([IdTicket] ASC),
    FOREIGN KEY ([IdUser]) REFERENCES [User] ([IdUser])
);

INSERT User(Lastname,Firstname,Login,Password)
	VALUE('Vialard','Celine','celvia','salutasalut');

INSERT User(Lastname,Firstname,Login,Password)
	VALUE('Betrisey','Julienne','julbet','salutasalut');

INSERT User(Lastname,Firstname,Login,Password)
	VALUE('Clerc','Theo','thecle','salutasalut');

INSERT Ticket(Name,IdUser)
	VALUE('ticket1',1);

INSERT Ticket(Name,IdUser)
	VALUE('ticket2',2);

INSERT Ticket(Name,IdUser)
	VALUE('ticket3',3);




