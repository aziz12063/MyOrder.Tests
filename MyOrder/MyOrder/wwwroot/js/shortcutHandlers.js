(function () {
    // Keep references so we can remove/replace listeners later if needed
    let ctrlIHandler = null;
    let f5Handler = null;

    /** Registers a handler for Ctrl + I */
    window.registerCtrlIHandler = function (dotNetHelper) {
        // Remove any previous listener to avoid duplicates
        if (ctrlIHandler) {
            window.removeEventListener('keydown', ctrlIHandler);
        }

        ctrlIHandler = function (event) {
            // Ctrl/Cmd+I (covers macOS option) – case-insensitive key compare
            if (event.ctrlKey && event.key.toLowerCase() === 'i') {
                event.preventDefault();
                dotNetHelper
                    .invokeMethodAsync('CtrlIPressed')
                    .catch(err => console.error('Error invoking CtrlIPressed:', err));
            }
        };

        window.addEventListener('keydown', ctrlIHandler);
    };

    /** Registers a handler for F5 */
    window.registerF5Handler = function (dotNetHelper) {
        // Remove any previous listener to avoid duplicates
        if (f5Handler) {
            window.removeEventListener('keydown', f5Handler);
        }

        f5Handler = function (event) {
            if (event.key === 'F5') {
                event.preventDefault();
                dotNetHelper
                    .invokeMethodAsync('F5Pressed')
                    .catch(err => console.error('Error invoking F5Pressed:', err));
            }
        };

        window.addEventListener('keydown', f5Handler);
    };
})();