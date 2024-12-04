function checkForEmptyFieldsofLogin() {
    var Email = document.getElementById("emailField").value;
    var Password = document.getElementById("passwordField").value;
    if (Email == "" || Password == "") {
        document.getElementById("status").innerText = "Please fill all the boxes.";
        //or
        //alert("Please enter all fields");
        return false;
    }
    if (Password.length < 8 || Password.length > 20) {
        document.getElementById("status").innerText = "Password length should be greater than 8 and less than 20.";
        return false;
    }
    var a = /^[a-zA-Z @0-9.-_]+$/;
    if (!Email.match(a)) {
        document.getElementById("status").innerText = "Incorrect Email.";
        return false;
    }
    return true;
}

