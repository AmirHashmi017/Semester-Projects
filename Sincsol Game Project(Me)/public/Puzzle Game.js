var correctAnswer;
var customImageSrc;
var score=0;
fetch('/api/puzzle')
    .then(response => response.json())
    .then(puzzles => {
        if (puzzles.length > 0) {
            randompuzzle=Math.floor(Math.random()*(puzzles.length-1));
            const firstPuzzle = puzzles[randompuzzle];
            correctAnswer = firstPuzzle.animalname;

            const base64Image = `data:image/png;base64,${firstPuzzle.puzzle_image}`;
            customImageSrc = base64Image;
            loadAndSliceImage();

        } else {
            console.error("No puzzles available in the response.");
        }
    })
    .catch(error => console.error('Error fetching Puzzle data:', error));

function checkGuess(event) {
    event.preventDefault();  
    const userGuess = document.getElementById("puzzleguess").value.trim();
    if (userGuess.toLowerCase() !== correctAnswer.toLowerCase()) {
        document.querySelector(".wronganswerimage").style.display = "block";
        document.querySelector(".wronganswer").style.zIndex = "6";

        document.querySelector(".retrybutton").style.display = "block";
        
    }
    else{
        let IsTopper=0;
        let ranking=0;
        let scorepercentage=((25-score)/25)*100;
        fetch('/api/toppers')
    .then(response => response.json())
    .then(toppers => {
        toppers.forEach(topper => {
            console.log(topper.score);
            if(scorepercentage>topper.score)
            {
                IsTopper=1;
            }
            if(IsTopper==0)
                {
                    window.location.href = `PuzzleResultPage.html?score=${score}&ranking=${ranking}`;
                }
                else{
                    window.location.href = `TopScorer.html?score=${score}&ranking=${ranking}`;
                }
        });
    })
    .catch(error => console.error('Error fetching Puzzle data:', error));
    
    }
}

document.querySelector(".retrybutton").addEventListener("click",()=>
{
    document.querySelector(".wronganswerimage").style.display = "None";
    document.querySelector(".wronganswer").style.zIndex = "1";
    document.querySelector(".retrybutton").style.display = "block";
    document.getElementById("puzzleguess").value="";
})

const coverImageSrc = "Assets/Puzzle Image.png";

function loadAndSliceImage() {
    const img = new Image();
    img.onload = () => {
        resizeAndSliceImage(img);
    };
    img.src = customImageSrc;
}

function resizeAndSliceImage(img) {
    const targetWidth = 350; 
    const targetHeight = 250;
    const rows = 5;
    const cols = 5;
    const pieceWidth = targetWidth / cols;
    const pieceHeight = targetHeight / rows;

    const resizeCanvas = document.createElement("canvas");
    resizeCanvas.width = targetWidth;
    resizeCanvas.height = targetHeight;
    const resizeCtx = resizeCanvas.getContext("2d");

    resizeCtx.drawImage(img, 0, 0, targetWidth, targetHeight);

    const canvas = document.createElement("canvas");
    const ctx = canvas.getContext("2d");

    for (let row = 0; row < rows; row++) {
        for (let col = 0; col < cols; col++) {
            canvas.width = pieceWidth;
            canvas.height = pieceHeight;
            ctx.clearRect(0, 0, pieceWidth, pieceHeight);
            ctx.drawImage(resizeCanvas, col * pieceWidth, row * pieceHeight, pieceWidth, pieceHeight, 0, 0, pieceWidth, pieceHeight);

            const pieceImg = canvas.toDataURL();
            const puzzleBox = document.querySelector(`.puzzle-box[data-index="${row * cols + col + 1}"]`);

            if (puzzleBox) {
                const boxImage = puzzleBox.querySelector(".box-image");
                boxImage.src = coverImageSrc;
                const handleClick = () => {
                    boxImage.src = pieceImg; 
                    score+=1;
                    document.querySelector('.score').textContent = `${score}/25`;
                    puzzleBox.removeEventListener("click", handleClick);
                };

                puzzleBox.addEventListener("click", handleClick);
            }
        }
    }
}

const puzzleGrid = document.querySelector(".puzzle-grid");
for (let i = 1; i <= 25; i++) {
    const puzzleBox = document.createElement("div");
    puzzleBox.classList.add("puzzle-box");
    puzzleBox.setAttribute("data-index", i);

    const containerImage = document.createElement("img");
    containerImage.src = "Assets/PuzzleBox.png"; 
    containerImage.alt = `Puzzle Container ${i}`;
    containerImage.classList.add("container-image");

    const boxImage = document.createElement("img");
    boxImage.alt = `Puzzle Box ${i}`;
    boxImage.classList.add("box-image");
    boxImage.src = coverImageSrc;
    
    const labelImage = document.createElement("div");
    labelImage.classList.add("label-image");

    const labelImg = document.createElement("img");
    labelImg.src = "Assets/PuzzleLabel.png";
    labelImg.alt = `Label ${i}`;
    labelImg.classList.add("label-img");

    const labelText = document.createElement("span");
    labelText.classList.add("label-text");
    labelText.textContent = i;

    labelImage.appendChild(labelImg);
    labelImage.appendChild(labelText);
    puzzleBox.appendChild(containerImage);
    puzzleBox.appendChild(boxImage);
    puzzleBox.appendChild(labelImage);

    puzzleGrid.appendChild(puzzleBox);
}

