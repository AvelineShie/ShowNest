const { createApp } = Vue

createApp({
    data() {
        return {
            eventId: '',

            tickets: [],

            // TicketTypeId: 0,
            // ticketTypeName: '',
            // startSellingTime: '',
            // endSellingTime: '',
            // sellingStatus: 0,
            // price: 0,
            // soldAmount: 0,
            // paidAmout: 0,
            // waitingToPayAmout: 0,
            // remainAmout: 0,

            priceOfPaidAmout: 0,
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
                    // res.data.forEach(ticket => {

                    //     this.TicketTypeId = ticket.TicketTypeId
                    //     this.ticketTypeName = ticket.ticketTypeName
                    //     this.startSellingTime = ticket.startSellingTime
                    //     this.endSellingTime = ticket.endSellingTime
                    //     this.sellingStatus = true
                    //     this.price = ticket.price
                    //     this.soldAmount = ticket.soldAmount
                    //     this.paidAmout = ticket.paidAmout
                    //     this.waitingToPayAmout = ticket.waitingToPayAmout
                    //     this.remainAmout = ticket.remainAmout

                    // })
                    this.tickets = res.data.map(x => {
                        return {
                            ...x,
                            status: x.sellingStatus ? '販售中' : '已售完'
                        }
                    })
                    console.log('this.tickets')
                    console.log(this.tickets)
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