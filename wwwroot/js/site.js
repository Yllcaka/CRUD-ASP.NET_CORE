// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var hidden = true;
var validationError = document.getElementsByClassName("field-validation-error");

var createButton = document.getElementById("create");
var createForm = document.getElementById("create-form");


if (validationError.length > 0) {
    createForm.style.display = "block";
    createButton.innerHTML = "Close";
    createButton.classList.add("delete");
    Create();
} 

function Create() {
    
    hidden = !hidden;
    createForm.style.display = hidden ? "none" : "block";
    
}

createButton.onclick = () => {
    if (
        createButton.innerHTML == "Add") {
        createButton.innerHTML = "Close";
        createButton.classList.add("delete");
    } else {
        createButton.innerHTML = "Add";
        createButton.classList.remove("delete");
    }
    Create();
}
