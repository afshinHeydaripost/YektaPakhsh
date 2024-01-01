function AjaxStart() {
    $('#loadingDiv').show();
    $('#loadingDiv').addClass("d-flex");
}
function AjaxStop() {
    $('#loadingDiv').removeClass("d-flex");
    $('#loadingDiv').hide()
}
$(document).ready(function () {
    AjaxStop();
});
function isNullOrEmpty(string) {
    return (string == null || string === "" || string.length == 0);
}

function objisNull(fildId) {
    $("#" + fildId).focus();
    $("#" + fildId).css("border", "1px red solid");
}

function objisFull(fildId) {
    $("#" + fildId).css("border", "1px red #dbdbdb");
}

function SubString(text, startIndex, length) {
    if (isNullOrEmpty(text))
        return "...";
    else {
        if (text.length > length)
            return text.substring(startIndex, length) + "...";
        else
            return text;
    }
}

function loadFile(event, tag) {
    var output = document.getElementById(tag);
    output.src = URL.createObjectURL(event.target.files[0]);
    output.onload = function () {
        URL.revokeObjectURL(output.src) // free memory
    }
};

function EnableTag(tag) {
    $(tag).attr("disabled", false);
    $(tag).removeClass('disabled');
}

function DisabledTag(tag) {
    $(tag).attr("disabled", true);
    $(tag).addClass('disabled');
}

function SendFormToServer(frm, Url, modal = null, isReload = false) {
    var valdata = $(frm).serialize();
    $.validator.unobtrusive.parse(frm);
    if ($(frm).valid()) {
        AjaxStart();
        $.ajax({
            url: Url,
            type: "POST",
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: valdata,
            success: function (result) {
                AjaxStop();
                if (result.isSuccess) {
                    if (!isNullOrEmpty(modal))
                        $(modal).modal('toggle');
                    ToastMessageSuccess(result.message);
                    if (isReload)
                        loadPage();
                } else {
                    ToastMessageError(result.message);
                }
            },
            error: function (xhr, status, error) {
                AjaxStop();
                ToastMessageError(error);
            }
        });
    }
}

function toEnglishDigits(number) {
    var res = number.replaceAll('۰', '0');
    res = res.replaceAll('۱', '1');
    res = res.replaceAll('۲', '2');
    res = res.replaceAll('۳', '3');
    res = res.replaceAll('۴', '4');
    res = res.replaceAll('۵', '5');
    res = res.replaceAll('۶', '6');
    res = res.replaceAll('۷', '7');
    res = res.replaceAll('۸', '8');
    res = res.replaceAll('۹', '9');
    return res;
}

String.prototype.toEnglishDigits = function () {
    var num_dic = {
        '۰': '0',
        '۱': '1',
        '۲': '2',
        '۳': '3',
        '۴': '4',
        '۵': '5',
        '۶': '6',
        '۷': '7',
        '۸': '8',
        '۹': '9',
    }
    return parseInt(this.replace(/[۰-۹]/g, function (w) {
        return num_dic[w]
    }));
}

function separate(number) { //جدا کردن سه رقم سه رقم اعداد
    number += '';
    number = number.replace(',', '');
    x = number.split('.');
    y = x[0];
    z = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(y))
        y = y.replace(rgx, '$1' + ',' + '$2');
    return y + z;
}

function addHyphen(element) {
    let val = $(element).val().split('-').join(''); // Remove dash (-) if mistakenly entered.
    let finalVal = val.match(/.{1,4}/g).join('-'); // Add (-) after 3rd every char.
    $(element).val(finalVal); // Update the input box.
}

function isValidNationalCode(nationalCode) {
    var L = nationalCode.length;

    if (L < 10 || parseInt(nationalCode, 10) == 0) return false;
    if (nationalCode == "1111111111" || nationalCode == "0000000000" || nationalCode == "2222222222" || nationalCode == "3333333333" ||
        nationalCode == "4444444444" || nationalCode == "5555555555" || nationalCode == "6666666666" || nationalCode == "7777777777" ||
        nationalCode == "8888888888" || nationalCode == "9999999999") return false;
    nationalCode = ('0000' + nationalCode).substr(L + 4 - 10);
    if (parseInt(nationalCode.substr(3, 6), 10) == 0) return false;
    var c = parseInt(nationalCode.substr(9, 1), 10);
    var s = 0;
    for (var i = 0; i < 9; i++)
        s += parseInt(nationalCode.substr(i, 1), 10) * (10 - i);
    s = s % 11;
    return (s < 2 && c == s) || (s >= 2 && c == (11 - s));
    return true;
}

function just_persian(str) {
    if (str != "") {
        var asciiCode = GetAscii(str);
        if (isNullOrEmpty(str) || str == " " || asciiCode == 66 || asciiCode == 69)
            return true;
        var text = ToPersianNumber(str);
        var p = /^[\u0600-\u06FF\s]+$/;
        if (!p.test(text)) {
            return false
        }
    }
    return true;
}

function AddClass(tag, className) {
    $(tag).addClass(className);
}

