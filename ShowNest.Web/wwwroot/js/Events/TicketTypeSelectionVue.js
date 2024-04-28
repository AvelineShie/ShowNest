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
        async onNextStepClicked() {
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
            let data = {
                eventDetail: this.ticketTypeSelection.eventDetail,
                selectedTickets,
                hasSeats: true
            };

            if (this.ticketTypeSelection.eventDetail.type !== 2) {
                const response = await fetch('/api/TicketTypes/GetAvailableTickets', {
                    method: 'POST',
                    headers: {
                        "content-type": "application/json"
                    },
                    body: JSON.stringify({
                        Criteria: selectedTickets
                    })
                });
                data.tickets = (await response.json()).tickets;
                data.hasSeats = false
            }
            this.save(flowId, data);

            const params = new URLSearchParams();
            params.append("flowId", flowId);

            let redirectUrl = `/events/seatSelector?${params.toString()}`
            if (this.ticketTypeSelection.eventDetail.type !== 2) {
                redirectUrl = `/events/registrations?${params.toString()}`
            }
            window.location = redirectUrl;
        },
        onViewMapClicked() {
            const longitude = this.ticketTypeSelection.eventDetail.locationLongitude;
            const latitude = this.ticketTypeSelection.eventDetail.locationLatitude;
            const location = this.ticketTypeSelection.eventDetail.eventLocation.split('/')[0].trim();
            let url = `https://www.google.com/maps/search/?api=1&query=${latitude},${longitude}(${location})`;

            window.open(url, '_blank');
        },
        onAddToGoogleCalendarClicked() {
            const eventName = this.ticketTypeSelection.eventDetail.eventName;

            const startTimeString = this.ticketTypeSelection.eventDetail.startTime.toString();
            const startTime = startTimeString.replaceAll(/(-|:)/g, '');
            const endTimeString = this.ticketTypeSelection.eventDetail.endTime.toString();
            const endTime = endTimeString.replaceAll(/(-|:)/g, '');
            const location = this.ticketTypeSelection.eventDetail.eventLocation.split('/')[0].trim();
            let url = `https://calendar.google.com/calendar/event?action=TEMPLATE&text=${eventName}&dates=${startTime}/${endTime}&location=${location}`

            window.open(url, '_blank');
        },
        toFormatDate(datetime) {
            return moment(this.ticketTypeSelection.eventDetail.startTime).format("YYYY/MM/DD HH:mm:ss")
        }
    },
    async mounted() {
        const urlParams = new URLSearchParams(window.location.search);
        const eventId = urlParams.get('eventId');
        await this.fetchTicketTypes(eventId);

        await $cookies.remove('expireTimeOnSelection');
        await $cookies.remove('expireTimeOnRegistration');
        await $cookies.remove('expireTimeOnPayment');
    }
}).mount('#app')