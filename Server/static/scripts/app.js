$('#switch').change(function () {
    var flag = this.checked ? 1 : 0
    $.get("charging/" + flag)
})