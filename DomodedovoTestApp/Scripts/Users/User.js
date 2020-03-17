$(document).ready(function () {

    // Настраиваем открытие модалки с большим изображением
    $('.user-image-medium').on('click', function () {
        $('.imagepreview').attr('src', $(this).attr('data-full-src'));
        $('#imagemodal').modal('show');
    });

});

