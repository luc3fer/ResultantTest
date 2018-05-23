var timer = setInterval(updateDashboard, 15000);
$(".navbar-collapse li").on("click", function () { updateDashboard() });

function updateDashboard() {
    clearInterval(timer);

    $.getJSON("/Home/CurrenciesList",
        function (json) {
            $('tbody').empty();
            var tr;

            for (var i = 0; i < json.length; i++) {
                tr = $('<tr/>');
                tr.append("<td>" + json[i].name + "</td>");
                tr.append("<td>" + json[i].volume + "</td>");
                tr.append("<td>" + json[i].amount + "</td>");
                $('table').append(tr);
            }
        }); 

    timer = setInterval(updateDashboard, 15000);
}