//获取当前月的第一天
function getCurrentMonthFirst() {
    var date = new Date();
    date.setDate(1);
    return date;
}

//获取当前月的最后一天
function getCurrentMonthLast() {
    var date = new Date();
    var currentMonth = date.getMonth();
    var nextMonth = ++currentMonth;
    var nextMonthFirstDay = new Date(date.getFullYear(), nextMonth, 1);
    var oneDay = 1000 * 60 * 60 * 24;
    return new Date(nextMonthFirstDay - oneDay);
}

//获取上个月的第一天
function getLastMonthFirst() {
    var nowdays = new Date();
    var year = nowdays.getFullYear();
    var month = nowdays.getMonth();
    if (month == 0) {
        month = 12;
        year = year - 1;
    }
    if (month < 10) {
        month = "0" + month;
    }
    var firstDay = year + "-" + month + "-" + "01";//上个月的第一天
    return firstDay;
}

//获取上个月的最后一天
function getLastMonthLast() {
    var nowdays = new Date();
    var year = nowdays.getFullYear();
    var month = nowdays.getMonth();
    if (month == 0) {
        month = 12;
        year = year - 1;
    }
    if (month < 10) {
        month = "0" + month;
    }
    var myDate = new Date(year, month, 0);
    var lastDay = year + "-" + month + "-" + myDate.getDate();//上个月的最后一天
    return lastDay;
}

///转换日期
function JsDate(mm) {
    if (mm != null && mm != "") {
        var ss = (mm).substr(6, 13)
        var date = new Date(ss * 1);//时间戳为10位需*1000，时间戳为13位的话不需乘1000
        Y = date.getFullYear() + '-';
        M = (date.getMonth() + 1 < 10 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1) + '-';
        D = (date.getDate() < 10 ? '0' + date.getDate() : date.getDate()) + ' ';
        h = (date.getHours() < 10 ? '0' + date.getHours() : date.getHours()) + ':';
        m = (date.getMinutes() < 10 ? '0' + date.getMinutes() : date.getMinutes()) + ':';
        s = date.getSeconds() < 10 ? '0' + date.getSeconds() : date.getSeconds();
        return Y + M + D + h + m + s;
    } else {
        return "";
    }
}

///转换短日期
function JsShortDate(mm) {
    if (mm != null && mm != "") {
        var ss = (mm).substr(6, 13)
        var date = new Date(ss * 1);//时间戳为10位需*1000，时间戳为13位的话不需乘1000
        Y = date.getFullYear() + '-';
        M = (date.getMonth() + 1 < 10 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1) + '-';
        D = date.getDate();
        return Y + M + D;
    } else {
        return "";
    }
}

//天数转换日期
//numb整数值是日期距离1900年1月1日的天数
function formatDate(numb, format) {
    var isNum = /^\d*$/; //正则表达式
    var isFloat = /^\d+(?=\.{0,1}\d+$|$)/;//小数
    if (!isNum.test(numb) && !isFloat.test(numb)) {
        return numb;
    }

    var time = new Date((numb - 1) * 24 * 3600000 + 1)
    time.setYear(time.getFullYear() - 70)
    var year = time.getFullYear() + ''
    var month = time.getMonth() + 1 + ''
    var date = time.getDate() + ''
    if (format && format.length === 1) {
        return year + format + month + format + date
    }
    return year + (month < 10 ? '0' + month : month) + (date < 10 ? '0' + date : date)
}

//格式化日期格式
function Format(now, mask) {
    var d = now;
    var zeroize = function (value, length) {
        if (!length) length = 2;
        value = String(value);
        for (var i = 0, zeros = ''; i < (length - value.length); i++) {
            zeros += '0';
        }
        return zeros + value;
    };

    return mask.replace(/"[^"]*"|'[^']*'|\b(?:d{1,4}|m{1,4}|yy(?:yy)?|([hHMstT])\1?|[lLZ])\b/g, function ($0) {
        switch ($0) {
            case 'd': return d.getDate();
            case 'dd': return zeroize(d.getDate());
            case 'ddd': return ['Sun', 'Mon', 'Tue', 'Wed', 'Thr', 'Fri', 'Sat'][d.getDay()];
            case 'dddd': return ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'][d.getDay()];
            case 'M': return d.getMonth() + 1;
            case 'MM': return zeroize(d.getMonth() + 1);
            case 'MMM': return ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'][d.getMonth()];
            case 'MMMM': return ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'][d.getMonth()];
            case 'yy': return String(d.getFullYear()).substr(2);
            case 'yyyy': return d.getFullYear();
            case 'h': return d.getHours() % 12 || 12;
            case 'hh': return zeroize(d.getHours() % 12 || 12);
            case 'H': return d.getHours();
            case 'HH': return zeroize(d.getHours());
            case 'm': return d.getMinutes();
            case 'mm': return zeroize(d.getMinutes());
            case 's': return d.getSeconds();
            case 'ss': return zeroize(d.getSeconds());
            case 'l': return zeroize(d.getMilliseconds(), 3);
            case 'L': var m = d.getMilliseconds();
                if (m > 99) m = Math.round(m / 10);
                return zeroize(m);
            case 'tt': return d.getHours() < 12 ? 'am' : 'pm';
            case 'TT': return d.getHours() < 12 ? 'AM' : 'PM';
            case 'Z': return d.toUTCString().match(/[A-Z]+$/);
            default: return $0.substr(1, $0.length - 2);
        }
    });
}

