const openButton = document.querySelector('.open-sideBar');
const sidebar = document.querySelector('.sidebar');

openButton.addEventListener('click', function () {
    sidebar.classList.toggle('open');
});