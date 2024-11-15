const urlParams = new URLSearchParams(window.location.search);
    const level = urlParams.get('level');
var difficultylevel;
if(level==2)
    difficultylevel="easy";
else if(level==3)
    difficultylevel="medium";
var IsWrong=false;
fetch('/api/quiz')
    .then(response => response.json())
    .then(questions => {
        var filteredQuestions = questions.filter(question => question.difficulty_level == difficultylevel);
        filteredQuestions=shuffleArray(filteredQuestions);
        let currentQuestionIndex = 0;
        let score = 0;
        const totalQuestions = filteredQuestions.length;
        document.querySelector('.score').textContent = `0/${totalQuestions}`;

        const loadQuestion = (index) => {
            const data = filteredQuestions[index];
            document.getElementById('question').textContent = data.question_statement;
            document.getElementById('option1').querySelector('p').textContent = `A) ${data.option_1}`;
            document.getElementById('option2').querySelector('p').textContent = `B) ${data.option_2}`;
            document.getElementById('option3').querySelector('p').textContent = `C) ${data.option_3}`;
            document.getElementById('option4').querySelector('p').textContent = `D) ${data.option_4}`;

            const correctAnswer = data.correct_option;

            if (data.question_image) {
                const base64Image = `data:image/png;base64,${data.question_image}`;
                document.getElementById('quizImage').src = base64Image;
                quizImage.style.display = 'block'; 
                document.querySelector('.buttoncontainer').style.top="77%";
                document.querySelector('.buttoncontainer').style.rowGap = '1vw';
            } else {
                document.getElementById('quizImage').src = ''; 
                quizImage.style.display = 'none';
                document.querySelector('.buttoncontainer').style.top="62%";
                document.querySelector('.buttoncontainer').style.rowGap = '1.5vw';
            }

            let optionClicked = false;
            document.querySelectorAll(".button").forEach(option => {
                option.style.backgroundColor = ""; 
                option.addEventListener('click', () => {
                    if (optionClicked) return;
                    optionClicked = true;

                    const selectedText = option.querySelector('p').textContent.split(') ')[1];
                    if (selectedText === correctAnswer) {
                        option.style.backgroundColor = "#BCEB01";
                        score++;
                    } else {
                        option.style.backgroundColor = "#F84434";
                        IsWrong=true;
                    }

                    document.querySelector('.score').textContent = `${score}/${totalQuestions}`;

                    setTimeout(() => {
                        currentQuestionIndex++;
                        if (currentQuestionIndex < totalQuestions&&(!IsWrong)) {
                            loadQuestion(currentQuestionIndex);
                        } else {
                            window.location.href = `QuizResultPage.html?score=${score}&totalQuestions=${totalQuestions}`;
                        }
                    }, 1000);
                });
            });
        };
        loadQuestion(currentQuestionIndex);
    })
    .catch(error => console.error('Error fetching quiz data:', error));

    function shuffleArray(array) {
        for (let i =0; i<array.length; i++) {
            let j = Math.floor(Math.random() * (array.length-1)); 
            [array[i], array[j]] = [array[j], array[i]]; 
        }
        return array;
    }
