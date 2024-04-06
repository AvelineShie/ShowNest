const {createApp} = Vue
const {createVuetify} = Vuetify

const vuetify = createVuetify()

const options = {
    data() {
        return {
            e1: 1,
            selectedOrganization: {},
            organizations: [],
            selectedEvent: {},
            events: [],
            userId: 1
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
                    headers: {'Content-Type': 'application/json'}, // 設定內容類型為 JSON
                    body: JSON.stringify({userId: 1}) // 將資料轉換成 JSON 字串
                })
                .then(response => {
                    return response.json()
                })
                .then(data => {
                    console.log(data)
                    if (!data.isSuccess)
                    {
                        this.selectedOrganization = {id: 0, name: 'No organization'}
                        throw new Error(data.message)
                    }
                    this.organizations = data.body.organizations.map(x => {
                        return {id: x.id, name: x.name}
                    })
                    this.selectedOrganization = null
                })
                .catch(err => {
                    console.error(err)
                })
        }
    },
    watch: {
        'selectedOrganization': {
            handler: function (val) {

            },
            immediate: false,
            deep: true
        }
    }
}
const app = createApp(options)
app.use(vuetify).mount('#app')

