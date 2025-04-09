/* Jenny Fernandez Garcia Wad24

- J'ai mis des animaux à la place des flèches car je trouvais ça plus clair et sympa, mnt, les flèches sont à côté si tu préfères les utiliser :)
- J'ai ajouté dans le tableau de récap les chiffres qui ont été entrés afin d'éviter d'entrer plusieurs fois le même et de perdre une tentative.
- J'ai commencé à faire le timer mais il n'est pas encore 100% fonctionnel

*/ 

// 1. Je vais chercher les éléments du DOM

    // tentative de l'utilisateur
    const GUESS = document.getElementById("guess");
    // console.dir(GUESS); 
    const GUESS_BTN = document.getElementById("guessBtn");
    // console.log(GUESS_BTN);
    const RESPONSE = document.getElementById("response");
    const ATTEMPT = document.querySelector("#guessing p:last-child");
    console.log(ATTEMPT);

    // DOM pour tableau réponses
    const TBODY = document.querySelector("tbody");

    // DOM pour timer
    const TIMER = document.getElementById("timer");

// 2. Je liste les variables dont j'aurai besoin pour mes fonctions
    // Fonction nombre mystère
    let min = 1
    let max = 100

    // Variables tentatives
    const ATTEMPT_MAX = 10;
    let attempt = ATTEMPT_MAX;

    // fonction timer
    let minutes = 5;
    let secondes = 1;


// 3. Je crée les évènements pour comparer la réponse

GUESS.addEventListener("keyup", (event)=>{
    if (event.key !== "Enter") return;
    compareToMysteryNumber();
});

GUESS_BTN.addEventListener("click", compareToMysteryNumber);

// 4. J'initialise mon code:

let mysteryNumber = createRandomIntInclusive(min,max);
console.log(mysteryNumber); //pour debug
ATTEMPT.textContent = " Il vous reste " + `${attempt}`+ " tentatives";
TIMER.textContent = "05:00";

// 5. Liste des fonctions

// Cette fonction réintialise le document afin de pouvoir relancer une partie

function newGame(){
    // Je réinitialise ma partie devinette
    GUESS.value = "";
    attempt =ATTEMPT_MAX;  
    GUESS.removeAttribute("disabled");
    GUESS_BTN.removeAttribute("disabled");
    ATTEMPT.textContent = " Il vous reste " + `${attempt}`+ " tentatives";
    RESPONSE.innerHTML = "";
    TIMER.textContent = "05:00";

    // Je réinitialise la tableau de réponses
    while (TBODY.children[0]) {
        TBODY.children[0].remove();
    }

    // Je génère un nouveau nombre mystère
    mysteryNumber = createRandomIntInclusive(min,max);
    console.log(mysteryNumber); //pour debug
    setInterval();    
}

// Cette fonction permet de créer un chiffre aléatoire entre 2 valeurs comprises

