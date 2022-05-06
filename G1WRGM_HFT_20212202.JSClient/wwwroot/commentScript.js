let comments = [];
let connection = null;
let selectedRowID = -1;
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
    await fetch('http://localhost:42069/comment')
        .then(x => x.json())
        .then(y => {
            comments = y;
            console.log(comments);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    comments.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            `<tr><td><a onclick="storeSelectedRowID(${t.commentID})">` + t.commentID + `</a></td><td><a onclick="storeSelectedRowID(${t.commentID})">` +
            t.content + "</a></td><td>" +
            `<button type="button" onclick="remove(${t.commentID})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:42069/comment/' + id, {
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
    let com = document.getElementById('comment').value;
    let vidId = document.getElementById('videoID').value;
    console.log(com);
    console.log(vidId);
    fetch('http://localhost:42069/comment', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { content: com, videoID: vidId }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function update() {
    let com = document.getElementById('comment').value;
    let vidId = document.getElementById('videoID').value;

    fetch('http://localhost:42069/comment', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { content: com, videoID: vidId, commentID: selectedRowID }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function storeSelectedRowID(id) {
    selectedRowID = id;
    alert("Row with " + id + "selected, UwU")
}