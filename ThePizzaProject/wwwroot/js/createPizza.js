const openLeftButton = document.querySelector('.left-baropen');
const openRightButton = document.querySelector('.right-baropen');

const leftsidebar = document.querySelector('.left-bar');
const rightsidebar = document.querySelector('.right-bar');


openLeftButton.addEventListener('click', function () {
    leftsidebar.classList.toggle('open');
});

openRightButton.addEventListener('click', function () {
    rightsidebar.classList.toggle('open');
});

//function toggleLeftBar() {
//    var leftBar = document.getElementById('leftBar');
//    leftBar.classList.toggle('open');
//}


//function toggleRightBar() {
//    var rightBar = document.getElementById('rightBar');
//    leftBar.classList.toggle('open');
//}