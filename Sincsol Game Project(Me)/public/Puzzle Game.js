function checkGuess(event) {
    event.preventDefault(); 
    const correctAnswer = "Dog"; 
    const userGuess = document.getElementById("puzzleguess").value.trim();
    
    if (userGuess.toLowerCase() !== correctAnswer.toLowerCase()) {
        document.querySelector(".wronganswerimage").style.display = "block";
        document.querySelector(".wronganswer").style.zIndex = "6";

        document.querySelector(".retrybutton").style.display = "block";
        
    }
}

document.querySelector(".retrybutton").addEventListener("click",()=>
{
    document.querySelector(".wronganswerimage").style.display = "None";
    document.querySelector(".wronganswer").style.zIndex = "1";
    document.querySelector(".retrybutton").style.display = "block";
    document.getElementById("puzzleguess").value="";
})
const puzzleGrid = document.querySelector(".puzzle-grid");

for (let i = 1; i <= 25; i++) {
    const puzzleBox = document.createElement("div");
    puzzleBox.classList.add("puzzle-box");

    const containerImage = document.createElement("img");
    containerImage.src = "Assets/PuzzleBox.png";
    containerImage.alt = `Puzzle Container ${i}`;
    containerImage.classList.add("container-image");

    const boxImage = document.createElement("img");
    boxImage.src = "Assets/puzzle Image.png";
    boxImage.alt = `Puzzle Box ${i}`;
    boxImage.classList.add("box-image");

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

