let page = 1
let cardsPerPage = 9
let pageIndexContainer = $('#page-index')[0]
let cardTemplate = $('.card-template')[0].content
let totalPages = 0
let totalEventsCount = 0

$(function () {
    loadAllCards()
})

async function loadAllCards() {
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
    await fetch(`/api/EventsIndex/GetEventsIndexCardsByApi?page=${page}&cardsPerPage=${cardsPerPage}`)
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
                totalEventsCount = data.totalEvents
            })
        })

    renderPagination()
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
    $paginationContainer.html('')

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
    console.log('totalEventsCount at render pagination() :')
    console.log(totalEventsCount)
    // numbers page button
    totalPages = Math.ceil(totalEventsCount / cardsPerPage)
    console.log('totalPages :')
    console.log(totalPages)

    for (let i = 1; i <= totalPages; i++) {
        const $pageButton = $('<button>', {
            text: i,
            class: 'index'
        })
        i === page ? $pageButton.addClass('active-index') : {}
        $pageButton.on('click',function(){
            page = i
            loadCards()
        })
        $paginationContainer.append($pageButton)
    }

    // next page button
    const $nextPageButton = $('<button>', {
        text: '⭢',
        class: 'index'
    })
    $nextPageButton.prop('disabled', page === totalPages)
    $nextPageButton.attr('class', 'index')

    $nextPageButton.on('click', function () {
        if (page < totalPages) {
            page++
            loadCards()
        }
    })

    $paginationContainer.append($nextPageButton)
}



(function () {
    const searchString = localStorage.getItem('searchString'); // 从 localStorage 中获取搜索字符串
    const searchInput = document.getElementById("event-search-search-input");
    if (searchString) {
        searchInput.placeholder = searchString; // 设置输入框的 placeholder 为搜索字符串
    }
})();