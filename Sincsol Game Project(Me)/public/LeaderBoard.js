fetch('/api/toppers')
    .then(response => response.json())
    .then(toppers => {
        let count=0;
        toppers.sort((a, b) => b.score - a.score);
        toppers.forEach((topper, index) => {
            if(count==0)
            {
                document.querySelector('.rank').innerText=topper.scorername;
            }
            const scoreElement = document.getElementById(`score${index + 1}`);
            if (scoreElement) {
                scoreElement.innerText = `Score: ${topper.score}%`;
            }
            count++;
        });
    })
    .catch(error => console.error('Error fetching Puzzle data:', error));