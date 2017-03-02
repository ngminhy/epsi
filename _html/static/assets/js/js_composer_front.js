document.documentElement.className += ' js_active ';
document.documentElement.className += 'ontouchstart' in document.documentElement ? ' parvez_mobile ' : ' parvez_desktop ';
(function () {
	var prefix = [
		'-webkit-',
		'-o-',
		'-moz-',
		'-ms-',
		""
	];
	for ( var i = 0; i < prefix.length; i++ ) {
		if ( prefix[ i ] + 'transform' in document.documentElement.style ) {
			document.documentElement.className += " parvez_transform ";
		}
	}
})();
/*
 On document ready jQuery will fire set of functions.
 If you want to override function behavior then copy it to your theme js file
 with the same name.
 */

jQuery( window ).load( function () {

} );
var parvez_js = function () {
	parvez_twitterBehaviour();
	parvez_toggleBehaviour();
	parvez_toggleBehaviourOld(); // todo remove on next release
	parvez_tabsBehaviour();
	parvez_accordionBehaviour();
	parvez_teaserGrid();
	parvez_carouselBehaviour();
	parvez_slidersBehaviour();
	parvez_prettyPhoto();
	parvez_googleplus();
	parvez_pinterest();
	parvez_progress_bar();
	parvez_plugin_flexslider();
	parvez_google_fonts();
	parvez_gridBehaviour();
	phm_rowBehaviour();
	parvez_ttaActivation(); // @since 4.5
	jQuery( document ).trigger( 'parvez_js' );
	window.setTimeout( parvez_waypoints, 1500 );
};
jQuery( document ).ready( function ( $ ) {
	window.parvez_js();
} ); // END jQuery(document).ready

if ( typeof window[ 'parvez_plugin_flexslider' ] !== 'function' ) {
	window.parvez_plugin_flexslider = function ( $parent ) {
		var $slider = $parent ? $parent.find( '.parvez_flexslider' ) : jQuery( '.parvez_flexslider' );
		$slider.each( function () {
			var this_element = jQuery( this );
			var sliderSpeed = 800,
				sliderTimeout = parseInt( this_element.attr( 'data-interval' ) ) * 1000,
				sliderFx = this_element.attr( 'data-flex_fx' ),
				slideshow = true;
			if ( sliderTimeout == 0 ) {
				slideshow = false;
			}

			this_element.is( ':visible' ) && this_element.flexslider( {
				animation: sliderFx,
				slideshow: slideshow,
				slideshowSpeed: sliderTimeout,
				sliderSpeed: sliderSpeed,
				smoothHeight: true
			} );
		} );
	};
}

/* Twitter
 ---------------------------------------------------------- */
if ( typeof window[ 'parvez_twitterBehaviour' ] !== 'function' ) {
	window.parvez_twitterBehaviour = function () {
		jQuery( '.parvez_twitter_widget .tweets' ).each( function ( index ) {
			var this_element = jQuery( this ),
				tw_name = this_element.attr( 'data-tw_name' ),
				tw_count = this_element.attr( 'data-tw_count' );

			this_element.tweet( {
				username: tw_name,
				join_text: "auto",
				avatar_size: 0,
				count: tw_count,
				template: "{avatar}{join}{text}{time}",
				auto_join_text_default: "",
				auto_join_text_ed: "",
				auto_join_text_ing: "",
				auto_join_text_reply: "",
				auto_join_text_url: "",
				loading_text: '<span class="loading_tweets">loading tweets...</span>'
			} );
		} );
	};
}

/* Google plus
 ---------------------------------------------------------- */
if ( typeof window[ 'parvez_googleplus' ] !== 'function' ) {
	window.parvez_googleplus = function () {
		if ( jQuery( '.parvez_googleplus' ).length > 0 ) {
			(function () {
				var po = document.createElement( 'script' );
				po.type = 'text/javascript';
				po.async = true;
				po.src = 'https://apis.google.com/js/plusone.js';
				var s = document.getElementsByTagName( 'script' )[ 0 ];
				s.parentNode.insertBefore( po, s );
			})();
		}
	}
}

/* Pinterest
 ---------------------------------------------------------- */
if ( typeof window[ 'parvez_pinterest' ] !== 'function' ) {
	window.parvez_pinterest = function () {
		if ( jQuery( '.parvez_pinterest' ).length > 0 ) {
			(function () {
				var po = document.createElement( 'script' );
				po.type = 'text/javascript';
				po.async = true;
				po.src = 'http://assets.pinterest.com/js/pinit.js';
				var s = document.getElementsByTagName( 'script' )[ 0 ];
				s.parentNode.insertBefore( po, s );
				//<script type="text/javascript" src="//assets.pinterest.com/js/pinit.js"></script>
			})();
		}
	}
}

