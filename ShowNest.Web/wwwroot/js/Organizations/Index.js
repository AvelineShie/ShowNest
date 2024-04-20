////切換行事曆按鈕
//document.addEventListener('DOMContentLoaded', function() {
//    // 取切换按钮
//    var calendarButton = document.querySelector('.Calendar');

//    // 添加事件監聽
//    calendarButton.addEventListener('click', function(event) {
//        event.preventDefault(); // 阻止跳轉連結


//        // 選擇切換
//        var blockToHide = document.getElementById('eventList');
//        var calendarBlock = document.getElementById('calendar');

//        // 切換區塊顯示狀態
//        if (blockToHide.style.display !== 'none') {
//            blockToHide.style.display = 'none'; // 隐藏近期活動區塊
//            calendarBlock.style.display = 'block'; // 顯示日曆區塊
//        } else {
//            blockToHide.style.display = 'block'; // 顯示近期活動區塊
//            calendarBlock.style.display = 'none'; // 隐藏日曆區塊
//        }
//    });
//});


////套用FullCalendar
//document.addEventListener('click', function() {
//    var calendarEl = document.getElementById('calendar');

//    var calendar = new FullCalendar.Calendar(calendarEl, {
//        headerToolbar: {
//            left: 'prevYear,prev,next,nextYear today',
//            center: 'title',
//            right: 'dayGridMonth,dayGridWeek,dayGridDay'
//        },
//        initialDate: '2023-01-12',
//        navLinks: true,
//        editable: true,
//        dayMaxEvents: true,
//        events: [
//            {
//                title: 'All Day Event',
//                start: '2023-01-01'
//            },
//            {
//                title: 'Long Event',
//                start: '2023-01-07',
//                end: '2023-01-10'
//            },
//            {
//                groupId: 999,
//                title: 'Repeating Event',
//                start: '2023-01-09T16:00:00'
//            },
//            {
//                groupId: 999,
//                title: 'Repeating Event',
//                start: '2023-01-16T16:00:00'
//            },
//            {
//                title: 'Conference',
//                start: '2023-01-11',
//                end: '2023-01-13'
//            },
//            {
//                title: 'Meeting',
//                start: '2023-01-12T10:30:00',
//                end: '2023-01-12T12:30:00'
//            },
//            {
//                title: 'Lunch',
//                start: '2023-01-12T12:00:00'
//            },
//            {
//                title: 'Meeting',
//                start: '2023-01-12T14:30:00'
//            },
//            {
//                title: 'Happy Hour',
//                start: '2023-01-12T17:30:00'
//            },
//            {
//                title: 'Dinner',
//                start: '2023-01-12T20:00:00'
//            },
//            {
//                title: 'Birthday Party',
//                start: '2023-01-13T07:00:00'
//            }
//        ]
//    });

//    calendar.render();
//});