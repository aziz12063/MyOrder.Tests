(function () {
    // Keep references so we can remove/replace listeners later if needed
    let ctrlIHandler = null;
    let f5Handler = null;

    /** Registers a handler for Ctrl + I */
    window.registerCtrlIHandler = function (dotNetHelper) {
        // If we already had a listener, remove it first to avoid duplicates:
        if (ctrlIHandler) {
            window.removeEventListener('keydown', ctrlIHandler);
            ctrlIHandler = null;
        }

        // Create a new handler closure that captures the current dotNetHelper
        ctrlIHandler = function (event) {
            // Ctrl/Cmd + I (case-insensitive check)
            if (event.ctrlKey && event.key.toLowerCase() === 'i') {
                event.preventDefault();
                dotNetHelper
                    .invokeMethodAsync('CtrlIPressed')
                    .catch(err => console.error('Error invoking CtrlIPressed:', err));
            }
        };

        // Attach the new listener
        window.addEventListener('keydown', ctrlIHandler);
    };

    /** Unregisters the handler for Ctrl + I */
    window.unregisterCtrlIHandler = function () {
        if (ctrlIHandler) {
            window.removeEventListener('keydown', ctrlIHandler);
            ctrlIHandler = null;
        }
    };

    /** Registers a handler for F5 */
    window.registerF5Handler = function (dotNetHelper) {
        // Remove any previous F5 listener to avoid duplicates
        if (f5Handler) {
            window.removeEventListener('keydown', f5Handler);
            f5Handler = null;
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

    /** Unregisters the handler for F5 */
    window.unregisterF5Handler = function () {
        if (f5Handler) {
            window.removeEventListener('keydown', f5Handler);
            f5Handler = null;
        }
    };
})();