/* Progress bar
 ---------------------------------------------------------- */
if ( typeof window[ 'parvez_progress_bar' ] !== 'function' ) {
	window.parvez_progress_bar = function () {
		if ( typeof jQuery.fn.waypoint !== 'undefined' ) {

			jQuery( '.parvez_progress_bar' ).waypoint( function () {
				jQuery( this ).find( '.parvez_single_bar' ).each( function ( index ) {
					var $this = jQuery( this ),
						bar = $this.find( '.parvez_bar' ),
						val = bar.data( 'percentage-value' );

					setTimeout( function () {
						bar.css( { "width": val + '%' } );
					}, index * 200 );
				} );
			}, { offset: '85%' } );
		}
	}
}

/* Waypoints magic
 ---------------------------------------------------------- */
if ( typeof window[ 'parvez_waypoints' ] !== 'function' ) {
	window.parvez_waypoints = function () {
		if ( typeof jQuery.fn.waypoint !== 'undefined' ) {
			jQuery( '.parvez_animate_when_almost_visible:not(.parvez_start_animation)' ).waypoint( function () {
				jQuery( this ).addClass( 'parvez_start_animation' );
			}, { offset: '85%' } );
		}
	}
}

/* Toggle
 * @deprecated since 4.4
 ---------------------------------------------------------- */
// @todo remove on next release
if ( typeof window[ 'parvez_toggleBehaviourOld' ] !== 'function' ) {
	/**
	 * @deprecated will be removed in next release
	 */
	window.parvez_toggleBehaviourOld = function () {
		jQuery( ".parvez_toggle" ).unbind( 'click' ).click( function ( e ) {
			if ( jQuery( this ).next().is( ':animated' ) ) {
				return false;
			}
			if ( jQuery( this ).hasClass( 'parvez_toggle_title_active' ) ) {
				jQuery( this ).removeClass( 'parvez_toggle_title_active' ).next().slideUp( 500 );
			} else {
				jQuery( this ).addClass( 'parvez_toggle_title_active' ).next().slideDown( 500 );
			}
		} );
		jQuery( '.parvez_toggle_content' ).each( function ( index ) {
			if ( jQuery( this ).next().is( 'h4.parvez_toggle' ) == false ) {
				jQuery( '<div class="last_toggle_el_margin"></div>' ).insertAfter( this );
			}
		} );
	}
}

/* Toggle/FAQ
 ---------------------------------------------------------- */
if ( typeof window[ 'parvez_toggleBehaviour' ] !== 'function' ) {
	window.parvez_toggleBehaviour = function ( $el ) {
		var event = function ( e ) {
			e && e.preventDefault && e.preventDefault();
			var title = jQuery( this );
			var element = title.closest( '.parvez_toggle' );
			var content = element.find( '.parvez_toggle_content' );
			if ( element.hasClass( 'parvez_toggle_active' ) ) {
				content.slideUp( {
					duration: 300,
					complete: function () {
						element.removeClass( 'parvez_toggle_active' );
					}
				} );
			} else {
				content.slideDown( {
					duration: 300,
					complete: function () {
						element.addClass( 'parvez_toggle_active' );
					}
				} );
			}
		};
		if ( $el ) {
			if ( $el.hasClass( 'parvez_toggle_title' ) ) {
				$el.unbind( 'click' ).click( event );
			} else {
				$el.find( ".parvez_toggle_title" ).unbind( 'click' ).click( event );
			}
		} else {
			jQuery( ".parvez_toggle_title" ).unbind( 'click' ).on( 'click', event );
		}
	}
}

/* Tabs + Tours
 ---------------------------------------------------------- */
