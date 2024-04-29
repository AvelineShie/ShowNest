let pageIndexContainer = $('#page-index')[0]
let cardTemplate = $('.card-template')[0].content
let totalPages = 0
let totalEventsCount = 0


let queryParametersDto = {
    id: 0,
    inputString: '',
    maxPrice: 99999999,
    minPrice: 0,
    startTime: null,
    endTime: null,
    categoryTag: 0,
    page: 1, // 頁碼，預設是第一頁
    cardsPerPage: 9, // 一頁幾張卡
}

$(function () {
    loadCards()
    inputStringEvent()
    categoryTagsEvent()
    feeDropdownColorChanging()
    timeDropdownColorChanging()
    dropdownItemEvent()
})

// 載入卡片
async function loadCards() {
    console.log('loadCards() executed')
    let cardsContainer = $('.cards')[0]
    cardsContainer.innerHTML = ''

    // 從別的頁面用nav搜尋時的狀況：把nav input的值從cookie拿到後給events input
    if (getQueryFromCookie('navQueryString')) {
        $('#event-search-search-input').val(getQueryFromCookie('navQueryString'))
        queryParametersDto.inputString = getQueryFromCookie('navQueryString')
        clearQueryCookie('navQueryString')
    }

    // 如果使用者把events input的文字清除，再直接按小標籤的話
    if (!$('#event-search-search-input').val()) {
        queryParametersDto.inputString = ''
    }

    // 從首頁點擊分類icon時，讀取queryCategoryId cookie
    // 同時把頁面上的小標籤加上active class
    if (getQueryFromCookie('queryCategoryId')) {
        queryParametersDto.categoryTag = parseInt(getQueryFromCookie('queryCategoryId'))
        clearQueryCookie('queryCategoryId')
        $(`#categories-tags-div a[id="${queryParametersDto.categoryTag}"]`).addClass('categories-tag-clicked');
    }

    await axios.post(`/api/EventsIndex/GetEventsIndexCardsByApi`, queryParametersDto)
        .then(res => {
            console.log(res)
            cards = res.data.data
            cards.forEach(function (data) {
                var cardToAppend = cardTemplate.cloneNode(true)
                $(cardToAppend).find('a').attr('href', `/Events/EventPage/${data.eventId}`)
                $(cardToAppend).find('a').addClass(data.eventStatusCssClass)
                $(cardToAppend).find('img').attr('src', data.eventImgUrl)
                $(cardToAppend).find('.card-name span').text(data.categoryName)
                $(cardToAppend).find('.card-name p').text(data.eventName)
                $(cardToAppend).find('.card-event-date').html(`<i class="fa-regular fa-calendar-days"></i>${convertEventTime(data.eventTime)}`)
                $(cardToAppend).find('.card-ticket-status').text(data.eventStatus)
                cardsContainer.append(cardToAppend)
            })
            totalEventsCount = cards.length !== 0 ? cards[0].totalEvents : 0

            if (totalEventsCount == 0) {
                $('#no-filter-result-text').css('display', 'block');
            } else {
                $('#no-filter-result-text').css('display', 'none');
            }
        })
        .catch(err => {
            console.error(err);
        })
    console.log('totalEventsCount')
    console.log(totalEventsCount)

    renderPagination()
}

