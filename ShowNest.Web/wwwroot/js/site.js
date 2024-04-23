$(function () {
    $('#header-nav-search-input').keypress(function (e) { 
        var queryString = ''
        if(e.which == 13){
            console.log('Pressed enter on header-nav-search-input')
            queryString = $('#header-nav-search-input').val()
            document.cookie = 'navQueryString=' + queryString + '; path=/'
        }
    })
})