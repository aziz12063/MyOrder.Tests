window.tryOpenLink = function (url, target) {
    const newWindow = window.open(url, target);
    return newWindow != null;
};