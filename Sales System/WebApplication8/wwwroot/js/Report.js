document.ready(function () {
    $("#btn").click(function () {
        ReportManager.GenerateReport();
    });
});
var ReportManager = {
    GenerateReport: function () {
        var jsonparam = "";
        var serviceUrl = "../Home/GetEmployeeReport";
        ReportManager.GetReport(serviceUrl, jsonparam, onFailed);
        function onFailed(error) {
            alert(error);
        }
    },
    GetReport: function (serviceUrl, jsonparam, errorCallBack) {
        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            data: "{" + jsonparam + "}",
            contentType: "application/json;charset=utf-8",
            success: function () {
                window.open('../Reports/ReportViewer.aspx', '_newtab');

            },
            error: errorCallBack
        });
    }
};