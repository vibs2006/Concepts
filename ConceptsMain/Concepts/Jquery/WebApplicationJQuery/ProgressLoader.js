function DarkenPageWithLoading() {
    var loadTopPos;
    //$(document).ready(function () {
        $(".DarkBg").remove();
        $("body").append("<div class='DarkBg'><img src='/images/loading.gif' id='loadImg' style='width:120px;height:120px'/></div>");
        $(".DarkBg").css({
            "display": "block",
            "height": $(document).height() + "px"
        });
        $(window).on("load resize", function () {
            $(".DarkBg").css({
                "width": document.body.scrollWidth + "px"
            });
        });
    //});

    $(window).scroll(function () {
        loadTopPos = $(window).scrollTop() + ($(window).height() / 2 - 75);
        $("#loadImg").css({
            "top": loadTopPos + "px",
            "transition": ".5s all ease"
        });
    });
}

function LightenPage() {
    $(document).ready(function () {
        $(".DarkBg").remove();
    });
}

var globalVerboseAjax = false;

var RegisterGlobalEvents = function (permissionToAnimateSortingDiv, jquerySelector) {

    if (permissionToAnimateSortingDiv == undefined) {
        permissionToAnimateSortingDiv = false;
        console.warn("permissionToAnimateSortingDiv Boolean Value NOT Defined. Please check 'registerGlobalevents' class");        
    }

    var globalElapsedTime;

    var triggerSortingDiv = function (permissionToAnimateSortingDiv, jquerySelector) {
        if (typeof (jquerySelector) != "undefined" && permissionToAnimateSortingDiv === true) {
            if ($(jquerySelector).length > 0) {
                $(jquerySelector).html("Total Elapsed time is " + globalElapsedTime + " seconds.").show().fadeOut(6000);
            }
        }
    }

    // ~/Images/loading.gif must be present for animation to work
    $(document).on("ajaxSend", function (event, jqXHR, ajaxOptions) {
        globalElapsedTime = window.performance.now();
        DarkenPageWithLoading();

        //console.log(event);
        //console.log(jqXHR);
        if (globalVerboseAjax) {
            console.log("url ajax - " + ajaxOptions.url);
            if (ajaxOptions.data) {
                console.log("Ajax Data:");
                console.log(ajaxOptions.data);
            }
        }
    });

    $(document).on("ajaxComplete", function () {
        globalElapsedTime = window.performance.now() - globalElapsedTime;
        globalElapsedTime = Math.round((globalElapsedTime / 1000) * 100) / 100;
        LightenPage();        
        triggerSortingDiv(permissionToAnimateSortingDiv, jquerySelector);
        console.log("%cLast Result Processed in " + globalElapsedTime + " Seconds.", "color:green");
    });

    $(document).on("ajaxError", function () {
        alert("An Server Side Error or Timeout has occured. Please check your server");
        console.error("An Server Side Error or Timeout has occured. Please check your server");
    });
}
