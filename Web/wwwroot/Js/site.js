$(document).ready(function () {

    $(".SpanBook").on("click", function () {

        $(this).toggleClass("clicked");
    })


    $(".owl-carousel").owlCarousel({
        items: 5,
        margin: 10,
        dots: false,
        autoplay: true,
        loop: true,
        responsive: {
            0: {
                items: 1
            },
            420: {
                items: 2
            },

            600: {
                items: 3
            },
            1000: {
                items: 5
            }
        }
    });


    var btn = $(this);
    $('.js-PostInBasket').on('click', function () {
        var btn = $(this);
        bootbox.confirm({
            message: 'Are You Sure To Add This Book ?',
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {
                    $.ajax({

                        url: '/api/Basket/?BookId=' + btn.data('id'),

                        method: 'POST',

                        success: function () {
                            window.location.reload();
                        },
                        error: () => {
                            alert("Error !!!!!!!!!!!")
                        }

                    })

                }
            }
        });



    })

    $('.js-removeInBasket').on('click', function () {
        var btn = $(this);
        bootbox.confirm({
            message: 'Are You Sure To Remove This Book ?',
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {
                    $.ajax({

                        url: '/api/Basket/?BookId=' + btn.data('id'),

                        method: 'DELETE',

                        success: function () {
                            btn.parentsUntil('.basketbook').parent().fadeOut()
                        },
                        error: () => {
                            alert("Error !!!!!!!!!!!")
                        }

                    })

                }
            }
        });



    })


    $('.js-addInBookMark').on('click', function () {
        var btn = $(this);

        $.ajax({

            url: '/api/BookMark/?BookId=' + btn.data('id'),

            method: 'POST',

            success: function () {
                window.location.reload();
                
            },
            error: () => {
                alert("Error !!!!!!!!!!!")
            }

        })
        



    })

    $('.js-removeInBooMark').on('click', function () {
        var btn = $(this);
        $.ajax({

            url: '/api/BookMark/?BookId=' + btn.data('id'),

            method: 'DELETE',

            success: function () {
                btn.parentsUntil('.basketbook').parent().fadeOut(); 
            },
            error: () => {
                alert("Error !!!!!!!!!!!")
            }

        })
        



    })

    $('.js-removeInBooMarkOutMarkPage').on('click', function () {
        var btn = $(this);
        $.ajax({

            url: '/api/BookMark/?BookId=' + btn.data('id'),

            method: 'DELETE',

            success: function () {
                $(".SpanBook").on("click", function () {
                    $(this).toggleClass("clicked");
                    window.location.reload();
                })
            },
            error: () => {
                alert("Error !!!!!!!!!!!")
            }

        })




    })

    $('.Searchinput').autocomplete({

        source: function (request, response) {
            $.ajax({

                url: '/api/Search/search?term=' + request.term ,
                method :"GET",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (xhr, textStatus, error) {
                    alert(xhr.statusText);
                    alert(textStatus);
                    alert(error);
                },
            });
        },
        minLength: 1
    });



    $('.js-removeBook').on('click', function () {
        var btn = $(this);
        bootbox.confirm({
            message: 'Are You Sure To Remove This Book ?',
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {
                    $.ajax({

                        url: '/api/RemoveBook/?id=' + btn.data('id'),

                        method: 'DELETE',

                        success: function () {
                            btn.parentsUntil('.book').parent().fadeOut()
                        },
                        error: () => {
                            alert("Error !!!!!!!!!!!")
                        }

                    })

                }
            }
        });




    })

    
});


















