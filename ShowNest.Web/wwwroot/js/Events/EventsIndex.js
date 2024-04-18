
let pageIndexContainer = $('#page-index')[0]
let cardTemplate = $('.card-template')[0].content
let totalPages = 0
let totalEventsCount = 0


let queryParametersDto = {
    id: 0,
    inputString: '',
    maxPrice: 0,
    minPrice: 0,
    startTime: '0001-01-01T00:00:00',
    endTime: '9999-12-31T23:59:59.9999999',
    categoryTag: 0,
    page: 1, // 頁碼，預設是第一頁
    cardsPerPage: 9, // 一頁幾張卡
}

$(function () {
    loadAllCards()
    categoryTagsColorChanging()
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

    await axios.post(`/api/EventsIndex/GetEventsIndexCardsByApi`, queryParametersDto)
        .then(res => {
            console.log(res)
            cards = res.data.data
            cards.forEach(function (data) {
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
        .catch(err => {
            console.error(err);
        })

    renderPagination()
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
            loadAllCards()
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
        $pageButton.on('click', function () {
            page = i
            loadAllCards()
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
            loadAllCards()
        }
    })

    $paginationContainer.append($nextPageButton)
}

function categoryTagsColorChanging() {
    let lastClickedTag = null
    $('#categories-tags-div a').click(function (e) {
        e.preventDefault()
        
        if ($(this).hasClass('categories-tag-clicked')) { // 點擊已經被選到的tag就取消選取
            $(this).removeClass('categories-tag-clicked')
            queryParametersDto.categoryTag = 0
            console.log(queryParametersDto.categoryTag)
        } else {
            if (lastClickedTag) { // 點擊另一個tag就取消已經選取的
                lastClickedTag.removeClass('categories-tag-clicked');
            }
            $(this).addClass('categories-tag-clicked')
            lastClickedTag = $(this)
            queryParametersDto.categoryTag = parseInt($(this).attr('id')) // 把id放進queryParametersDto
            console.log(queryParametersDto.categoryTag)
        }
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


(function () {
    const searchString = localStorage.getItem('searchString');
    const searchInput = document.getElementById("event-search-search-input");
    if (searchString) {
        searchInput.value = searchString;
    }
    window.addEventListener('unload', function (event) {

        localStorage.removeItem('searchString');
    });
})();



document.querySelectorAll(".dropdown-item").forEach(item => {
    item.addEventListener("click", function (event) {
        event.preventDefault();
        const filterValue = item.textContent.trim(); // 獲取選擇的篩選值
        let minPrice = 0;
        let maxPrice = 0;
        let priceValue = '';
        let timeValue = '';
        let startTime = '';
        let endTime = '';

        // 根據選擇的篩選值設置相應的查詢參數值
        switch (filterValue) {
            case "全部費用":
                // 不需要設置查詢參數值
                break;
            case "免費":
                // 設置 Price 參數值為 free
                priceValue = "free";
                break;
            case "1 - 1000":
                minPrice = 1;
                maxPrice = 1000;
                break;
            case "1000 - 2000":
                minPrice = 1000;
                maxPrice = 2000;
                break;
            case "2000 - 3000":
                minPrice = 2000;
                maxPrice = 3000;
                break;
            case "3000 up":
                minPrice = 3000;
                maxPrice = Infinity; // 使用 Infinity 表示無限大
                break;
            case "今天":
                // 設置 startTime 參數值為 today
                timeValue = "today";
                break;
            case "一周內":
                // 獲取一周後的日期
                const oneWeekLater = new Date();
                oneWeekLater.setDate(oneWeekLater.getDate() + 7);
                startTime = new Date().toISOString().split('T')[0];
                endTime = oneWeekLater.toISOString().split('T')[0];
                break;
            case "一個月內":
                // 獲取一個月後的日期
                const oneMonthLater = new Date();
                oneMonthLater.setMonth(oneMonthLater.getMonth() + 1);
                startTime = new Date().toISOString().split('T')[0];
                endTime = oneMonthLater.toISOString().split('T')[0];
                break;
            case "兩個月內":
                // 獲取兩個月後的日期
                const twoMonthsLater = new Date();
                twoMonthsLater.setMonth(twoMonthsLater.getMonth() + 2);
                startTime = new Date().toISOString().split('T')[0];
                endTime = twoMonthsLater.toISOString().split('T')[0];
                break;
            default:
                break;
        }

        // 構建新的URL，僅包含更新後的查詢參數
        let newUrl = window.location.origin + window.location.pathname;

        if (priceValue !== '') {
            newUrl += "?Price=" + priceValue;
        } else if (minPrice !== 0 || maxPrice !== 0) {
            newUrl += "?MinPrice=" + minPrice + "&MaxPrice=" + maxPrice;
        } else if (timeValue !== '') {
            newUrl += "?startTime=" + timeValue;
        }
        else if (startTime !== '' && endTime !== '') {
            newUrl += "?StartTime=" + startTime + "&EndTime=" + endTime;
        }

        // 重定向到新的URL
        window.location.href = newUrl;
    });
});



