const { createApp } = Vue;

createApp({
    data() {
        return {
            data: {},
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
}).mount('#Ecpay')





//$("#checkoutBtn").on('click', (e) => {
//    //e.preventDefault(); //因為送出就跳轉到綠界，這個可以停住確認自己的console.log的內容
//    let formData = $("#form").serializeArray();
//    var json = {};
//    $.each(formData, function () {
//        json[this.name] = this.value || "";
//    });
//    console.log(json);
//    //step3 : 新增訂單到資料庫
//    $.ajax({
//        type: 'POST',
//        url: '/api/Ecpay/AddOrders',
//        contentType: 'application/json; charset=utf-8',
//        data: JSON.stringify(json),
//        success: function (res) {
//            console.log(res);
//        },
//        error: function (err) { console.log(err); },
//    });
//});