//Element
const $seatsGroup = document.querySelector('.seats-group');
const $currentArea = document.querySelector('.current-area');
// let $selectedSeat = document.querySelector(.seat-id).dataset;

//Add EventHandler
// $selectedSeat.addEventListener('click', SeatsOnClicked);

//function

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

function SeatsOnClicked() {
    
    let $seatStatus = $selectedSeat.getAttribute('seat-status');

    if ($seatStatus === '0') {
        $selectedSeat.setAttribute('seat-status', '1');
    } else if ($seatStatus === '1') {
        $selectedSeat.setAttribute('seat-status', '0');
    }

    // $selectedSeat.setAttribute('seat-status', '0');
}