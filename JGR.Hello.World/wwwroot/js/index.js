"use strict";

// Create and start a connection.
// Add to the submit button a handler that sends messages to the hub.
// Add to the connection object a handler that receives messages from the hub
// Then add them to the list.

var connection = new signalR.HubConnectionBuilder().withUrl("/messageHub").build();

var chageView = {
    load: function(classname, color, divname, msg) {
        var divCardBorder = document.createElement("div");
        divCardBorder.className = "card " + classname;
        divCardBorder.style.marginBottom = "10%";
    
        var divCardBody = document.createElement("div");
        divCardBody.className = "card-body";
        divCardBorder.appendChild(divCardBody)
        
        var title = document.createElement("div");
        title.className = "card-header bg-transparent";
        title.textContent = "ApplicationName: " + msg.ApplicationName;
        title.style.color = color;
        title.style.fontWeight = "bold"
        divCardBody.appendChild(title);
    
        var ul = document.createElement("ul");
        ul.className = "list-group list-group-flush";
        divCardBody.appendChild(ul);
    
        var liid = document.createElement("li");
        liid.className = "list-group-item";
        liid.textContent = "Id: " + msg.Id;
        ul.appendChild(liid);
    
        var limsg = document.createElement("li");
        limsg.className = "list-group-item";
        limsg.textContent = "Message: " + msg.Message;
        ul.appendChild(limsg);
    
        var lidate = document.createElement("li");
        lidate.className = "list-group-item";
        lidate.textContent = "Date: " + msg.Date;
        ul.appendChild(lidate);
    
        document.getElementById(divname).appendChild(divCardBorder);
    }
  }

connection.on("ReceiveMessage", function (user, message) {
    var msg = JSON.parse(message)

    if(msg.ApplicationName == user)
    {
        chageView.load("border-primary","blue","thisapp",msg);
    }
    else
    {
        chageView.load("border-info","Aqua","otherapp",msg);
    }
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});