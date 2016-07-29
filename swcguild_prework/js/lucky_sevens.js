
function play(){
    var startingBet = document.getElementById("betAmount").value;
    var bet = startingBet;
    var dice1 = Math.floor(Math.random() *6) +1;
    var dice2 = math.floor(Math.random() *6) +1;
    var diceTotal = dice1 + dice2;
    
    while (bet > 0){
        if (diceTotal != 7){
            bet -=1;
        }
        else{ 
            bet +=4
            }
    }
}
