
function emptyContentColor() {
    return $('#emptycontent').css('color');
}
function randomColors() {
    var colors = ['#c23531', '#2f4554', '#61a0a8', '#d48265', '#91c7ae', '#749f83', '#ca8622', '#bda29a', '#6e7074', '#546570', '#c4ccd3'];
    var randomIndex = Math.random() * colors.length;
    return $.merge(colors.slice(randomIndex), colors.slice(0, randomIndex));
}
function initChart1() {
    var chart = echarts.init($('.mycard .chart1')[0]);
    var option = {
        color: randomColors(),
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'shadow'
            }
        },
        grid: {
            left: 0,
            right: 0
        },
        xAxis: {
            show: false,
            type: 'category',
            data: ['02/01', '02/02', '02/03', '02/04', '02/05', '02/06', '02/07', '02/08', '02/09', '02/10', '02/11', '02/12']
        },
        yAxis: {
            show: false,
            type: 'value',
            max: function (value) {
                return value.max + 100;
            }
        },
        series: [{
            name: 'Page View',
            type: 'bar',
            data: [800, 1000, 600, 1200, 600, 500, 800, 500, 1500, 1000, 900, 600]
        }]
    };
    chart.setOption(option);
    return chart;
}
function initChart2() {
    var chart = echarts.init($('.mycard .chart2')[0]);
    var option = {
        color: randomColors(),
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'shadow'
            }
        },
        grid: {
            left: 0,
            right: 0
        },
        xAxis: {
            show: false,
            type: 'category',
            data: ['02/01', '02/02', '02/03', '02/04', '02/05', '02/06', '02/07', '02/08', '02/09', '02/10', '02/11', '02/12']
        },
        yAxis: {
            show: false,
            type: 'value',
            max: function (value) {
                return value.max + 200;
            }
        },
        series: [{
            name: 'Dedicated IP',
            type: 'line',
            smooth: true,
            areaStyle: {},
            data: [800, 1000, 600, 1200, 600, 500, 800, 500, 1500, 1000, 900, 600]
        }]
    };
    chart.setOption(option);
    return chart;
}

function initChart3() {
    var chart = echarts.init($('.mycard .chart3')[0]);
    var option = {
        color: randomColors(),
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'shadow'
            }
        },
        grid: {
            left: 0,
            right: 0
        },
        xAxis: {
            show: false,
            type: 'category',
            data: ['02/01', '02/02', '02/03', '02/04', '02/05', '02/06', '02/07', '02/08', '02/09', '02/10', '02/11', '02/12']
        },
        yAxis: {
            show: false,
            type: 'value',
            max: function (value) {
                return value.max + 200;
            }
        },
        series: [{
            name: 'User Amount',
            type: 'bar',
            data: [400, 500, 300, 900, 300, 600, 600, 300, 800, 1200, 200, 300]
        }, {
            name: 'Page View',
            type: 'line',
            smooth: true,
            data: [800, 1000, 600, 1200, 600, 500, 800, 500, 1500, 1000, 900, 600]
        }]
    };
    chart.setOption(option);
    return chart;
}

function initTabStripChart1() {
    var chart = echarts.init($('.tabstrip-chart.chart1')[0]);
    var contentColor = emptyContentColor();
    var option = {
        title: {
            text: 'Week Page View',
            padding: [20, 20, 0, 20],
            textStyle: {
                fontSize: 12,
                fontWeight: 'normal',
                color: contentColor
            }
        },
        color: randomColors(),
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'shadow'
            }
        },
        xAxis: {
            type: 'category',
            boundaryGap: false,
            axisLine: {
                lineStyle: {
                    color: contentColor
                }
            },
            data: ['02/01', '02/02', '02/03', '02/04', '02/05', '02/06', '02/07', '02/08', '02/09', '02/10', '02/11', '02/12']
        },
        yAxis: {
            type: 'value',
            axisLine: {
                lineStyle: {
                    color: contentColor
                }
            }
        },
        series: [{
            name: 'Page View',
            type: 'line',
            smooth: true,
            areaStyle: {},
            data: [800, 1000, 600, 1200, 600, 500, 800, 500, 1500, 1000, 900, 600]
        }]
    };
    chart.setOption(option);
    return chart;
}

function initTabStripChart2() {
    var chart = echarts.init($('.tabstrip-chart.chart2')[0]);
    var contentColor = emptyContentColor();
    var option = {
        title: {
            text: 'Week User Amount',
            padding: [20, 20, 0, 20],
            textStyle: {
                fontSize: 12,
                fontWeight: 'normal',
                color: contentColor
            }
        },
        color: randomColors(),
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'shadow'
            }
        },
        xAxis: {
            type: 'category',
            axisLine: {
                lineStyle: {
                    color: contentColor
                }
            },
            data: ['02/01', '02/02', '02/03', '02/04', '02/05', '02/06', '02/07', '02/08', '02/09', '02/10', '02/11', '02/12']
        },
        yAxis: {
            type: 'value',
            axisLine: {
                lineStyle: {
                    color: contentColor
                }
            }
        },
        series: [{
            name: 'User Amount',
            type: 'bar',
            data: [400, 500, 300, 900, 300, 600, 600, 300, 800, 1200, 200, 300]
        }, {
            name: 'Page View',
            type: 'line',
            smooth: true,
            data: [800, 1000, 600, 1200, 600, 500, 800, 500, 1500, 1000, 900, 600]
        }]
    };
    chart.setOption(option);
    return chart;
}


function initChartPie() {
    var chart = echarts.init($('.mychart-pie')[0]);
    var contentColor = emptyContentColor();
    var option = {
        color: randomColors(),
        title: {
            text: '用户访问来源',
            subtext: '这是说明文字',
            x: 'center',
            textStyle: {
                color: contentColor
            }
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'vertical',
            left: 'left',
            textStyle: {
                color: contentColor
            },
            data: ['直接访问', '邮件营销', '联盟广告', '视频广告', '搜索引擎']
        },
        series: [{
            name: '访问来源',
            type: 'pie',
            radius: '55%',
            center: ['50%', '60%'],
            data: [
                { value: 335, name: '直接访问' },
                { value: 310, name: '邮件营销' },
                { value: 234, name: '联盟广告' },
                { value: 135, name: '视频广告' },
                { value: 1548, name: '搜索引擎' }
            ],
            itemStyle: {
                emphasis: {
                    shadowBlur: 10,
                    shadowOffsetX: 0,
                    shadowColor: 'rgba(0, 0, 0, 0.5)'
                }
            }
        }]
    };
    chart.setOption(option);
    return chart;
}

F.ready(function () {
    
    if (F._base) {
        return;
    }

    var chart1 = initChart1();
    var chart2 = initChart2();
    var chart3 = initChart3();
    var tabstripChart1 = initTabStripChart1();
    var tabstripChart2 = initTabStripChart2();
    var chartPiew = initChartPie();


    F.windowResize(function () {
        chart1.resize();
        chart2.resize();
        chart3.resize();
        tabstripChart1.resize();
        tabstripChart2.resize();
        chartPiew.resize();
    });


    var mytabstrip = $('.mytabstrip');
    if (mytabstrip.length) {
        F(mytabstrip).on('tabchange', function (event, tab) {
            var chartDom = tab.el.find('.tabstrip-chart')[0];
            var chartInstance = echarts.getInstanceByDom(chartDom);

            // 如果图表宽度为零，说明是在隐藏状态下初始化的，需要重置大小
            if (!chartInstance.getWidth()) {
                chartInstance.resize();
            }
        });
    }



});