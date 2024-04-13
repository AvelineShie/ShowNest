const {createApp} = Vue

createApp({
    data() {
        return {
            ticketTypeSelection: {},
            isAgreed: false
        }
    },
    methods: {
        async fetchTicketTypes(eventId) {
            const response = await fetch(`/api/tickettypes/gettickettypeselection?eventId=${eventId}`);
            const data = await response.json()

            this.ticketTypeSelection = data
        },
        onTicketPriceRowClicked(ticketPriceRow, num) {
            if (ticketPriceRow.tickets.purchaseAmount + num < 0) {
                return
            }

            ticketPriceRow.tickets.purchaseAmount += num
        },
        save(key, data) {
            console.log('Save Data:', key, data);
            sessionStorage.setItem(key, JSON.stringify(data));
        },
        onNextStepClicked() {
            if (!this.isAgreed) {
                alert('Not agreed');
                return;
            }

            const flowId = new Date().getTime();
            const selectedTickets = this.ticketTypeSelection.ticketPriceRow
                .filter(i => i.tickets.purchaseAmount !== 0)
                .map(i => ({
                    TicketTypeId: i.id,
                    TicketCount: i.tickets.purchaseAmount
                }));
            this.save(flowId, {selectedTickets});

            const params = new URLSearchParams();
            params.append("flowId", flowId);
            const redirectUrl = `/events/seatSelector?${params.toString()}`
            window.location = redirectUrl;
        },
    },
    async mounted() {
        const urlParams = new URLSearchParams(window.location.search);
        const eventId = urlParams.get('eventId');

        await this.fetchTicketTypes(eventId);
    }
}).mount('#app')