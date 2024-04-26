$(function () {
	$('.carousel-item:first').addClass('active');
	$('#categories-section #categories a').click(function (e) {
		queryCategoryId = $(this).attr('category-id')
		document.cookie = "queryCategoryId=" + queryCategoryId + "; path=/"
	})
})