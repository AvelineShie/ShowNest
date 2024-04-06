const {createApp} = Vue

createApp({
    data() {
        return {
            ticketTypeSelection: {},
            isAgreed: false
        }
    },
    methods: {
        async fetchTicketTypes() {
            const response = await fetch('/api/tickettypes/gettickettypeselection?eventId=100');
            const data = await response.json()

            this.ticketTypeSelection = data
        },
        onTicketPriceRowClicked(ticketPriceRow, num) {
            if (ticketPriceRow.tickets.purchaseAmount + num < 0) {
                return
            }

            ticketPriceRow.tickets.purchaseAmount += num
        },
        onNextStepClicked() {
            if (!this.isAgreed) {
                alert('Not agreed');
                return;
            }

            const params = new URLSearchParams();
            for (const ticketPriceRow of this.ticketTypeSelection.ticketPriceRow) {
                if (ticketPriceRow.tickets.purchaseAmount !== 0) {
                    params.append(ticketPriceRow.id, ticketPriceRow.tickets.purchaseAmount);
                }
            }

            const redirectUrl = `/events/seatSelector?${params.toString()}`
            window.location = redirectUrl;
        },
    },
    async mounted() {
        await this.fetchTicketTypes();
    }
}).mount('#app')