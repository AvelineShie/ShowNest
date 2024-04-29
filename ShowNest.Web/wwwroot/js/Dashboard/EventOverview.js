const { createApp } = Vue

createApp({
    data() {
        return {
            // general section
            eventId: 0,
            eventName: '',
            allRemainedTicketsCount: 0,
            allSoldTicketsCount: 0,
            allTicketsAmount: 0,
            eventTime: '',
            eventPlace: '',

            //tickets section
            tickets: [],
            totalPaidAmount: 0,
            totalWaitingToPayAmount: 0,
            totalPaidPrice: 0,

            // orders section
            orders:[],
        }
    },
    methods: {
        getTicketsData() {
            console.log('getTicketsData() processing')
            axios.get('/api/EventsOverviewApi/GetEventsOverviewDto', {
                params: {
                    eventId: parseInt(this.eventId)
                }
            })
                .then(res => {
                    console.log(res)

                    //general section
                    this.eventId = res.data.eventId
                    this.eventName = res.data.eventName
                    this.eventTime = res.data.eventTime
                    this.eventPlace = res.data.eventPlace
                    this.allRemainedTicketsCount = res.data.allRemainedTicketsCount
                    this.allSoldTicketsCount = res.data.allSoldTicketsCount
                    this.allTicketsAmount = res.data.allTicketsAmount

                    // tickets section
                    let ticketsData = res.data.tickets
                    this.tickets = ticketsData.map(x => {
                        return {
                            ...x,
                            status: x.sellingStatus ? '販售中' : '已售完',
                        }
                    })
                    ticketsData.forEach(e => {
                        this.totalPaidAmount += e.paidAmount
                        this.totalWaitingToPayAmount += e.waitingToPayAmount
                        this.totalPaidPrice += (e.paidAmount * e.price)
                    });

                    // orders section
                    let ordersData = res.data.orders
                    this.orders = ordersData.map(x =>{
                        return{
                            ...x,
                        }
                    })
                })
                .catch(err => {
                    console.error(err);
                })
        }
    },
    mounted() {
        this.eventId = $('#app').attr('event-id')
        console.log(this.eventId)
        this.getTicketsData()
    },
}).mount('#app')