(
    function () {
    let f5Handler = null;

    window.registerF5Handler = function (dotNetHelper) {
        f5Handler = function (e) {
            if (e.key === 'F5') {
                e.preventDefault();
                dotNetHelper.invokeMethodAsync('F5Pressed').catch(function (error) {
                    console.error('Error invoking F5Pressed:', error);
                });
            }
        };
        window.addEventListener('keydown', f5Handler);
    };
    }
)();


