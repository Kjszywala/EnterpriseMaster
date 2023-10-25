// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function showDropdownServices() {
    document.getElementById('toggle-1').checked = true;
}

function hideDropdownServices() {
    document.getElementById('toggle-1').checked = false;
}
function showDropdownSupport() {
    document.getElementById('toggle-2').checked = true;
}
function hideDropdownSupport() {
    document.getElementById('toggle-2').checked = false;
}

// Get the modal and link elements
const modal = document.getElementById("myModal");
const openModal = document.getElementById("openModal");
const closeButton = document.querySelector(".close");

// Open the modal when the link is clicked
openModal.addEventListener("click", () => {
    modal.style.display = "block";
});

// Close the modal when the close button is clicked
closeButton.addEventListener("click", () => {
    modal.style.display = "none";
});

// Close the modal if the user clicks outside the modal content
window.addEventListener("click", (event) => {
    if (event.target === modal) {
        modal.style.display = "none";
    }
});