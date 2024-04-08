var page = 1
var cardsPerPage = 9
var pageIndexContainer = $('#page-index')[0]
var cardTemplate = $('.card-template')[0].content

window.onload = function(){
    loadCards()
}

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