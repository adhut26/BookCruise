
$(document).ready(function () {
    $("#createSubmit").click(function (event) {
        event.preventDefault(); 
        if (validateDate()) {
            var formData = {
                Name: $("#Name").val(),
                Arrival: $("#Arrival").val(),
                Destination: $("#Destination").val(),
                Membership: $("#Membership").val(),
                amount: $("#amount").val(),
                CreatedOn: $("#CreatedOn").val()
            };

            $.ajax({
                url: '/Cruise/Create',  
                type: "POST",
                headers: {
                    "RequestVerificationToken": requestVerificationToken
                },
                data: formData,
                success: function (response) {
                   
                    alert("Booking created successfully!");
                    window.location.href = '/Cruise/Index'; 
                },
                error: function (error) {
                   
                    alert("Error creating booking.");
                }
            });
        } else {
            alert("Save failed. Please check the form.");
        }
    });
});
   
    function validateDate() {
        var dateOfBirth = document.getElementById("CreatedOn").value;

    var dateRegex = /^\d{4}-\d{2}-\d{2}$/;
    if (!dateRegex.test(dateOfBirth)) {
        alert("Invalid date format. Please use YYYY-MM-DD format.");
    return false;
        }

    var parsedDate = new Date(dateOfBirth);
    if (isNaN(parsedDate)) {
        alert("Invalid date. Please enter a valid date.");
    return false;
        }


    return true;
    }


document.getElementById('createSubmit').onclick = function () {
        return validateDate();
    };