// 分頁功能
function renderPagination() {

    const $paginationContainer = $('#page-index')
    $paginationContainer.html('')

    // 有活動的時候才顯示頁籤
    if (totalEventsCount != 0) {
        // previous page button
        const $prevPageButton = $('<button>', {
            text: '⭠',
            class: 'index'
        })
        $prevPageButton.prop('disabled', queryParametersDto.page === 1)
        $prevPageButton.attr('class', 'index')
        $prevPageButton.on('click', function () {
            if (queryParametersDto.page > 1) {
                queryParametersDto.page--
                loadCards()
            }
        })

        $paginationContainer.append($prevPageButton)
        console.log('totalEventsCount at render pagination() :')
        console.log(totalEventsCount)
        // numbers page button
        totalPages = Math.ceil(totalEventsCount / queryParametersDto.cardsPerPage)
        console.log('totalPages :')
        console.log(totalPages)

        for (let i = 1; i <= totalPages; i++) {
            const $pageButton = $('<button>', {
                text: i,
                class: 'index'
            })
            i === queryParametersDto.page ? $pageButton.addClass('active-index') : {}
            $pageButton.on('click', function () {
                queryParametersDto.page = i
                console.log("queryParametersDto.page")
                console.log(queryParametersDto.page)
                loadCards()
            })
            $paginationContainer.append($pageButton)
        }

        // next page button
        const $nextPageButton = $('<button>', {
            text: '⭢',
            class: 'index'
        })
        $nextPageButton.prop('disabled', queryParametersDto.page === totalPages)
        $nextPageButton.attr('class', 'index')

        $nextPageButton.on('click', function () {
            if (queryParametersDto.page < totalPages) {
                queryParametersDto.page++
                loadCards()
            }
        })

        $paginationContainer.append($nextPageButton)
    }
}

// input 搜尋字串查詢功能
function inputStringEvent() {
    $('#event-search-search-input').keypress(function (e) {
        if (e.which == 13) {
            // 如果nav input和events input都有值，取events input的
            // 在JS中，空字串被視為"假值"
            queryParametersDto.inputString = $(this).val() ? $(this).val() : $('#header-nav-search-input').val()
            console.log('queryParametersDto.inputString')
            console.log(queryParametersDto.inputString)
            loadCards()
        }

    })
}

// 分類標籤查詢功能和顏色變換
function categoryTagsEvent() {
    let lastClickedTag = $('#categories-tags-div a').filter('.categories-tag-clicked') || null
    console.log('lastClickedTag :')
    console.log(lastClickedTag)
    console.log('lastClickedTag :')
    $('#categories-tags-div a').click(function (e) {
        e.preventDefault()

        if ($(this).hasClass('categories-tag-clicked')) { // 點擊已經被選到的tag就取消選取
            $(this).removeClass('categories-tag-clicked')
            queryParametersDto.categoryTag = 0
            console.log(queryParametersDto.categoryTag)
        } else {
            if (lastClickedTag) { // 點擊另一個tag就取消已經選取的
                lastClickedTag.removeClass('categories-tag-clicked')
            }
            $(this).addClass('categories-tag-clicked')
            lastClickedTag = $(this)
            queryParametersDto.categoryTag = parseInt($(this).attr('id')) // 把id放進queryParametersDto
            console.log(queryParametersDto.categoryTag)
        }

        loadCards()
    })
}

// 從cookie取得nav input的值 (有需要的話可以改寫成拿到指定的cookie)
function getQueryFromCookie(cookieName) {
    var nameForQuery = `${cookieName}=`
    var decodeAllCookies = decodeURIComponent(document.cookie)
    var allCookies = decodeAllCookies.split(';')
    for (var i = 0; i < allCookies.length; i++) {
        var cookie = allCookies[i].trim()
        if (cookie.indexOf(nameForQuery) == 0) {
            return cookie.substring(nameForQuery.length, cookie.length)
        }
    }
}

// 清除nav input的Cookie (有需要的話可以改寫成清除指定的cookie)
function clearQueryCookie(cookieName) {
    let yesterday = new Date()
    yesterday.setDate(yesterday.getDate() - 1)
    let expires = yesterday.toUTCString()

    let cookieValue = getQueryFromCookie(cookieName)

    document.cookie = `${cookieName}=${cookieValue}; expires=${expires}; path=/`
}

