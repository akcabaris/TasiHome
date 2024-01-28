function filterItems() {
    var input, filter, ilanList, ilanItems, i, txtValue;
    input = document.getElementById("searchInput");
    filter = input.value.toUpperCase();
    ilanList = document.getElementsByClassName("ilan");

    for (i = 0; i < ilanList.length; i++) {
        ilanItems = ilanList[i].getElementsByTagName("p")[0];
        txtValue = ilanItems.textContent || ilanItems.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            ilanList[i].style.display = "";
        } else {
            ilanList[i].style.display = "none";
        }
    }
}

document.getElementById("searchInput").addEventListener("keyup", filterItems);

function forCreatUserPhoneNumberInput(input) {
    input.value = input.value.replace(/\D/g, '');
}


