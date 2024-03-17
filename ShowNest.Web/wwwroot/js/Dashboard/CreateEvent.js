const organizeList = document.getElementById("organizeList");
const activitySelect = document.querySelector(".activity-select");
const newActivity = document.querySelector(".new-activity");
const newActivityRadio = document.querySelector('.new-activiy-radio');
const ActivityItem = document.getElementById("ActivityItem");
const TOSzone = document.querySelector(".TOSzone");
const establishBtn = document.querySelector(".establishBtn");
const checkBox = document.querySelector(".checkbox");


activitySelect.style.display = "none";
newActivity.style.display = "none";
TOSzone.style.display = "none";
establishBtn.style.display = "none";


organizeList.addEventListener("change", function() {
    if(organizeList.value == 'option1'){
        activitySelect.style.display = "none";
        newActivity.style.display = "none";
        TOSzone.style.display = "none";
        establishBtn.style.display = "none";
    }
    else{
        activitySelect.style.display = "block";
        newActivity.style.display = "block";
        TOSzone.style.display = "block";
        establishBtn.style.display = "block";
        newActivityRadio.checked = true;
        establishBtn.disabled = true;
    }
});

ActivityItem.addEventListener("click", () => {
     newActivityRadio.checked = false;
});


//改變按鈕狀態
checkBox.addEventListener("change", function () {
    // 如果 checkbox 是勾選狀態
    if (this.checked) {
        // 啟用按鈕
        establishBtn.disabled = false;
        // 改變按鈕顏色
        establishBtn.style.backgroundColor = "var(--main-green)";
    }
});