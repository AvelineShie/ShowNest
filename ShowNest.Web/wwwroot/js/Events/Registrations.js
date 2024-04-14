const {createApp} = Vue

createApp({
    data() {
        return {
            counter: '',
            remainTime: 0,
        }
    },
    methods: {
        startCountdown() {
            setInterval(() => {

                let minutes = Math.floor(this.remainTime / 60);
                let seconds = Math.floor(this.remainTime % 60);

                minutes = minutes < 10 ? '0' + minutes : minutes;
                seconds = seconds < 10 ? '0' + seconds : seconds;

                this.counter = minutes + ':' + seconds;

                if (this.remainTime > 0) {
                    this.remainTime--;
                } else {
                    clearInterval();
                }

            }, 1000);
        },
        setExpireTime(timesUp) {
            $cookies.set("expireTimeOnRegistration", timesUp)
        },
        getExpireTime() {
            return $cookies.get("expireTimeOnRegistration");
        }
    },
    mounted() {
        let expireTime = this.getExpireTime();
        let setTimer = 600000;
        if (!expireTime) {
            expireTime = new Date().getTime() + setTimer * 1000;

            this.setExpireTime(expireTime);
        }

        const remainTimeMs = expireTime - new Date().getTime();

        if (remainTimeMs <= 0) {
            window.alert('填寫時間已截止，請重新購票');
            window.location.href = 'TicketTypeSelection';
            $cookies.remove('expireTimeOnRegistration');
        } else {
            this.remainTime = remainTimeMs / 1000;
            this.startCountdown();
        }
    },
}).mount('#countdownOnRegistration')

createApp({
    data() {
        return {
            data: {},
            contactInformation: {
                name: undefined,
                email: undefined,
                phone: undefined
            }
        }
    },
    methods: {
        getData(key) {
            return JSON.parse(sessionStorage.getItem(key));
        },
        async onConfirmationClicked() {
            const response = await fetch('/api/Orders/CreateOrder', {
                method: 'POST',
                headers: {
                    "content-type": "application/json"
                },
                body: JSON.stringify({
                    Tickets: this.data.tickets,
                    ContactInformation: this.contactInformation
                })
            });
            console.log(response)
        }
    },
    computed: {
        totalPrice() {
            if (!this.data.tickets)
                return 0;

            return this.data.tickets.reduce((total, ticket) => total + ticket.price, 0);
        }
    },
    mounted() {
        // Load data
        const params = new URLSearchParams(window.location.search);
        const flowId = params.get("flowId");
        this.data = this.getData(flowId);
    }
}).mount('#registrations')