var op = {
    Get: function () {
        Helper.AjaxCallGet("https://localhost:7172/api/Values", {}, "Json",
            function (data) {
                console.log(data)
            },
            function () {

            }

        )
    },
}