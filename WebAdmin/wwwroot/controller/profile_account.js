

//Show edit modal
function ShowEditModal(elm, id) {
    let text = $(elm).html();
    $(elm).attr('disabled', true); $(elm).html(_loadAnimationSmallHtml);
    $.get(`/Account/UserProfile/${id}`).done(function (response) {
        $(elm).attr('disabled', false); $(elm).html(text);
        if (response.result === 0 || response.result === -1) {
            CheckResponseIsSuccess(response); return false;
        }
    }).fail(function (err) {
        $(elm).attr('disabled', false); $(elm).html(text);
        CheckResponseIsSuccess({ result: -1, error: { code: err.status } });
    });
}

