const { createApp, ref } = Vue
const { createVuetify } = Vuetify
const vuetify = createVuetify();


const options = {
    data() {
        return {

            //====================CreateEvent(R)
            userId: 2,
            selectedOrganization: {}, //組織下拉v-model
            organizations: [], //下拉items
            displaySelectActivityType: false, /*隱藏*/
            activityTypes: ["全新的活動", "既有的活動"], //活動下拉item/val
            selectedActivityType: "全新的活動", //活動下拉式v-model
            displayExistingActivities: false, //既有活動後打開
            radioCheck: {}, //所選任一活動
            checkbox: false, //初始未勾選
            stepButton: false, //初始不可按
            radio: 'Option 1',
            items: ['實體活動', '線上活動'],
            selectedEvent: {},
            events: [],

            //====================SetEvent(R,U)
            eventId: '',
            OrgName: '',

            eventNameInput: '',
            startTime: '',
            endTime: '',
            noEndTime: false,
            mainOrganizerInput: '',
            coOrganizer: '',

            number: '', //人數
            unlimited: '',

            placeName: '',
            EventAddress: '',
            updateMap:'',

            streaming:'',
            SHOWNESTLive: '', //線上選項

            introduction: '',

            
            eventStatus: [], //實體或線上
            placeSection: true, //實體活動欄位
            onlineEventArea: false, //線上活動欄位

            //地圖
            center: { lat: 40.689247, lng: -74.044502 },
            position:{ lat: 40.689247, lng: -74.044502 },

            // CKEditor
            editor: ClassicEditor,
            description: '',
            editorConfig: {
                language: 'zh-cn',
                toolbar: ['bold', 'italic', 'heading', 'Superscript', 'link', 'undo', 'redo', 'imageUpload']
            },

            //圖片
            fileupload: '',
            restoreImg: '',

            //活動隱私狀態
            public: '',
            private:'',

            tag:'',

            //======================SetTicket(R,U)
            //選票種
            //TicketTypeList: [
            //    { id:1, name:"全票" }
            //],
            //selectedTicketType: [],

            //選票區
            //TicketAreaList:
            //[
            //    { id: 1, name: "特1A" },
            //    { id: 2, name: "特1B" },
            //    { id: 3, name: "2A區" },
            //    { id: 4, name: "2B區" },
            //    { id: 5, name: "2C區" },
            //    { id: 6, name: "2D區" },
            //    { id: 7, name: "2E區" },
            //    { id: 8, name: "2F區" },
            //    { id: 9, name: "2G區" },
            //    { id: 10, name: "3A區" },
            //    { id: 11, name: "3B區" },
            //    { id: 12, name: "3C區" },
            //    { id: 13, name: "3D區" },
            //    { id: 14, name: "3E區" },
            //    { id: 15, name: "3F區" },
            //    { id: 16, name: "3G區" }
            //],
            //selectedTicketAreaList: [],

        }
    },
    mounted() {
        this.CreateEventbyUserId()
        /*this.CreateAndEditEvent()*/
        /*this.GetOrgEventsByOrgId()*/
    },
    methods: {
        async CreateEventbyUserId() {
            await axios.get('/api/CreateEvent/CreateEventbyUserId')
                .then(res => {
                    if (res.data == null) {
                        this.selectedOrganization = { id: 0, name: '沒有組織，請先建立新組織' }
                    }
                    console.log(res.data)
                    this.orgNames = res.data.forEach(o => console.log(o.orgName));
                    this.orgNames = res.data.map(o => ({ id: o.orgId, name: o.orgName }));
            })
            .catch(err => {
                console.error(err); 
            })

        },

        imgUpload(e) {
            let formData = new FormData();
            for (let i = 0; i < e.target.filtes.length; i++) {
                formData.append('files', e.target.files[i]);
            }
            axios.post('/api/ImgUploadApi/UploadImages', formData, {
                header: {
                    'Content-'
                }
            })
        }

        //    const data = await response.json();
        //    if (!data.isSuccess) {
        //        this.selectedOrganization = { id: 0, name: '沒有組織，請先建立組織' };
        //        throw new Error(data.message);
        //    }

        //    this.orgNames = data.body.orgNames.map(x => {
        //        return { id: x.id, name: x.name };
        //    });
        //    console.log(orgNames);

        //    this.selectedOrganization = null;
        //} catch (err) {
        //    console.error(err);
        //}

        

        //CreateAndEditEvent() {
        //    fetch('/api/CreateEvent/CreateAndEditEvent',
        //        {
        //            method: 'POST', 
        //            headers: { 'Content-Type': 'application/json' }, 
        //            body: JSON.stringify({ eventId: this.eventId })
        //        })
        //        .then(response => {
        //            return response.json()
        //        })
        //        .then(data => {
        //            if (!data.isSuccess) {
        //                this.selectedOrganization = { id: 0, name: '沒有組織，請先建立組織' }
        //                throw new Error(data.message)
        //            }
        //            this.organizations = data.body.organizations.map(x => {
        //                return { id: x.id, name: x.name }
        //            })
        //            this.selectedOrganization = null
        //        })
        //        .catch(err => {
        //            console.error(err)
        //        })
        //},
        //GetOrgEventsByOrgId() {
        //    console.log(this.selectedOrganization)
        //},

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
        },

        //'onlineEventArea': {
        //    handler: function (value) {
        //        if (value == "1") {
        //            this.onlineEventArea = true
        //            this.placeSection = false
        //        }
        //    }
        //}

        //'checkbox': {
        //    handler: function (newVal) {
        //        // 透過 newVal, prevVal 取得監聽前後變數的值
        //        if (newVal == preVal) {
        //            this.stepButton = false;
        //            this.checkboxErrorMsg = "請勾選同意後進行!";
        //        }
        //        else {
        //            this.stepButton = true;
        //            this.checkboxErrorMsg = "";
        //        }
        //    },
        //    immediate: false
        //},
    }
}
const app = createApp(options); // 創建一個 Vue 應用實例，使用 options 作為配置選項
app.component('draggable', vuedraggable)
app.component('GoogleMap', GoogleMap)
app.component('GoogleMapMarker', Marker)
app.use(CKEditor)
app.use(vuetify)
app.mount('#app')



