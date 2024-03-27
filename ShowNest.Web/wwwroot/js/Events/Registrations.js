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
                }
                else {
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
        let setTimer = 900;
        if (!expireTime) {
            expireTime = new Date().getTime() + setTimer * 1000;

            this.setExpireTime(expireTime);
        }

        const remainTimeMs = expireTime - new Date().getTime();
        
        if (remainTimeMs <= 0 ) {
            window.alert('填寫時間已截止，請重新購票');
            window.location.href = 'TicketTypeSelection';
            $cookies.remove('expireTimeOnRegistration');
        } else {
            this.remainTime = remainTimeMs / 1000;
            this.startCountdown();
        }
    },
}).mount('#countdownOnRegistration')