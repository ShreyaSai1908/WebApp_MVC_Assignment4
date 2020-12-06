var btnAddPerson = null;
var editedPersonArea = null;

function GetAddPersonForm(urlToCreateForm)
{
    btnAddPerson = $("#btnAddPerson");

    $.get(urlToCreateForm, function (result) {
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
            $("#peopleListArea").append(data);
            $("#toggleBtnAddPersonForm").html(btnAddPerson); 

        }).fail(function (badForm)
        {
            console.log("badForm: Fail");
            //$("#createCarDiv").html(badForm.responseText);
        });
}

function GetEditPersonForm(urlToEditForm, personID) {
    console.log("urlToEditForm:", urlToEditForm);
    console.log("personID:", personID);

    //personListArea = $("#peopleListArea").children();
    //editedPersonArea = personListArea[personID];

    editedPersonArea = $("#personRowID-" + personID);
    

    $.get(urlToEditForm + "/" + personID, function (result) {
        editedPersonArea.html(result);
        //editedPersonArea.innerHTML = result;
        //console.log("Edit Person Form", editedPersonArea.innerHTML);
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
            console.log(data);
            $(editedPersonArea).replaceWith(data);

            /*
            //element = editedPersonArea;
            //element.innerHTML = data;

            //console.log("Edit Person View", editedPersonArea.innerHTML);
            //editedPersonArea.innerHTML = data;
            */
            
            // $("#toggleBtnAddPersonForm").html(btnAddPerson);

        }).fail(function (badForm) {
            console.log("badForm: Fail");
            //$("#createCarDiv").html(badForm.responseText);
        });
}

function RemovePerson(urlToRemovePerson, personID) {
    console.log("urlToRemovePerson:", urlToRemovePerson);
    console.log("personID:", personID);

    //personListArea = $("#peopleListArea").children();
    //editedPersonArea = personListArea[personID];

    removedPersonArea = $("#personRowID-" + personID);
    //console.log("Remove Person", removedPersonArea.tagName);

    $.get(urlToRemovePerson + "/" + personID, function (result) {
        //editedPersonArea.replaceWith(result);
        //editedPersonArea.innerHTML = result;
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
            //$("#createCarDiv").html(badForm.responseText);
        });
}
