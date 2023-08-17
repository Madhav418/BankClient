function Validate() {
    var l = document.getElementById("login").value;
    var p = document.getElementById("password").value;
    if (l.trim().length == 0 || p.trim().length == 0) {
        document.getElementById("msg").innerText = ""
        // alert("Enter the username/password");
        return false;
    }
    return true;
}