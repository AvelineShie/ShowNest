import {api} from "/js/api/api.js"

export const order = {
    GetOrderDetailByOrderId: function (id, handler, error){
        api.request.get('api/Order/GetOrderDetail?orderId='+id, handler, error);
    },
     UpdateOrderDetail: function (param, handler, error) {
        api.request.post('api/Orders/UpdateOrderDetail', param, handler, error);
    }
}