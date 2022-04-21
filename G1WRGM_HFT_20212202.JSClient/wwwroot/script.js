let ytccs = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:42069/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("YTContentCreatorCreated", (user, message) => {
        getdata();
    });

    connection.on("YTContentCreatorDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:42069/ytcontentcreator')
        .then(x => x.json())
        .then(y => {
            ytccs = y;
            console.log(ytccs);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    ytccs.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.creatorID + "</td><td>" +
            t.creatorName + "</td><td>" +
            `<button type="button" onclick="remove(${t.creatorID})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:42069/ytcontentcreator/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('ytccName').value;
    fetch('http://localhost:42069/ytcontentcreator', {
    method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { creatorName: name }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}