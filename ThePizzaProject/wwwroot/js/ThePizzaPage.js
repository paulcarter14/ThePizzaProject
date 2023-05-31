window.onload = function () {
    var allSlices = ["slice1", "slice2", "slice3", "slice4", "slice5"];

    function clearClicks() {
        allSlices.forEach(function (id) {
            document.getElementById(id).classList.remove('clicked');
        });
    }

    allSlices.forEach(function (sliceId) {
        document.getElementById(sliceId).addEventListener("mouseover", function () {
            clearClicks();
            for (let i = 1; i <= parseInt(sliceId.slice(-1)); i++) {
                document.getElementById("slice" + i).classList.add('clicked');
            }
        });
    });

    allSlices.forEach(function (sliceId) {
        document.getElementById(sliceId).addEventListener("click", function () {
            clearClicks();
            for (let i = 1; i <= parseInt(sliceId.slice(-1)); i++) {
                document.getElementById("slice" + i).classList.add('clicked');
            }
        });
    });
}