const urlParams = new URLSearchParams(window.location.search);
const score = urlParams.get('score'); 
const scorePercentage = (((25 - score) / 25) * 100);

async function checkPosition(event) {
    event.preventDefault();
    const username = document.getElementById("puzzleguess").value.trim();

    const updateResponse=await updateTopScores(scorePercentage, username); 
    if (updateResponse && updateResponse.success) {
        const positionResponse = await fetch(`/api/position/${encodeURIComponent(username)}`);
        const positionData = await positionResponse.json();

        if (positionData.success) {
            window.location.href = `PuzzleResultPage.html?score=${score}&ranking=${positionData.position}`;
        } else {
            console.error('Error retrieving position:', positionData.message);
            alert('Unable to determine your ranking.');
        }
    } else {
        console.error('Error updating top scores:', updateResponse.message);
        alert('Score update failed.');
    }
}

async function updateTopScores(score, scorerName) {
    try {
        const response = await fetch('/api/update-toppers', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ score, scorerName })
        });

        return await response.json();  
    } catch (error) {
        console.error('Error updating top scores:', error);
        throw error; 
    }
}
