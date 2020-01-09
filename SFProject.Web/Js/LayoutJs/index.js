var IEiver = IEVersion();
if (IEiver >= 0 && IEiver <= 8) {
    alert("检测到您当前版本的浏览器(IE" + IEiv + ")与系统不兼容,建议升级到最新版IE浏览器或者下载火狐、谷歌浏览器体验最佳效果!")
}

var $, tab, dataStr, layer;
layui.config({
    base: "/Js/LayoutJs/"
}).extend({
    "bodyTab": "bodyTab"
})
jQuery.support.cors = true;
layui.use(['bodyTab', 'form', 'element', 'layer', 'jquery'], function () {
    var form = layui.form,
        element = layui.element;
    $ = layui.$;
    layer = parent.layer === undefined ? layui.layer : top.layer;
    tab = layui.bodyTab({
        openTabNum: "50"  //最大可打开窗口数量
    });

    if (IEiver == 'edge' || IEiver == -1 || IEiver * 1 > 9) {
        if (window.history && window.history.pushState) {
            $(window).on('popstate', function () {
                /// 当点击浏览器的 后退和前进按钮 时才会被触发， 
                window.history.pushState('forward', null, '');
                window.history.forward(1);
            });
        }
        window.history.pushState('forward', null, '');  //在IE中必须得有这两行
        window.history.forward(1);
    }

    //通过顶部菜单获取左侧二三级菜单   注：此处只做演示之用，实际开发中通过接口传参的方式获取导航数据
    function getData() {
        $.ajax({
            type: 'POST',
            url: '/System/Menu/GetMenuList',
            data: {},
            success: function (data) {
                if (data.msg == "200") {
                    var str = "[";
                    for (var i = 0; i < data.data.length; i++)
                    {
                        if (data.data[i].SuperID == "0" && data.data[i].IsValid == "1")
                        {
                            str += '{"id":' + i + ',"title":"' + data.data[i].MenuName + '","icon":"' + data.data[i].Icon + '","href":"#","spread":false,"children":['
                            var ye=0
                            for (var j = 0; j < data.data.length; j++)
                            {
                                if (data.data[i].ID == data.data[j].SuperID && data.data[i].IsValid == "1") {
                                    ye = 1
                                    str += '{"id":' + j + ',"title":"' + data.data[j].MenuName + '","icon":"' + data.data[j].Icon + '","href":"' + data.data[j].Link + '","spread":false,"children":[]},'
                                }
                            }
                            if (ye == 1) {
                                str = str.substr(0, str.length - 1);
                            }
                            str+="]},"
                        }
                    }
                    str = str.substr(0, str.length - 1);
                    str+="]"
                    var listdata = str
                    dataStr = JSON.parse(listdata);
                    tab.render();
                } else {
                    layer.msg('由于长时间未操作或者你主动清除了缓存，请重新登录', {
                        icon: 2
                    }, function () {
                        window.location.href = "/Login/Login/Index";
                    });
                }
            }, error: function (re) {
                layer.msg('由于长时间未操作或者你主动清除了缓存，请重新登录', {
                    icon: 2
                }, function () {
                    window.location.href = "/Login/Login/Index";
                });
            }
        })

        //var listdata = '[{"id":2,"title":"系统管理","icon":"&#xe620;","href":"#","spread":false,"children":[{"id":3,"title":"用户管理","icon":"","href":"/User/SysUser/Index","spread":false,"children":null},{"id":4,"title":"角色管理","icon":"","href":"/Role/Role/Index","spread":false,"children":null},{"id":5,"title":"组织及职位管理","icon":"","href":"/Organization/OrganizationInfo/Index","spread":false,"children":null}]},{"id":6,"title":"订单管理","icon":"&#xe630;","href":"#","spread":false,"children":[{"id":7,"title":"订单管理","icon":"","href":"/Order/Order/Index","spread":false,"children":null},{"id":8,"title":"订单确认","icon":"","href":"/Order/Order/OrderSure","spread":false,"children":null},{"id":9,"title":"订单评价","icon":"","href":"/Order/Order/OrderEvaluation","spread":false,"children":null}]},{"id":10,"title":"客户管理","icon":"icon-icon10","href":"#","spread":false,"children":[{"id":11,"title":"客户基本信息管理","icon":"","href":"/Order/Order/Customer","spread":false,"children":null}]},{"id":13,"title":"服务管理","icon":"&#xe735;","href":"#","spread":false,"children":[{"id":14,"title":"服务管理","icon":"","href":"/Product/ProductInfo/Index","spread":false,"children":null},{"id":25,"title":"标签管理","icon":"","href":"/Product/ProductSign/Index","spread":false,"children":null},{"id":26,"title":"类别管理","icon":"","href":"/Category/Category/Index","spread":false,"children":null}]},{"id":18,"title":"客服管理","icon":"&#xe770;","href":"#","spread":false,"children":[{"id":19,"title":"客户提醒","icon":"","href":"/CustomerRemind/CustomerRemindInfo/Index","spread":false,"children":null},{"id":20,"title":"订单到期提醒","icon":"","href":"/ExpireOrderRemind/ExpireOrderRemindInfo/Index","spread":false,"children":null},{"id":21,"title":"工单处理","icon":"","href":"/Order/Order/Index","spread":false,"children":null}]},{"id":22,"title":"策略管理","icon":"&#xe628;","href":"#","spread":false,"children":[{"id":23,"title":"定价策略管理","icon":"","href":"/StrategyCondition/StrategyConditionInfo/Index","spread":false,"children":null},{"id":24,"title":"营销活动管理","icon":"","href":"/StrategyCondition/StrategyConditionInfo/Marketing","spread":false,"children":null}]},{"id":27,"title":"服务商管理","icon":"&#xe653;","href":"#","spread":false,"children":[{"id":28,"title":"服务商信息","icon":"","href":"/SIManager/SIInfo/Index","spread":false,"children":null},{"id":29,"title":"服务商考核规则","icon":"","href":"/SIManager/SIInfo/AppraiseRotu","spread":false,"children":null},{"id":30,"title":"服务商考核查询","icon":"","href":"/Examination/ExaminationInfo/Index","spread":false,"children":null},{"id":31,"title":"服务商订单","icon":"","href":"/SIManager/SIInfo/SIOrder","spread":false,"children":null},{"id":32,"title":"服务商准入审批","icon":"","href":"/BusinessFlow/ApplicationAssessmentList/Index","spread":false,"children":null},{"id":33,"title":"流程配置","icon":"","href":"/ModifyTacheConfig/ModifyTacheConfigInfo/Index","spread":false,"children":null}]},{"id":35,"title":"门户运营","icon":"&#xe7ae;","href":"#","spread":false,"children":[{"id":38,"title":"首页Banner管理","icon":"","href":" /PortalOperation/PortalOperation/Index","spread":false,"children":null},{"id":39,"title":"热门关键词","icon":"","href":" /PortalOperation/PortalOperation/ContactUs","spread":false,"children":null},{"id":61,"title":"首页产品配置","icon":"","href":"/PortalOperation/PortalOperation/HomeProductConfig","spread":false,"children":null},{"id":1061,"title":"Q&A问答管理","icon":"","href":"/PortalOperation/PortalOperation/QuestionMsg","spread":false,"children":null},{"id":1063,"title":"文档标签管理","icon":"","href":"/PortalOperation/PortalOperation/HElable","spread":false,"children":null},{"id":1065,"title":"留言管理","icon":"","href":"/PortalOperation/PortalOperation/LeaveMeaage","spread":false,"children":null}]},{"id":51,"title":"AP接口管理","icon":"&#xe6b2;","href":"#","spread":false,"children":[{"id":57,"title":"AP接口日志","icon":"","href":"/apilog/apilog/Index","spread":false,"children":null},{"id":59,"title":"AP接口配置","icon":"","href":"/apilog/apilog/AESKeySystem","spread":false,"children":null}]},{"id":1066,"title":"合同管理","icon":"&#xe653;","href":"#","spread":false,"children":[{"id":1067,"title":"合同管理","icon":"","href":"/Contract/Contron/Index","spread":false,"children":null}]},{"id":1070,"title":"统计管理","icon":"&#xe62c;","href":"#","spread":false,"children":[{"id":1073,"title":"服务统计","icon":"","href":"/Report/Report/Index","spread":false,"children":null}]},{"id":1074,"title":"费用管理","icon":"&#xe65e;","href":"#","spread":false,"children":[{"id":1076,"title":"资金账号","icon":"","href":"/CICCpayment/CICCpayment/Index","spread":false,"children":null},{"id":1080,"title":"合同账号","icon":"","href":"/CICCpayment/CICCpayment/HeTong","spread":false,"children":null},{"id":1081,"title":"提现记录","icon":"","href":"/CICCpayment/CICCpayment/TiXian","spread":false,"children":null},{"id":1082,"title":"充值记录","icon":"","href":"/CICCpayment/CICCpayment/ChongZhi","spread":false,"children":null},{"id":1083,"title":"订单支付记录","icon":"","href":"/CICCpayment/CICCpayment/OrderPayLog","spread":false,"children":null}]}]'
        //dataStr = JSON.parse(listdata);
        //tab.render();
    }

    //三级导航菜单
    $('body').on('click', 'li.layui-nav-item.layui-nav-item-2', function () {
        $(this).toggleClass('layui-nav-itemed-2');
        $('dd.layui-this').removeClass('layui-this');
        if ($(this).siblings('li.layui-nav-item.layui-nav-item-2').hasClass('layui-nav-item-2')) {
            $(this).siblings('li.layui-nav-item.layui-nav-item-2').removeClass('layui-nav-itemed');
            $(this).siblings('li.layui-nav-item.layui-nav-item-2').removeClass('layui-nav-itemed-2');
        }
    });

    $('body').on('click', 'dl.layui-nav-child > dd', function (e) {
        e.stopPropagation();
        if (!$(this).hasClass('layui-nav-item-2')) {
            $('li.layui-nav-item.layui-nav-item-2').removeClass('layui-nav-itemed');
            $('li.layui-nav-item.layui-nav-item-2').removeClass('layui-nav-itemed-2');
        }
    });

    //页面加载时判断左侧菜单是否显示
    //通过顶部菜单获取左侧菜单
    $(".topLevelMenus li,.mobileTopLevelMenus dd").click(function () {
        if ($(this).parents(".mobileTopLevelMenus").length != "0") {
            $(".topLevelMenus li").eq($(this).index()).addClass("layui-this").siblings().removeClass("layui-this");
        } else {
            $(".mobileTopLevelMenus dd").eq($(this).index()).addClass("layui-this").siblings().removeClass("layui-this");
        }
        $(".layui-layout-admin").removeClass("showMenu");
        $("body").addClass("site-mobile");
        //渲染顶部窗口
        tab.tabMove();
    })

    //隐藏左侧导航
    $(".hideMenu").click(function () {
        if ($(".topLevelMenus li.layui-this a").data("url")) {
            layer.msg("此栏目状态下左侧菜单不可展开");  //主要为了避免左侧显示的内容与顶部菜单不匹配
            return false;
        }
        $(".layui-layout-admin").toggleClass("showMenu");
        //渲染顶部窗口
        tab.tabMove();
    })

    //通过顶部菜单获取左侧二三级菜单   注：此处只做演示之用，实际开发中通过接口传参的方式获取导航数据
    getData();

    //手机设备的简单适配
    $('.site-tree-mobile').on('click', function () {
        $('body').addClass('site-mobile');
    });
    $('.site-mobile-shade').on('click', function () {
        $('body').removeClass('site-mobile');
    });

    // 添加新窗口
    $("body").on("click", ".layui-nav .layui-nav-item  a:not('.mobileTopLevelMenus .layui-nav-item a')", function () {
        //如果不存在子级
        if ($(this).siblings().length == 0) {
            addTab($(this));
            $('body').removeClass('site-mobile');  //移动端点击菜单关闭菜单层
        }
        $(this).parent("li").siblings().removeClass("layui-nav-itemed");
    })

    //清除缓存
    $(".clearCache").click(function () {
        window.sessionStorage.clear();
        window.localStorage.clear();
        var index = layer.msg('清除缓存中，请稍候', { icon: 16, time: false, shade: 0.8 });
        setTimeout(function () {
            layer.close(index);
            layer.msg("缓存清除成功！");
        }, 1000);
    })

    //刷新后还原打开的窗口
    if (cacheStr == "true") {
        if (window.sessionStorage.getItem("menu") != null) {
            menu = JSON.parse(window.sessionStorage.getItem("menu"));
            curmenu = window.sessionStorage.getItem("curmenu");
            var openTitle = '';
            for (var i = 0; i < menu.length; i++) {
                openTitle = '';
                if (menu[i].icon) {
                    if (menu[i].icon.split("-")[0] == 'icon') {
                        openTitle += '<i class="seraph ' + menu[i].icon + '"></i>';
                    } else {
                        openTitle += '<i class="layui-icon">' + menu[i].icon + '</i>';
                    }
                }
                openTitle += '<cite>' + menu[i].title + '</cite>';
                openTitle += '<i class="layui-icon layui-unselect layui-tab-close" data-id="' + menu[i].layId + '">&#x1006;</i>';
                element.tabAdd("bodyTab", {
                    title: openTitle,
                    content: "<iframe src='" + menu[i].href + "' data-id='" + menu[i].layId + "'></frame>",
                    id: menu[i].layId
                })
                //定位到刷新前的窗口
                if (curmenu != "undefined") {
                    if (curmenu == '' || curmenu == "null") {  //定位到后台首页
                        element.tabChange("bodyTab", '');
                    } else if (JSON.parse(curmenu).title == menu[i].title) {  //定位到刷新前的页面
                        element.tabChange("bodyTab", menu[i].layId);
                    }
                } else {
                    element.tabChange("bodyTab", menu[menu.length - 1].layId);
                }
            }
            //渲染顶部窗口
            tab.tabMove();
        }
    } else {
        window.sessionStorage.removeItem("menu");
        window.sessionStorage.removeItem("curmenu");
    }
})

//打开新窗口
function addTab(_this) {
    tab.tabAdd(_this);
}

function delTab(_this) {
    tab.tabDelete(_this);
}

///ie浏览器
function IEVersion() {
    var userAgent = navigator.userAgent; //取得浏览器的userAgent字符串  
    var isIE = userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1; //判断是否IE<11浏览器  
    var isEdge = userAgent.indexOf("Edge") > -1 && !isIE; //判断是否IE的Edge浏览器  
    var isIE11 = userAgent.indexOf('Trident') > -1 && userAgent.indexOf("rv:11.0") > -1;
    if (isIE) {
        var reIE = new RegExp("MSIE (\\d+\\.\\d+);");
        reIE.test(userAgent);
        var fIEVersion = parseFloat(RegExp["$1"]);
        if (fIEVersion == 7) {
            return 7;
        } else if (fIEVersion == 8) {
            return 8;
        } else if (fIEVersion == 9) {
            return 9;
        } else if (fIEVersion == 10) {
            return 10;
        } else {
            return 6;//IE版本<=7
        }
    } else if (isEdge) {
        return 'edge';//edge
    } else if (isIE11) {
        return 11; //IE11  
    } else {
        return -1;//不是ie浏览器
    }
}