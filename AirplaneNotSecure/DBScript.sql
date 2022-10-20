CREATE TABLE [User] (
    [IdUser] INT IDENTITY (1, 1) NOT NULL,
    [Lastname]	NVARCHAR(20) 	NOT NULL,
    [Firstname] NVARCHAR (20) 	NOT NULL,
    [Login] 	NVARCHAR (20) 	NOT NULL,
    [Password] 	NVARCHAR (30) 	NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUser] ASC),
);

CREATE TABLE [Ticket] (
    [IdTicket]	INT	IDENTITY (1, 1) 	NOT NULL,
    [Name]  	NVARCHAR(20) 			NOT NULL,
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




