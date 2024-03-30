document.addEventListener("DOMContentLoaded", function () {
    const activityFormSelect = document.querySelector('.form-select');
    const onlineActivityElement = document.querySelector('.online-section');
    const mapElement = document.querySelector('#map').closest('div');
    const mapNote = document.querySelector('.map-note');
    const placeLog = document.querySelector('.place-section');
    const websiteLinkInput = document.getElementById("basic-url");
    const okSpan = document.querySelector(".OK");
    hideOnlineElements();

//網址列驗證
    websiteLinkInput.addEventListener("change", function () {
        var websiteLink = websiteLinkInput.value;
        var regex = /^[a-z0-9]{3,16}$/;

        if (regex.test(websiteLink)) {
            websiteLinkInput.dataset.isValid = "true";
            okSpan.style.display = "block";
        } else {
            websiteLinkInput.dataset.isValid = "false";
            okSpan.style.display = "請輸入3 到 16 個小寫英文或數字";
        }
    });


//線上或實體選項顯示
    function hideOnlineElements() {
        onlineActivityElement.style.display = 'none';
        mapElement.style.display = 'block';
        mapNote.style.display = 'block';
        placeLog.style.display = 'block';
    }

    activityFormSelect.addEventListener('change', function () {
        var selectedValue = activityFormSelect.value;
        if (selectedValue === '實體活動') {
            hideOnlineElements();
        }
        else {
            onlineActivityElement.style.display = 'block';
            mapElement.style.display = 'none';
            mapNote.style.display = 'none';
            placeLog.style.display = 'none';
        }
    });
});

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
//document.getElementById('uploadInput')
//    .addEventListener('change', function () {
//    const file = this.files[0];
//    if (file) {
//        const reader = new FileReader();
//        reader.onload = function () {
//            //render img on uploadInput
//            const uploadedImage = document.getElementById('uploadedImage');
//            uploadedImage.src = reader.result;
//        }
//        reader.readAsDataURL(file);
//    }
//});

// 還原原圖
document.getElementById('restoreBtn')
    .addEventListener('click', function () {
        const uploadedImage = document.getElementById('uploadedImage');
        uploadedImage.src = '/img/Dashboard/upload-img.png';
});

