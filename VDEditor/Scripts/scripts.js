$(document).ready(function () {
    $('#notification').fadeIn('slow');
});

function confSubmit(form) {
    if (!confirm("Are you sure? This can't be un-done.")) {
        return false;
    }
}