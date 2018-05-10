


// 显示居中通知对话框
function showCenterNotify(message) {
    F.notify({
        message: message,
        messageIcon: '',
        modal: true,
        hideOnMaskClick: true,
        header: false,
        displayMilliseconds: 3000,
        positionX: 'center',
        positionY: 'center',
        messageAlign: 'center',
        minWidth: 200
    });
}