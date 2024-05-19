const { createApp, ref } = Vue
const { createVuetify } = Vuetify
const vuetify = createVuetify();


const options = {
    data() {
        return {

            //====================CreateEvent(R)
            userId: '',
            organzationId: 1,
            selectedOrganization: [], //組織下拉v-model
            orgNames: [],//下拉items
            displaySelectActivityType: true, /*隱藏*/
            activityTypes: ["全新的活動", "既有的活動"], //活動下拉item/val
            selectedActivityType: "全新的活動", //活動下拉式v-model
            displayExistingActivities: false, //既有活動後打開
            radioCheck: {}, //所選任一活動
            checkbox: false, //初始未勾選
            stepButton: true, 
            radio: 'Option 1',
            items: ['實體活動', '線上活動'],
            selectedEvent: {},
            events: [],

            eventsforInput: [],

            //============================SetEvent(C,U)

            /*Orgname: '',*/

            eventId:'',
            eventNameInput: '',
            startTime: '',
            endTime: '',
            noEndTime: false,

            mainOrganizerInput: '',
            coOrganizer: '',

            privacy: false,
            
            number: 0, //人數
            unlimited: '',
            eventStatus: 1, //預設實體

            //圖片
            imgUrl: 'https://res.cloudinary.com/do2tfk5nk/image/upload/v1713610498/ShowNestImg/UnUploadedImg_vsrtfu.jpg',

            placeName: '',
            eventAddress: '', 

            //地圖

            longitude: '',
            latitude: '',
            map: null, // 存儲地圖實例
            marker: null,

            streaming: '',
            streamingUrl: '', 

            introduction: '',

            // CKEditor
            editor: ClassicEditor,
            description: '',
            editorConfig: {
                language: 'zh-cn',
                toolbar: ['bold', 'italic', 'heading', 'Superscript', 'link', 'undo', 'redo', 'imageUpload']
            },

            categoryItems: [
                { id: 1, name: '音樂' },
                { id: 2, name: '戲劇' },
                { id: 3, name: '展覽' },
                { id: 4, name: '電影' },
                { id: 5, name: '藝文活動' },
                { id: 6, name: '美食' },
                { id: 7, name: '運動' },
                { id: 8, name: '課程講座' },
                { id: 10, name: '演唱會' }
            ],
            selectedCategories: [],
            

            //Render Data
            ticketDetail: [
                {
                    eventId: '',
                    ticketName: '',
                    startSaleTime: '',
                    endSaleTime: '',
                    price: '',
                    amount: '',
                }
            ],
            savedTicketDetail: [], 
            showTable: true, // 控制表格的顯示與否,
            //orgId: '',
            //orgname: '',

        }
    },
    mounted() {
        this.googleMap()
        this.renderTags()
        this.CreateEventbyUserId()
        this.GetOrgEventsByOrgId()
        this.fetchActivitiesByOrgId()

    },
    methods: {
        //地圖手動輸入刷新
        InputGoogleMap(lat, lng) {
            (g => { var h, a, k, p = "The Google Maps JavaScript API", c = "google", l = "importLibrary", q = "__ib__", m = document, b = window; b = b[c] || (b[c] = {}); var d = b.maps || (b.maps = {}), r = new Set, e = new URLSearchParams, u = () => h || (h = new Promise(async (f, n) => { await (a = m.createElement("script")); e.set("libraries", [...r] + ""); for (k in g) e.set(k.replace(/[A-Z]/g, t => "_" + t[0].toLowerCase()), g[k]); e.set("callback", c + ".maps." + q); a.src = `https://maps.${c}apis.com/maps/api/js?` + e; d[q] = f; a.onerror = () => h = n(Error(p + " could not load.")); a.nonce = m.querySelector("script[nonce]")?.nonce || ""; m.head.append(a) })); d[l] ? console.warn(p + " only loads once. Ignoring:", g) : d[l] = (f, ...n) => r.add(f) && u().then(() => d[l](f, ...n)) })
                ({ key: "AIzaSyBfdBJM1O3m1EPh0SXiX1vTDiTW52WCIIw", v: "beta" });

            let map;
            /*console.log(lat, lng)*/

            let latFormData = parseFloat(lat)
            let lngFormData = parseFloat(lng)
            
            /*console.log(latFormData, lngFormData);*/

            async function initMap() {
                const position = { lat: latFormData, lng: lngFormData };
                const { Map } = await google.maps.importLibrary("maps");
                const { AdvancedMarkerView } = await google.maps.importLibrary("marker");

                map = new Map(document.getElementById("map"), {
                    zoom: 15,
                    center: position,
                    mapId: "DEMO_MAP_ID",
                });
                
                const marker = new AdvancedMarkerView({
                    map: map,
                    position: position,
                    title: "SHOWNEST",
                });
            }
            initMap()
        },

        //自動代入Data
        googleMap(lat, lng) {
            (g => { var h, a, k, p = "The Google Maps JavaScript API", c = "google", l = "importLibrary", q = "__ib__", m = document, b = window; b = b[c] || (b[c] = {}); var d = b.maps || (b.maps = {}), r = new Set, e = new URLSearchParams, u = () => h || (h = new Promise(async (f, n) => { await (a = m.createElement("script")); e.set("libraries", [...r] + ""); for (k in g) e.set(k.replace(/[A-Z]/g, t => "_" + t[0].toLowerCase()), g[k]); e.set("callback", c + ".maps." + q); a.src = `https://maps.${c}apis.com/maps/api/js?` + e; d[q] = f; a.onerror = () => h = n(Error(p + " could not load.")); a.nonce = m.querySelector("script[nonce]")?.nonce || ""; m.head.append(a) })); d[l] ? console.warn(p + " only loads once. Ignoring:", g) : d[l] = (f, ...n) => r.add(f) && u().then(() => d[l](f, ...n)) })
                ({ key: "AIzaSyBfdBJM1O3m1EPh0SXiX1vTDiTW52WCIIw", v: "beta" });

            let map;
            /*console.log(lat, lng)*/

            let latFormData = parseFloat(this.latitude)
            let lngFormData = parseFloat(this.longitude)
            /*console.log(latFormData, lngFormData);*/

            async function initMap() {
                const position = { lat: latFormData, lng: lngFormData };
                const { Map } = await google.maps.importLibrary("maps");
                const { AdvancedMarkerView } = await google.maps.importLibrary("marker");

                map = new Map(document.getElementById("map"), {
                    zoom: 15,
                    center: position,
                    mapId: "DEMO_MAP_ID",
                });
                
                const marker = new AdvancedMarkerView({
                    map: map,
                    position: position,
                    title: "SHOWNEST",
                });
            }
            initMap()
        },

        //地理編碼
        geocode() {
            const geocoder = new google.maps.Geocoder();
            geocoder.geocode({ address: this.eventAddress }, (results, status) => {
                if (status === 'OK') {
                    /*console.log(results)*/
                    const lat = results[0].geometry.location.lat();
                    const lng = results[0].geometry.location.lng();
                    this.latitude = lat;
                    this.longitude = lng;
                    /*console.log(lat, lng)*/
                    /*alert('Geocode was this status' + status);*/

                    this.InputGoogleMap(lat, lng);
                }
            });
        },

        //組織下拉
        async CreateEventbyUserId() {
            await axios.get('/api/CreateEvent/CreateEventbyUserId')
                .then(res => {
                    if (res.data == null) {
                   
                        this.selectedOrganization = { id: 0, name: '沒有組織，請先建立新組織' }
                    }

                    this.orgNames = res.data.map(o => ({ id: o.orgId, name: o.orgName }));
                    console.log(res.data[1].orgId); //todo
                })
                .catch(err => {
                    console.error(err);
                })
        },        

        //示範
        GetOrgEventsByOrgId() {
            console.log(this.selectedOrganization)
        }, 

        //活動列表
        async fetchActivitiesByOrgId() {
            await axios.get(`/api/CreateEvent/GetActivitiesByOrgId`)
            .then(res => {
                if (res.data !== null) {
                    this.eventsforInput = res.data.map(a => ({ eventId: a.eventId, eventName: a.eventName }));
                    console.log( this.eventsforInput)
                }
            })
            .catch(err => {
                console.error(err);
            })
        }, 

        //建立活動
        CreateAndEditEvent() {
            console.log(this.orgNames)
            axios.post('/api/CreateEvent/CreateAndEditEvent', {
                //"DTO": data
                "OrgId": this.organzationId,//todo
                "EventName": this.eventNameInput,
                "StartTime": this.startTime,
                "EndTime": this.endTime,
                "noEndTime": this.noEndTime,
                "MainOrganizer": this.mainOrganizerInput,
                "CoOrganizer": this.coOrganizer,
                "Attendance": this.number,
                "EventStatus": this.eventStatus,
                "StreamingName": this.streaming,
                "StreamingUrl": this.streamingUrl,
                "LocationName": this.placeName,
                "EventAddress": this.eventAddress,
                "EventIntroduction": this.introduction,
                "EventDescription": this.description,
                "EventImage": this.imgUrl,
                "IsPrivateEvent": this.privacy,

                "CategoryId": this.selectedCategories[0].id,
                
                "TicketDetail" : this.ticketDetail
                    .map(ticket => ({
                        "TicketTypeId": ticket.ticketTypeId,
                        "TicketName": ticket.ticketName,
                        "StartSaleTime": ticket.startSaleTime,
                        "EndSaleTime": ticket.endSaleTime,
                        "Price": ticket.price,
                        "Amount": ticket.amount,
                    }))

                
            }) 
                .then(res => {
                    window.location.href = `/Dashboard/Events/${res.data.id}/Overview`
                    
                })
                .catch(err => {
                    console.error(err);
                })
        },

        //tag item
        selectCategory(item) {
            this.selectedCategories = [item]; // 將 selectedCategories 設置為包含選取項的單一元素陣列
        },

        //選擇活動& pass eventId
        handleEventSelection() {
            this.stepButton = 2; //跳轉
            this.EditEventRender(this.radioCheck);
            console.log(this.radioCheck)
        },

        //渲染活動內容
        EditEventRender() {
            console.log("Render Success!");
            axios.get('/api/CreateEvent/RenderEventData', {
                params: {
                    eventId: parseInt(this.radioCheck)
                }
            })
                .then(res => {
                    let info = res.data.data;
                    console.log(res.data);

                    //DB回傳字首會變小
                    this.organzationId = info.orgId
                    this.Orgname = info.orgname 

                    this.eventId = info.eventId
                    this.eventNameInput = info.eventName
                    this.startTime = info.startTime
                    this.endTime = info.endTime 
                    this.mainOrganizerInput = info.mainOrganizer 
                    this.coOrganizer = info.coOrganizer
                    this.privacy = info.isPrivateEvent
                    this.number = info.attendance 
                    this.eventStatus = info.eventStatus

                    this.imgUrl = info.eventImage
                    this.placeName = info.locationName 
                    this.eventAddress = info.eventAddress 
                    this.streaming = info.streamingName
                    this.streamingUrl = info.streamingUrl
                    this.longitude = info.longitude
                    this.latitude = info.latitude
                    this.googleMap()
                    this.introduction = info.eventIntroduction
                    this.description = info.eventDescription

                    // ============Render Tag
                    this.renderTags();


                    //========================Render Ticket
                    this.ticketDetail = info.ticketDetail
                        .map(ticket => ({
                        ticketTypeId: ticket.ticketTypeId,
                        eventId: ticket.eventId,
                        ticketName: ticket.ticketName,
                        startSaleTime: ticket.startSaleTime,
                        endSaleTime: ticket.endSaleTime,
                        price: ticket.price,
                        amount: ticket.amount,
                        }));

                    console.log(info.ticketDetail);

                })
                .catch(err => {
                    console.error(err);
                });
        },

        //渲染標籤
        renderTags() {
                let tags = '';
                this.categoryItems.forEach(category => {
                    tags += `<div class="tag">
                    <input type="checkbox" id="category-${category.id}" v-model="selectedCategories" :value="category.id" @change="selectCategory(category.id)">
                    <label for="category-${category.id}" href="./Events/Index" class="categories-tag">${category.name}</label>
                </div>`;
                });
                return tags;
        },

        //圖床
        imgUpload(e) {
            let formData = new FormData();
            for (let i = 0; i < e.target.files.length; i++) {
                formData.append('files', e.target.files[i]);
            }
            axios.post('/api/ImgUploadApi/UploadImages', formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            })
                .then(res => {
                    console.log(res)
                    this.imgUrl = res.data[0]
                })
                .catch(err => {
                    console.error(err);
                })
        },

        //跳轉第三頁
        handleClick() {
            this.stepButton = 3;
        },

        //送出
        submitClick() {
            this.CreateAndEditEvent()
        },

        //票卷: 儲存Btn
        addNewTicket(index) {
            if (index >= 0 && index < this.ticketDetail.length) {
                //index < ticketDtail's item 數量
                // 直接修改 ticketDetail 陣列中的物件
                this.ticketDetail[index] = {
                    ticketName: this.ticketTypeInput,
                    startSaleTime: this.startSaleTime,
                    endSaleTime: this.endSaleTime,
                    price: this.prince,
                    amount: this.amount
                };
            } else {
                // 添加新的票卷內容
                this.ticketDetail.push({
                    TicketName: this.ticketTypeInput,
                    StartSaleTime: this.startSaleTime,
                    EndSaleTime: this.endSaleTime,
                    Price: this.price,
                    Amount: this.amount
                });
            }
            console.log(this.ticketDetail)
            // 清空輸入欄位
            //this.ticketTypeInput = '';
            //this.startSaleTime = '';
            //this.endSaleTime = '';
            //this.price = '';
            //this.amount = '';
            
        },

        //todo: 會通通刪除
        //票卷:刪除Btn
        deleteTicket(index) {
            this.ticketDetail.splice(index, 1); // 刪除指定索引的票卷
        },

        //標籤值更新
        selectCategory(selectedCategory) {
            this.selectedCategories = [];
            this.selectedCategories.push(selectedCategory);
        }

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

        //選擇既有活動後觸發列表
        'selectedActivityType': {
            handler: function (val) {
                if (val === "既有的活動") {
                    this.displayExistingActivities = true
                    this.fetchActivitiesByOrgId();
                }
            }
        },

        //選組織
        'selectedOrganization': {
            handler: function (value) {
                
                if (value != '') {
                    console.log(value);
                    //var index = this.orgNames.findIndex(
                    //    (value) => orgNames.name === value

                    //);
                    //console.log(index);

                    //var index = this.orgNames.findIndex(
                    //    (value) => this.orgName.name === value

                    //);
                    
                }
                
                
            }
        }
        //handleChange(value) {

        //    if (this.orgNames !== null) {
        //        console.log(value);

        //        var index = this.orgNames.findIndex(
        //            (value) => orgNames.name === value
        //        );

        //        console.log(index);
        //    }
        //},

        //測試commit1

        
    }
}
const app = createApp(options);
// 創建一個 Vue 應用實例，使用 options 作為配置選項
app.use(CKEditor)
app.use(vuetify)
app.mount('#app')









