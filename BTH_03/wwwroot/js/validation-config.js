$(document).ready(function () {
    // Ẩn tất cả thông báo lỗi validation khi vừa load trang
    $('.field-validation-error').hide();
    $('.validation-summary-errors').hide();
    
    $('form').each(function () {
        var validator = $(this).data('validator');
        if (validator) {
            // Tắt validation khi đang gõ
            validator.settings.onkeyup = false;
            
            // Chỉ validate khi blur (rời khỏi trường input)
            validator.settings.onfocusout = function (element) {
                // Chỉ validate nếu đã có giá trị hoặc đã từng blur
                if ($(element).val() !== '' || element.hasAttribute('data-val-touched')) {
                    $(element).attr('data-val-touched', 'true');
                    // Hiển thị message lỗi khi validate
                    $(element).siblings('.field-validation-error').show();
                    $(element).valid();
                }
            };
            
            // Khi có lỗi validation
            validator.settings.highlight = function (element) {
                $(element).addClass('is-invalid').removeClass('is-valid');
                // Hiển thị message lỗi
                $(element).siblings('.field-validation-error').show();
            };
            
            // Khi không có lỗi
            validator.settings.unhighlight = function (element) {
                $(element).removeClass('is-invalid').addClass('is-valid');
            };
            
            // Hiển thị validation summary khi submit
            $(this).on('submit', function() {
                $('.validation-summary-errors').show();
            });
        }
    });
});

