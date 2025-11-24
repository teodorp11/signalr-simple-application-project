// Creating a connection
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

// Connecting to methods that Hub invokes (Receving notifications from the Hub)
connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
});

connectionUserCount.on("updateTotalUsers", (value) => {
    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = value.toString();
});

// Invoking Hub methods (Sending notifications to the Hub)
function newWindowLoadedOnClient() {
    connectionUserCount.send("NewWindowLoaded");
}

// Starting the connection
function fulfilled() {
    // do something on start
    console.log("Connection to User Hub successful");
    newWindowLoadedOnClient();
}

function rejected() {
    // do something on failure
}

connectionUserCount.start().then(fulfilled, rejected)