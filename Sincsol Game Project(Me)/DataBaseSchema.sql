CREATE TABLE quiz_questions (
    id SERIAL PRIMARY KEY,
    question_statement VARCHAR(50) NOT NULL,
    option_1 VARCHAR(20) NOT NULL,
    option_2 VARCHAR(20) NOT NULL,
    option_3 VARCHAR(20) NOT NULL,
    option_4 VARCHAR(20) NOT NULL,
    correct_option VARCHAR(20) NOT NULL,
    difficulty_level TEXT CHECK (difficulty_level IN ('easy', 'medium', 'hard')) NOT NULL,
    question_image BYTEA,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);



INSERT INTO quiz_questions (question_statement, option_1, option_2, option_3, option_4, correct_option, difficulty_level, question_image)
VALUES (
    'What sound does this animal make?',
    'Meow',
    'Oink',
    'Moo',
    'Quark',
    'Meow',
    'easy',
    pg_read_binary_file('D:/Github Repos/Sincsol-Game-Project/Assets/CatImage.png')
);


CREATE TABLE Puzzle (
    id SERIAL PRIMARY KEY,
    AnimalName TEXT NOT NULL,
    puzzle_image BYTEA NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Puzzle (AnimalName, puzzle_image)
VALUES (
    'Cat',
    pg_read_binary_file('D:/Github Repos/Sincsol-Game-Project/Assets/CatImage.png')
);

CREATE TABLE Toppers (
    id SERIAL PRIMARY KEY,
    position INT NOT NULL UNIQUE,
    scorername TEXT NOT NULL,
    score FLOAT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);



INSERT INTO Toppers (position , scorername,score)
VALUES (
    '3',
 	'Ahmad',
	10.3
);


UPDATE toppers
SET score = 15.43
WHERE position=2;