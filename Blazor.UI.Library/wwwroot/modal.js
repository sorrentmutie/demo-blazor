var myModal;

window.mostraModale = function (id) {
    console.log(id);
    myModal = new bootstrap.Modal(document.getElementById(id));
    myModal.show();
}

window.nascondiModale = function() {
    if (myModal)
        myModal.hide();
}