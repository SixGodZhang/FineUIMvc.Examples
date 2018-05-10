
// 通知对话框分组
(function () {

    // _notifySpace: 消息框之间的间距
    // _notifies: 存放当前正在显示的对话框列表
    var _orderNumber = 1, _notifySpace = 5, _notifies = [];

    // 对话框关闭处理函数
    function onNotifyHide() {
        // 先清空之前尚未完成的动画
        clearNotifiesAnimation();

        var notify = this;
        var notifyHeight = notify.el.outerHeight(true) + _notifySpace;
        var notifyIndex = $.inArray(notify, _notifies);
        _notifies.splice(notifyIndex, 1);

        var count = _notifies.length;
        if (count) {
            for (var i = notifyIndex; i < count; i++) {
                var item = _notifies[i];
                item.top -= notifyHeight;
                item.el.animate({
                    'top': item.top
                });
            }

            // 按照 notify.top 重新排序
            _notifies.sort(function (a, b) {
                return a.top - b.top;
            });
        }
    }

    // 所有对话框下移
    function moveNotifiesDown(newNotify, fn) {
        // 先清空之前尚未完成的动画
        clearNotifiesAnimation();

        var count = _notifies.length, finished = 0;
        if (!count) {
            fn.apply(window);
            return;
        }

        var notifyHeight = newNotify.el.outerHeight(true) + _notifySpace;
        for (var i = 0; i < count; i++) {
            var item = _notifies[i];
            item.top += notifyHeight;
            item.el.animate({
                'top': item.top
            }, function () {
                // 动画完成后执行的函数
                finished++;

                if (finished >= count) {
                    fn.apply(window);
                }
            });
        }
    }

    // 停止动画，并回调
    function clearNotifiesAnimation() {
        var count = _notifies.length;
        if (count) {
            for (var i = 0; i < count; i++) {
                var item = _notifies[i];
                var itemEl = item.el;
                if (itemEl.is(":animated")) {
                    itemEl.stop(false, true);
                }
            }
        }
    }

    // 获取对话框元素的top属性
    function calcNotifyTop() {
        var top = _notifySpace;
        if (_notifies.length) {
            var lastNotify = _notifies[_notifies.length - 1];
            top += lastNotify.top + lastNotify.el.outerHeight(true);
        }
        return top;
    }

    // 公开方法
    window.showNotifyGroup = function (options, newestOnTop) {
        // 创建一个消息对话框实例
        $.extend(options, {
            positionX: 'right',
            listeners: {
                hide: onNotifyHide
            }
        });

        if (newestOnTop) {
            // 最新的显示在最上方，需要先隐藏，等 moveNotifiesDown 之后再显示
            options.hidden = true;
            options.top = _notifySpace;
        } else {
            options.top = calcNotifyTop();
        }

        var notify = F.notify(options);

        if (newestOnTop) {
            moveNotifiesDown(notify, function () {
                notify.show();
            });
            _notifies.splice(0, 0, notify);
        } else {
            _notifies.push(notify);
        }
    }


})();