if ( typeof window[ 'parvez_tabsBehaviour' ] !== 'function' ) {
	window.parvez_tabsBehaviour = function ( $tab ) {
		if ( jQuery.ui ) {
			/* jQuery(function ($) {
			 $(document.body).off('click.preview', 'a')
			 }); */ // this causes wp-customizer bug
			var $call = $tab || jQuery( '.parvez_tabs, .parvez_tour' ),
				ver = jQuery.ui && jQuery.ui.version ? jQuery.ui.version.split( '.' ) : '1.10',
				old_version = parseInt( ver[ 0 ] ) == 1 && parseInt( ver[ 1 ] ) < 9;
			// if($call.hasClass('ui-widget')) $call.tabs('destroy');
			$call.each( function ( index ) {
				var $tabs,
					interval = jQuery( this ).attr( "data-interval" ),
					tabs_array = [];
				//
				$tabs = jQuery( this ).find( '.parvez_tour_tabs_wrapper' ).tabs( {
					show: function ( event, ui ) {
						parvez_prepare_tab_content( event, ui );
					},
					beforeActivate: function ( event, ui ) {
						ui.newPanel.index() !== 1 && ui.newPanel.find( '.parvez_pie_chart:not(.parvez_ready)' );
					},
					activate: function ( event, ui ) {
						parvez_prepare_tab_content( event, ui );
					}
				} );
				if ( interval && interval > 0 ) {
					try {
						$tabs.tabs( 'rotate', interval * 1000 );
					} catch ( e ) {
						// nothing.
						window.console && window.console.log && console.log( e );
					}
				}

				jQuery( this ).find( '.parvez_tab' ).each( function () {
					tabs_array.push( this.id );
				} );

				jQuery( this ).find( '.parvez_tabs_nav li' ).click( function ( e ) {
					e.preventDefault();
					/*if (jQuery.inArray(jQuery(this).attr('href'), tabs_array)) {
					 if (old_version) {
					 $tabs.tabs("select", jQuery(this).attr('href'));
					 } else {
					 $tabs.tabs("option", "active", jQuery(jQuery(this).attr('href')).index() - 1);
					 }
					 return false;
					 }*/
					if ( old_version ) {
						$tabs.tabs( "select", jQuery( 'a', this ).attr( 'href' ) );
					} else {
						$tabs.tabs( "option", "active", jQuery( this ).index() );
					}
					return false;
				} );

				jQuery( this ).find( '.parvez_prev_slide a, .parvez_next_slide a' ).click( function ( e ) {
					e.preventDefault();
					if ( old_version ) {
						var index = $tabs.tabs( 'option', 'selected' );
						if ( jQuery( this ).parent().hasClass( 'parvez_next_slide' ) ) {
							index ++;
						}
						else {
							index --;
						}
						if ( index < 0 ) {
							index = $tabs.tabs( "length" ) - 1;
						}
						else if ( index >= $tabs.tabs( "length" ) ) {
							index = 0;
						}
						$tabs.tabs( "select", index );
					} else {
						var index = $tabs.tabs( "option", "active" ),
							length = $tabs.find( '.parvez_tab' ).length;

						if ( jQuery( this ).parent().hasClass( 'parvez_next_slide' ) ) {
							index = (index + 1) >= length ? 0 : index + 1;
						} else {
							index = index - 1 < 0 ? length - 1 : index - 1;
						}

						$tabs.tabs( "option", "active", index );
					}

				} );

			} );
		}
	}
}
;

/* Tabs + Tours
 ---------------------------------------------------------- */
if ( typeof window[ 'parvez_accordionBehaviour' ] !== 'function' ) {
	window.parvez_accordionBehaviour = function () {
		jQuery( '.parvez_accordion' ).each( function ( index ) {
			var $this = jQuery( this );
			var $tabs,
				interval = $this.attr( "data-interval" ),
				active_tab = ! isNaN( jQuery( this ).data( 'active-tab' ) ) && parseInt( $this.data( 'active-tab' ) ) > 0 ? parseInt( $this.data( 'active-tab' ) ) - 1 : false,
				collapsible = active_tab === false || $this.data( 'collapsible' ) === 'yes';
			//
			$tabs = $this.find( '.parvez_accordion_wrapper' ).accordion( {
				header: "> div > h3",
				autoHeight: false,
				heightStyle: "content",
				active: active_tab,
				collapsible: collapsible,
				navigation: true,

				activate: parvez_accordionActivate,
				change: function ( event, ui ) {
					if ( jQuery.fn.isotope != undefined ) {
						ui.newContent.find( '.isotope' ).isotope( "layout" );
					}
					parvez_carouselBehaviour( ui.newPanel );
				}
			} );
			if ( true === $this.data( 'vcDisableKeydown' ) ) {
				$tabs.data( 'uiAccordion' )._keydown = function () {
				};
			}
			//.tabs().tabs('rotate', interval*1000, true);
		} );
	}
}

/* Teaser grid: isotope
 ---------------------------------------------------------- */
if ( typeof window[ 'parvez_teaserGrid' ] !== 'function' ) {
	window.parvez_teaserGrid = function () {
		var layout_modes = {
			fitrows: 'fitRows',
			masonry: 'masonry'
		};
		jQuery( '.parvez_grid .teaser_grid_container:not(.parvez_carousel), .parvez_filtered_grid .teaser_grid_container:not(.parvez_carousel)' ).each( function () {
			var $container = jQuery( this );
			var $thumbs = $container.find( '.parvez_thumbnails' );
			var layout_mode = $thumbs.attr( 'data-layout-mode' );
			$thumbs.isotope( {
				// options
				itemSelector: '.isotope-item',
				layoutMode: (layout_modes[ layout_mode ] == undefined ? 'fitRows' : layout_modes[ layout_mode ])
			} );
			$container.find( '.categories_filter a' ).data( 'isotope', $thumbs ).click( function ( e ) {
				e.preventDefault();
				var $thumbs = jQuery( this ).data( 'isotope' );
				jQuery( this ).parent().parent().find( '.active' ).removeClass( 'active' );
				jQuery( this ).parent().addClass( 'active' );
				$thumbs.isotope( { filter: jQuery( this ).attr( 'data-filter' ) } );
			} );
			jQuery( window ).bind( 'load resize', function () {
				$thumbs.isotope( "layout" );
			} );
		} );

		/*
		 var isotope = jQuery('.parvez_grid ul.thumbnails');
		 if ( isotope.length > 0 ) {
		 isotope.isotope({
		 // options
		 itemSelector : '.isotope-item',
		 layoutMode : 'fitRows'
		 });
		 jQuery(window).load(function() {
		 isotope.isotope("layout");
		 });
		 }
		 */
	}
}

