
let timerId1;
let timerId2;

document.getElementById("minutes").value = localStorage.getItem('length');

function StartExercise() {
    let min = String(document.getElementById("minutes").value);
    console.log(min);
    localStorage.setItem('length', min);
    document.body.style.backgroundColor = "lightskyblue";
    document.getElementById("breath").innerHTML = "Breath in";
    // repeat with the interval of 5 seconds = 6 breaths
    timerId1 = setInterval(() => {
        Breathing()
    }, 5000);

    // after X seconds stop
    timerId2 = setTimeout(() => {
        clearInterval(timerId1);
        document.getElementById("breath").innerHTML = "You're done";
        document.body.style.backgroundColor = "whitesmoke";

        window.location.href = 'AddExercise?min=' + localStorage.getItem('length');
        //var url = '@Url.Action("AddExercise", "Home")?min=' + localStorage.getItem('length');
        //console.log(url);

    }, document.getElementById("minutes").value * 6000);
}

function Breathing() {
    var s = document.body.style;

    if (s.backgroundColor != "lightskyblue") {
        document.getElementById("breath").innerHTML = "Breath in";
        s.backgroundColor = "lightskyblue";
    }
    else {
        document.getElementById("breath").innerHTML = "Breath out";
        s.backgroundColor = "dodgerblue";
    }
}

function CancelExercise() {
    clearInterval(timerId1);
    clearTimeout(timerId2);
    document.getElementById("breath").innerHTML = "You're exercise is cancelled";
    document.body.style.backgroundColor = "whitesmoke";
}