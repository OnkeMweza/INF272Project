function Vitals()
{
   
    document.getElementById("hRate").innerHTML = Math.floor((Math.random() * 150) + 60);
    document.getElementById("bSugar").innerHTML = Math.floor((Math.random() * 170) + 60);
    document.getElementById("wBlood").innerHTML = Math.floor((Math.random() * 100000) + 10000);
    document.getElementById("rBlood").innerHTML = Math.floor((Math.random() * 100000) + 10000);
    document.getElementById("glucose").innerHTML = Math.floor((Math.random() * 140) + 50);
    document.getElementById("cholesterol").innerHTML = Math.floor((Math.random() * 100) + 20);
    document.getElementById("bPressure").innerHTML = Math.floor((Math.random() * 150) + 35);
    document.getElementById("antibodies").innerHTML = Math.floor((Math.random() * 20000) + 3000);
    document.getElementById("iLevels").innerHTML = Math.floor((Math.random() * 600) + 450);

    if (document.getElementById("hRate").innerHTML == 150 || document.getElementById("hRate").innerHTML == 60) {
        document.getElementById("hRate").style.color = "red";
    }
    if (document.getElementById("bSugar").innerHTML == 170 || document.getElementById("bSugar").innerHTML == 60) {
        document.getElementById("bSugar").style.color = "red";
    }
    if (document.getElementById("wBlood").innerHTML < 12000) {
        document.getElementById("wBlood").style.color = "red";
    }
    if (document.getElementById("rBlood").innerHTML < 12000) {
        document.getElementById("rBlood").style.color = "red";
    }
    if (document.getElementById("glucose").innerHTML == 140 || document.getElementById("glucose").innerHTML == 50) {
        document.getElementById("glucose").style.color = "red";
    }
    if (document.getElementById("cholesterol").innerHTML == 100 || document.getElementById("cholesterol").innerHTML == 20) {
        document.getElementById("cholesterol").style.color = "red";
    }
    if (document.getElementById("bPressure").innerHTML == 150 || document.getElementById("bPressure").innerHTML == 35) {
        document.getElementById("bPressure").style.color = "red";
    }
    if (document.getElementById("antibodies").innerHTML < 3500) {
        document.getElementById("antibodies").style.color = "red";
    }
    if (document.getElementById("iLevels").innerHTML < 470) {
        document.getElementById("iLevels").style.color = "red";
    }

    if (document.getElementById("hRate").style.color == "red" || document.getElementById("bSugar").style.color == "red" || document.getElementById("wBlood").style.color == "red" || document.getElementById("rBlood").style.color == "red" || document.getElementById("glucose").style.color == "red" || document.getElementById("cholesterol").style.color == "red" || document.getElementById("bPressure").style.color == "red" || document.getElementById("antibodies").style.color == "red" || document.getElementById("iLevels").style.color == "red")
    {
        alert("One or more of your vitals are at a concerning level, please contact the nearest hospital if possible");

        document.getElementById("hRate").style.color = "black";
        document.getElementById("bSugar").style.color = "black";
        document.getElementById("wBlood").style.color = "black";
        document.getElementById("rBlood").style.color = "black";
        document.getElementById("glucose").style.color = "black";
        document.getElementById("cholesterol").style.color = "black";
        document.getElementById("bPressure").style.color = "black";
        document.getElementById("antibodies").style.color = "black";
        document.getElementById("iLevels").style.color = "black";
        document.getElementById("hospAlert").style.color = "red";
    }
    
}

function hospDistance()
{

    var iOne = Math.floor((Math.random() * 10) + 0);
    var iTwo = Math.floor((Math.random() * 10) + 0);
    var iThree = Math.floor((Math.random() * 10) + 0);
    var iFour = Math.floor((Math.random() * 10) + 0);
    var iFive = Math.floor((Math.random() * 10) + 0);

    var distance = [1.4, 0.5, 3, 4.5, 5, 4.7, 0.7, 2, 2.7, 1.3, 5.5]; 

    document.getElementById("distanceHospOne").innerHTML = distance[iOne];
    document.getElementById("distanceHospTwo").innerHTML = distance[iTwo];
    document.getElementById("distanceHospThree").innerHTML = distance[iThree];
    document.getElementById("distanceHospFour").innerHTML = distance[iFour];
    document.getElementById("distanceHospFive").innerHTML = distance[iFive];

    if (distance[iOne] < distance[iTwo] && distance[iThree] && distance[iFour] && distance[iFive]) {
        document.getElementById("distanceHospOne").style.color = "blue";
        document.getElementById("hospNameOne").style.color = "blue";
    }
    else if (distance[iTwo] < distance[iOne] && distance[iThree] && distance[iFour] && distance[iFive]) {
        document.getElementById("distanceHospTwo").style.color = "blue";
        document.getElementById("hospNameTwo").style.color = "blue";
    }
    else if (distance[iThree] < distance[iOne] && distance[iTwo] && distance[iFour] && distance[iFive]) {
        document.getElementById("distanceHospThree").style.color = "blue";
        document.getElementById("hospNameThree").style.color = "blue";
    }
    else if (distance[iFour] < distance[iOne] && distance[iThree] && distance[iTwo] && distance[iFive]) {
        document.getElementById("distanceHospFour").style.color = "blue";
        document.getElementById("hospNameFour").style.color = "blue";
    }
    else
    {
        document.getElementById("distanceHospFive").style.color = "blue";
        document.getElementById("hospNameFive").style.color = "blue";
    }
    

}