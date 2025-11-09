(function () {
    const toggle = document.getElementById('menuToggle');
    const left = document.getElementById('leftMenu');
    const body = document.body;

    if (!toggle || !left) return;

    function setCollapsed(collapsed) {
        if (collapsed) {
            left.classList.add('collapsed');
            toggle.setAttribute('aria-expanded', 'false');
        } else {
            left.classList.remove('collapsed');
            toggle.setAttribute('aria-expanded', 'true');
        }
    }

    toggle.addEventListener('click', function () {
        if (window.matchMedia('(max-width: 800px)').matches) {
            const open = left.classList.toggle('open');
            body.classList.toggle('leftmenu-open-scroll-lock', open);
            toggle.setAttribute('aria-expanded', String(open));
        } else {
            const collapsed = !left.classList.contains('collapsed');
            setCollapsed(collapsed);
        }
    });

    document.addEventListener('click', function (e) {
        if (window.matchMedia('(max-width: 800px)').matches) {
            if (!left.contains(e.target) && !toggle.contains(e.target) && left.classList.contains('open')) {
                left.classList.remove('open');
                body.classList.remove('leftmenu-open-scroll-lock');
                toggle.setAttribute('aria-expanded', 'false');
            }
        }
    });

    window.addEventListener('resize', function () {
        if (!window.matchMedia('(max-width: 800px)').matches) {
            left.classList.remove('open');
            body.classList.remove('leftmenu-open-scroll-lock');
            toggle.setAttribute('aria-expanded', left.classList.contains('collapsed') ? 'false' : 'true');
        }
    });
})();
