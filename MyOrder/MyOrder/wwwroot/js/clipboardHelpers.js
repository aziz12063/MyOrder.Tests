window.clipboardHelper = {
    /**
     * Copies the provided text to the system clipboard.
     * @param {string} text - The text to copy.
     * @returns {Promise<void>} - A promise that resolves when the text is copied.
     */
    copyTextToClipboard: async function (text) {
        if (!text) {
            return Promise.reject(new Error("No text provided to copy."));
        }

        if (navigator.clipboard && window.isSecureContext) {
            // Use the modern Clipboard API
            return navigator.clipboard.writeText(text);
        } else {
            // Fallback for older browsers or non-secure context (HTTP)
            let textArea = document.createElement("textarea");
            textArea.value = text;
            // Move the textarea off-screen
            textArea.style.position = "fixed";
            textArea.style.left = "-999999px";
            textArea.style.top = "-999999px";
            document.body.appendChild(textArea);
            textArea.focus();
            textArea.select();

            return new Promise((resolve, reject) => {
                try {
                    let successful = document.execCommand('copy');
                    if (successful) {
                        resolve();
                    } else {
                        reject(new Error('Failed to copy text.'));
                    }
                } catch (err) {
                    reject(err);
                } finally {
                    document.body.removeChild(textArea);
                }
            });
        }
    },

    /**
     * Reads text from the system clipboard.
     * @returns {Promise<string>} - A promise that resolves with the clipboard text.
     */
    pasteTextFromClipboard: async function () {
        if (navigator.clipboard && window.isSecureContext) {
            // Use the modern Clipboard API
            return navigator.clipboard.readText();
        } else {
            // Fallback for older browsers or non-secure context (HTTP)
            return Promise.reject(new Error("Clipboard reading is not supported in this browser or the context is not secure."));
        }
    }
};