if ( typeof window[ 'parvez_carouselBehaviour' ] !== 'function' ) {
	window.parvez_carouselBehaviour = function ( $parent ) {
		var $carousel = $parent ? $parent.find( ".parvez_carousel" ) : jQuery( ".parvez_carousel" );
		$carousel.each( function () {
			var $this = jQuery( this );
			if ( $this.data( 'carousel_enabled' ) !== true && $this.is( ':visible' ) ) {
				$this.data( 'carousel_enabled', true );
				var carousel_width = jQuery( this ).width(),
					visible_count = getColumnsCount( jQuery( this ) ),
					carousel_speed = 500;
				if ( jQuery( this ).hasClass( 'columns_count_1' ) ) {
					carousel_speed = 900;
				}
				/* Get margin-left value from the css grid and apply it to the carousele li items (margin-right), before carousele initialization */
				var carousele_li = jQuery( this ).find( '.parvez_thumbnails-fluid li' );
				carousele_li.css( { "margin-right": carousele_li.css( "margin-left" ), "margin-left": 0 } );

				jQuery( this ).find( '.parvez_wrapper:eq(0)' ).jCarouselLite( {
					btnNext: jQuery( this ).find( '.next' ),
					btnPrev: jQuery( this ).find( '.prev' ),
					visible: visible_count,
					speed: carousel_speed
				} )
					.width( '100%' );//carousel_width

				var fluid_ul = jQuery( this ).find( 'ul.parvez_thumbnails-fluid' );
				fluid_ul.width( fluid_ul.width() + 300 );

				jQuery( window ).resize( function () {
					var before_resize = screen_size;
					screen_size = getSizeName();
					if ( before_resize != screen_size ) {
						window.setTimeout( 'location.reload()', 20 );
					}
				} );
			}

		} );
	}
}

