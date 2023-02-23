CREATE TABLE SuperheroPowerLink (
    SuperheroId INT NOT NULL,
    PowerId INT NOT NULL,
    CONSTRAINT PK_SuperheroPowerLink PRIMARY KEY (SuperheroId, PowerId),
    CONSTRAINT FK_SuperheroPowerLink_Superhero FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id),
    CONSTRAINT FK_SuperheroPowerLink_Power FOREIGN KEY (PowerId) REFERENCES Power(Id)
);