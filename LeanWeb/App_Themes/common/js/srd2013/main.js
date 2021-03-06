require.config({
	baseUrl : '/',
	map: {
		'*' : { 'jquery' : 'jquery-private' },
		'jquery-private' : { 'jquery' : 'jquery' }
	},
	deps : ['modernizr'],
	paths : {
		'stable' : '',
		'unstable' : '',
		'modernizr' : '',
		'fef.jquery' : '',
		'jquery-private' : '',
		'jquery-ui' : '',
		'throttle-debounce' : '',
		'yakety' : '',
        'variables' : ''
	}
});


require(["jquery"], function(jq){
	jq(document).ready(function(){
		/* Stable components */
        /* Non-responsive breadcrumbs */
        require(["stable/breadcrumb"], function(breadcrumb){});
        /**/
        /* Responsive breadcrumbs *
        require(["stable/breadcrumb-responsive"], function(breadcrumb){});
        /**/
        require(["stable/custom-input"], function(customInput){});
        require(["stable/form-selectbox"], function(selectBox){});
        require(["stable/responsive-tables"], function(responsiveTables){});
        require(["stable/set"], function(set){});
        require(["stable/modal"], function(modal){});
        require(["stable/modalmanager"], function(modalManager){});
        require(["stable/responsive-images"], function(responsiveImages){});
        require(["stable/dropdown"], function(dropdown){});
        require(["stable/slide-in-panel"], function(slideInPanel){
            jq("[data-js=slideInPanel]").each(function(){
                jq(this).slideInPanel(jq(this).data());
            });
        });
        require(['stable/carousel'], function() {
            jq('[data-js=carousel]').carousel();
        });
        require(["stable/alerts"], function(alerts){});
        require(["stable/quote"], function(quote){});
        require(["stable/rail-nav"], function(railNav){
            jq("[data-js=railNav]").each(function(i, nav){
                if(jq(nav).attr("id") == null || jq(nav).attr("id") == undefined){
                    jq(nav).attr("id", "fef_railNav" + i);  
                }
                jq(nav).railNav(jq(this).data());
            });
        });
        require(["stable/griddy"], function(griddy){});
        require(["stable/card"], function(card){});
        require(["stable/sifter"], function(sifter){});
        require(["stable/form"], function(form){});

		/* Unstable components */
		require(["unstable/modal"], function(modal){});
		require(["unstable/pagination"], function(pagination){});
	});
});

(function (fallback) {    

    fallback = fallback || function () { };

    // function to trap most of the console functions from the FireBug Console API. 
    var trap = function () {
        // create an Array from the arguments Object           
        var args = Array.prototype.slice.call(arguments);
        // console.raw captures the raw args, without converting toString
        console.raw.push(args);
        var message = args.join(' ');
        console.messages.push(message);
        fallback(message);
    };

    // redefine console
    if (typeof console === 'undefined') {
        console = {
            messages: [],
            raw: [],
            dump: function() { return console.messages.join('\n'); },
            log: trap,
            debug: trap,
            info: trap,
            warn: trap,
            error: trap,
            assert: trap,
            clear: function() { 
                  console.messages.length = 0; 
                  console.raw.length = 0 ;
            },
            dir: trap,
            dirxml: trap,
            trace: trap,
            group: trap,
            groupCollapsed: trap,
            groupEnd: trap,
            time: trap,
            timeEnd: trap,
            timeStamp: trap,
            profile: trap,
            profileEnd: trap,
            count: trap,
            exception: trap,
            table: trap
        };
    }

})(null); // to define a fallback function, replace null with the name of the function (ex: alert)