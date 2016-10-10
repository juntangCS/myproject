function formValidation(form) {
    if (form.$invalid) {
        var errors = form.$error;
        for (var i in errors) {
            var item = errors[i];
            for (var j = 0; j < item.length; j++) {
                var obj = item[j];
                if (j === 0) {
                    $('[name="' + obj.$name + '"]').focus();
                }
                $('[name="' + obj.$name + '"]').parent().addClass('has-error');
                obj.$setDirty();
            }
        }
        return false;
    } else {
        return true;

    }
}

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageUrl = decodeURIComponent(window.location.search.substring(1)),
        sUrlVariables = sPageUrl.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sUrlVariables.length; i++) {
        sParameterName = sUrlVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};

/* 显示遮罩层 */
function showOverlay() {
    $("#overlay").height(pageHeight());
    $("#overlay").width(pageWidth());

    // fadeTo第一个参数为速度，第二个为透明度
    // 多重方式控制透明度，保证兼容性，但也带来修改麻烦的问题
    $("#overlay").fadeTo(200, 0.5);
}

/* 隐藏覆盖层 */
function hideOverlay() {
    $("#overlay").fadeOut(200);
}

/* 当前页面高度 */
function pageHeight() {
    return document.body.scrollHeight;
}

/* 当前页面宽度 */
function pageWidth() {
    return document.body.scrollWidth;
}