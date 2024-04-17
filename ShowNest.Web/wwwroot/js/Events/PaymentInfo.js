const {createApp} = Vue;

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
            $cookies.set("expireTimeOnPayment", timesUp)
        },
        getExpireTime() {
            return $cookies.get("expireTimeOnPayment");
        }
    },
    mounted() {
        let expireTime = this.getExpireTime();
        let setTimer = 900;
        if (!expireTime) {
            expireTime = new Date().getTime() + setTimer * 1000;

            this.setExpireTime(expireTime);
        }

        const remainTimeMs = expireTime - new Date().getTime();

        if (remainTimeMs <= 0) {
            window.alert('付款時間已截止，請重新購票');
            window.location.href = 'TicketTypeSelection';
            $cookies.remove('expireTimeOnPayment');
        } else {
            this.remainTime = remainTimeMs / 1000;
            this.startCountdown();
        }
    },
}).mount('#counterOnPayment')

createApp({
    data() {
        return {
            data: {},
            orderId: null
        }
    },
    methods: {
        getData(key) {
            return JSON.parse(sessionStorage.getItem(key));
        },
        async onCheckoutClicked() {
            const params = new URLSearchParams(window.location.search);
            const orderId = params.get("orderId");

            const response = await fetch('/api/Ecpay/GetEcpayOrderInfo', {
                method: 'POST',
                headers: {
                    "content-type": "application/json"
                },
                body: JSON.stringify({
                    orderId: +orderId
                })
            });
            const ecpayOrder = await response.json();
            console.log(ecpayOrder);

            const form = document.createElement('form');
            form.method = 'POST';
            form.action = 'https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5';

            for (const key in ecpayOrder) {
                if (ecpayOrder.hasOwnProperty(key)) {
                    const hiddenField = document.createElement('input');
                    hiddenField.type = 'hidden';
                    hiddenField.name = key;
                    hiddenField.value = ecpayOrder[key];

                    form.appendChild(hiddenField);
                }
            }

            document.body.appendChild(form);
            form.submit();
        },
        onCancelPurchaseClicked() {
            const params = new URLSearchParams(window.location.search);
            const flowId = params.get("flowId");
            sessionStorage.removeItem(flowId);
            $cookies.remove('expireTimeOnSelection');
            $cookies.remove('expireTimeOnRegistration');
            $cookies.remove('expireTimeOnPayment');
            `TicketTypeSelection?eventId=${this.data.eventDetail.eventId}`;
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
        const orderId = params.get("orderId");
        this.data = this.getData(flowId);
        this.orderId = orderId;
    }
}).mount('#paymentInfo')