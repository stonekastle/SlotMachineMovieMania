var getResults = function () {
    console.log("fire results")
    var questionSet = Math.floor(Math.random() * 6) + 1;
    return { success: true, reels: [questionSet, questionSet, questionSet], prize: null, credits: 10, dayWinnings: 10, lifetimeWinnings: 500 }
}

getResults();