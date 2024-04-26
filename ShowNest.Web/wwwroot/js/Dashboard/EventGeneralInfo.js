const app = Vue.createApp({
    data() {
        return {
            eventId: 0,
            eventName: '',
            eventTime: '',
            organizer: '',
            coOrganizer: '',
            capacity: '',
            eventType: '',
            eventBrief: '',
            eventDescription: '',
            eventImg: '',
            longitude: 0,
            latitude: 0,
            eventLocation:'',

            map: null,
            marker: null,
        }
    },
    methods: {
        getDto() {
            axios.get('/api/EventsGeneralInfoApi/GetEventGeneralInfoDtoByApi', {
                params: {
                    eventId: parseInt(this.eventId)
                }
            })
                .then(res => {
                    console.log(res)
                    let info = res.data
                    this.eventName = info.eventName
                    this.eventTime = `${info.eventStartTime}${info.eventEndTime ? ' - ' + info.eventEndTime : ''}`
                    this.organizer = info.organizer
                    this.coOrganizer = info.coOrganizer
                    this.capacity = info.capacity
                    this.eventType = info.eventType
                    this.eventBrief = info.eventBrief
                    this.eventDescription = info.eventDescription
                    this.longitude = info.longitude
                    this.latitude = info.latitude
                    this.eventLocation = `${info.eventLocationName} / ${info.eventLocationAddress}`

                    // 處理圖片錯誤的話，給他一個預設圖片
                    var img = new Image()
                    img.src = info.eventImg
                    this.eventImg = info.eventImg
                    img.onerror = function () {
                        this.eventImg = 'https://res.cloudinary.com/do2tfk5nk/image/upload/v1713610498/ShowNestImg/UnUploadedImg_vsrtfu.jpg'
                    }.bind(this)

                    this.googleMap()
                })
                .catch(err => {
                    console.error(err);
                })
        },
        googleMap() {
            (g => { var h, a, k, p = "The Google Maps JavaScript API", c = "google", l = "importLibrary", q = "__ib__", m = document, b = window; b = b[c] || (b[c] = {}); var d = b.maps || (b.maps = {}), r = new Set, e = new URLSearchParams, u = () => h || (h = new Promise(async (f, n) => { await (a = m.createElement("script")); e.set("libraries", [...r] + ""); for (k in g) e.set(k.replace(/[A-Z]/g, t => "_" + t[0].toLowerCase()), g[k]); e.set("callback", c + ".maps." + q); a.src = `https://maps.${c}apis.com/maps/api/js?` + e; d[q] = f; a.onerror = () => h = n(Error(p + " could not load.")); a.nonce = m.querySelector("script[nonce]")?.nonce || ""; m.head.append(a) })); d[l] ? console.warn(p + " only loads once. Ignoring:", g) : d[l] = (f, ...n) => r.add(f) && u().then(() => d[l](f, ...n)) })
                ({ key: "AIzaSyB3EaB96udUsBhoJ7Wb28Eul-JZCvLctcE", v: "beta" });
            let map;
            let latFormData = parseFloat(this.latitude)
            let lngFormData = parseFloat(this.longitude)
            async function initMap() {
                
                // The location of BS
                // const position = { lat: parseFloat(this.longitude), lng: parseFloat(this.latitude) };
                const position = { lat: latFormData, lng: lngFormData };
                // Request needed libraries.
                // ts-ignore
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
            initMap()
        }
    },
    mounted() {
        this.eventId = $('#app').attr('event-id')
        console.log(`eventId: ${this.eventId}`)
        this.getDto()
    },
})

app.mount('#app')