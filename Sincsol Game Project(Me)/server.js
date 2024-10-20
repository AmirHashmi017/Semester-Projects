const express = require('express');
const { Pool } = require('pg');
const app = express();
const port = 3000;

const pool = new Pool({
    user: 'postgres', 
    host: 'localhost',
    database: 'SincsolGame',
    password: 'postgres',
    port: 5432,           
});

app.get('/api/quiz', async (req, res) => {
    try {
        const result = await pool.query('SELECT * FROM quiz_questions');
        const quizQuestion = result.rows;
        quizQuestion.forEach(question => {
            if (question.question_image) {
                const buffer = question.question_image;
                const base64Image = buffer.toString('base64');
                question.question_image = base64Image;
            }
        });
        

        res.json(quizQuestion);
    } catch (error) {
        console.error('Error fetching quiz data', error);
        res.status(500).send('Server Error');
    }
});

app.use(express.static('public'));

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
