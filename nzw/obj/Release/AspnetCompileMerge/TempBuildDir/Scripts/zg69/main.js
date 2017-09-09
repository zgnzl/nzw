/**
 * Created by buwawa on 2016/7/19.
 */

/**
 * 所有js的入口 ready 表标页面上的dom与js载入完成
 */
$(document).ready(function () {
	// 导航菜单的下拉效果--------------------------------------------------
	$('.oe-page-header li.dropdown').mousemove(function () {
			$(this).find('ul').slideDown(200);
		})
		.mouseleave(function () {
			$(this).find('ul').slideUp(100);
		});
	// 导航菜单的下拉效果结束-----------------------------------------------

	$('.oe-introduce-btn').click(function (e) {
		$('.oe-introduce-box').addClass('open-introduce');
		$(document).one("click", function () {
			$('.oe-introduce-box').removeClass('open-introduce');
		});
		e.stopPropagation();
	});

	$('.oe-logo-view a').click(function (e) {


		$('.oe-introduce-logob .row').hide();
		$($('.oe-introduce-logob .row')[$(this).attr('rowIndex')]).show();

		$('.oe-introduce-logob').addClass('open-introduce');
		$(document).one("click", function () {
			$('.oe-introduce-logob').removeClass('open-introduce');
		});
		e.stopPropagation();
	});
	//$(document).one("click", function () {
	//	$('.oe-introduce-box').removeClass('open-introduce');
	//	e.stopPropagation();
	//});


	$('.oe-lspx-list a').click(function () {
		$(this).attr('url');

		$('.oe-technology-iframe .oe-iframe').attr({src: $(this).attr('url')});
	});

	//主页水平滚动banner--------------------------------------------------
	new Swiper('.oe-banner-area-style01', {
		loop: true,
		autoplay: 5000,

		// 如果需要分页器
		pagination: '.swiper-pagination',
		paginationClickable: true
	});
	//主页水平滚动banner结束-----------------------------------------------


	//最新活动------------------------------------------------------------
	var activityWrapper = new Swiper('.oe-activity-wrapper-container', {
		direction: 'vertical',
		wrapperClass: 'oe-activity-wrapper',
		slideClass: 'oe-index-item',
		onSlideChangeEnd: function (swiper) {
			var btns = $('.oe-activity-page-btn li');
			btns.removeClass('active');
			$(btns[swiper.activeIndex]).addClass('active');
		}
	});

	$('.oe-activity-page-btn li').mouseenter(function () {
		$('.oe-activity-page-btn li').removeClass('active');
		activityWrapper.slideTo($(this).index(), 1000, false);
		$(this).addClass('active');
	});
	//最新活动结束-------------------------------------------------------


	//原创tab-----------------------------------------------------------
	var yuanchuangWrapperTop = new Swiper('.oe-yuanchuang-container', {
		wrapperClass: 'oe-yuanchuang-wrapper',
		slideClass: 'oe-index-item',
		onSlideChangeEnd: function (swiper) {
			var btns = $('.oe-yuanchuang-btn li');
			btns.removeClass('active');
			$(btns[swiper.activeIndex]).addClass('active');
		}
	});

	$('.oe-yuanchuang-btn li').mouseenter(function () {
		$('.oe-yuanchuang-btn li').removeClass('active');
		yuanchuangWrapperTop.slideTo($(this).index(), 1000, false);
		$(this).addClass('active');
	});
	//原创tab结束-------------------------------------------------------
	//原创tab-----------------------------------------------------------
	var fenxiangWrapperTop = new Swiper('.oe-fenxiang-container', {
		wrapperClass: 'oe-fenxiang-wrapper',
		slideClass: 'oe-index-item',
		onSlideChangeEnd: function (swiper) {
			var btns = $('.oe-fenxiang-btn li');
			btns.removeClass('active');
			$(btns[swiper.activeIndex]).addClass('active');
		}
	});

	$('.oe-fenxiang-btn li').mouseenter(function () {
		$('.oe-fenxiang-btn li').removeClass('active');
		fenxiangWrapperTop.slideTo($(this).index(), 1000, false);
		$(this).addClass('active');
	});

	/*swiper bug 在一开始就不显示的元素里，swiper无法正确的起作用，所以一开始 让2个tab都可见
	 然后再隐藏第二个
	 */
	$('#index-tab-02').removeClass('active');
	//原创tab结束-------------------------------------------------------


	//内容区域的幻灯图---------------------------------------------------
	var contentWrapper = new Swiper('.oe-content-swiper', {
		slideClass: 'oe-banner-item',
		onSlideChangeEnd: function (swiper) {
			var btns = $('.oe-swiper-page-btn li');
			btns.removeClass('active');
			$(btns[swiper.activeIndex]).addClass('active');
		}
	});

	$('.oe-swiper-page-btn li').mouseenter(function () {
		$('.oe-swiper-page-btn li').removeClass('active');
		contentWrapper.slideTo($(this).index(), 1000, false);
		$(this).addClass('active');
	});
	//内容区域的幻灯图结束------------------------------------------------


	//幻灯区域上下3图文本------------------------------------------------
	new Swiper('.oe-banner-area-style03', {
		nextButton: '.swiper-button-next',
		prevButton: '.swiper-button-prev',
		paginationClickable: true,
		slidesPerView: 3,
		spaceBetween: 50,
		breakpoints: {
			950: {
				slidesPerView: 2,
				spaceBetween: 40
			},
			600: {
				slidesPerView: 1,
				spaceBetween: 10
			}
		}
	});
	//幻灯区域上下3图文本结束------------------------------------------------


	//产品二级banner-------------------------------------------------------
	new Swiper('.oe-banner-style02-container', {
		loop: true,
		autoplay: 5000,
		// 如果需要分页器
		pagination: '.swiper-pagination',
		paginationClickable: true
	});
	//产品二级banner结束---------------------------------------------------


	//核心产品快捷效果------------------------------------------------------
	$('.oe-product-shortcut .oe-box-item').mouseenter(function () {
			var me = this;
			$('.oe-product-shortcut .oe-box-item').removeClass('active');
			$(me).addClass('active');
			$(me).animate({'height': '340'}, 250);
		})
		.mouseleave(function () {
			$('.oe-product-shortcut .oe-box-item').stop();
			$('.oe-product-shortcut .oe-box-item').removeClass('active');
			$('.oe-product-shortcut .oe-box-item').height(208);
		});

	//核心产品快捷效果结束--------------------------------------------------


	new Swiper('.oe-banner-area-style06', {
		loop: true,
		pagination: '.swiper-pagination',
		paginationClickable: true
	});

	new Swiper('.oe-banner-area-style07', {
		loop: true,
		pagination: '.swiper-pagination',
		paginationClickable: true
	});

	new Swiper('.oe-programme-wrapper-01 .oe-programme-wrapper', {
		nextButton: '.oe-programme-wrapper-01 .swiper-button-next',
		prevButton: '.oe-programme-wrapper-01 .swiper-button-prev',
		paginationClickable: true,
		slidesPerView: 3,
		spaceBetween: 15,
		breakpoints: {
			950: {
				slidesPerView: 2,
				spaceBetween: 20
			},
			600: {
				slidesPerView: 1,
				spaceBetween: 10
			}
		}
	});
	new Swiper('.oe-programme-wrapper-02 .oe-programme-wrapper', {
		nextButton: '.oe-programme-wrapper-02 .swiper-button-next',
		prevButton: '.oe-programme-wrapper-02 .swiper-button-prev',
		paginationClickable: true,
		slidesPerView: 3,
		spaceBetween: 15,
		breakpoints: {
			950: {
				slidesPerView: 2,
				spaceBetween: 20
			},
			600: {
				slidesPerView: 1,
				spaceBetween: 10
			}
		}
	});
	new Swiper('.oe-programme-wrapper-03 .oe-programme-wrapper', {
		nextButton: '.oe-programme-wrapper-03 .swiper-button-next',
		prevButton: '.oe-programme-wrapper-03 .swiper-button-prev',
		paginationClickable: true,
		slidesPerView: 3,
		spaceBetween: 15,
		breakpoints: {
			950: {
				slidesPerView: 2,
				spaceBetween: 20
			},
			600: {
				slidesPerView: 1,
				spaceBetween: 10
			}
		}
	});
	new Swiper('.oe-programme-wrapper-04 .oe-programme-wrapper', {
		nextButton: '.oe-programme-wrapper-04 .swiper-button-next',
		prevButton: '.oe-programme-wrapper-04 .swiper-button-prev',
		paginationClickable: true,
		slidesPerView: 3,
		spaceBetween: 15,
		breakpoints: {
			950: {
				slidesPerView: 2,
				spaceBetween: 20
			},
			600: {
				slidesPerView: 1,
				spaceBetween: 10
			}
		}
	});
	new Swiper('.oe-programme-wrapper-05 .oe-programme-wrapper', {
		nextButton: '.oe-programme-wrapper-05 .swiper-button-next',
		prevButton: '.oe-programme-wrapper-05 .swiper-button-prev',
		paginationClickable: true,
		slidesPerView: 3,
		spaceBetween: 15,
		breakpoints: {
			950: {
				slidesPerView: 2,
				spaceBetween: 20
			},
			600: {
				slidesPerView: 1,
				spaceBetween: 10
			}
		}
	});
	new Swiper('.oe-programme-wrapper-06 .oe-programme-wrapper', {
		nextButton: '.oe-programme-wrapper-06 .swiper-button-next',
		prevButton: '.oe-programme-wrapper-06 .swiper-button-prev',
		paginationClickable: true,
		slidesPerView: 3,
		spaceBetween: 15,
		breakpoints: {
			950: {
				slidesPerView: 2,
				spaceBetween: 20
			},
			600: {
				slidesPerView: 1,
				spaceBetween: 10
			}
		}
	});
	new Swiper('.oe-programme-wrapper-07 .oe-programme-wrapper', {
		nextButton: '.oe-programme-wrapper-07 .swiper-button-next',
		prevButton: '.oe-programme-wrapper-07 .swiper-button-prev',
		paginationClickable: true,
		slidesPerView: 3,
		spaceBetween: 15,
		breakpoints: {
			950: {
				slidesPerView: 2,
				spaceBetween: 20
			},
			600: {
				slidesPerView: 1,
				spaceBetween: 10
			}
		}
	});
	new Swiper('.oe-programme-wrapper-08 .oe-programme-wrapper', {
		nextButton: '.oe-programme-wrapper-08 .swiper-button-next',
		prevButton: '.oe-programme-wrapper-08 .swiper-button-prev',
		paginationClickable: true,
		slidesPerView: 3,
		spaceBetween: 15,
		breakpoints: {
			950: {
				slidesPerView: 2,
				spaceBetween: 20
			},
			600: {
				slidesPerView: 1,
				spaceBetween: 10
			}
		}
	});
	new Swiper('.oe-programme-wrapper-09 .oe-programme-wrapper', {
		nextButton: '.oe-programme-wrapper-09 .swiper-button-next',
		prevButton: '.oe-programme-wrapper-09 .swiper-button-prev',
		paginationClickable: true,
		slidesPerView: 3,
		spaceBetween: 15,
		breakpoints: {
			950: {
				slidesPerView: 2,
				spaceBetween: 20
			},
			600: {
				slidesPerView: 1,
				spaceBetween: 10
			}
		}
	});
	new Swiper('.oe-programme-wrapper-10 .oe-programme-wrapper', {
			nextButton: '.oe-programme-wrapper-10 .swiper-button-next',
			prevButton: '.oe-programme-wrapper-10 .swiper-button-prev',
			paginationClickable: true,
			slidesPerView: 3,
			spaceBetween: 15,
			breakpoints: {
				950: {
					slidesPerView: 2,
					spaceBetween: 20
				},
				600: {
					slidesPerView: 1,
					spaceBetween: 10
				}
			}
		});
	new Swiper('.oe-programme-wrapper-11 .oe-programme-wrapper', {
		nextButton: '.oe-programme-wrapper-11 .swiper-button-next',
		prevButton: '.oe-programme-wrapper-11 .swiper-button-prev',
		paginationClickable: true,
		slidesPerView: 3,
		spaceBetween: 15,
		breakpoints: {
			950: {
				slidesPerView: 2,
				spaceBetween: 20
			},
			600: {
				slidesPerView: 1,
				spaceBetween: 10
			}
		}
	});
	//首页客服和技术服务客服 开始--------------------------------------------------


	$(function(){
    var $qqServer = $('.qqserver');
    var $qqserverFold = $('.qqserver_fold');
    var $qqserverUnfold = $('.qqserver_arrow');
    $qqserverFold.click(function(){
        $qqserverFold.hide();
        $qqServer.addClass('unfold');
    });
    $qqserverUnfold.click(function(){
        $qqServer.removeClass('unfold');
        $qqserverFold.show();
    });
    //窗体宽度小鱼1024像素时不显示客服QQ
    function resizeQQserver(){
        $qqServer[document.documentElement.clientWidth < 960 ? 'hide':'show']();
    }
    $(window).bind("load resize",function(){
        resizeQQserver();
    });
});


	//首页客服和技术服务客服 结束--------------------------------------------------
});