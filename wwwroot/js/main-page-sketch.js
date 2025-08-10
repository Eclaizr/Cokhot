let menu = document.querySelector('#menu-icon');
let navbar =  document.querySelector('.navbar');

menu.onclick = () => {
    menu.classList.toggle('bx-x');
    navbar.classList.toggle('open');
}

function animateChick() {
    const chick = document.querySelector('.chick-image');
    chick.style.transform = 'scale(1.2) rotate(10deg)';
    setTimeout(() => {
        chick.style.transform = 'scale(1) rotate(0deg)';
    }, 300);
}

const observerOptions = {
    threshold: 0.1,
    rootMargin: '0px 0px -50px 0px'
};
const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.style.opacity = '1';
            entry.target.style.transform = 'translateY(0)';
        }
    });
}, observerOptions);

document.addEventListener('DOMContentLoaded', () => {
    const animatedElements = document.querySelectorAll('.feature-card');
    animatedElements.forEach(el => {
        el.style.opacity = '0';
        el.style.transform = 'translateY(30px)';
        el.style.transition = 'all 0.6s ease';
        observer.observe(el);
    });
});

// Parallax effect
window.addEventListener('scroll', () => {
    const scrolled = window.pageYOffset;
    const ingredients = document.querySelectorAll('.ingredient');
    ingredients.forEach((ingredient, index) => {
        const speed = 0.5 + (index * 0.1);
        ingredient.style.transform += ` translateY(${scrolled * speed}px)`;
    });
});

// Counter animation
window.animateCounter = function (targetValue) {
    const counter = document.getElementById('mealsCount');
    if (!counter) return;

    let currentValue = 0;
    const increment = targetValue / 50;
    const timer = setInterval(() => {
        currentValue += increment;
        if (currentValue >= targetValue) {
            currentValue = targetValue;
            clearInterval(timer);
        }
        counter.textContent = Math.floor(currentValue);
    }, 40);
};