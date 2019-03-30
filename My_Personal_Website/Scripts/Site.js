//Page preloader
$(window).on("load", function () {
    $(".loader-wrapper").fadeOut("slow");
});

var amountScrolled = 200;

$(window).scroll(function () {
    if ($(window).scrollTop() > amountScrolled) {
        $('a.backToTop').fadeIn('slow');
    } else {
        $('a.backToTop').fadeOut('slow');
    }
});

$('a.backToTop').click(function () {
    $('html, body').animate({
        scrollTop: 0
    }, 700);
    return false;
});



$(document).ready(function () {

    // $("body").css("background", "blue");
    //LoadStyle();



});



//Showing uploading images befor submit
$("#uploadFile").on('change', function () {

    //Get count of selected files
    var countFiles = $(this)[0].files.length;

    var imgPath = $(this)[0].value;
    var extn = imgPath.substring(imgPath.lastIndexOf('.') + 1).toLowerCase();
    var image_holder = $("#ImageHolder");
    image_holder.empty();

    if (extn == "gif" || extn == "png" || extn == "jpg" || extn == "jpeg" || extn =="pdf") {
        if (typeof (FileReader) != "undefined") {

            //loop for each file selected for uploaded.
            for (var i = 0; i < countFiles; i++) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $("<img />", {
                        "src": e.target.result,
                        "class": "thumb-image"
                    }).appendTo(image_holder);

                }

                image_holder.show();
                reader.readAsDataURL($(this)[0].files[i]);
            }

        } else {
            alert("This browser does not support FileReader.");
        }
    } else {
        alert("Pls select only images");
    }
});


//function LoadStyle(id) {
//    $.ajax({
//        url: 'base/GetStyle/'+id,
//        dataType: "json",
//        method: 'GET',
//        success: function (data) {
            
            
//            $(data).each(function (index, emp) {
//                $("body").css("background", emp.BgStyle);
//            });
//        },
//        error: function (err) {
//            console.log(err);
//        }
//    });
//    return false;
//}

