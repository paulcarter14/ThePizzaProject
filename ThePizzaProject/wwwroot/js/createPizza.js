const openLeftButton = document.querySelector('.left-baropen');
const openRightButton = document.querySelector('.right-baropen');

const leftsidebar = document.querySelector('.left-bar');
const rightsidebar = document.querySelector('.right-bar');


function toggleLeftBar() {
    var leftBar = document.getElementById('leftBar');
    leftBar.classList.toggle('open');
}


function toggleRightBar() {
    var rightBar = document.getElementById('rightBar');
    rightBar.classList.toggle('open');
}