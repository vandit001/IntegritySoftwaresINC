(function($) {
	
	"use strict"
	
	
	
	/* - Portfolio Fit */
	function portfolio_fit() {
		if($(".portfolio-list").length) {
			var $container = $(".portfolio-list");
			$container.isotope({
				layoutMode: 'fitRows',
				percentPosition: true,				
				itemSelector: ".portfolio-box",
				gutter: 0
			});
			
			$("#filters a").on("click",function(){
				$('#filters a').removeClass("active");
				$(this).addClass("active");
				var selector = $(this).attr("data-filter");
				$container.isotope({ filter: selector });
				return false;
			});
		}
	}	
	
	/* + Document On Ready */
	$(document).ready(function() {
		/* - CaseStudy Slider */
        $('.homeslider-slider').owlCarousel({
            loop: true,			
			margin:0,
			autoplay: true,
			autoplayTimeout:20000,
			nav:false,
			dots: true,
			responsive:{
				0:{
					items:1
				},
				1920:{
					items:1
				}
			}
		}) 
		
		/*$('.carousel').carousel({
		  interval: 2000
		})*/
		
		
		/* - CaseStudy Slider */
		$('.carousel-testimony').owlCarousel({
			loop:true,			
            margin: 30,
            autoplay: true,
			autoplayTimeout:7000,
			nav:false,
			dots: true,
			responsive:{
				0:{
					items:1
				},
				768:{
					items:2
				},
				1024:{
					items:3
				}
			}
		})

		
		$(".switchbox .navbar-toggler").click(function(){
		  $("body").toggleClass("darkmode");
		});
		
		// Progress Bar Active Code
		if ($.fn.barfiller) {
			$('#bar1').barfiller({
				tooltip: true,
				duration: 1000,
				animateOnResize: true
			});
			$('#bar2').barfiller({
				tooltip: true,
				duration: 1000,
				animateOnResize: true
			});
			$('#bar3').barfiller({
				tooltip: true,
				duration: 1000,
				animateOnResize: true
			});
			$('#bar4').barfiller({
				tooltip: true,
				duration: 1000,
				animateOnResize: true
			});
		}
		
		
        $('#datetimepicker1').datetimepicker({
            format: 'DD-MM-YYYY hh:mm A'
        });
		
		portfolio_fit();
		
		/* - Portfolio Popup */
		if($(".portfolio-list .portfolio-box").length){
			var url;
			$(".portfolio-box .portfolio-detail").magnificPopup({
				delegate: " > a",
				type: "image",
				tLoading: "Loading image #%curr%...",
				mainClass: "mfp-img-mobile",
				gallery: {
					enabled: true,
					navigateByImgClick: false,
					preload: [0,1] // Will preload 0 - before current, and 1 after the current image
				},
				image: {
					tError: "<a href="%url%">The image #%curr%</a> could not be loaded.",				
				}
			});
		}

		
		 new WOW().init();
		
		
	});	/* - Document On Ready /- */	


	$( window ).scroll(function() {

		if ($(window).scrollTop() >= 50) {
			$('.header-block').addClass('menu-fixed');
		}
		else {
			$('.header-block').removeClass('menu-fixed');
		} 
		
		
		if ($(this).scrollTop() >= 200) {
            $('#back2top').fadeIn(200);
        } else {
            $('#back2top').fadeOut(200);
        }
		
	});
	
	$('#back2top').click(function () { $('body,html').animate({ scrollTop: 0 }, 500); });
	
	/* + Window On Load */
	$(window).on("load",function() {
		portfolio_fit();
		
    });
	
})(jQuery);