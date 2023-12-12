let searchBtn = document.querySelector('#search-btn');
let searchBar = document.querySelector('.search-bar-container');
let menu = document.querySelector('#menu-bar');
let navbar = document.querySelector('.navbar');

menu.addEventListener('click', () => {
    menu.classList.toggle('fa-times');
    navbar.classList.toggle('active');

    // If the navbar is active, close the search bar
    if (navbar.classList.contains('active')) {
        searchBtn.classList.remove('fa-times');
        searchBar.classList.remove('active');
    }
});

searchBtn.addEventListener('click', () => {
    searchBtn.classList.toggle('fa-times');
    searchBar.classList.toggle('active');

    // If the search bar is active, close the navbar
    if (searchBar.classList.contains('active')) {
        menu.classList.remove('fa-times');
        navbar.classList.remove('active');
    }
});
