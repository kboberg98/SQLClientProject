-- Insert powers
INSERT INTO Power (Name, Description) VALUES ('Super Strength', 'Gives hero super human strength');
INSERT INTO Power (Name, Description) VALUES ('Teleportation', 'Ability to teleport anywhere');
INSERT INTO Power (Name, Description) VALUES ('Invisibility', 'Ability to turn invisible');
INSERT INTO Power (Name, Description) VALUES ('Telekinesis', 'Ability to lift objects with their mind');

-- Associate powers with superheroes
INSERT INTO SuperheroPowerLink (SuperheroId, PowerId) VALUES (1, 1);
INSERT INTO SuperheroPowerLink (SuperheroId, PowerId) VALUES (1, 2);
INSERT INTO SuperheroPowerLink (SuperheroId, PowerId) VALUES (2, 2);
INSERT INTO SuperheroPowerLink (SuperheroId, PowerId) VALUES (2, 3);
INSERT INTO SuperheroPowerLink (SuperheroId, PowerId) VALUES (3, 3);
INSERT INTO SuperheroPowerLink (SuperheroId, PowerId) VALUES (3, 4);