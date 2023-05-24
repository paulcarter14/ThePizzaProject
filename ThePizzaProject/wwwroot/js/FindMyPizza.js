const openLeftButton = document.querySelector('.left-baropen');
const openRightButton = document.querySelector('.right-baropen');

const leftsidebar = document.querySelector('.left-bar');
const rightsidebar = document.querySelector('.right-bar');
const topbar = document.querySelector('.top-bar')


//Öppna båda
function toggleFilter() {
    var leftBar = document.getElementById('leftBar');
    leftBar.classList.toggle('open');

    var rightBar = document.getElementById('rightBar');
    rightBar.classList.toggle('open');

    var topbar = document.getElementById('topbar');
    topbar.classList.toggle('open');
}

//orkade inte skriva om dessa så de säger att man kan toggla men egentligen stänger man dem bara.
function toggleLeftBar() {
    var leftBar = document.getElementById('leftBar');
    leftBar.classList.toggle('open');
}


function toggleRightBar() {
    var rightBar = document.getElementById('rightBar');
    rightBar.classList.toggle('open');
}

//applicera båda formsen på samma submit knapp.
var positiveForm = document.getElementById('positiveForm');
var negativeForm = document.getElementById('negativeForm');

var submitFormsButton = document.getElementById('submitForms');

submitFormsButton.addEventListener('click', function (e) {
    e.preventDefault(); // Preventing default form submission

    // Submit both forms
    positiveForm.submit();
    negativeForm.submit();
});