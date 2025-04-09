
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
    const START_DIV = document.getElementById("start");

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
    let timer;

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
TIMER.textContent = `${minutes}`+ ": 00";
startGame();


// 5. Liste des fonctions

// Cette fonction réintialise le document afin de pouvoir relancer une partie

function newGame(){
    // Je réinitialise ma partie devinette
    GUESS.value = "";
    attempt = ATTEMPT_MAX;    
    ATTEMPT.textContent = " Il vous reste " + `${attempt}`+ " tentatives";
    RESPONSE.innerHTML = "";

    // Je réinitialise le timer
    TIMER.textContent = `${minutes}`+ ": 00";
    minutes = 5;
    secondes = 1;  
    startGame();

    // Je réinitialise la tableau de réponses
    while (TBODY.children[0]) {
        TBODY.children[0].remove();
    }

    // Je génère un nouveau nombre mystère
    mysteryNumber = createRandomIntInclusive(min,max);
    console.log(mysteryNumber); //pour debug
        
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
                GUESS.value = "";

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
            RESPONSE.innerHTML = " 😿Dommage, il ne te reste plus de tentatives 😿. Le nombre mystère était: "+ `${mysteryNumber}`;
            stopGame();
        }
        
        // Si bonne réponse
        else{
            winGame();
            RESPONSE.innerHTML = " 🎉Bravo, tu as trouvé en "+ `${ATTEMPT_MAX - attempt +1}` + " tentative(s)!🎉 Le nombre mystère était bien : " + `${mysteryNumber}`;
            stopGame()

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

// Cette fonction arrête le jeu en cas de fin de timer

function stopGame(){
    clearInterval(timer);
    GUESS.value = "";
    GUESS.setAttribute("disabled","true");
    GUESS_BTN.setAttribute("disabled","true");
    ATTEMPT.textContent = "";

    // Création du bouton rejouer
    const REPLAY = document.createElement("button");
    REPLAY.innerText = "Rejouer";
    REPLAY.addEventListener("click", newGame);
    ATTEMPT.appendChild(REPLAY);
}

// Cette fonction crée le bouton start qui permet de lancer le jeu et le chrono

function startGame(){
    const START = document.createElement("button");
    START.innerText = "START";
    START.addEventListener("click",()=>{
        GUESS.removeAttribute("disabled");
        GUESS_BTN.removeAttribute("disabled");
        timer = setInterval(function(){
    
            if(minutes === 0 && secondes === 0){
                TIMER.textContent = "00:00";
                TIMER.style.backgroundColor = "red";
                RESPONSE.innerHTML = " ⌚Dommage, il ne te reste plus de temps! ⌚ Le nombre mystère était: "+ `${mysteryNumber}`;
                stopGame();
        
            }
            else{
                if (minutes === 0 && secondes <= 30){
                    TIMER.style.backgroundColor = "red";
                }
                if (secondes === 0){
                    minutes -= 1;
                    secondes = 59;
                }else{
                    secondes -= 1;
                }
        
            }   
            let displayMinutes = minutes.toString().padStart(2,"0");
            let displaySecondes = secondes.toString().padStart(2,"0");
        
            TIMER.textContent = `${displayMinutes}`+ ":"+ `${displaySecondes}`;
            
        }, 1000);
        START_DIV.removeChild(START);
    });
    START_DIV.appendChild(START);
}

function winGame(){
    const CANVAS = document.getElementById("confetti-canvas");

    // Code pour créer des feux d'artifice de confettis pendant 15 secondes

    let duration = 15*1000;
    let animationEnd = Date.now() + duration;
    let defaults = { //Ici on donne les paramètres de 
        startVelocity: 30, 
        spread: 360, 
        ticks: 60, 
        zIndex: 0 
    };

    function randomInRange(min, max) {
        return Math.random() * (max - min) + min;
    }

    let interval = setInterval(()=>{
        let timeLeft = animationEnd - Date.now();
        if (timeLeft <= 0){
            return clearInterval(interval);
        }
        let particleCount = 50 * (timeLeft /duration)

        // Start a bit higher than random
        confetti({ ...defaults, particleCount, origin: { x: randomInRange(0.1, 0.3), y: Math.random() - 0.2 } });
        confetti({ ...defaults, particleCount, origin: { x: randomInRange(0.7, 0.9), y: Math.random() - 0.2 } });

    } ,250);

    /*   Cette partie-ci ne fait le code qu'une seule fois, commenter l'autre partie du code pour la faire fonctionner
    let myConfetti = confetti.create(CANVAS, {
            resize: true,
            useWorker: true
        });
        myConfetti({
            particleCount: 150, // Nombre de confetti à lancer
            spread: 180,// Angle maximal de dispersion des confettis
        });
    }*/
}