if ( typeof window[ 'parvez_slidersBehaviour' ] !== 'function' ) {
	window.parvez_slidersBehaviour = function () {
		//var sliders_count = 0;
		jQuery( '.parvez_gallery_slides' ).each( function ( index ) {
			var this_element = jQuery( this );
			var ss_count = 0, $imagesGrid;

			/*if ( this_element.hasClass('parvez_slider_fading') ) {
			 var sliderSpeed = 500, sliderTimeout = this_element.attr('data-interval')*1000, slider_fx = 'fade';
			 var current_ss;

			 function slideshowOnBefore(currSlideElement, nextSlideElement, options) {
			 jQuery(nextSlideElement).css({"position" : "absolute" });
			 jQuery(nextSlideElement).find("div.description").animate({"opacity": 0}, 0);
			 }

			 function slideshowOnAfter(currSlideElement, nextSlideElement, options) {
			 jQuery(nextSlideElement).find("div.description").animate({"opacity": 1}, 2000);

			 jQuery(nextSlideElement).css({"position" : "static" });
			 var new_h = jQuery(nextSlideElement).find('img').height();
			 if ( jQuery.isNumeric(new_h) ) {
			 //this_element.animate({ "height" : new_h }, sliderSpeed );
			 }
			 }

			 this_element.find('ul')
			 .before('<div class="ss_nav ss_nav_'+ss_count+'"></div><div class="parvez_fading_nav"><a id="next_'+ss_count+'" href="#next"></a> <a id="prev_'+ss_count+'" href="#prev"></a></div>')
			 .cycle({
			 fx: slider_fx, // choose your transition type, ex: fade, scrollUp, shuffle, etc...
			 pause: 1,
			 speed: sliderSpeed,
			 timeout: sliderTimeout,
			 delay: -ss_count * 1000,
			 before: slideshowOnBefore,
			 after:slideshowOnAfter,
			 pager:  '.ss_nav_'+ss_count
			 });
			 //.find('.description').width(jQuery(this).width() - 20);
			 ss_count++;
			 }
			 else*/
			if ( this_element.hasClass( 'parvez_slider_nivo' ) ) {
				var sliderSpeed = 800,
					sliderTimeout = this_element.attr( 'data-interval' ) * 1000;

				if ( sliderTimeout == 0 ) {
					sliderTimeout = 9999999999;
				}

				this_element.find( '.nivoSlider' ).nivoSlider( {
					effect: 'boxRainGrow,boxRain,boxRainReverse,boxRainGrowReverse', // Specify sets like: 'fold,fade,sliceDown'
					slices: 15, // For slice animations
					boxCols: 8, // For box animations
					boxRows: 4, // For box animations
					animSpeed: sliderSpeed, // Slide transition speed
					pauseTime: sliderTimeout, // How long each slide will show
					startSlide: 0, // Set starting Slide (0 index)
					directionNav: true, // Next & Prev navigation
					directionNavHide: true, // Only show on hover
					controlNav: true, // 1,2,3... navigation
					keyboardNav: false, // Use left & right arrows
					pauseOnHover: true, // Stop animation while hovering
					manualAdvance: false, // Force manual transitions
					prevText: 'Prev', // Prev directionNav text
					nextText: 'Next' // Next directionNav text
				} );
			}
			else if ( this_element.hasClass( 'parvez_image_grid' ) ) {
				if ( jQuery.fn.imagesLoaded ) {
					$imagesGrid = this_element.find( '.parvez_image_grid_ul' ).imagesLoaded( function () {
						$imagesGrid.isotope( {
							// options
							itemSelector: '.isotope-item',
							layoutMode: 'fitRows'
						} );
					} );
				} else {
					this_element.find( '.parvez_image_grid_ul' ).isotope( {
						// options
						itemSelector: '.isotope-item',
						layoutMode: 'fitRows'
					} );
				}

			}
		} );
	}
}
if ( typeof window[ 'parvez_prettyPhoto' ] !== 'function' ) {
	window.parvez_prettyPhoto = function () {
		try {
			// just in case. maybe prettyphoto isnt loaded on this site
			if ( jQuery && jQuery.fn && jQuery.fn.prettyPhoto ) {
				jQuery( 'a.prettyphoto, .gallery-icon a[href*=".jpg"]' ).prettyPhoto( {
					animationSpeed: 'normal', /* fast/slow/normal */
					padding: 15, /* padding for each side of the picture */
					opacity: 0.7, /* Value betwee 0 and 1 */
					showTitle: true, /* true/false */
					allowresize: true, /* true/false */
					counter_separator_label: '/', /* The separator for the gallery counter 1 "of" 2 */
					//theme: 'light_square', /* light_rounded / dark_rounded / light_square / dark_square */
					hideflash: false, /* Hides all the flash object on a page, set to TRUE if flash appears over prettyPhoto */
					deeplinking: false, /* Allow prettyPhoto to update the url to enable deeplinking. */
					modal: false, /* If set to true, only the close button will close the window */
					callback: function () {
						var url = location.href;
						var hashtag = (url.indexOf( '#!prettyPhoto' )) ? true : false;
						if ( hashtag ) {
							location.hash = "!";
						}
					} /* Called when prettyPhoto is closed */,
					social_tools: ''
				} );
			}
		} catch ( err ) {
			window.console && window.console.log && console.log( err );
		}
	}
}

