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

app.use(express.json()); 

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

app.get('/api/puzzle', async (req, res) => {
    try {
        const result = await pool.query('SELECT * FROM puzzle');
        const puzzleQuestion = result.rows;
        puzzleQuestion.forEach(puzzle => {
            if (puzzle.puzzle_image) {
                const buffer = puzzle.puzzle_image;
                const base64Image = buffer.toString('base64');
                puzzle.puzzle_image = base64Image;
            }
        });
        

        res.json(puzzleQuestion);
    } catch (error) {
        console.error('Error fetching Puzzle data', error);
        res.status(500).send('Server Error');
    }
});

app.get('/api/toppers', async (req, res) => {
    try {
        const result = await pool.query('SELECT * FROM toppers');
        const toppers = result.rows;
        res.json(toppers);
    } catch (error) {
        console.error('Error fetching toppers data', error);
        res.status(500).send('Server Error');
    }
});


app.post('/api/update-toppers', async (req, res) => {
    const { score: newScore, scorerName: newScorerName } = req.body;

    try {
        const result = await pool.query(
            `SELECT position, scorername, score FROM toppers ORDER BY score DESC`
        );
        const toppers = result.rows;

        if (toppers.length < 3 || newScore > toppers[2].score) {
            if (toppers.length === 3) {
                await pool.query(`DELETE FROM toppers WHERE position = 3`);
            }

            if (toppers.length >= 2 && newScore > toppers[1].score) {
                await pool.query(`UPDATE toppers SET position = 3 WHERE position = 2`);
            }
            if (toppers.length >= 1 && newScore > toppers[0].score) {
                await pool.query(`UPDATE toppers SET position = 2 WHERE position = 1`);
            }

            const newPosition = newScore > toppers[0].score ? 1 : (newScore > toppers[1].score ? 2 : 3);

            await pool.query(
                `INSERT INTO toppers (position, scorername, score) VALUES ($1, $2, $3)
                 ON CONFLICT (position) DO UPDATE 
                 SET scorername = EXCLUDED.scorername, score = EXCLUDED.score`,
                [newPosition, newScorerName, newScore]
            );

            res.json({ success: true, message: 'Top scores updated' });
        } else {
            res.json({ success: false, message: 'Score did not qualify for top 3' });
        }
    } catch (error) {
        console.error('Error updating top scores:', error);
        res.status(500).json({ success: false, message: 'Internal Server Error' });
    }
});
app.get('/api/position/:scorerName', async (req, res) => {
    const { scorerName } = req.params;

    try {
        const result = await pool.query(
            `SELECT position FROM toppers WHERE scorername = $1`,
            [scorerName]
        );

        if (result.rows.length > 0) {
            res.json({ success: true, position: result.rows[0].position });
        } else {
            res.json({ success: false, message: 'Scorer not found' });
        }
    } catch (error) {
        console.error('Error fetching position by scorer name:', error);
        res.status(500).json({ success: false, message: 'Internal Server Error' });
    }
});


app.use(express.static('public'));

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
