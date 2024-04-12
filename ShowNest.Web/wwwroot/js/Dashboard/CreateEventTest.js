
const { createApp } = Vue
const { createVuetify } = Vuetify
const vuetify = createVuetify();

const options = {
    data() {
        return {
            //CreateEvent
            e1: 1, //???
            selectedOrganization: {},
            organizations: [],
            displaySelectActivityType: false,
            activityTypes: ["全新的活動", "既有的活動"],
            selectedActivityType: "全新的活動",
            displayExistingActivities: false,
            selectedEvent: {}, //勾選的活動

            //SetEvent
            /*OrganizationName:*/

            events: [],
            userId: 1,
            radio: 'Option 1',
            items: ['實體活動', '線上活動'],
            checkbox: false, // 同意書
        }
    },
    mounted() {
        this.getOrganizationsById()
    },
    methods: {
        getOrganizationsById() {
            fetch('/api/Events/GetOrganizationsById',
                {
                    method: 'POST', // 設定請求方法為 POST
                    headers: { 'Content-Type': 'application/json' }, // 設定內容類型為 JSON
                    body: JSON.stringify({ userId: this.userId }) // 將資料轉換成 JSON 字串
                })
                .then(response => {
                    return response.json()
                })
                .then(data => {
                    if (!data.isSuccess) {
                        this.selectedOrganization = { id: 0, name: '沒有組織，請先建立組織' }
                        throw new Error(data.message)
                    }
                    this.organizations = data.body.organizations.map(x => {
                        return { id: x.id, name: x.name }
                    })
                    this.selectedOrganization = null
                })
                .catch(err => {
                    console.error(err)
                })
        },
        getEventsByOrganizationId() {
            console.log(this.selectedOrganization)
        },
    },
    watch: {
        'selectedOrganization': {
            handler: function (val) {
                if (val) {
                    this.displaySelectActivityType = true
                }
            },
            immediate: false,
            deep: true
        },
        'selectedActivityType': {
            handler: function (val) {
                if (val === "既有的活動") {
                    this.displayExistingActivities = true
                    this.getEventsByOrganizationId()
                }
            }
        }
    }
}
const app = createApp(options); // 創建一個 Vue 應用實例，使用 options 作為配置選項
app.use(vuetify).mount('#app');


/*==========google map=============*/
//import VueGoogleMaps from '@fawmi/vue-google-maps';
//const mapOptions = {
//    data() {
//        return {
//            // 地圖的中心點
//            center: { lat: 51.093048, lng: 6.842120 },
//            // 地圖的縮放級別
//            zoom: 7,
//            // 地圖的類型
//            mapTypeId: 'terrain',
//        };
//    },
//    template: `
//    <GMapMap
//      :center="center"
//      :zoom="zoom"
//      :map-type-id="mapTypeId"
//      style="width: 100vw; height: 900px"
//    >
//    </GMapMap>
// `,
//};

//const mapApp = createApp(mapOptions);

////安裝地圖套件
//mapApp.use(VueGoogleMaps, {
//    load: {
//        key: 'AIzaSyBPB4VPZKkuM469YuZcRdGGKnsItE1C7ik',
//    },
//    autobindAllEvents: true,
//});
//mapApp.use(vuetify).mount('#mapApp'); // 掛載應用到 DOM 元素上