if ( typeof window[ 'parvez_google_fonts' ] !== 'function' ) {
	window.parvez_google_fonts = function () {
		return false; // @todo check this for what this is needed
	}
}
window.vcParallaxSkroll = false;
if ( typeof window[ 'phm_rowBehaviour' ] !== 'function' ) {
	window.phm_rowBehaviour = function () {
		var $ = window.jQuery;
		var local_function = function () {
			var $elements = $( '[data-vc-full-width="true"]' );
			$.each( $elements, function ( key, item ) {
				var $el = $( this );
				var $el_full = $el.next( '.phm_row-full-width' );
				var el_margin_left = parseInt( $el.css( 'margin-left' ), 10 );
				var el_margin_right = parseInt( $el.css( 'margin-right' ), 10 );
				var offset = 0 - $el_full.offset().left - el_margin_left;
				var width = $( window ).width();
				$el.css( {
					'position': 'relative',
					'left': offset,
					'box-sizing': 'border-box',
					'width': $( window ).width()
				} );
				if ( ! $el.data( 'vcStretchContent' ) ) {
					var padding = (- 1 * offset);
					if ( padding < 0 ) {
						padding = 0;
					}
					var paddingRight = width - padding - $el_full.width() + el_margin_left + el_margin_right;
					if ( paddingRight < 0 ) {
						paddingRight = 0;
					}
					$el.css( { 'padding-left': padding + 'px', 'padding-right': paddingRight + 'px' } );
				}
				$el.attr( "data-vc-full-width-init", "true" );
			} );
		};
		/**
		 * @todo refactor as plugin.
		 * @returns {*}
		 */
		var parallaxRow = function () {
			var vcSkrollrOptions,
				callSkrollInit = false;
			if ( vcParallaxSkroll ) {
				vcParallaxSkroll.destroy();
			}
			$( '.parvez_parallax-inner' ).remove();
			$( '[data-5p-top-bottom]' ).removeAttr( 'data-5p-top-bottom data-30p-top-bottom' );
			$( '[data-vc-parallax]' ).each( function () {
				var skrollrSpeed,
					skrollrSize,
					skrollrStart,
					skrollrEnd,
					$parallaxElement,
					parallaxImage,
					youtubeId;
				callSkrollInit = true; // Enable skrollinit;
				if ( $( this ).data( 'vcParallaxOFade' ) == 'on' ) {
					$( this ).children().attr( 'data-5p-top-bottom', 'opacity:0;' ).attr( 'data-30p-top-bottom',
						'opacity:1;' );
				}

				skrollrSize = $( this ).data( 'vcParallax' ) * 100;
				$parallaxElement = $( '<div />' ).addClass( 'parvez_parallax-inner' ).appendTo( $( this ) );
				$parallaxElement.height( skrollrSize + '%' );

				parallaxImage = $( this ).data( 'vcParallaxImage' );

				youtubeId = vcExtractYoutubeId( parallaxImage );

				if ( youtubeId ) {
					insertYoutubeVideoAsBackground( $parallaxElement, youtubeId );
				} else if ( parallaxImage !== undefined ) {
					$parallaxElement.css( 'background-image', 'url(' + parallaxImage + ')' );
				}

				skrollrSpeed = skrollrSize - 100;
				skrollrStart = - skrollrSpeed;
				skrollrEnd = 0;

				$parallaxElement.attr( 'data-bottom-top', 'top: ' + skrollrStart + '%;' ).attr( 'data-top-bottom',
					'top: ' + skrollrEnd + '%;' );
			} );

			if ( callSkrollInit && window.skrollr ) {
				vcSkrollrOptions = {
					forceHeight: false,
					smoothScrolling: false,
					mobileCheck: function () {
						return false;
					}
				};
				vcParallaxSkroll = skrollr.init( vcSkrollrOptions );
				return vcParallaxSkroll;
			}
			return false;
		};
		/**
		 * @todo refactor as plugin.
		 * @returns {*}
		 */
		var fullHeightRow = function () {
			$( '.phm_row-o-full-height:first' ).each( function () {
				var $window,
					windowHeight,
					offsetTop,
					fullHeight;
				$window = $( window );
				windowHeight = $window.height();
				offsetTop = $( this ).offset().top;
				if ( offsetTop < windowHeight ) {
					fullHeight = 100 - offsetTop / (windowHeight / 100);
					$( this ).css( 'min-height', fullHeight + 'vh' );
				}
			} );
		};
		$( window ).unbind( 'resize.vcRowBehaviour' ).bind( 'resize.vcRowBehaviour', local_function );
		$( window ).bind( 'resize.vcRowBehaviour', fullHeightRow );
		local_function();
		fullHeightRow();
		initVideoBackgrounds(); // must be called before parallax
		parallaxRow();
	}
}

if ( typeof window[ 'parvez_gridBehaviour' ] !== 'function' ) {
	window.parvez_gridBehaviour = function () {
		jQuery.fn.vcGrid && jQuery( '[data-vc-grid]' ).vcGrid();
	}
}
/* Helper
 ---------------------------------------------------------- */
if ( typeof window[ 'getColumnsCount' ] !== 'function' ) {
	window.getColumnsCount = function ( el ) {
		var find = false,
			i = 1;

		while ( find == false ) {
			if ( el.hasClass( 'columns_count_' + i ) ) {
				find = true;
				return i;
			}
			i ++;
		}
	}
}

var screen_size = getSizeName();
function getSizeName() {
	var screen_size = '',
		screen_w = jQuery( window ).width();

	if ( screen_w > 1170 ) {
		screen_size = "desktop_wide";
	}
	else if ( screen_w > 960 && screen_w < 1169 ) {
		screen_size = "desktop";
	}
	else if ( screen_w > 768 && screen_w < 959 ) {
		screen_size = "tablet";
	}
	else if ( screen_w > 300 && screen_w < 767 ) {
		screen_size = "mobile";
	}
	else if ( screen_w < 300 ) {
		screen_size = "mobile_portrait";
	}
	return screen_size;
}

