//Element
const $seatsGroup = document.querySelector('.seats-group');
const $currentArea = document.querySelector('.current-area');

//Add EventHandler
// $seatsGroup.addEventListener('click', SeatsOnClicked);

//function
function SeatsOnClicked(e) {

    let $SeatId = document.querySelector('[seat-id]');
    if (e.target.classList.contains('seat') &&
        e.target.getAttribute('seat-status', '0')) {
        e.target($SeatId).setAttribute('seat-status', '1');
    } else if (e.target.classList.contains('seat') &&
        e.target.getAttribute('seat-status', '1')) {
        e.target($SeatId).setAttribute('seat-status', '0');
    }
    
}

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

async function RenderSeatAreaAndSeats() {
    let urlParams = new URLSearchParams(window.location.search);
    let seatAreaId = urlParams.get("id")
    let response = await fetch(`/api/seats?seatAreaId=${seatAreaId}`);
    let viewModel = await response.json();

    let $currentAreaName = document.createElement('p');
    $currentAreaName.innerHTML = viewModel.seatAreaName;
    $currentArea.appendChild($currentAreaName);
        
    for (let row of viewModel.seats) {
        let $row = CreateRow();
        $seatsGroup.appendChild($row);
        
        for (let seat of row) {
            let $seat = CreateSeat();
            $seat.setAttribute('seat-id', seat.seatId);
            $seat.setAttribute('data-bs-title', seat.seatNumber);
            $seat.setAttribute('seat-status', seat.seatStatus);
            $row.appendChild($seat);
        }
    }

    //Bootstrap tooltip trigger
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
}

RenderSeatAreaAndSeats();

