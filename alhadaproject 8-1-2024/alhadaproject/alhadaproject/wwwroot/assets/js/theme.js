
(function () {

    "use strict";
    var Core = {

        initialized: false,
        initialize: function () {

            if (this.initialized)
                return;
            this.initialized = true;
            this.build();
        },
        build: function () {

            // Scroll to Top Button.
            $.scrollToTop();
            // Owl Carousel
            this.owlCarousel();
            // dropdown menu
            this.dropdownhover();
            // Dropdown Menu mobile
            this.editDropdown();
            //flexslider
            this.flexslider();
            //choosenselect
            this.choosenselect();
            //masonrygrid
            this.masonrygrid();
            this.LoadEvents()

        },
        LoadEvents() {

        },

        owlCarousel: function (options) {

            var total = $("div.owl-carousel:not(.manual)").length,
                    count = 0;
            $("div.owl-carousel:not(.manual)").each(function () {

                var slider = $(this);
                var defaults = {
                    // Most important owl features
                    items: 4,
                    itemsCustom: false,
                    itemsDesktop: [1199, 2],
                    itemsDesktopSmall: [979, 1],
                    itemsTablet: [768, 2],
                    itemsTabletSmall: false,
                    itemsMobile: [479, 1],
                    singleItem: true,
                    itemsScaleUp: false,
                    //Basic Speeds
                    slideSpeed: 200,
                    paginationSpeed: 800,
                    rewindSpeed: 1000,
                    //Autoplay
                    autoPlay: false,
                    stopOnHover: false,
                    // Navigation
                    navigation: true,
                    navigationText: ["<i class=\"icons icon-left\"></i>", "<i class=\"icons icon-right\"></i>"],
                    rewindNav: true,
                    scrollPerPage: false,
                    //Pagination
                    pagination: true,
                    paginationNumbers: false,
                    // Responsive
                    responsive: true,
                    responsiveRefreshRate: 200,
                    responsiveBaseWidth: window,
                    // CSS Styles
                    baseClass: "owl-carousel",
                    theme: "owl-theme",
                    //Lazy load
                    lazyLoad: false,
                    lazyFollow: true,
                    lazyEffect: "fade",
                    //Auto height
                    autoHeight: false,
                    //JSON
                    jsonPath: false,
                    jsonSuccess: false,
                    //Mouse Events
                    dragBeforeAnimFinish: true,
                    mouseDrag: true,
                    touchDrag: true,
                    //Transitions
                    transitionStyle: false,
                    // Other
                    addClassActive: false,
                    //Callbacks
                    beforeUpdate: false,
                    afterUpdate: false,
                    beforeInit: false,
                    afterInit: false,
                    beforeMove: false,
                    afterMove: false,
                    afterAction: false,
                    startDragging: false,
                    afterLazyLoad: false
                }

                var config = $.extend({}, defaults, options, slider.data("plugin-options"));
                // Initialize Slider
                slider.owlCarousel(config).addClass("owl-carousel-init");
            });
        },
        dropdownhover: function (options) {

            /** Extra script for smoother navigation effect **/
            if ($(window).width() > 992) {
                $('.pgl-navbar-main .dropdown-toggle').addClass('disabled');
                $('.navbar .dropdown').hover(function () {
                    "use strict";
                    $(this).addClass('open').find('.dropdown-menu').first().stop(true, true).delay(250).slideDown();
                }, function () {
                    "use strict";
                    var na = $(this);
                    na.find('.dropdown-menu').first().stop(true, true).delay(100).slideUp('fast', function () {
                        na.removeClass('open');
                    });
                });
            } else
                return;
        },
        editDropdown: function () {

            if ($(window).width() < 1024) {
                $('.navbar-nav .dropdown').click(function () {
                    $(this).addClass('open').find('.dropdown-menu').first().stop(true, true).show();
                }, function () {
                    $(this).removeClass('open').find('.dropdown-menu').first().stop(true, true).hide();
                    $('.navbar-nav .dropdown > a').click(function () {
                        location.href = this.href;
                    });
                });
            }

        },
        flexslider: function (options) {
            // The slider being synced must be initialized first
            $('#carousel').flexslider({
                animation: "slide",
                controlNav: false,
                animationLoop: false,
                slideshow: false,
                itemWidth: 148,
                itemMargin: 10,
                asNavFor: '#slider'
            });
            $('#slider').flexslider({
                animation: "slide",
                controlNav: false,
                animationLoop: false,
                slideshow: false,
                sync: "#carousel"
            });
        },
        choosenselect: function (options) {

            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': {allow_single_deselect: true},
                '.chosen-select-no-single': {disable_search_threshold: 10},
                '.chosen-select-no-results': {no_results_text: 'Oops, nothing found!'},
                '.chosen-select-width': {width: "95%"}
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }

        },
        masonrygrid: function (options) {

            // Masonry for desktop
            if ($(window).width() < 361)
                return;
            var $container = $('.masonry-desk');
            // initialize

            $container.imagesLoaded(function () {
                $container.masonry();
            });
            var $items = document.querySelectorAll('.masonry-item');
            imagesLoaded($items, function () {
                $container.masonry({
                    itemSelector: '.masonry-item'
                });
            });
        }

    };
    Core.initialize();
    $(window).load(function () {


    });
})();
function preview_images(ev)
{
    var total_file = document.getElementById("images").files.length;
    for (var i = 0; i < total_file; i++)
    {
        if (jQuery('.img-responsive').length % 10 == 0) {
            jQuery('#image_preview').append("<div class='row'>");
        }
        var imagesLength = jQuery(".img-responsive").length;
        imagesLength;
        var src = URL.createObjectURL(event.target.files[i]);
        jQuery('#image_preview').append("<div class='col-md-1'><img class='img-responsive' src='" + src + "'><input type='hidden' value='" + src + "' name='image_path[" + imagesLength + "]'></div>");
    }
}

