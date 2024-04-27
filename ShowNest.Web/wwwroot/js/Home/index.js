$(function () {
	$('.carousel-item:first').addClass('active');
	$('#categories-section #categories a').click(function (e) {
		queryCategoryId = $(this).attr('category-id')
		document.cookie = "queryCategoryId=" + queryCategoryId + "; path=/"
	})
	var img = new Image();
	img.src = $('img.transparent')[0].src
	img.onload = function () {
		$('img.transparent').removeClass('transparent')
	}
})