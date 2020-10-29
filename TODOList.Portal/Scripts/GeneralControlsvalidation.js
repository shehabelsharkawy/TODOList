function isNumeric(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function isNumericMore0(evt)
{
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31 && (charCode <= 48 || charCode > 57))
        return false;

    return true;
}

function isDecimal(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
function resetValidation() {
       $(".field-validation-error").empty();
        //Removes validation from input-fields
        $('.input-validation-error').addClass('input-validation-valid');
        $('.input-validation-error').removeClass('input-validation-error');
        //Removes validation message after input-fields
        $('.field-validation-error').addClass('field-validation-valid');
        $('.field-validation-error').removeClass('field-validation-error');
        //Removes validation summary 
        $('.validation-summary-errors').addClass('validation-summary-valid');
        $('.validation-summary-errors').removeClass('validation-summary-errors');
       
    }
function showHideSpinner(state) {
    if (state == true) {
        $(".laodingModal").show();
        $(".loadingPopup").show();
    }
    else if (state == false) {
        $(".laodingModal").hide();
        $(".loadingPopup").hide();
    }
}

(function ($) {
    $.QueryString = (function (paramsArray) {
        let params = {};

        for (let i = 0; i < paramsArray.length; ++i) {
            let param = paramsArray[i]
                .split('=', 2);

            if (param.length !== 2)
                continue;

            params[param[0]] = decodeURIComponent(param[1].replace(/\+/g, " "));
        }

        return params;
    })(window.location.search.substr(1).split('&'))
})(jQuery);


function getQueryStringValue(key) {
    return decodeURIComponent(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
}

var accept = {
    '.PNG': 1,
    '.jpg': 1,
    '.png': 1,
    '.jpeg': 1,
    '.JPG': 1,
    '.JPEG': 1,
    '.TIF': 1,
    '.tif': 1,
    '.gif': 1,
    '.GIF': 1,
};
function check_extension(filename, submitId) {
    var re = /\..+$/;
    var ext = filename.match(re);
    var submitEl = document.getElementById(submitId);
    if (accept[ext] == 1) {
        return true;
    } else {
        swal({
            title: "Warning!",
            text: 'Invalid image, please select another image',
            type: "warning",
        });
        return false;
    }
}