
// 文本 - 性别
function renderGender(value, params) {
    return value == 1 ? '男' : '女';
}

// 超链接标签 - 所学专业
function renderMajor(value, params) {
    var url = 'http://gsa.ustc.edu.cn/search?q=' + F.urlEncode(value);
    return F.formatString('<a href="{0}" data-qtip="{1}" target="_blank">{1}</a>', url, F.htmlEncode(value));
}

// 图片标签 - 分组
function renderGroup(value, params) {
    var imageUrl = F.baseUrl + 'res/images/16/' + value + '.png';
    return F.formatString('<img class="f-grid-imagefield" src="{0}"/>', imageUrl);
}

// HTML - 行扩展列
function renderExpander(value, params) {
    return '<div class="expander">' +
        '<p><strong>姓名：</strong>' + params.rowData.values.Name + '</p>' +
        '<p><strong>简介：</strong>' + value + '</p>' +
        '</div>';
}

// 公共方法 - 显示通知框
function showNotify(content) {
    // 消息正文可能会比较长，所以不显示前面的图标（messageIcon: ''）
    F.notify({
        message: content,
        target: '_top',
        header: false,
        messageIcon: '',
        positionX: 'center',
        positionY: 'top'
    });
}

// 公共方法 - 通过消息框展示表格选中的行
function notifySelectedRows(gridId) {
    var grid = F(gridId);

    if (!grid.hasSelection()) {
        F.alert('没有选中项！');
        return;
    }

    var genderColumn = grid.getColumn('Gender');
    var majorColumn = grid.getColumn('Major');

    var result = ['<table class="result">'];
    result.push('<tr>');
    if (grid.idField) {
        result.push('<th>ID</th>');
    }
    if (grid.textField) {
        result.push('<th>Text</th>');
    }
    if (genderColumn) {
        result.push('<th>性别</th>');
    }
    if (majorColumn) {
        result.push('<th>专业</th>');
    }

    result.push('</tr>');

    $.each(grid.getSelectedRows(true), function (index, row) {
        result.push('<tr>');
        if (grid.idField) {
            result.push('<td>' + row.id + '</td>');
        }
        if (grid.textField) {
            result.push('<td>' + row.text + '</td>');
        }
        if (genderColumn) {
            result.push('<td>' + (row.values['Gender'] == 1 ? '男' : '女') + '</td>');
        }
        if (majorColumn) {
            result.push('<td>' + row.values['Major'] + '</td>');
        }

        result.push('</tr>');
    });

    result.push('</table>');

    showNotify(result.join(''));
}

