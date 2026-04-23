document.querySelectorAll(".menu-title").forEach(menu => {
    menu.addEventListener("click", () => {
        const submenu = menu.nextElementSibling;

        submenu.style.display =
            submenu.style.display === "flex" ? "none" : "flex";
    });
});