function ChangeUrl(url) {
    location.replace(url);
}

function loadPage() {
    location.reload();
}

$(".JustDigit").keypress(function (event) {
    var controlKeys = [8, 9, 13, 35, 36, 37, 39];
    var isControlKey = controlKeys.join(",").match(new RegExp(event.which));
    if (!event.which || (45 <= event.which && event.which <= 57) || (48 == event.which && $(this).attr("value")) || isControlKey) {
        return
    } else {
        event.preventDefault()
    }
});

$(".Number").keyup(function (event) {
    var Num = $(this).val();
    Num += '';
    Num = Num.replace(',', '');
    Num = Num.replace(',', '');
    Num = Num.replace(',', '');
    Num = Num.replace(',', '');
    Num = Num.replace(',', '');
    Num = Num.replace(',', '');
    x = Num.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1))
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    $(this).val(x1 + x2)
});

function ToSafeUrl(strUrl) {
    var res = "";
    var text = String(strUrl);
    res = text.replaceAll(" ", "-");
    res = res.replaceAll(":", "-");
    res = res.replaceAll("/./", "-");
    res = res.replaceAll("///", "-");
    res = res.replaceAll("/\\/", "-");
    res = res.replaceAll('/', "-");
    res = res.replaceAll("/?/", "-");
    res = res.replaceAll("!", "-");
    res = res.replaceAll("@", "");
    res = res.replaceAll("#", "");
    res = res.replaceAll("%", "");
    res = res.replaceAll("^", "");
    res = res.replaceAll("&", "");
    res = res.replaceAll("/*/", "");
    res = res.replaceAll("/+/", "");
    res = res.replaceAll("~", "");
    res = res.replaceAll(",", "");
    res = res.replaceAll("$", "");
    res = res.replaceAll("insert", "");
    res = res.replaceAll("select", "");
    res = res.replaceAll("update", "");
    return res;
}

String.prototype.replaceAll = String.prototype.replaceAll || function (string, replaced) {
    return this.replace(new RegExp(string, 'g'), replaced);
};

function GetAscii(str) {
    return str.charCodeAt(0);
}

function ToPersianNumber(num) {
    var i = 0,
        dontTrim = dontTrim || false,
        num = dontTrim ? String(num) : String(num).trim(),
        len = num.length,
        res = '',
        pos,
        persianNumbers = typeof persianNumber == 'undefined' ? ['۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹'] :
            persianNumbers;
    for (; i < len; i++)
        if ((pos = persianNumbers[num.charAt(i)]))
            res += pos;
        else
            res += num.charAt(i);
    return res;
}

function SetMaxLength(id, length) {
    $("#" + id).attr('maxlength', length);
}

function confirmation(message) {
    return confirm(message);
}

function SelectColor(id) { //تنطیم کردن رنگ پیشفرض
    $('#' + id).prop('selected', true);
}

function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

function isPhoneNumber(number) {
    var regex = new RegExp('^(\\+98|0)?9\\d{9}$');
    var result = regex.test(number);
    return result;
}

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function isIncludes(strText, strSearchText) {
    return strText.includes(strSearchText);
}

function PostToServer(url, data, callbackFunction, showloder = false) {
    if (showloder)
        AjaxStart();
    $.post(url, data, function (res) {
        AjaxStop();
        if (typeof callbackFunction == 'function') {
            callbackFunction.call(this, res);
        }
    }).fail(function (xhr, status, error) {
        AjaxStop();
        console.log("error on :" + url);
    })
}
function GetFromServer(url, data, callbackFunction, isShowLoading = true) {
    if (isShowLoading)
        AjaxStart();
    $.ajax({
        type: 'GET',
        url: url,
        data: data,
        success: function (res) {
            AjaxStop();
            if (typeof callbackFunction == 'function') {
                callbackFunction.call(this, res);
            }
        },
        error: function (res) {
            AjaxStop();
            console.log('error')
        }
    })
}

function ValidationSummary(tagErrors, tagValid) {
    $(tagErrors).html("<ul></ul>");
    $(tagErrors).addClass("validation-summary-valid");
    $(tagValid).removeClass("validation-summary-errors");
    $(tagValid).html("<ul></ul>");
}

function GetStrIdsChekcedCheckBoxValue(inputSelector, charJoin) {
    var sels = $(inputSelector);
    var sids = [];
    var outputStr = "";
    for (var i = 0; i < sels.length; i++) {
        if (sels[i].checked) {
            sids.push(sels[i].value.trim());
        }
    }
    outputStr = sids.join(charJoin);
    return outputStr;
}

function CopyURL(Url = "") {
    var url = window.location.href + Url;
    if (isNullOrEmpty(Url))
        url = window.location.href;
    navigator.clipboard.writeText(url).then(function () {
        ToastMessageSuccess("لینک با موفقیت کپی شد")
    }, function (err) {
        ToastMessageError('خطا در کپی کردن لینک ', err);
    });
}

function GetDisplayWidth() {
    $(window).width();
}