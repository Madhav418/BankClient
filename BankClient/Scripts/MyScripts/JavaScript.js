
    function showLogoutConfirmation() {
        var confirmLogout = confirm("Would you like to provide feedback before logging out?");
    if (confirmLogout) {
        window.location.href = "@Url.Action("FeedBack", "Bank", new {showAlert = true})";
        } else {
        window.location.href = "@Url.Action("LogOut", "Bank")";
        }
    }