deletePreview = function (ele, i) {
    "use strict";
    try {
        $(ele).parent().remove();
        window.filesToUpload.splice(i, 1);
    } catch (e) {
        console.log(e.message);
    }
}

$("#imagesN").on('change', function () {
    "use strict";

    // create an empty array for the files to reside.
    window.filesToUpload = [];

    if (this.files.length >= 1) {
        $("[id^=previewImg]").remove();
        $.each(this.files, function (i, img) {
            var reader = new FileReader(),
                    newElement = $("<div id='previewImg" + i + "' class='previewBox'><img /></div>"),
                    deleteBtn = $("<span class='delete' onClick='deletePreview(this, " + i + ")'>X</span>").prependTo(newElement),
                    preview = newElement.find("img");

            reader.onloadend = function () {
                preview.attr("src", reader.result);
                preview.attr("alt", img.name);
            };

            try {
                window.filesToUpload.push(document.getElementById("file").files[i]);
            } catch (e) {
                console.log(e.message);
            }

            if (img) {
                reader.readAsDataURL(img);
            } else {
                preview.src = "";
            }

            newElement.appendTo("#filediv");
        });
    }
});

// get inbox count unread inbox count 
(function () {
    var get_inbox = function () {
        var inbox_element = document.getElementById('inbox');
        if (!inbox_element) {
            return;
        }
        onSuccess = function (data) {
            if (data <= '0') {
                return;
            }
            jQuery(inbox_element).addClass('activeInbox');
            jQuery('#bage').html(data);

            return;
        }
        onError = function (error) {
            console.log("Error ", error);
        }
        var url = window.base_url + "Setting/get_inbox_count";
        jQuery.get(url).then(onSuccess, onError);
    }
    var get_unapproved_list = function () {
        var element = document.getElementById('unapproved');
        if (!element) {
            return;
        }
        onSuccess = function (data) {
            if (data <= '0') {
                return;
            }
            jQuery(element).addClass('activeInbox');
            jQuery('#approve_bage').html(data);

            return;
        }
        onError = function (error) {
            console.log("Error ", error);
        }
        var url = window.base_url + "Setting/get_unapproved_count";
        jQuery.get(url).then(onSuccess, onError);
    }
    get_inbox();
    get_unapproved_list();


    this.addNewRecord = function () {
        if (!jQuery(".new_record")) {
            return;
        }
        var date = new Date();
        var month = date.getMonth();
        month++;

        var date_string = date.getFullYear() + "-" + month + "-" + date.getDate();
        var time_string = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
        var HTML = "<div class='row'>";

        HTML += "<div class='col-md-1 col-xs-6'><div class='form-group'>";
        HTML += "<input type='text' name='time' readonly value='" + time_string + "' class='form-control form-input'>";
        HTML += "</div></div>";

        HTML += "<div class='col-md-1 col-xs-6'><div class='form-group'>";
        HTML += "<input type='text' name='date' readonly value='" + date_string + "' class='form-control form-input'>";
        HTML += "</div></div>";

        HTML += "<div class='col-md-1 col-xs-6'><div class='checkbox'><label>";
        HTML += "<input type='radio' name='type' value='0' class=''> إتصال "; 
        HTML += "</label></div></div>";
        
        HTML += "<div class='col-md-1 col-xs-6'><div class='checkbox'><label>"; 
        HTML += "<input type='radio' name='type' value='1' class=''> زيارة ";
        HTML += "</label></div></div>";
        

        HTML += "<div class='col-md-8 col-xs-12'> <div class='form-group'>";
        HTML += "<input type='text'  value='' name='commenit' placeholder='أضف التفاصيل جديد ' class='form-control'>";
        HTML += "</div></div>";

        HTML += "<div class='col-md-2 col-xs-12 '> <div class='row pgl-narrow-row '>";
        HTML += "<input type='submit'  value=' حفظ التفاصيل' class='btn btn-block btn-primary margtop'>";
        HTML += "</div></div>";


        HTML += "</div>";
        jQuery(".new_record").html(HTML);
    }

    this.openCommenitBox = function () {
        jQuery('#new_comment_form').show('fast', function () {
            jQuery(".new_commenit").hide();
            jQuery(".hide_new_commenit").show();
            window.addNewRecord();
        });
    }
    this.hideCommenitBox = function () {
        jQuery('#new_comment_form').hide('fast', function () {
            jQuery(".new_record").html();
            jQuery(".new_commenit").show();
            jQuery(".hide_new_commenit").hide();
        });
    }

})()