function loadScript( url, $obj, callback ) {

	var script = document.createElement( "script" );
	script.type = "text/javascript";

	if ( script.readyState ) {  //IE
		script.onreadystatechange = function () {
			if ( script.readyState == "loaded" ||
				script.readyState == "complete" ) {
				script.onreadystatechange = null;
				callback();
			}
		};
	} else {  //Others
		/*
		 script.onload = function(){

		 callback();
		 };
		 */
	}

	script.src = url;
	$obj.get( 0 ).appendChild( script );
}

if ( typeof window[ 'parvez_prepare_tab_content' ] !== 'function' ) {
	/**
	 * Prepare html to correctly display inside tab container
	 *
	 * @param event - ui tab event 'show'
	 * @param ui - jquery ui tabs object
	 */
	window.parvez_prepare_tab_content = function ( event, ui ) {
		var panel = ui.panel || ui.newPanel,
			$pie_charts = panel.find( '.parvez_pie_chart:not(.parvez_ready)' ),
			$round_charts = panel.find( '.parvez_round-chart' ),
			$line_charts = panel.find( '.parvez_line-chart' ),
			$carousel = panel.find( '[data-ride="parvez_carousel"]' ),
			$ui_panel, $google_maps;
		parvez_carouselBehaviour();
		parvez_plugin_flexslider( panel );
		if ( ui.newPanel.find( '.parvez_masonry_media_grid, .parvez_masonry_grid' ).length ) {
			ui.newPanel.find( '.parvez_masonry_media_grid, .parvez_masonry_grid' ).each( function () {
				var grid = jQuery( this ).data( 'vcGrid' );
				grid && grid.gridBuilder && grid.gridBuilder.setMasonry && grid.gridBuilder.setMasonry();
			} );
		}
		if ( panel.find( '.parvez_masonry_media_grid, .parvez_masonry_grid' ).length ) {
			panel.find( '.parvez_masonry_media_grid, .parvez_masonry_grid' ).each( function () {
				var grid = jQuery( this ).data( 'vcGrid' );
				grid && grid.gridBuilder && grid.gridBuilder.setMasonry && grid.gridBuilder.setMasonry();
			} );
		}
		$pie_charts.length && jQuery.fn.vcChat && $pie_charts.vcChat();
		$round_charts.length && jQuery.fn.vcRoundChart && $round_charts.vcRoundChart( { reload: false } );
		$line_charts.length && jQuery.fn.vcLineChart && $line_charts.vcLineChart( { reload: false } );
		$carousel.length && jQuery.fn.carousel && $carousel.carousel( 'resizeAction' );
		$ui_panel = panel.find( '.isotope, .parvez_image_grid_ul' ); // why var name '$ui_panel'?
		$google_maps = panel.find( '.parvez_gmaps_widget' );
		if ( $ui_panel.length > 0 ) {
			$ui_panel.isotope( "layout" );
		}
		if ( $google_maps.length && ! $google_maps.is( '.map_ready' ) ) {
			var $frame = $google_maps.find( 'iframe' );
			$frame.attr( 'src', $frame.attr( 'src' ) );
			$google_maps.addClass( 'map_ready' );
		}
		if ( panel.parents( '.isotope' ).length ) {
			panel.parents( '.isotope' ).each( function () {
				jQuery( this ).isotope( "layout" );
			} );
		}
	}
}
var parvez_ttaActivation = function () {
	jQuery( '[data-vc-accordion]' ).on( 'show.vc.accordion', function ( e ) {
		var $ = window.jQuery, ui = {};
		ui.newPanel = $( this ).data( 'vc.accordion' ).getTarget();
		window.parvez_prepare_tab_content( e, ui );
	} );
};

var parvez_accordionActivate = function ( event, ui ) {
	if ( ui.newPanel.length && ui.newHeader.length ) {
		var $pie_charts = ui.newPanel.find( '.parvez_pie_chart:not(.parvez_ready)' ),
			$round_charts = ui.newPanel.find( '.parvez_round-chart' ),
			$line_charts = ui.newPanel.find( '.parvez_line-chart' ),
			$carousel = ui.newPanel.find( '[data-ride="parvez_carousel"]' );
		if ( jQuery.fn.isotope != undefined ) {
			ui.newPanel.find( '.isotope, .parvez_image_grid_ul' ).isotope( "layout" );
		}
		if ( ui.newPanel.find( '.parvez_masonry_media_grid, .parvez_masonry_grid' ).length ) {
			ui.newPanel.find( '.parvez_masonry_media_grid, .parvez_masonry_grid' ).each( function () {
				var grid = jQuery( this ).data( 'vcGrid' );
				grid && grid.gridBuilder && grid.gridBuilder.setMasonry && grid.gridBuilder.setMasonry();
			} );
		}
		//jQuery('html, body').animate({scrollTop: ui.newHeader.offset().top - 100}, 1000); // #1370 enhancement, #1762 issue.
		parvez_carouselBehaviour( ui.newPanel );
		parvez_plugin_flexslider( ui.newPanel );
		$pie_charts.length && jQuery.fn.vcChat && $pie_charts.vcChat();
		$round_charts.length && jQuery.fn.vcRoundChart && $round_charts.vcRoundChart( { reload: false } );
		$line_charts.length && jQuery.fn.vcLineChart && $line_charts.vcLineChart( { reload: false } );
		$carousel.length && jQuery.fn.carousel && $carousel.carousel( 'resizeAction' );
		if ( ui.newPanel.parents( '.isotope' ).length ) {
			ui.newPanel.parents( '.isotope' ).each( function () {
				jQuery( this ).isotope( "layout" );
			} );
		}
	}
};

