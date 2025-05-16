function updatePreview() {
    const form = document.querySelector("form");
    const previewImage = document.getElementById("previewImage");

    if (!form || !previewImage) return;

    const formData = new FormData(form);
    fetch("/Home/Preview", {
        method: "POST",
        body: formData
    })
        .then(res => res.ok ? res.blob() : Promise.reject("Помилка при створенні прев’ю"))
        .then(blob => {
            const url = URL.createObjectURL(blob);
            previewImage.src = url;
            previewImage.style.display = "block";
        })
        .catch(console.error);
}
function onQrTypeChange() {
    const value = document.getElementById("QrType").value;
    document.querySelectorAll(".qr-section").forEach(el => el.classList.add("d-none"));

    switch (value) {
        case "Text": document.getElementById("textFields").classList.remove("d-none"); break;
        case "Email": document.getElementById("emailFields").classList.remove("d-none"); break;
        case "SMS": document.getElementById("smsFields").classList.remove("d-none"); break;
        case "WiFi": document.getElementById("wifiFields").classList.remove("d-none"); break;
    }
}
function downloadQr() {
    const img = document.getElementById("qrImage");
    if (!img) return;
    const link = document.createElement("a");
    link.href = img.src;
    link.download = "qr_code." + img.src.split('.').pop();
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}
function copyQr() {
    const qrImage = document.getElementById("qrImage");
    if (!qrImage) return;

    fetch(qrImage.src)
        .then(res => res.blob())
        .then(blob => {
            const item = new ClipboardItem({ "image/png": blob });
            navigator.clipboard.write([item])
                .then(() => alert("QR-код скопійовано!"))
                .catch(err => alert("Не вдалося скопіювати QR-код: " + err));
        });
}
function copyQrImage(qrSelector) {
    const img = document.querySelector(qrSelector);
    if (!img) return;

    const canvas = document.createElement("canvas");
    const ctx = canvas.getContext("2d");

    canvas.width = img.naturalWidth;
    canvas.height = img.naturalHeight;
    ctx.drawImage(img, 0, 0);

    canvas.toBlob(blob => {
        const item = new ClipboardItem({ "image/png": blob });
        navigator.clipboard.write([item])
            .then(() => alert("Зображення скопійовано!"))
            .catch(() => alert("Не вдалося скопіювати зображення."));
    });
}
function initThemeToggle() {
    const toggle = document.getElementById("themeToggle");
    const stylesheet = document.getElementById("themeStylesheet");
    const label = document.getElementById("themeLabel");
    const navLinks = document.querySelectorAll(".navbar-nav .nav-link");

    const applyTheme = (isDark) => {
        stylesheet.href = `/css/${isDark ? "dark" : "light"}.css`;
        label.innerHTML = isDark ? "🌙" : "🌞";
        navLinks.forEach(link => {
            link.classList.remove(isDark ? "text-dark" : "text-light");
            link.classList.add(isDark ? "text-light" : "text-dark");
        });
    };

    toggle.addEventListener("change", () => {
        const isDark = toggle.checked;
        localStorage.setItem("theme", isDark ? "dark" : "light");
        applyTheme(isDark);
    });

    const savedTheme = localStorage.getItem("theme") || "light";
    toggle.checked = savedTheme === "dark";
    applyTheme(toggle.checked);
}
document.addEventListener("DOMContentLoaded", () => {
    onQrTypeChange();
    initThemeToggle();

    const inputs = document.querySelectorAll("input, textarea, select");
    inputs.forEach(el => {
        el.addEventListener("input", () => setTimeout(updatePreview, 200));
        el.addEventListener("change", () => setTimeout(updatePreview, 200));
    });
    updatePreview();
});