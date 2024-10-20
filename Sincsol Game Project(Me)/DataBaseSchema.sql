CREATE TABLE quiz_questions (
    id SERIAL PRIMARY KEY,
    question_statement TEXT NOT NULL,
    option_1 TEXT NOT NULL,
    option_2 TEXT NOT NULL,
    option_3 TEXT NOT NULL,
    option_4 TEXT NOT NULL,
    correct_option TEXT NOT NULL,
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
