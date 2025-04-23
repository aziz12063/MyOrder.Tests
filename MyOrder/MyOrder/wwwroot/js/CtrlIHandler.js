(function () {
    let CtrlIPressed = null;

    window.registerCtrlIHandler = function (dotNetHelper) {
        CtrlIPressed = function (event) {
            if (event.ctrlKey && event.key === "i") {
                event.preventDefault();
                dotNetHelper.invokeMethodAsync('CtrlIPressed').catch(function (error) {
                    console.error('Error invoking CtrlIPressed:', error);
                });
            }
        };
        window.addEventListener('keydown', CtrlIPressed);
    };
})();