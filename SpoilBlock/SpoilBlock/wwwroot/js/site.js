document.addEventListener('DOMContentLoaded', function () {


    
        var sidebar = document.querySelector('.sidebar'),
            catSubMenu = document.querySelector('.cat-sub-menu'),
            sidebarBtns = document.querySelectorAll('.sidebar-toggle');

        var _iterator = _createForOfIteratorHelper(sidebarBtns),
            _step;

        try {
            for (_iterator.s(); !(_step = _iterator.n()).done;) {
                var sidebarBtn = _step.value;

                if (sidebarBtn && catSubMenu && sidebarBtn) {
                    sidebarBtn.addEventListener('click', function () {
                        var _iterator2 = _createForOfIteratorHelper(sidebarBtns),
                            _step2;

                        try {
                            for (_iterator2.s(); !(_step2 = _iterator2.n()).done;) {
                                var sdbrBtn = _step2.value;
                                sdbrBtn.classList.toggle('rotated');
                            }
                        } catch (err) {
                            _iterator2.e(err);
                        } finally {
                            _iterator2.f();
                        }

                        sidebar.classList.toggle('hidden');
                        catSubMenu.classList.remove('visible');
                    });
                }
            }
        } catch (err) {
            _iterator.e(err);
        } finally {
            _iterator.f();
        }
   
});