function createRandomIntInclusive(min,max){
    min = Math.ceil(min);
    max = Math.floor(max);
    // Je renvoie un entier aléatoire compris entre valeur min et max inclues
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

// Cette fonction permet de comparer ce qui a été entré par l'utilisateur avec le nombre à deviner

function compareToMysteryNumber(){
    let guess = parseInt(GUESS.value);
    // console.log(guess);
    GUESS.focus()

    if(isNaN(guess) || guess > max || guess < min){
        alert("Veuillez entrer un chiffre correct!")
    }

    else{
        // Création éléments pour le tableau de réponse
    const RESPONSE_TR = document.createElement("tr");
    const RESPONSE_TD = document.createElement("td");
    const CURRENT_GUESS = document.createElement("td");
    const CLUE = document.createElement("td");

        if(guess !== mysteryNumber && attempt > 1){
            if(guess > mysteryNumber){
                // 1ere div
                attempt -= 1 ;
                RESPONSE.innerHTML = "Trop haut!"
                ATTEMPT.textContent = " Il vous reste " + `${attempt}`+ " tentative(s)";
                GUESS.value = "";
                

                // Tableau réponses
                CLUE.innerText = "🦒"; // "↑"
                RESPONSE_TD.innerText = RESPONSE.innerHTML;
                CURRENT_GUESS.innerText = `${guess}` + " :";
                RESPONSE_TR.append(CURRENT_GUESS,RESPONSE_TD,CLUE);           

                if(guess <= (mysteryNumber + 5)){
                    RESPONSE_TR.style.backgroundColor = "#a8dadc";
                    CLUE.innerText = "🦒" + "🥵";
                }
                TBODY.appendChild(RESPONSE_TR);
            }

            else if(guess < mysteryNumber){
                // 1ère div
                attempt -= 1;
                RESPONSE.innerHTML = "Trop bas!"
                ATTEMPT.textContent = " Il vous reste " + `${attempt}`+ " tentative(s)";
                GUESS.value = "↓";

                // Tableau réponse
                CLUE.innerText = "🐭"; // ""
                RESPONSE_TD.innerText = RESPONSE.innerHTML;
                CURRENT_GUESS.innerText = `${guess}` + " :";
                RESPONSE_TR.append(CURRENT_GUESS,RESPONSE_TD,CLUE);  
                
                if(guess >= (mysteryNumber - 5)){
                    RESPONSE_TR.style.backgroundColor = "#a8dadc";
                    CLUE.innerText = "🐭" + "🥵";
                }
                TBODY.appendChild(RESPONSE_TR);
            }
        }

        // Si plus de tentatives
        else if (attempt === 1 && guess !== mysteryNumber){
            GUESS.value = "";
            GUESS.setAttribute("disabled","true");
            GUESS_BTN.setAttribute("disabled","true");
            RESPONSE.innerHTML = " 😿Dommage, il ne te reste plus de tentatives 😿. Le nombre mystère était: "+ `${mysteryNumber}`;
            ATTEMPT.textContent = "";


                // Création du bouton rejouer
            const REPLAY = document.createElement("button");
            REPLAY.innerText = "Rejouer";
            REPLAY.addEventListener("click", newGame);
            ATTEMPT.appendChild(REPLAY);
        }
        
        // Si bonne réponse
        else{
            // Partie devinette
            GUESS.value = "";
            GUESS.setAttribute("disabled","true");
            GUESS_BTN.setAttribute("disabled","true");
            RESPONSE.innerHTML = " 🎉Bravo, tu as trouvé en "+ `${ATTEMPT_MAX - attempt +1}` + " tentative(s)!🎉 Le nombre mystère était bien : " + `${mysteryNumber}`;
            ATTEMPT.textContent = "";
            
            // Création du bouton rejouer
            const REPLAY = document.createElement("button");
            REPLAY.innerText = "Rejouer";
            REPLAY.addEventListener("click", newGame);
            ATTEMPT.appendChild(REPLAY);

            // Tableau de réponses
            CLUE.innerText = "🥳";
            RESPONSE_TD.innerText =" 🎉Bravo, tu as trouvé!";
            CURRENT_GUESS.innerText = `${guess}` + " :"
            RESPONSE_TR.style.backgroundColor = "green";
            RESPONSE_TR.append(CURRENT_GUESS,RESPONSE_TD,CLUE);  
            TBODY.appendChild(RESPONSE_TR);
        }
    }
}

// // Gérer le timer
setInterval(function(){
    if (minutes === 0 && secondes <= 30){
        TIMER.style.backgroundColor = "red";
    }
    else if(minutes === 0 && secondes === 1){
        TIMER.textContent = "00:00";
        TIMER.style.backgroundColor = "red";
    }
    else{
        secondes -= 1;
        if (secondes === 0){
            minutes -= 1;
            secondes = 59;            
        }
        else if(minutes === 0){
            minutes = minutes;
        }        
    }
    if(minutes.toString().length === "1"){
        minutes = "0" + minutes;
    }
    if(secondes.toString().length === "1"){
        secondes = "0" + secondes;
    }
    TIMER.textContent = `${minutes}`+ ":"+ `${secondes}`;
}, 1000);