// 費用和時間選單查詢功能
function dropdownItemEvent() {
    $('#event-search-filter .dropdown-item').click(function (event) {

        const filterValue = $(this).text().trim(); // 獲取選擇的篩選值

        // 根據選擇的篩選值設置相應的查詢參數值

        switch (filterValue) {
            case "全部費用":
                //// 不需要設置查詢參數值
                queryParametersDto.minPrice = 0
                queryParametersDto.maxPrice = 99999999
                break;
            case "免費":
                // // 設置 Price 參數值為 free
                // priceValue = "free";
                queryParametersDto.minPrice = 0
                queryParametersDto.maxPrice = 0
                break;
            case "1 - 2000":
                // minPrice = 1;
                // maxPrice = 1000;
                queryParametersDto.minPrice = 1;
                queryParametersDto.maxPrice = 2000;
                break;
            case "2000 - 4000":
                // minPrice = 1000;
                // maxPrice = 2000;
                queryParametersDto.minPrice = 2000;
                queryParametersDto.maxPrice = 4000;
                break;
            case "4000 - 6000":
                // minPrice = 2000;
                // maxPrice = 3000;
                queryParametersDto.minPrice = 4000;
                queryParametersDto.maxPrice = 6000;
                break;
            case "6000 up":
                // minPrice = 3000;
                // maxPrice = Infinity; // 使用 Infinity 表示無限大
                queryParametersDto.minPrice = 6000;
                queryParametersDto.maxPrice = 99999999;
                break;
            case "全部時間":
                queryParametersDto.startTime = null
                queryParametersDto.endTime = null
                break;
            case "今天":
                // // 設置 startTime 參數值為 today
                // timeValue = "today";
                const now = new Date()
                queryParametersDto.startTime = now.toISOString().split('T')[0]
                now.setDate(now.getDate() + 1)
                queryParametersDto.endTime = now.toISOString().split('T')[0]
                break;
            case "兩周內":
                // 獲取一周後的日期
                const oneWeekLater = new Date();
                oneWeekLater.setDate(oneWeekLater.getDate() + 14);
                queryParametersDto.startTime = new Date().toISOString().split('T')[0];
                queryParametersDto.endTime = oneWeekLater.toISOString().split('T')[0];

                break;
            case "兩個月內":
                // 獲取一個月後的日期
                const oneMonthLater = new Date();
                oneMonthLater.setMonth(oneMonthLater.getMonth() + 2);
                queryParametersDto.startTime = new Date().toISOString().split('T')[0];
                queryParametersDto.endTime = oneMonthLater.toISOString().split('T')[0];

                break;
            case "四個月內":
                // 獲取兩個月後的日期
                const twoMonthsLater = new Date();
                twoMonthsLater.setMonth(twoMonthsLater.getMonth() + 4);
                queryParametersDto.startTime = new Date().toISOString().split('T')[0];
                queryParametersDto.endTime = twoMonthsLater.toISOString().split('T')[0];
                break;
            default:
                break;
        }

        loadCards()
    })
}

// 卡片時間格式轉換
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

// 費用選單顏色切換
function feeDropdownColorChanging() {
    let lastClickedFeeItem = null
    $('#filter-fee-wrap .dropdown-item').click(function (event) {
        event.preventDefault()

        if (lastClickedFeeItem) {
            $('#filter-fee-wrap .dropdown-item').removeClass('event-search-filter-clicked')
        }
        $(this).addClass('event-search-filter-clicked')
        console.log('lastClickedItem')
        console.log(lastClickedFeeItem)
        lastClickedFeeItem = $(this)
    })
}

// 時間選單顏色切換
function timeDropdownColorChanging() {
    let lastClickedTimeItem = null
    $('#filter-time-wrap .dropdown-item').click(function (event) {
        event.preventDefault()

        if (lastClickedTimeItem) {
            $('#filter-time-wrap .dropdown-item').removeClass('event-search-filter-clicked')
        }
        $(this).addClass('event-search-filter-clicked')
        console.log('lastClickedItem')
        console.log(lastClickedTimeItem)
        lastClickedTimeItem = $(this)
    })
}