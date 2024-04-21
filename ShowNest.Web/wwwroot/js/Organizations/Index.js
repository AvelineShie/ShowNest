

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
document.addEventListener('DOMContentLoaded', function () {
    const calendarEl = document.getElementById('calendar');
    
    const calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        events: [
            {
                title: '首映會：星際之旅',
                start: '2024-06-28'
            },
            {
                title: '陳奕迅「十年」演唱會',
                start: '2024-07-05'
            },
            {
                title: '首映會：未來之戰',
                start: '2024-07-20'

            },
            {
                title: '展覽：時空之旅',
                start: '2024-04-07',
                end: '2024-04-10'
            },
            {
                title: '李宗盛「等等我，我要去天堂看看」演唱會',
                start: '2024-04-17'
            },
            {
                title: '創新思維工作坊：發想與實踐',
                start: '2024-04-20',
                end: '2024-04-23'
            },
            {
                title: '經典音樂會：莫札特之夜',
                start: '2024-05-07'
            },
            {
                title: '登山活動：健行山林',
                start: '2024-06-07',
                end: '2024-06-12'
            },
            {
                title: '植物園探索：生態奇觀',
                start: '2024-06-05',
                end: '2024-06-10'
            },
            {
                title: '美食節：火鍋嘉年華',
                start: '2024-08-10'
            },
            {
                title: '文學欣賞課程：名家講座',
                start: '2024-08-07',
                end: '2024-08-10'
            },
            {
                title: '經典戲劇欣賞會：紅樓夢',
                start: '2024-09-07'
            },
            {
                title: '音樂會：愛琴海之夜',
                start: '2024-09-05'
            },
            {
                title: '書法展示：墨寶匯',
                start: '2024-09-08'
            }]
        ,
        editable: true,
        selectable: true,
        dayMaxEvents: true
    });
    
    calendar.render()
});