let pages = function () {

    let IsFinished = JSON.parse($("#back").val());


    if (IsFinished.back == true) {
        $("#back").attr("disabled", true);
    }
    else {
        $("back").attr("disabled", false);
    }

    if (IsFinished.next == true) {
        $("#next").attr("disabled", true);
    }
    else {
        $("#next").attr("disabled", false);
    }

    let url = new URLSearchParams(window.location.search);
    let page = url.get('page');
    let sortType = url.get('sortType');

    if (sortType == null) {
        sortType = "PopularityAsc"
    }

    let dataParams = checkParams();
    let search = checkSearchParams();

    $('#back').click(function () {

        if (IsFinished.back == false) {
            $('#bicyclesList').load(`/Home/BicyclesList/?sortType=${sortType}&page=${+page - 1}${dataParams}${search}`, pages);
            history.pushState({ sortType }, '', `?sortType=${sortType}&page=${+page - 1}${dataParams}${search}`);
        }

    })

    $('#next').click(function () {


        if (IsFinished.next == false) {
            $('#bicyclesList').load(`/Home/BicyclesList/?sortType=${sortType}&page=${+page + 1}${dataParams}${search}`, pages);
            history.pushState({ sortType }, '', `?sortType=${sortType}&page=${+page + 1}${dataParams}${search}`);
        }

    })
}


let checkParams = function ()
{
    let url = new URLSearchParams(window.location.search);

    let result = "";

    let popularity = url.get('popularity');
    let model = url.get('model');
    let price = url.get("price");
    let company = url.get("company");
    let year = url.get("year");
    let country = url.get("country");

    if (popularity != null) {
        result = result + `&popularity=${popularity}`;
    }
    if (model != null) {
        result = result + `&model=${model}`;
    }
    if (price != null) {
        result = result + `&price=${price}`;
    }
    if (company != null) {
        result = result + `&company=${company}`;
    }
    if (year != null) {
        result = result + `&year=${year}`;
    }
    if (country != null) {
        result = result + `&country=${country}`;
    }
    

    return result;
}

let checkSearchParams = function ()
{
    let url = new URLSearchParams(window.location.search);

    let result = "";

    let searchParam = url.get('searchParam');
    let searchValue = url.get('searchValue');
    if (searchParam != null) {
        result = result + `&searchParam=${searchParam}`;
    }
    if (searchValue != null) {
        result = result + `&searchValue=${searchValue}`;
    }

    return result;
}


let url = new URLSearchParams(window.location.search);
let sortType = url.get('sortType');
let page = url.get('page');
let data = url.get('data');

if (page == null) {
    page = 0;
}
if (sortType == null) {
    sortType = "PopularityAsc"
}

let dataParams = checkParams();
let search = checkSearchParams();

$('#bicyclesList').load('/Home/BicyclesList' + `/?sortType=${sortType}&page=${page}${dataParams}${search}`, pages);
history.pushState({ sortType }, '', `?sortType=${sortType}&page=${page}${dataParams}${search}`);



$('.sort-item').click(function () {

    let sortType = $(this).val();

    let dataParams = checkParams();
    let search = checkSearchParams();

    $('#bicyclesList').load(`/Home/BicyclesList/?sortType=${sortType}&page=${page}${dataParams}${search}`, pages);
    history.pushState({ sortType }, '', `?sortType=${sortType}&page=${page}${dataParams}${search}`);
});


$('#filter-button').click(function (e) {
    e.preventDefault();

    let form = $('#filter').serializeArray();
    let selected = [];
    $('#filter input:checked').each(function () {
        selected.push($(this).val());
    });


    let paramsData = [];
    form.forEach((element) =>
    {
        if (selected.includes(element.name)) {
            paramsData.push(element);
        }
    })

    let page = 0;
    let filterParams = $.param(paramsData)
  
    let search = checkSearchParams();

    $('#bicyclesList').load(`/Home/BicyclesList/?sortType=${sortType}&page=${page}&${filterParams}${search}`, pages);
    history.pushState({ sortType }, '', `?sortType=${sortType}&page=${page}&${filterParams}${search}`);

})

$('#search-button').click(function (e) {

    e.preventDefault();
    let form = $('#search').serializeArray();
    let resUrl = "";

    form.forEach((element) => {
        if (element.value != "") {
            resUrl = resUrl + `&${element.name}=${element.value}`
        }
        else {
            resUrl = "";
        }
    })

    console.log(form);
    console.log(resUrl);

    let dataParams = checkParams();

    $('#bicyclesList').load(`/Home/BicyclesList/?sortType=${sortType}&page=0${dataParams}${resUrl}`, pages);
    history.pushState({ sortType }, '', `?sortType=${sortType}&page=0${dataParams}${resUrl}`);

})

$('#reset').click(function (e) {

    let sortType = "PopularityAsc";
    $('#bicyclesList').load(`/Home/BicyclesList/?sortType=${sortType}&page=0`, pages);
    history.pushState({ sortType }, '', `?sortType=${sortType}&page=0`);

})