//将数字转换成金额显示
function toMoney(num) {
    num = num + '';
    var str = num.split('').reverse().join('').replace(/(\d{3}(?=\d)(?!\d+\.|$))/g, '$1,').split('').reverse().join('');
    if (str.split('.').length < 2) {
        return str + '.00';
    }
    return str.split('.')[0] + '.' + str.split('.')[1].substring(0, 2);
}

//将数字转换成金额显示，带￥
function toMoneyWithCNY(num) {
    num = num + '';
    var str = "￥" + num.split('').reverse().join('').replace(/(\d{3}(?=\d)(?!\d+\.|$))/g, '$1,').split('').reverse().join('');
    if (str.split('.').length < 2) {
        return str + '.00';
    }
    return str.split('.')[0] + '.' + str.split('.')[1].substring(0, 2);
}

//小数转化为百分数
function toPercent(point) {
    var str = Number(point * 100).toFixed(2);
    str += "%";
    return str;
}

//百分数转化为小数
function toPoint(percent) {
    var str = percent.replace("%", "");
    str = str / 100;
    return str;
}

//判断字符是否为空的方法
function isEmpty(obj) {
    if (typeof obj == "undefined" || obj == null || obj == "") {
        return true;
    } else {
        return false;
    }
}

//获取当前日期字符串
function getCurrentTimeStr() {
    var isTime = new Date();
    var y = isTime.getFullYear();
    var m = isTime.getMonth();
    var d = isTime.getDate();
    var h = isTime.getHours();
    var mi = isTime.getMinutes();
    var s = isTime.getSeconds();
    m = m + 1;
    var str = "";
    str += y;
    str += (m + "").length < 2 ? ("0" + m) : m;
    str += (d + "").length < 2 ? ("0" + d) : d;
    str += (h + "").length < 2 ? ("0" + h) : h;
    str += (mi + "").length < 2 ? ("0" + mi) : mi;
    str += (s + "").length < 2 ? ("0" + s) : s;
    return str;
}

//状态数字转文本描述
function getTextForStatus(val) {
    var value;
    switch (val) {
        case 10:
            value = "待审核";
            break;
        case 20:
            value = "待配载";
            break;
        case 30:
            value = "待提货";
            break;
        case 40:
            value = "待配送";
            break;
        case 50:
            value = "待中转";
            break;
        case 60:
            value = "待二次配载";
            break;
        case 70:
            value = "待二次提货";
            break;
        case 80:
            value = "待二次配送";
            break;
        case 90:
            value = "待签收";
            break;
        case 100:
            value = "已完成";
            break;
    }
    return value;
}

//根据配置加载页面按钮
function getButtonConfig() {
    //获取当前页面路径
    var pageUrl = window.location.pathname;
    $.ajax({
        type: 'POST',
        url: '/System/Menu/GetPageConfigMenuButton',
        data: { Link: pageUrl },
        success: function (res) {
            if (res.code == 200) {
                var ButtonList = [];//获取可用的按钮数组
                for (var i = 0; i < res.data.length; i++) {
                    if (res.data[i].HasPermission == 1) {
                        ButtonList.push(res.data[i].RoleButtonValue);
                    }
                }
                if (ButtonList.length > 0) {
                    //遍历页面所有按钮，遍历是否在集合中，如果不在就隐藏按钮
                    $("button").each(function (index, element) {
                        if ($(this).data("role") != null || $(this).data("role") != undefined) {
                            if ($.inArray($(this).data("role"), ButtonList) == -1) {
                                $(this).css("display", "none");
                            }
                        }
                    })
                }
            }
        }
    });

}
