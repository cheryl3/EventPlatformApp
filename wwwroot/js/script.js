document.getElementById("eventInputForm")
    .addEventListener("submit", async function (event) {
        event.preventDefault();
        const upcomingDays = document.getElementById("upcomingDays").value;

        try {
            const url = `https://localhost:7095/api/Event/getEvent?days=${upcomingDays}`;
            const response = await fetch(url, {
                method: 'GET',
                headers: {
                    'Accept': 'application/json'
                }
            });
            const eventData = await response.json();

            const pageSize = 5;
            let currentPage = 1;
            let currentSort = { column: null, asc: true };

            const table = document.getElementById("result");
            table.innerHTML = "<tr> " +
                "<th onclick=sort(0)>Name</th >" +
                "<th onclick=sort(1)>Start Date</th>" +
                "<th>End Date</th>" +
                "</tr> ";

            eventData.forEach(event => {
                table.innerHTML += `<tr>
                        <td>${event.name}</td>
                        <td>${event.startsOn}</td>
                        <td>${event.endsOn}</td>
                    </tr>`;
            });
        }
        catch (error) {
            console.error("Error occurred while fetching event list: ", error);
        }
    });

document.getElementById("ticketInputForm")
    .addEventListener("submit", async function (event) {
        event.preventDefault();
        try {
            const eventID = document.getElementById("eventID").value;
            const url = `https://localhost:7095/api/Event/Ticket/getTicket?eventId=${eventID}`;
            const response = await fetch(url, {
                method: 'GET',
                headers: {
                    'Accept': 'application/json'
                }
            });
            const ticketDetails = await response.json();

            const table = document.getElementById("result");
            table.innerHTML = "<tr> " +
                "<th>Event Name</th >" +
                "<th>Ticket Type</th>" +
                "<th>Price</th>" +
                "<th>Tickets Sold</th>" +
                "</tr> ";

            ticketDetails.forEach(ticket => {
                table.innerHTML += `<tr>
                        <td>${ticket.eventName}</td>
                        <td>${ticket.ticketType}</td>
                        <td>${ticket.price}</td>
                        <td>${ticket.sold}</td>
                    </tr>`;
            });
        }
        catch (error) {
            console.error("Error occurred while fetching ticket details: ", error);
        }
    });


document.getElementById("higestAmount")
    .addEventListener("submit", async function (event) {
        event.preventDefault();
        try {
            const url = `https://localhost:7095/api/Event/Ticket/getTop5Amount`;
            const response = await fetch(url, {
                method: 'GET',
                headers: {
                    'Accept': 'application/json'
                }
            });
            const ticketDetails = await response.json();

            const table = document.getElementById("result");
            table.innerHTML = "<tr> " +
                "<th>Event Name</th >" +
                "<th>Ticket Type</th>" +
                "<th>Price</th>" +
                "<th>Tickets Sold</th>" +
                "</tr> ";

            ticketDetails.forEach(ticket => {
                table.innerHTML += `<tr>
                        <td>${ticket.eventName}</td>
                        <td>${ticket.ticketType}</td>
                        <td>${ticket.price}</td>
                        <td>${ticket.sold}</td>
                    </tr>`;
            });
        }
        catch (error) {
            console.error("Error occurred while fetching top 5 highest amount ticket details: ", error);
        }
    });


document.getElementById("higestSales")
    .addEventListener("submit", async function (event) {
        event.preventDefault();
        try {
            const url = `https://localhost:7095/api/Event/Ticket/getTop5Sales`;
            const response = await fetch(url, {
                method: 'GET',
                headers: {
                    'Accept': 'application/json'
                }
            });
            const ticketDetails = await response.json();

            const table = document.getElementById("result");
            table.innerHTML = "<tr> " +
                "<th>Event Name</th >" +
                "<th>Ticket Type</th>" +
                "<th>Price</th>" +
                "<th>Tickets Sold</th>" +
                "</tr> ";

            ticketDetails.forEach(ticket => {
                table.innerHTML += `<tr>
                        <td>${ticket.eventName}</td>
                        <td>${ticket.ticketType}</td>
                        <td>${ticket.price}</td>
                        <td>${ticket.sold}</td>
                    </tr>`;
            });
        }
        catch (error) {
            console.error("Error occurred while fetching top 5 highest sales ticket details: ", error);
        }
    });