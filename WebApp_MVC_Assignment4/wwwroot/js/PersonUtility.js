var btnAddPerson = null;
var editedPersonArea = null;

function GetAddPersonForm(urlToCreateForm)
{
    btnAddPerson = $("#btnAddPerson");

    $.get(urlToCreateForm, function (result) {
        console.log("From Controller:", result);
        btnAddPerson.replaceWith(result);
    })
}
        
function PostAddPersonForm(event, form)
{
    event.preventDefault();

    $.post(form.action,
        {
            FirstName: form.FirstName.value,
            LastName: form.LastName.value,
            PhoneNumber: form.PhoneNumber.value,
            Address: form.Address.value
        },
        function (data, status)
        {
            console.log("AddPerson[Post] data:", data);
            $("#peopleListArea").append(data);
            $("#toggleBtnAddPersonForm").html(btnAddPerson); 

        }).fail(function (badForm)
        {
            $("#toggleBtnAddPersonForm").html(badForm.responseText);
        });
}

function GetEditPersonForm(urlToEditForm, personID) {
    console.log("urlToEditForm:", urlToEditForm);
    editedPersonArea = $("#personRowID-" + personID);    
    $.get(urlToEditForm + "/" + personID, function (result) {
        //console.log("editedPersonArea:", result);
        editedPersonArea.html(result);
    })
}

function PostEditPersonForm(event, form) {
    event.preventDefault();

    $.post(form.action,
        {
            PersonID: form.PersonID.value,
            FirstName: form.FirstName.value,
            LastName: form.LastName.value,
            PhoneNumber: form.PhoneNumber.value,
            Address: form.Address.value
        },
        function (data, status) {
            console.log("PersonEdit [Post] data:", data);
            $(editedPersonArea).replaceWith(data);

        }).fail(function (badForm) {
            console.log("badForm:", badForm.responseText);
            editedPersonArea.html(badForm.responseText);
        });
}

function RemovePerson(urlToRemovePerson, personID) {
    removedPersonArea = $("#personRowID-" + personID);
    $.get(urlToRemovePerson + "/" + personID, function (result) {
        removedPersonArea.replaceWith(result);
    })
}

function SearchPeople(event, form) {
    event.preventDefault();

    $.post(form.action,
        {
            Search: form.Search.value
        },
        function (data, status) {
            console.log(data);
            $("#peopleListArea").html(data);
            
        }).fail(function (badForm) {
            console.log("badForm: Fail");
        });
}