/**
 * Reinitialize all video backgrounds
 */
function initVideoBackgrounds() {
	jQuery( '.phm_row' ).each( function () {
		var $row = jQuery( this ),
			youtubeUrl,
			youtubeId;

		if ( $row.data( 'vcVideoBg' ) ) {
			youtubeUrl = $row.data( 'vcVideoBg' );
			youtubeId = vcExtractYoutubeId( youtubeUrl );

			if ( youtubeId ) {
				$row.find( '.parvez_video-bg' ).remove();
				insertYoutubeVideoAsBackground( $row, youtubeId );
			}

			jQuery( window ).on( 'grid:items:added', function ( event, $grid ) {
				if ( ! $row.has( $grid ).length ) {
					return;
				}

				vcResizeVideoBackground( $row );
			} );
		} else {
			$row.find( '.parvez_video-bg' ).remove();
		}
	} );
}

/**
 * Insert youtube video into element.
 *
 * Video will be w/o controls, muted, autoplaying and looping.
 */
function insertYoutubeVideoAsBackground( $element, youtubeId, counter ) {
	if ( 'undefined' === typeof( YT.Player ) ) {
		// wait for youtube iframe api to load. try for 10sec, then abort
		counter = 'undefined' === typeof( counter ) ? 0 : counter;
		if ( counter > 100 ) {
			console.warn( 'Too many attempts to load YouTube api' );
			return;
		}

		setTimeout( function () {
			insertYoutubeVideoAsBackground( $element, youtubeId, counter ++ );
		}, 100 );

		return;
	}

	var player,
		$container = $element.prepend( '<div class="parvez_video-bg"><div class="inner"></div></div>' ).find( '.inner' );

	player = new YT.Player( $container[ 0 ], {
		width: '100%',
		height: '100%',
		videoId: youtubeId,
		playerVars: {
			playlist: youtubeId,
			iv_load_policy: 3, // hide annotations
			enablejsapi: 1,
			disablekb: 1,
			autoplay: 1,
			controls: 0,
			showinfo: 0,
			rel: 0,
			loop: 1
		},
		events: {
			onReady: function ( event ) {
				event.target.mute().setLoop( true );
			}
		}
	} );

	vcResizeVideoBackground( $element );

	jQuery( window ).bind( 'resize', function () {
		vcResizeVideoBackground( $element );
	} );
}

/**
 * Resize background video iframe so that video content covers whole area
 */
function vcResizeVideoBackground( $element ) {
	var iframeW,
		iframeH,
		marginLeft,
		marginTop,
		containerW = $element.innerWidth(),
		containerH = $element.innerHeight(),
		ratio1 = 16,
		ratio2 = 9;

	if ( ( containerW / containerH ) < ( ratio1 / ratio2 ) ) {
		iframeW = containerH * (ratio1 / ratio2);
		iframeH = containerH;

		marginLeft = - Math.round( ( iframeW - containerW ) / 2 ) + 'px';
		marginTop = - Math.round( ( iframeH - containerH ) / 2 ) + 'px';

		iframeW += 'px';
		iframeH += 'px';
	} else {
		iframeW = containerW;
		iframeH = containerW * (ratio2 / ratio1);

		marginTop = - Math.round( ( iframeH - containerH ) / 2 ) + 'px';
		marginLeft = - Math.round( ( iframeW - containerW ) / 2 ) + 'px';

		iframeW += 'px';
		iframeH += 'px';
	}

	$element.find( '.parvez_video-bg iframe' ).css( {
		maxWidth: '1000%',
		marginLeft: marginLeft,
		marginTop: marginTop,
		width: iframeW,
		height: iframeH
	} );
}

/**
 * Extract video ID from youtube url
 */
function vcExtractYoutubeId( url ) {
	if ( 'undefined' === typeof(url) ) {
		return false;
	}

	var id = url.match( /(?:https?:\/{2})?(?:w{3}\.)?youtu(?:be)?\.(?:com|be)(?:\/watch\?v=|\/)([^\s&]+)/ );

	if ( null != id ) {
		return id[ 1 ];
	}

	return false;
}