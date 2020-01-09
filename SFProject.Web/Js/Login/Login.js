layui.use(['form', 'layer', 'jquery'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer
    $ = layui.jquery;

    jQuery.support.cors = true;

    //登录按钮
    form.on("submit(login)", function (data) {
        $(this).text("登录中...").attr("disabled", "disabled").addClass("layui-disabled");
        localStorage.setItem("UserName", $("#UserName").val());
        var _this = $(this);
        var objparam = new Object();
        objparam.UserName = $("#UserName").val();
        objparam.Password = $("#Password").val();

        $.ajax({
            type: 'POST',
            url: '/Login/Login/UserLogin',
            data: { requestData: JSON.stringify(objparam) },
            success: function (data) {
                if (data.code == "200") {
                    if (data.msg != "false") {
                        localStorage.setItem("Token", data.msg)
                        localStorage.setItem("UserInfo", JSON.stringify(data.data[0]));
                        window.location.href = "/Login/Login/Main";
                    } else {
                        layer.msg("账号已禁用！", { icon: 2 })
                        _this.text("登录").removeAttr("disabled").removeClass("layui-disabled");
                    }
                } else {
                    layer.msg("用户名或者密码错误！", { icon: 2 })
                    _this.text("登录").removeAttr("disabled").removeClass("layui-disabled");
                }
            },
            error: function (data) {
                layer.msg(data);
            }
        });
        
        return false;
    })

    $("#register").click(function () {
        window.location.href = "/Login/Login/Register";
    });

    var UserName = $("#UserName").val();
    var Password = $("#Password").val();

    if (UserName != '') {
        $("#pUserName").addClass("layui-input-active");
    } else {
        $("#pUserName").removeClass("layui-input-active");
    }

    if (Password != '') {
        $("#pPassword").addClass("layui-input-active");
    } else {
        $("#pPassword").removeClass("layui-input-active");
    }

    //表单输入效果
    $(".loginBody .input-item").click(function (e) {
        e.stopPropagation();
        $(this).addClass("layui-input-focus").find(".layui-input").focus();
    })
    $(".loginBody .layui-form-item .layui-input").focus(function () {
        $(this).parent().addClass("layui-input-focus");
    })
    $(".loginBody .layui-form-item .layui-input").blur(function () {
        $(this).parent().removeClass("layui-input-focus");
        if ($(this).val() != '') {
            $(this).parent().addClass("layui-input-active");
        } else {
            $(this).parent().removeClass("layui-input-active");
        }
    })
})
