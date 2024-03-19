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


//���ܫ��s���A
checkBox.addEventListener("change", function () {
    // �p�G checkbox �O�Ŀ窱�A
    if (this.checked) {
        // �ҥΫ��s
        establishBtn.disabled = false;
        // ���ܫ��s�C��
        establishBtn.style.backgroundColor = "var(--main-green)";
    }
});