let page = 1
let cardsPerPage = 9
let pageIndexContainer = $('#page-index')[0]
let cardTemplate = $('.card-template')[0].content

$(function () {
    getTotalEvetnsCount()
    loadCards()
})

function loadCards() {
    let cardsContainer = $('.cards')[0]
    cardsContainer.innerHTML = ''
    // for checking
    console.log('cardTemplate')
    console.log(cardTemplate)
    console.log('cardsContainer')
    console.log(cardsContainer)
    console.log('pageIndexContainer')
    console.log(pageIndexContainer)

    // for checking
    fetch(`/api/EventsIndex/GetEventsIndexCardsByApi?page=${page}&cardsPerPage=${cardsPerPage}`)
        .then(res => res.json())
        .then(cards => {
            console.log('cards')
            console.log(cards)
            cards.data.forEach(function (data) {
                var cardToAppend = cardTemplate.cloneNode(true)
                console.log(data.eventId)
                $(cardToAppend).find('a').attr('href', `/Events/EventPage/${data.eventId}`)
                $(cardToAppend).find('a').addClass(data.eventStatusCssClass)
                $(cardToAppend).find('img').attr('src', data.eventImgUrl)
                $(cardToAppend).find('.card-name span').text(data.categoryName)
                $(cardToAppend).find('.card-name p').text(data.eventName)
                $(cardToAppend).find('.card-event-date').html(`<i class="fa-regular fa-calendar-days"></i>${convertEventTime(data.eventTime)}`)
                $(cardToAppend).find('.card-ticket-status').text(data.eventStatus)
                cardsContainer.append(cardToAppend)
            })
        })

    renderPagination()
}

function getTotalEvetnsCount() {
    fetch(`/api/EventsIndex/GetTotalEventsCount`)
        .then(res => res.json())
        .then(data => {
            let totalEventsCount = parseInt(data)
            console.log('totalEventsCount :')
            console.log(totalEventsCount)
        })
}

function convertEventTime(datetimeString) {
    let formatter = Intl.DateTimeFormat('zh-TW', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
        hour: '2-digit',
        minute: '2-digit',
        hour12: false
    })
    let convertedDate = new Date(datetimeString)
    return formatter.format(convertedDate).replace(/,/, '').replace(/(\d{2}:\d{2}):\d{2} (\w+)/, '$1 $2');
}

// pagination
function renderPagination() {

    const $paginationContainer = $('#page-index')

    // previous page button
    const $prevPageButton = $('<button>', {
        text: '⭠',
        class: 'index'
    })
    $prevPageButton.prop('disabled', page === 1)
    $prevPageButton.attr('class', 'index')
    $prevPageButton.on('click', function () {
        if (page > 1) {
            page--
            loadCards()
        }
    })

    $paginationContainer.append($prevPageButton)

    // next page button
    let totalPages = Math.ceil(totalEventsCount / cardsPerPage)

    const $nextPageButton = $('<button>', {
        text: '⭢',
        class: 'index'
    })
    $nextPageButton.prop('disabled', page === totalPages)
    $nextPageButton.attr('class', 'index')

    $nextPageButton.on('click', function () {
        if (page < totalPages>) {
            page++
            loadCards()
        }
    })

    $paginationContainer.append($nextPageButton)

    // numbers page button
    const $pageButton = $('<button>', {

    })
}