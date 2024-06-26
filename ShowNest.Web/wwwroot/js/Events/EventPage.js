﻿//(g => { var h, a, k, p = "The Google Maps JavaScript API", c = "google", l = "importLibrary", q = "__ib__", m = document, b = window; b = b[c] || (b[c] = {}); var d = b.maps || (b.maps = {}), r = new Set, e = new URLSearchParams, u = () => h || (h = new Promise(async (f, n) => { await (a = m.createElement("script")); e.set("libraries", [...r] + ""); for (k in g) e.set(k.replace(/[A-Z]/g, t => "_" + t[0].toLowerCase()), g[k]); e.set("callback", c + ".maps." + q); a.src = `https://maps.${c}apis.com/maps/api/js?` + e; d[q] = f; a.onerror = () => h = n(Error(p + " could not load.")); a.nonce = m.querySelector("script[nonce]")?.nonce || ""; m.head.append(a) })); d[l] ? console.warn(p + " only loads once. Ignoring:", g) : d[l] = (f, ...n) => r.add(f) && u().then(() => d[l](f, ...n)) })
//    ({ key: "AIzaSyB3EaB96udUsBhoJ7Wb28Eul-JZCvLctcE", v: "beta" });

//// Initialize and add the map
//let map;

//async function initMap() {
//    // The location of BS
//    const position = { lat: 25.04169, lng: 121.536355 };
//    // Request needed libraries.
//    //@ts-ignore
//    const { Map } = await google.maps.importLibrary("maps");
//    const { AdvancedMarkerView } = await google.maps.importLibrary("marker");

//    // The map, centered at BS
//    map = new Map(document.getElementById("map"), {
//        zoom: 15,
//        center: position,
//        mapId: "DEMO_MAP_ID",
//    });

//    // The marker, positioned at BS
//    const marker = new AdvancedMarkerView({
//        map: map,
//        position: position,
//        title: "BS",
//    });
//}

//initMap();


//--報名人顯示區塊--
const toggleAttendeesBtn = document.getElementById('toggleAttendeesBtn');
const attendeesList = document.querySelector('.attendees');

toggleAttendeesBtn.addEventListener('click', function () {
    const isListVisible = attendeesList.style.display !== 'none';
    attendeesList.style.display = isListVisible ? 'none' : '';
    toggleAttendeesBtn.textContent = isListVisible ? '顯示報名人' : '隱藏報名人';
});