-- Insert assistant 1
INSERT INTO Assistant (Name, SuperheroId)
VALUES ('Mary Jane Watson', 1);

-- Associate assistant 1 with superhero 1
UPDATE Assistant
SET SuperheroId = 1
WHERE Name = 'Mary Jane Watson';

-- Insert assistant 2
INSERT INTO Assistant (Name, SuperheroId)
VALUES ('Alfred Pennyworth', 2);

-- Associate assistant 2 with superhero 2
UPDATE Assistant
SET SuperheroId = 2
WHERE Name = 'Alfred Pennyworth';

-- Insert assistant 3
INSERT INTO Assistant (Name, SuperheroId)
VALUES ('Lois Lane', 3);

-- Associate assistant 3 with superhero 3
UPDATE Assistant
SET SuperheroId = 3
WHERE Name = 'Lois Lane';