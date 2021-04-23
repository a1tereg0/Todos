// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
if ('onLine' in navigator) {
    if (!navigator.onLine) {
        if (window.location.pathname === '/Admin/TodoPages/Create' || window.location.pathname === '/Admin/TodoPages/Edit') {
            
        }
    }
}

window.addEventListener('offline', () => {
    if (window.location.pathname === '/Admin/TodoPages/Create' || window.location.pathname === '/Admin/TodoPages/Edit') {
        alert("Cant add or make changes when offline");
        let submitButton = document.querySelector('input[type=submit]')
        submitButton.disabled = true;
    }
})
window.addEventListener('online', () => {
    if (window.location.pathname === '/Admin/TodoPages/Create' || window.location.pathname === '/Admin/TodoPages/Edit') {
        let submitButton = document.querySelector('input[type=submit]')
        submitButton.disabled = false;
    }
})