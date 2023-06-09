﻿const openLeftButton = document.querySelector('.left-baropen');
const openRightButton = document.querySelector('.right-baropen');

const leftsidebar = document.querySelector('.left-bar');
const rightsidebar = document.querySelector('.right-bar');
const topbar = document.querySelector('.top-bar')


//Öppna båda
function toggleFilter() {
    var leftBar = document.getElementById('leftBar');
    var rightBar = document.getElementById('rightBar');
    var topbar = document.getElementById('topbar');

    if (leftBar.classList.contains('open') && rightBar.classList.contains('open')) {
        // Both sidebars are open, so close them both
        leftBar.classList.remove('open');
        rightBar.classList.remove('open');
        topbar.classList.remove('open');
    } else {
        // At least one sidebar is closed, so open the closed one
        if (!leftBar.classList.contains('open')) {
            leftBar.classList.add('open');
        }
        if (!rightBar.classList.contains('open')) {
            rightBar.classList.add('open');
        }
        topbar.classList.add('open');
    }
}

//orkade inte skriva om dessa så de säger att man kan toggla men egentligen stänger man dem bara.
function toggleLeftBar() {
    event.preventDefault();
    var leftBar = document.getElementById('leftBar');
    var rightBar = document.getElementById('rightBar');
    var topbar = document.getElementById('topbar');

    leftBar.classList.toggle('open');

    // If both sidebars are closed, toggle the topbar
    if (!leftBar.classList.contains('open') && !rightBar.classList.contains('open')) {
        topbar.classList.toggle('open');
    }
}


function toggleRightBar() {
    event.preventDefault();
    var leftBar = document.getElementById('leftBar');
    var rightBar = document.getElementById('rightBar');
    var topbar = document.getElementById('topbar');

    rightBar.classList.toggle('open');

    // If both sidebars are closed, toggle the topbar
    if (!leftBar.classList.contains('open') && !rightBar.classList.contains('open')) {
        topbar.classList.toggle('open');
    }
}

function submitForm() {
    document.getElementById('positiveForm').submit();
}