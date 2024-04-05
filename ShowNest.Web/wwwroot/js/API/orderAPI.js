import {api} from "/js/api/api.js"

export const order = {
    GetOrderDetailByOrderId: function (id, handler, error){
        api.request.get('api/Order/GetOrderDetail?orderId='+id, handler, error);
    }
}