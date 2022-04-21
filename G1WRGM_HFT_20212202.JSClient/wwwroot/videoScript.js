let videos = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:42069/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("VideoCreated", (user, message) => {
        getdata();
    });

    connection.on("VideoDeleted", (user, message) => {
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
    await fetch('http://localhost:42069/video')
        .then(x => x.json())
        .then(y => {
            videos = y;
            console.log(videos);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    videos.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.videoID + "</td><td>" +
            t.title + "</td><td>" +
            `<button type="button" onclick="remove(${t.videoID})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:42069/video/' + id, {
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
    let vidName = document.getElementById('title').value;
    let crId = document.getElementById('creatorID').value;
    fetch('http://localhost:42069/video', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { title: vidName, creatorID: crId }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}