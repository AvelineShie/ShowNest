
/**
 *
 * API access
 *
 */

export const api = {
    /**
     * App 初始化
     */
    request: {

        // GET operator
        get: function get(url, handler, error) {

            let fixedUrl = _api.helper.url(url);

            $.ajax({
                url: fixedUrl,
                method: 'GET',
                //headers: headers,
                dataType: 'json',
                contentType: 'application/json'
            }).done(function (data) {
                handler(data);
            }).fail(function (res) {
                if (typeof error == 'function') {
                    error(res);
                } else {
                    handler(res);
                }
            });
        },

        // POST operator
        post: function post(url, data, handler, error) {

            // Cache
            let fixedUrl = _api.helper.url(url),
                formMode = false,
                fdata;

            if (data._form) {

                fdata = new FormData();
                formMode = true;

                for (var i in data) {
                    if (i[0] != '_') fdata.append(i, data[i]);
                }
            }

            $.ajax({
                url: fixedUrl,
                method: 'POST',
                data: !formMode ? JSON.stringify(data) : fdata,
                dataType: formMode ? 'html' : 'json',
                contentType: formMode ? false : 'application/json',
                processData: formMode ? false : true
            }).done(function (data) {
                handler(data);
            }).fail(function (res) {
                if (typeof error == 'function') {
                    error(res);
                } else {
                    handler(res);
                }
            });
        }
    }
}

const config = {
    host: `https://${window.location.host}/`,
};
const _api = {}

_api.config = config;
/**
 * Helper
*/
_api.helper = {
    // URL fixer
    url: function url(_url) {
        var return_url = _api.config.host + _url; console.log(return_url);
        return return_url;
        //return 'https://localhost:7156/'+_url;
    }
};

