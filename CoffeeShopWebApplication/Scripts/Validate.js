
function testInputs()
{
    var FNRegEx = /^[a-zA-Z]{2,}$/g;
    var LNRegEx = /^[a-zA-Z]{2,}$/g;
    var EMRegEx = /"^[A-z0-9]{5,30}@[a-z]{5,10}.[a-z]{2,3}$"/g;
    var PNRegEx = /"^\d{ 3})-(\d{ 3 }) -(\d{ 4 }) $"/g;
    var PWRegEx = /"^[a-zA-Z]{2,}$")/g;

    var element1 = document.getElementById("firstName").value;
    var element2 = document.getElementById("lastName").value;
    var element3 = document.getElementById("email").value;
    var element4 = document.getElementById("phoneNumber").value;
    var element5 = document.getElementById("password").value;

    if (!element1.match(FNRegEx) || !element2.match(LNRegEx) || !element3.match(EMRegEx) || !element4.match(PNRegEx) || !element5.match(PWRegEx))
    {
        return false;
    }

    else
    {
        alert("You did not meet");
        return true;
    }

}




