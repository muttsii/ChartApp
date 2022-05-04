function DashBoardcount() {

    $.ajax({
        type: "POST",
        url: 'Home/DashBoardcount',
        data: JSON.stringify({}),
        contentType: "Application/json:charset=utf-8",
        dataType: "json",
        success: function (json) {
            var values = json.dashBoardcount;
            var UKcount = parseInt(values[0]);
            var DACHcount = parseInt(values[1]);
            var NAcount = parseInt(values[2]);
            var Southeast_Imagingcount = parseInt(values[3]);
            var Commitcount = parseInt(values[4]);
            var Beneluxcount = parseInt(values[5]);
            var Scandinaviacount = parseInt(values[6]);
            var Iberiacount = parseInt(values[7]);
            var PhilipsDACHcount = parseInt(values[8]);
            var MediFarcount = parseInt(values[9]);
            var ANZcount = parseInt(values[10]);
            var Meditcount = parseInt(values[11]);
            var Francecount = parseInt(values[12]);
            var SouthAfricacount = parseInt(values[13]);
            var PreopOnlinecount = parseInt(values[14]);
            var AttiehMedicocount = parseInt(values[15]);
            var Answer_Medicalcount = parseInt(values[16]);
            var Educationcount = parseInt(values[17]);


            Highcharts.chart('container', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Roots in which the patch you have typed is installed'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.y}</b>'
                },
                accessibility: {
                    point: {
                        valueSuffix: '%'
                    }
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    name: 'Count',
                    colorByPoint: true,
                    data: [{
                        name: 'UK',
                        y: UKcount,
                    }, {
                        name: 'DACH',
                        y: DACHcount
                    }, {
                        name: 'NA',
                        y: NAcount
                    }, {
                        name: 'Southeast_Imaging',
                        y: Southeast_Imagingcount
                    }, {
                        name: 'Commit',
                        y: Commitcount
                    }, {
                        name: 'Benelux',
                        y: Beneluxcount
                    }, {
                        name: 'Scandinavia',
                        y: Scandinaviacount
                    }, {
                        name: 'Iberia',
                        y: Iberiacount
                    }, {
                        name: 'PhilipsDACH',
                        y: PhilipsDACHcount
                    }, {
                        name: 'MediFar',
                        y: MediFarcount
                    }, {
                        name: 'ANZ',
                        y: ANZcount
                    }, {
                        name: 'Medit',
                        y: Meditcount
                    }, {
                        name: 'France',
                        y: Francecount
                    }, {
                        name: 'SouthAfrica',
                        y: SouthAfricacount
                    }, {
                        name: 'PreopOnline',
                        y: PreopOnlinecount
                    }, {
                        name: 'AttiehMedico',
                        y: AttiehMedicocount
                    }, {
                        name: 'Answer_Medical',
                        y: Answer_Medicalcount
                    }, {
                        name: 'Education',
                        y: Educationcount
                    }]
                }]
            });
        }
    })
};