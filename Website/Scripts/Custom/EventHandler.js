$(document).ready(function () {
  $(window).keydown(function (event) {
    if (event.keyCode == 13) {
      event.preventDefault();

      if($('#sendmessage').length > 0)
        $('#sendmessage').click();

      if ($('.button-start').length > 0)
        $('.button-start').click();
      return false;
    }
    return true;
  });
});