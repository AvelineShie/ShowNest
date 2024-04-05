const {createApp} = Vue
const {createVuetify} = Vuetify

const vuetify = createVuetify()

const options = {
    data() {
        return {
            e1: 1,
            message: 'Hello Vue!',
            selectTicketTypeStatus: false,
            ticketTypes: [
                {
                    id: 1,
                    name: "全票",
                    seatArea: ["B1特一", "B1特二"],
                    price: 3000
                },
                {
                    id: 2,
                    name: "全票",
                    seatArea: ["B1特一", "B1特二"],
                    price: 2600
                },
                {
                    id: 3,
                    name: "全票",
                    seatArea: ["B1特一", "B1特二"],
                    price: 2400
                }
            ]
        }
    },
    mounted() {
        console.log('App mounted!')
    },
    methods: {
    }
}
const app = createApp(options)
app.use(vuetify).mount('#app')

