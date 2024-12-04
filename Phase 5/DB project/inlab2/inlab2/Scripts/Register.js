function checkForEmptyFieldsofRegister() {
    var Name = document.getElementById("nameField").value;
    var Email = document.getElementById("emailField").value;
    var Address = document.getElementById("addressField").value;
    var Contact = document.getElementById("contactField").value;
    var Password1 = document.getElementById("password1Field").value;
    var Password2 = document.getElementById("password2Field").value;
    var Date = document.getElementById("dateField").value;
    if (Name == "" || Address == "" || Contact == "" || Email == "" || Password1 == "" || Password2 == "" || Date == "") {
        document.getElementById("status").innerText = "Please enter all the required information.";
        //or
        //alert("Please enter all fields");
        return false;
    }
    if (Name.length < 3 || Name.length > 20) {
        document.getElementById("status").innerText = "Name length should be greater than 3 and less than 100.";
        return false;
    }
    var a = /^[a-zA-Z ]+$/;
    if (!Name.match(a)) {
        document.getElementById("status").innerText = "Only alphabets are allowed in Name section.";
        return false;
    }
    if (Email.length < 8 || Email.length > 30) {
        document.getElementById("status").innerText = "Email length should be greater than 8 and less than 30.";
        return false;
    }
    if (Address.length < 8 || Address.length > 100) {
        document.getElementById("status").innerText = "Address length should be greater than 8 and less than 100.";
        return false;
    }
    var b = /^[0-9a-zA-Z -,]+$/;
    if (!Address.match(b)) {
        document.getElementById("status").innerText = "Only alphabets and digits are allowed in Address section.";
        return false;
    }
    if (Contact.length < 10 || Contact.length > 15) {
        document.getElementById("status").innerText = "Contact length should be greater than 10 and less than 15.";
        return false;
    }
    var c = /^[0-9-]+$/;
    if (!Contact.match(c)) {
        document.getElementById("status").innerText = "Only Digits are allowed in Contact section.";
        return false;
    }
    if (Password1.length < 8 || Password1.length > 15) {
        document.getElementById("status").innerText = "Password length should be greater than 8 and less than 15.";
        return false;
    }
    if (Password1 != Password2) {
        document.getElementById("status").innerText = "Passwords does not match.";
        return false;
    }



    return true;
}

