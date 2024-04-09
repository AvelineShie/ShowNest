document.getElementById("header-nav-search-input").addEventListener("keypress", function (event) {
    if (event.key === "Enter") {
        event.preventDefault();
        document.getElementById("searchForm");
        console.log("Enter key pressed, form submitted.");
    }
});
