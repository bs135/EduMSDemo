$.datepicker.regional['vi-VN'] = {
    closeText: 'Xong',
    prevText: 'Lui',
    nextText: 'Tới',
    currentText: 'Hôm nay',
    monthNames: ['Tháng giêng', 'Tháng hai', 'Tháng ba', 'Tháng tư', 'Tháng năm', 'Tháng sáu',
    'Tháng bảy', 'Tháng tám', 'Tháng chín', 'Tháng mười', 'Tháng mười một', 'Tháng mười hai'],
    monthNamesShort: ['Một', 'Hai', 'Ba', 'Tư', 'Năm', 'Sáu',
    'Bảy', 'Tám', 'Chín', 'Mười', 'Mười một', 'Mười hai'],
    dayNames: ['Chủ nhật', 'Thứ hai', 'Thứ ba', 'Thứ tư', 'Thứ năm', 'Thứ sáu', 'Thứ bảy'],
    dayNamesShort: ['CN', 'Hai', 'Ba', 'Tư', 'Năm', 'Sáu', 'Bảy'],
    dayNamesMin: ['CN', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7'],
    weekHeader: 'Tuần',
    dateFormat: 'dd/mm/yy',
    firstDay: 1,
    isRTL: false,
    showMonthAfterYear: false,
    yearSuffix: ''
};

$.timepicker.regional['vi-VN'] = {
    currentText: 'Bây giờ',
    closeText: 'Xong',
    amNames: ['SA', 'S'],
    pmNames: ['CH', 'C'],
    timeFormat: 'HH:mm',
    timeOnlyTitle: 'Chọn thời gian',
    timeText: 'Thời gian',
    hourText: 'Giờ',
    minuteText: 'Phút',
    secondText: 'Giây',
    millisecText: 'Mili giây',
    microsecText: 'Micro giây',
    timezoneText: 'Múi giờ',
    isRTL: false
};

$.datepicker.setDefaults($.datepicker.regional['vi-VN']);
$.timepicker.setDefaults($.timepicker.regional['vi-VN']);