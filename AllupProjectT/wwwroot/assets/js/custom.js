$(document).ready(function () {


    $('#searchBtn').click(function (e) {

        e.preventDefault();
        let search = $('#searchInput').val();
        let categoryId = $('#categoryId').val();

        let searchUrl = 'product/search' + search + '&categoryId=' + categoryId
        if (search.length >= 3) {

            fetch(searchUrl)
                .then(res => res.text())
                .then(data => {
                    console.log(data);

                    $('searchBody').html(data )
                    // Old Partial
                    //for (var i = 0; i < data.length; i++) {
                    //    let item `<a class="d-block" href="#">
                    //     </a>`
                    //}


                })

        }
        consol.log(search + ' ' + categoryId)
    })


    $('.modalBtn').click(function (e) {
        e.preventDefault();

        let url = $(this).attr('href');

        fetch(url)
        .then(res=>res.text())
            .then(data => {
                $('.modal-content').html(data)
                $('.quick-view-image').slick({
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    dots: false,
                    fade: true,
                    asNavFor: '.quick-view-thumb',
                    speed: 400,
                });

                $('.quick-view-thumb').slick({
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    asNavFor: '.quick-view-image',
                    dots: false,
                    arrows: false,
                    focusOnSelect: true,
                    speed: 400,
                });
            })
    })

    $('.addBasket').click(function (e) {
        e.preventDefault();
        let url = $(this).attr('href')

        fetch(url)
            .then(res => res.(text))
            .then(data => {
                $('.header-cart').html(data);
            })
            
    })
})
