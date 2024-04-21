

    // 切換行事曆按鈕
document.addEventListener('DOMContentLoaded', function() {
    // 取切换按钮
    var calendarButton = document.querySelector('.Calendar');

    // 添加事件監聽
    calendarButton.addEventListener('click', function(event) {
        event.preventDefault(); // 阻止跳轉連結


        // 選擇切換
        var blockToHide = document.getElementById('eventList');
        var calendarBlock = document.getElementById('calendar');

        // 切換區塊顯示狀態
        if (blockToHide.style.display !== 'none') {
            blockToHide.style.display = 'none'; // 隐藏近期活動區塊
            calendarBlock.style.display = 'block'; // 顯示日曆區塊
        } else {
            blockToHide.style.display = 'block'; // 顯示近期活動區塊
            calendarBlock.style.display = 'none'; // 隐藏日曆區塊
        }
    });
});



////套用FullCalendar
//document.addEventListener('DOMContentLoaded', function () {
//    const calendarEl = document.getElementById('calendar');
    
//    const calendar = new FullCalendar.Calendar(calendarEl, {
//        initialView: 'dayGridMonth'
//        //>>>eventJson
//        //範例
//        //[{
//        //        title: '登山活動：健行山林',
//        //        start: '2024-06-07',
//        //        end: '2024-06-12'
//        //    }]
//        ,
//        editable: true,
//        selectable: true,
//        dayMaxEvents: true
//    });
    
//    calendar.render()
//});


//document.addEventListener('DOMContentLoaded', function () {
//    const calendarEl = document.getElementById('calendar');
    

//    // Fetch the JSON data from the server
//    fetch('/Organizations/GetEventsJson')
//        .then(response => response.json())
//        .then(jsonEventsString => {
//            const calendar = new FullCalendar.Calendar(calendarEl, {
//                initialView: 'dayGridMonth',
//                events: jsonEventsString, // Use the fetched JSON events here
//                editable: true,
//                selectable: true,
//                dayMaxEvents: true
//            });

//            calendar.render();
//        })
//        .catch(error => console.error('Error fetching events:', error));
//});
