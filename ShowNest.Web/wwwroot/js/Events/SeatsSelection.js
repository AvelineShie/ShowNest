//Element
const $seatsGroup = document.querySelector('.seats-group');

function CreateRow() {
    let $row = document.createElement('div');
    $row.setAttribute('class', 'row');
    return $row;
}

function CreateSeat() {
    let $seat = document.createElement('div');
    $seat.setAttribute('class', 'seat');
    $seat.setAttribute('data-bs-toggle', 'tooltip');
    $seat.setAttribute('data-bs-placement', 'top');
    return $seat;
}

async function RenderSeat() {
    let response = await fetch('/api/seats?seatAreaId=1');
    let seats = await response.json();

    for (let row of seats) {
        let $row = CreateRow();
        $seatsGroup.appendChild($row);
        
        for (let seat of row) {
            let $seat = CreateSeat();
            $seat.setAttribute('seat-id', seat.id);
            $seat.setAttribute('data-bs-title', seat.Number);
            $seat.setAttribute('seat-status', seat.Status);
            $row.appendChild($seat);
        }
    }

    //Bootstrap tooltip trigger
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
}

RenderSeat();