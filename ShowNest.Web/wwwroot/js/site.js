document.getElementById("header-nav-search-input").addEventListener("keypress", function (event) {
    if (event.key === "Enter") {
        event.preventDefault();
        const searchString = document.getElementById("header-nav-search-input").value;
        localStorage.setItem('searchString', searchString);
        window.location.href = `/events/Explore?inputString=${searchString}`;

    }
});
