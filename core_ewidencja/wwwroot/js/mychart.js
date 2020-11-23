function renderChart(data, labels) {
    var ctx = document.getElementById("myChart").getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'zużycie energii',
                data: data,
            }]
        },
    });
}

$("#renderBtn").click(

 
    function () {
        data = [15008, 15010, 15015, 15018, 15022, 15027, 15035,15067];
        labels = ["14.03.2018", "16.04.2018", "tuesday", "wednesday", "thursday", "friday", "saturday"];
        renderChart(data, labels);
    }
);