/*=============票區選擇===============*/
//格式錯誤要改寫
//import draggable from "@@/vuedraggable";
//const SelectTicketArea = createApp({
//    name: "two-lists",
//    components: {
//        draggable
//    },
//    data() {
//        return {
//            list1: [
//              { name: "特1A", id: 1 },
//{ name: "特1B", id: 2 },
//{ name: "2A區", id: 3 },
//{ name: "2B區", id: 4 },
//{ name: "2C區", id: 5 },
//{ name: "2D區", id: 6 },
//{ name: "2E區", id: 7 },
//{ name: "2F區", id: 8 },
//{ name: "2G區", id: 9 },
//{ name: "3A區", id: 10 },
//{ name: "3B區", id: 11 },
//{ name: "3C區", id: 12 },
//{ name: "3D區", id: 13 },
//{ name: "3E區", id: 14 },
//{ name: "3F區", id: 15 },
//{ name: "3G區", id: 16 }
//            ],
//            list2: [],
//            新增一個變數來儲存使用者輸入的選項名稱
//            newOptionName: ''
//        };
//    },
//    methods: {
//        add: function () {
//            this.list1.push({ name: this.newOptionName, id: this.list1.length + 1 });
//        },
//        replace: function () {
//            list1.length = 0;
//            list2.push({ name: this.newOptionName, id: 1 }); //因為list清空, 所以加入的是id=1
//        },
//        clone: function (el) {
//            return {
//                name: el.name
//            };
//        },
//        log: function (evt) {
//            console.log(evt);
//        }
//    },
//}).mount('#app');

//<ul>
//  <li>特1A</li>
//  <li>特1B</li>
//  <li>2A區</li>
//  <li>2B區</li>
//  <li>2C區</li>
//  <li>2D區</li>
//  <li>2E區</li>
//  <li>2F區</li>
//  <li>2G區</li>
//  <li>3A區</li>
//  <li>3B區</li>
//  <li>3C區</li>
//  <li>3D區</li>
//  <li>3E區</li>
//  <li>3F區</li>
//  <li>3G區</li>
//</ul>

/*===========票種選擇===========*/

//const SelectTicketType = createApp({
//    name: "two-lists",
//    components: {
//        draggable
//    },
//    data() {
//        return {
//            list1: [
//                { name: "全票", id: 100 },
//            ],
//            list2: []
//        };
//    },
//    methods: {
//        add: function () {
//            this.list1.push({ name: "全票" });
//        },
//        replace: function () {
//            list1.length = 0; // 清空 list1
//            list2.push({ name: "全票" }); // list2添加新的全票
//        },
//        clone: function (el) {
//            return {
//                name: el.name
//            };
//        },
//        log: function (evt) {
//            console.log(evt);
//        }
//    },
//}).mount('#app');


/*=============google map ==============*/
//寫的格式錯誤
//const { GoogleMap, Marker } = Vue3GoogleMap

//const map = createApp({
//  setup() {
//    const center = { lat: 40.689247, lng: -74.044502 };

//    return {
//      center
//    }
//  }
//})

//map.component('GoogleMap', GoogleMap)
//map.component('GoogleMapMarker', Marker)

//map.mount('#app')
