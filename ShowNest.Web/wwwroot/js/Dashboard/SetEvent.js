    const eventNameInput = document.getElementById("EventNameInput");
    const activityFormSelect = document.querySelector(".form-select");
    const onlineActivityElement = document.querySelector(".online-section");
    const mapElement = document.querySelector("#map").closest("div");
    const mapNote = document.querySelector(".map-note");
    const placeLog = document.querySelector(".place-section");
    const websiteLinkInput = document.getElementById("basic-url");
    const okSpan = document.querySelector(".OK");
    const startTimeInput = document.getElementById("startTime");
    const endTimeInput = document.getElementById("endTime");
    const checkbox = document.getElementById("checkbox");
    const timeError = document.getElementById("timeError");
    const locationName = document.getElementById("LocationName");
    const eventAddress = document.getElementById("EventAddress");
    const eventStatus = document.getElementById("EventStatus");

    hideOnlineElements();



//線上或實體顯示
    function hideOnlineElements() {
        onlineActivityElement.style.display = "none";
        mapElement.style.display = "block";
        mapNote.style.display = "block";
        placeLog.style.display = "block";
    }

    activityFormSelect.addEventListener("change", function () {
            if(activityFormSelect.value === "實體活動") {
                hideOnlineElements();
            }
            else {
                onlineActivityElement.style.display = "block";
                mapElement.style.display = "none";
                mapNote.style.display = "none";
                placeLog.style.display = "none";
            }
        });
   /* });*/

/*地圖*/
(g => { var h, a, k, p = "The Google Maps JavaScript API", c = "google", l = "importLibrary", q = "__ib__", m = document, b = window; b = b[c] || (b[c] = {}); var d = b.maps || (b.maps = {}), r = new Set, e = new URLSearchParams, u = () => h || (h = new Promise(async (f, n) => { await (a = m.createElement("script")); e.set("libraries", [...r] + ""); for (k in g) e.set(k.replace(/[A-Z]/g, t => "_" + t[0].toLowerCase()), g[k]); e.set("callback", c + ".maps." + q); a.src = `https://maps.${c}apis.com/maps/api/js?` + e; d[q] = f; a.onerror = () => h = n(Error(p + " could not load.")); a.nonce = m.querySelector("script[nonce]")?.nonce || ""; m.head.append(a) })); d[l] ? console.warn(p + " only loads once. Ignoring:", g) : d[l] = (f, ...n) => r.add(f) && u().then(() => d[l](f, ...n)) })
    ({ key: "AIzaSyBPB4VPZKkuM469YuZcRdGGKnsItE1C7ik", v: "beta" });


// Initialize and add the map
let map;

async function initMap() {
    // The location of BS
    const position = { lat: 25.0415940, lng: 121.5337079 };
    // Request needed libraries.
    //@ts-ignore
    const { Map } = await google.maps.importLibrary("maps");
    const { AdvancedMarkerView } = await google.maps.importLibrary("marker");

    // The map, centered at BS
    map = new Map(document.getElementById("map"), {
        zoom: 15,
        center: position,
        mapId: "DEMO_MAP_ID",
    });

    // The marker, positioned at BS
    const marker = new AdvancedMarkerView({
        map: map,
        position: position,
        title: "BS",
    });
}

initMap();

/*Map end*/

/*上傳圖片 */
document.getElementById('uploadInput')
    .addEventListener('change', function () {
    const file = this.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = function () {
            //render img on uploadInput
            const uploadedImage = document.getElementById('uploadedImage');
            uploadedImage.src = reader.result;
        }
        reader.readAsDataURL(file);
    }
});

// 還原原圖
document.getElementById('restoreBtn')
    .addEventListener('click', function () {
        const uploadedImage = document.getElementById('uploadedImage');
        uploadedImage.src = '/img/Dashboard/upload-img.png';
});

/*欄位驗證*/
function validateForm() {
    //活動名稱欄
    if (eventNameInput.value === "") {
        eventNameInput.classList.add("is-invalid"); // 添加 is-invalid 類別
        return false; // 驗證失敗，阻止提交
    } else {
        eventNameInput.classList.remove("is-invalid"); // 移除 is-invalid 類別
    }


    //網址列驗證
    /*websiteLinkInput.addEventListener("change", function () {*/
    let regex = /^[a-z0-9]{3,16}$/;

    if (websiteLinkInput === "") {
        websiteLinkInput.classList.add("is-invalid"); // 添加 is-invalid 類別
        return false; // 驗證失敗，阻止提交
    }
    else {
        websiteLinkInput.classList.remove("is-invalid"); // 移除 is-invalid 類別
    }

    // 檢查網址是否符合規則
    let regex = /^[a-z0-9]{3,16}$/;
    if (regex.test(websiteLink)) {
        websiteLinkInput.dataset.isValid = "false";
        okSpan.textContent = "請輸入3 到 16 個小寫英文或數字"; // 顯示錯誤訊息
        okSpan.style.display = "block";
        return false; //驗證失敗, 阻止提交

    } else {
        websiteLinkInput.dataset.isValid = "true";
        okSpan.innerHTML = '<i class="fa-solid fa-circle-check"></i> 可以使用';
        okSpan.style.display = "block"; //顯示OK
    }
   /* });*/

    //時間欄位
    if ((startTimeInput.value === "" && endTimeInput.value === "") || checkbox.checked) {
        timeError.style.display = "none";
    } else {
        timeError.style.display = "block";
        return false; // 驗證失敗，阻止提交
    }

    //startTimeInput.addEventListener("change", checkTimeSelection);
    //endTimeInput.addEventListener("change", checkTimeSelection);
    //checkbox.addEventListener("change", checkTimeSelection);
    //checkTimeSelection();

    //活動類型&活動地點驗證
    // 清除所有驗證錯誤
    //locationName.classList.remove("is-invalid");
    //eventAddress.classList.remove("is-invalid");

    // 實體活動
    if (eventStatus.value === "0" && locationName.value === "" || eventAddress.value === "") { 
            locationName.classList.add("is-invalid");
            return false;
    }

    return true;
}

