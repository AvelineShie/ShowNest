const { createApp } = Vue
const { createVuetify } = Vuetify


const vuetify = createVuetify();

const options = {
    data() {
        return {
            e1: 1,
            displaySelectActivityType: false,
            activityTypes: ["全新的活動", "既有的活動"],
            selectedActivityType: "全新的活動",
            displayExistingActivities: false,
            selectedOrganization: {},
            organizations: [],
            selectedEvent: {},
            events: [],
            userId: 1,
            radio: 'Option 1',
            items: ['實體活動', '線上活動']
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
const app = createApp(options);

app.use(vuetify).mount('#app');

// /*EventType*/
// export default {
//     data: () => ({
//         items: ['實體活動', '線上活動'],
//     }),
// }


/*Event dropdown list menu*/
//import { ref } from 'vue'

//const radio = ref('Option 1')

//export default {
//    data() {
//        return {
//            radio: 'Option 1',
//        }
//    },
//}

